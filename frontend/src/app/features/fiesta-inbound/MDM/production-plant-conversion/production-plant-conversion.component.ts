import { Component } from '@angular/core'
import { PagePermission, PermissionService } from '../../../../service/permission.service'
import { ToastrService } from 'ngx-toastr'
import { DxDataGridComponent } from 'devextreme-angular';
import { ViewChild } from '@angular/core';
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
import { confirm } from 'devextreme/ui/dialog';
import { firstValueFrom } from 'rxjs'

@Component({
  selector: 'app-production-plant-conversion',
  templateUrl: './production-plant-conversion.component.html',
  styleUrls: ['./production-plant-conversion.component.scss']
})
export class ProductionPlantConversionComponent {

}