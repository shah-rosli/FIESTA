import { Component, EventEmitter, Input, Output, ViewChild } from '@angular/core'
import { Column } from 'devextreme/ui/data_grid'
import { ToastrService } from 'ngx-toastr'
import { errorToastOptions } from '../../utils/errorToastOption'
import { DxValidatorComponent } from 'devextreme-angular'

export interface CriteriaRetrievedEvent {
  filterExpression: FilterExpression
  isViewFullView: boolean
}

export type FilterExpression = ("and" | BinaryFilter)[]
type BinaryFilter = [string, "anyof" | "=", string[] | string]

interface FieldsDropdown {
  dataField: string,
  caption: string
}

interface Criteria {
  field: string,
  operator: "anyof" | "=",
  value: string
}

@Component({
  selector: 'app-filter-criteria',
  templateUrl: './filter-criteria.component.html',
  styleUrls: ['./filter-criteria.component.scss']
})
export class FilterCriteriaComponent {
  @ViewChild('targetValidator', { static: false }) validator: DxValidatorComponent

  @Input('columns') columnConfig: Column[]
  @Input() fieldsDropdown: FieldsDropdown[]
  @Input() show: boolean
  @Input() useViewSwitching: boolean = false
  @Input() useActiveRecords: boolean = true
  @Input() mustProvideFilter: boolean = false

  @Output() onCriteriaRetrieved = new EventEmitter<CriteriaRetrievedEvent>()

  isFullView: boolean = false
  fieldCriteria: Criteria
  activeRecordCriteria: Criteria

  activeRecordDataSource = [
    { caption: "All", dataField: "" },
    { caption: "No", dataField: "Y" },
    { caption: "Yes", dataField: "N" },
  ]
  fullViewDataSource = [
    { caption: "No", value: false },
    { caption: "Yes", value: true },
  ]

  constructor(private toastr: ToastrService) { }

  ngOnInit(): void {
    this.resetCriteria()
  }

  resetCriteria() {
    const firstFieldFromDropdown = this.fieldsDropdown[0].dataField
    this.fieldCriteria = { field: firstFieldFromDropdown, operator: "anyof", value: "" }
    this.activeRecordCriteria = { field: "deleteFlag", operator: "=", value: "N" }
  }

  onActiveRecordsChange(e) {
    if (this.useActiveRecords) {
      this.activeRecordCriteria.value = e.value
    }
  }

  onRetrieveClick() {
    const selectedFieldCriteria = this.fieldCriteria.field
    if (!selectedFieldCriteria) {
      return
    }

    if (!this.columnConfig.some(column => column.dataField === selectedFieldCriteria)) {
      this.toastr.error(`Selected field '${selectedFieldCriteria}' is invalid as it does not exist in datagrid`, 'Error!', errorToastOptions)
      return
    }

    const validateResult = this.validator.instance.validate()
    if (!validateResult.isValid) {
      this.toastr.error(`You must specify a filter value before retrieving data.`)
      return
    }

    const parsedTextBoxData = this.fieldCriteria.value
      .split('\n')
      .filter(singleSearchValue => singleSearchValue.trim() !== "")
      .map(singleSearchValue => singleSearchValue.trim())

    const deduplicatedTextBoxData = Array.from(new Set(parsedTextBoxData))

    if (deduplicatedTextBoxData.length > 100) {
      this.toastr.warning(`Filtering more than 100 values may not work as expected. Consider reducing your filter.`)
    }

    const binaryFilters: BinaryFilter[] = []
    binaryFilters.push([this.fieldCriteria.field, this.fieldCriteria.operator, deduplicatedTextBoxData])

    if (this.useActiveRecords) {
      binaryFilters.push([this.activeRecordCriteria.field, this.activeRecordCriteria.operator, this.activeRecordCriteria.value])
    }

    const validBinaryFilters = binaryFilters.filter((binaryFilter) => binaryFilter[2].length > 0)

    const filterExpression = []
    for (let i = 0; i < validBinaryFilters.length; i++) {
      if (i === 0) {
        filterExpression.push(validBinaryFilters[i])
        continue
      }
      filterExpression.push("and")
      filterExpression.push(validBinaryFilters[i])
    }

    this.onCriteriaRetrieved.emit({
      filterExpression: filterExpression.length === 0 ? null : filterExpression,
      isViewFullView: this.isFullView
    })
  }
}
