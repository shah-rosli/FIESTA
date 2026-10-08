import { Injectable } from '@angular/core'
import { Router } from '@angular/router'
import CryptoES from 'crypto-es'
import { formatMessage, loadMessages, locale } from 'devextreme/localization'
import { DateTime } from "luxon"
import { CookieService } from 'ngx-cookie-service'
import { environment } from 'src/environments/environment'
import { MessageEventManager } from './message.event.service'
import { SendRequestService } from './send-request.service'
import { TokenProperties } from 'src/app/app.module'


@Injectable({
  providedIn: 'root'
})

export class BaseService {
  secretKey: string = "1234";
  locales: any = null;
  locale: string = null;
  formatMessage = formatMessage;
  getIPAddressURL = "https://ip.seeip.org/json"
  publicURL = ['ComingSoon', 'NoSideMenu', 'PageError401', 'PageError404', 'PageError500', 'Offline', 'NoAccessUser', '**'];


  constructor(private send: SendRequestService, private router: Router,
    private messageEventManager: MessageEventManager, private cookieService: CookieService) {
    //load languages
    this.locales = this.getLanguageCodeData()
    this.locale = this.getLanguageData()
    loadMessages(this.getDictionaryData())
    locale(this.locale)
  }

  encrypt(value) {
    // encrypt(value:string):string {
    // let value:string="shajeer@gmail.com"
    let keySize = 256
    let salt = CryptoES.lib.WordArray.random(16)
    // well known algorithm to generate key
    let key = CryptoES.PBKDF2(this.secretKey, salt, {
      keySize: keySize / 32,
      iterations: 100
    })
    // random IV
    let iv = CryptoES.lib.WordArray.random(128 / 8)
    // specify everything explicitly
    let encrypted = CryptoES.AES.encrypt(value, key, {
      iv: iv,
      padding: CryptoES.pad.Pkcs7,
      mode: CryptoES.mode.CBC
    })
    // combine everything together in base64 string

    return CryptoES.enc.Base64.stringify(salt.concat(iv).concat(encrypted.ciphertext))

    //return CryptoJS.AES.encrypt(value, this.secretKey.trim()).toString();
  }





  // create side menu Array
  async getSideMenu(USER_ID?: string) {
    var SideMenuObject = [] as any
    const userID = USER_ID ? USER_ID : JSON.parse(this.cookieService.get('UserInfo')).USER_ID
    if (userID) {
      let data = await this.send.sendRequest(`${environment.ServiceURL_Main}UserAccess/GetUserList/${userID}`, "GET", "").toPromise()

      //level 1
      if (data.menu_list.length !== 0) {
        localStorage.setItem('SideMenu', JSON.stringify(data.menu_list))//for sending user right to each page
        data.menu_list.forEach((items, index) => {
          if (items.parent_id === 0) {
            let MainItemobj = {}
            MainItemobj["Id"] = items.menu_id
            MainItemobj["Icon"] = items.icon
            MainItemobj["Link"] = items.link
            MainItemobj["Desc"] = items.menu_name
            MainItemobj["External"] = false
            MainItemobj["Sub"] = ""
            MainItemobj["AccessRight"] = items.access_right

            SideMenuObject.push(MainItemobj)
          }
        })

        //level 2

        SideMenuObject.forEach((MainItem, index) => {
          const SubMenuObject = [] as any

          data.menu_list.forEach((items, index) => {
            if (items.parent_id === MainItem.Id) {

              let SubItemobj = {}
              SubItemobj["Id"] = items.menu_id
              SubItemobj["Icon"] = items.icon
              SubItemobj["Link"] = items.link
              SubItemobj["Desc"] = items.menu_name
              SubItemobj["External"] = false
              SubItemobj["Sub"] = ""
              SubItemobj["AccessRight"] = items.access_right
              SubMenuObject.push(SubItemobj)

            }

            //level 3

            SubMenuObject.forEach((MainItem, index) => {
              const SubMenuObject2 = [] as any

              data.menu_list.forEach((items, index) => {
                if (items.parent_id === MainItem.Id) {

                  let SubItemobj = {}
                  SubItemobj["Id"] = items.menu_id
                  SubItemobj["Icon"] = items.icon
                  SubItemobj["Link"] = items.link
                  SubItemobj["Desc"] = items.menu_name
                  SubItemobj["External"] = false
                  SubItemobj["Sub"] = ""
                  SubItemobj["AccessRight"] = items.access_right
                  SubMenuObject2.push(SubItemobj)

                }

              })

              if (SubMenuObject2.length !== 0) {
                MainItem["SideMenu"] = SubMenuObject2

              }

            })


          })

          if (SubMenuObject.length !== 0) {
            MainItem["SideMenu"] = SubMenuObject

          }

        })
      }
      if (data.menu_list.length === 0) {
        this.router.navigate(['NoSideMenu'])
      }


    }

    localStorage.setItem("UserMenu", JSON.stringify(SideMenuObject))//right place to save is here not in sidemenu. here will take effect right away and control whole component
    console.log("COMPLETE SET USERMENU & broadcast send")
    this.messageEventManager.broadcast({ name: 'sidemenuDone' })//

    return await SideMenuObject
  }


  getUserAccessPermission(PageUrl) {

    let LeftMenu = JSON.parse(localStorage.getItem('SideMenu'))
    let Access = null
    if (LeftMenu !== null) {
      LeftMenu.forEach(function (item) {
        if (item.link === PageUrl) {
          Access = item.access_right
        }
      })
    }

    return Access

  }

  getLanguageCodeData() {

    //cannot get from param... too early to establish connection to DB during contruct..

    let LanguageCodeData = []
    if (localStorage.getItem("paramDictionary")) {

      let temp = JSON.parse(localStorage.getItem("paramDictionary"))

      temp.forEach((element) => {
        if (element.PARAM_CATEGORY == 'System_Language') {
          let obj = {}
          obj["Language"] = element.PARAM_VALUE
          obj["LanguageCode"] = element.PARAM_KEY
          LanguageCodeData.push(obj)
        }
      })
      return LanguageCodeData

    } else {

      return LanguageCodeData

    }

  }

  getParamData(category) {

    let ParamData = []
    if (localStorage.getItem("paramDictionary")) {

      let temp = JSON.parse(localStorage.getItem("paramDictionary"))

      temp.forEach((element) => {
        if (element.PARAM_CATEGORY == category) {
          let obj = {}
          obj["PARAM_KEY"] = element.PARAM_KEY
          obj["PARAM_VALUE"] = element.PARAM_VALUE
          ParamData.push(obj)
        }
      })
      if (ParamData) {
        ParamData = ParamData.sort((a, b) => a.PARAM_VALUE.localeCompare(b.PARAM_VALUE))
      }
      return ParamData

    } else {

      return ParamData

    }

  }

  getBooleanData() {

    //cannot get from param... too early to establish connection to DB during contruct..

    let BooleanData = []
    if (localStorage.getItem("paramDictionary")) {

      let temp = JSON.parse(localStorage.getItem("paramDictionary"))

      temp.forEach((element) => {
        if (element.PARAM_CATEGORY == 'System_Boolean') {
          let obj = {}
          obj["Value"] = element.PARAM_VALUE
          obj["Key"] = element.PARAM_KEY
          BooleanData.push(obj)
        }
      })
      return BooleanData

    } else {

      return BooleanData

    }

  }

  getLanguageData() {
    //console.log("GET LANGUAGE DATA : " + this.cookieService.get("language"))
    if (this.cookieService.get("language")) {
      return (this.cookieService.get("language"))
    } else if (this.getUserInfo("DEFAULT_LANGUAGE")) {
      return this.getUserInfo("DEFAULT_LANGUAGE")
    } else {
      return "en"
    }
  }

  setLanguageData(locale) {
    this.cookieService.set("language", locale)
  }

  setParamData(val) {
    localStorage.setItem('paramDictionary', JSON.stringify(val))
  }

  getDictionaryData(val?: any) {
    //return DictionaryData;
    if (val) {

      //get all languages
      var LangDic: string = ""
      let LangSet = []
      for (const item in val[0]) {
        if (item != 'CFG_SYSTEM_LANGUAGE_ID' && item != 'LABEL_NAME') {
          LangSet.push(item)
        }
      }

      //get all the language labels arrange by languages
      for (const item in LangSet) {

        var LangDetSet: string = ""
        val.forEach(valitem => {
          LangDetSet = LangDetSet + '"' + valitem.LABEL_NAME + '": "' + valitem[LangSet[item]] + '",'
        })
        LangDic = LangDic + '"' + LangSet[item].toLowerCase() + '" : { ' + LangDetSet.substring(0, LangDetSet.length - 1) + ' },'

      }
      localStorage.setItem('languageDictionary', '{ ' + LangDic.substring(0, LangDic.length - 1) + ' }')
    }
    return JSON.parse(localStorage.getItem('languageDictionary'))

  }

  getMessage(msg) {
    let value: any
    value = formatMessage(msg, '')
    if (!value) {
      if (environment.environmentName.includes("DEV")) {
        value = msg + "**"
      } else {
        value = msg
      }
    }
    return value
  }

  getMessage_notranslate(msg) {
    return msg
  }

  getSystemFormat(val) {

    //cannot get from param... too early to establish connection to DB during contruct..
    let DateFormatData = ""
    if (localStorage.getItem("paramDictionary")) {

      let temp = JSON.parse(localStorage.getItem("paramDictionary"))

      temp.forEach((element) => {
        if (element.PARAM_CATEGORY == 'System_Format' && element.PARAM_KEY == val) {
          DateFormatData = element.PARAM_VALUE
        }
      })
      return DateFormatData

    } else {
      return DateFormatData
    }
  }

  // getUserInfo<T extends keyof TokenProperties>(key: T) {
  //   if (this.cookieService.get('UserInfo')) {
  //     const UserInfo = JSON.parse(this.cookieService.get('UserInfo'))
  //     return UserInfo[key]
  //   } else {
  //     return ""
  //   }
  // }

  getUserInfo<T extends keyof TokenProperties>(key: T): TokenProperties[T] {
    if (this.cookieService.get("UserInfo")) {
      const UserInfo = JSON.parse(this.cookieService.get("UserInfo"))
      return UserInfo[key]
    } else {
      return
    }
  }

  getMomentDisplayDateYYYYMM(val) {
    let returnVal: any
    let momentDateFormat = "yyyy/MM"
    val = DateTime.fromISO(val).toObject()//convert to object
    returnVal = DateTime.utc(val).toFormat(momentDateFormat)
    if (returnVal == "Invalid date" || DateTime.utc(val).setZone(this.getUserInfo('DEFAULT_TIMEZONE')).toFormat('yyyy') == "0001" || DateTime.utc(val).setZone(this.getUserInfo('DEFAULT_TIMEZONE')).toFormat('yyyy') == "0000") {
      returnVal = ""
    }
    return returnVal

  }

  getMomentDisplayDate(val) {
    let returnVal: any
    let momentDateFormat = this.getMomentConvertedDateFormat(this.getUserInfo('DEFAULT_DISP_DATE_FORMAT'))
    //returnVal = moment.utc(val).tz(this.getUserInfo('DEFAULT_TIMEZONE')).format(momentDateFormat); //Convertion
    if (!momentDateFormat) {
      momentDateFormat = "dd MMM yyyy"
    }
    val = DateTime.fromISO(val).toObject()//convert to object
    returnVal = DateTime.utc(val).toFormat(momentDateFormat)//convert to datetime
    if (returnVal == "Invalid date" || DateTime.utc(val).setZone(this.getUserInfo('DEFAULT_TIMEZONE')).toFormat('yyyy') == "0001" || DateTime.utc(val).setZone(this.getUserInfo('DEFAULT_TIMEZONE')).toFormat('yyyy') == "0000") {
      returnVal = ""
    }
    return returnVal
  }

  getMomentDisplayDateTime(val) {
    let returnVal: any
    let momentDateFormat = this.getMomentConvertedDateFormat(this.getUserInfo('DEFAULT_DISP_DATETIME_FORMAT'))
    if (!momentDateFormat) {
      momentDateFormat = "dd MMM yyyy HH:mm"
    }
    val = DateTime.fromISO(val).toObject()
    val = DateTime.fromObject(val)//convert to luxon datetime
    returnVal = val.toFormat(momentDateFormat) //convert to luxon dateformat
    if (!val.isValid) {
      returnVal = ""
    }
    return returnVal
  }

  getMomentConvertedDateFormat(val) {
    //default based on header date to avoid return null and cuase error
    let MomentConvertedDateFormat = this.getSystemFormat('DefaultHeaderDTMFormatLuxon')

    if (localStorage.getItem("paramDictionary")) {
      let temp = JSON.parse(localStorage.getItem("paramDictionary"))
      temp.forEach((element) => {
        if (element.PARAM_CATEGORY == 'System_MomentDateTimeConvertion' && element.PARAM_KEY == val) {
          MomentConvertedDateFormat = element.PARAM_KEY//luxon use small caseletter, no need to convert
        }
      })
      return MomentConvertedDateFormat
    } else {
      return MomentConvertedDateFormat
    }
  }

  getAttachment(val) {
    //let valout = new DOMParser().parseFromString(val, "text/html").documentElement.textContent;
    let valout = encodeURIComponent(val)
    return `${environment.ServiceURL_Main}DownloadFile?filename=` + valout
  }

  getConsigneeMaterialGroupLabel(eprVal) {
    let returnVal = ""
    if (eprVal.COMPANY_CODE == '1000' || eprVal.COMPANY_CODE == '22H0') { // REL RSMC
      returnVal = "Consignee"
    } else {
      returnVal = "Material Group"
    }
    return returnVal
  }

  prepareApprovalMatrix(val, userList) {

    let tempUserList = userList
    let tempApprovalMatrix = []
    let OverallSeq = 1

    //distict seq + sort seq
    let tempSeq = val.map(item => item.Sequence).filter((value, index, self) => self.indexOf(value) === index)
    tempSeq = tempSeq.sort((a, b) => (a > b ? 1 : -1))

    //each sequence
    let tempCounter = 1
    tempSeq.forEach(function (item) {
      let approvalSeqItem = val.filter(filter => filter.Sequence == item)

      let approvalSelectionList = []

      //each palleral approver
      approvalSeqItem.forEach(function (item) {

        let approvalSelectionListDet = []
        let selectedUserId = ""

        //prepare user selection
        if (item.Userid.length == 0) {
          //max@20201002 - for approver
          //approvalSelectionListDet = tempUserList;
          approvalSelectionListDet = null
        } else if (item.Userid.length == 1) {
          let tmpApprovalSelectionItem = tempUserList.filter(filter => filter.USER_ID == item.Userid[0])
          if (tmpApprovalSelectionItem.length > 0) {
            approvalSelectionListDet = tmpApprovalSelectionItem
          } else {
            //can't find user
            //max@20201002 - for approver
            //approvalSelectionListDet = tempUserList;
            approvalSelectionListDet = null
          }
        } else {
          item.Userid.forEach(function (item) {
            let tempSelection = tempUserList.filter(filter => filter.USER_ID == item)
            approvalSelectionListDet.push(tempSelection[0])
          })
        }

        //auto selected user
        //auto when there is only one selection
        if (item.Userid.length == 1) {
          selectedUserId = item.Userid[0]
          //auto when it is set in DB
        } else if (item.DefaultUserId) {
          if (item.Userid.includes(item.DefaultUserId)) {
            selectedUserId = item.DefaultUserId
          }
          //Auto assign Dept approval with multiple sam GJG
        } else if (item.Role.substring(0, 4) == 'Dept' && item.Userid.length > 0 && !selectedUserId) {

          let tempFinalDeptAppr = val.filter(filter => filter.Role.substring(0, 4) == 'Dept')

          //If dept final approval - get first approver
          if (item == tempFinalDeptAppr[tempFinalDeptAppr.length - 1]) {
            selectedUserId = item.Userid[0]
            //If not dept final approval - get last approver
          } else {
            selectedUserId = item.Userid[item.Userid.length - 1]
          }
        }

        let approvalSelection = {
          Role: item.Role,
          Userid: item.Userid,
          UserSelection: approvalSelectionListDet,
          SelectedUserId: selectedUserId,
          DisplaySelectedUserId: selectedUserId,
          OverallSeq: OverallSeq,
          ApprovalOpen: false
        }
        OverallSeq = OverallSeq + 1
        approvalSelectionList.push(approvalSelection)

      })
      let tempApprovalMatrixItem = {
        seq: tempCounter,
        approvalSelection: approvalSelectionList
      }
      tempCounter = tempCounter + 1
      tempApprovalMatrix.push(tempApprovalMatrixItem)

    })

    //console.log(tempApprovalMatrix);
    //this.approvalMatrix = tempApprovalMatrix;
    //this.approvalMatrix = val;

    return tempApprovalMatrix
  }

  processApprovalMatrix(userList, approvalMatrix) {

    //massage to remove additional approval if it is part of main approval flow
    let nonAdditonalApprovalList = []
    approvalMatrix.forEach(element => {
      element.approvalSelection.forEach(element2 => {
        if (element2.Role != 'Additional Appr') {
          nonAdditonalApprovalList.push(element2.SelectedUserId)
        }
      })
    })
    nonAdditonalApprovalList.forEach(nonAdditonalApprovalListItem => {
      approvalMatrix.forEach(element => {
        element.approvalSelection = element.approvalSelection.filter(element2 => (element2.Role == 'Additional Appr' && element2.SelectedUserId != nonAdditonalApprovalListItem) || element2.Role != 'Additional Appr')
      })
    })

    //Massage approval
    let finalApprovalMatrix = []
    for (let sequence of approvalMatrix) {
      for (let approver of sequence.approvalSelection) {
        let approverFound = false
        let cummulativeRole = ""

        //check approver exist
        let countIndex = 0
        for (let finalApprovalMatrixItem of finalApprovalMatrix) {
          // add role to existing same approver
          if (finalApprovalMatrixItem.APPR_USERID == approver.SelectedUserId) {

            // console.log("##");
            // console.log(sequence.seq); // get the current seq -- 3
            // console.log(sequence.approvalSelection.length); // check current seq is parallel -- 5 parallel?
            // console.log(finalApprovalMatrixItem.APPR_SEQUENCE); //previous inserted seq
            // console.log(finalApprovalMatrix.filter(filter => filter.APPR_SEQUENCE == finalApprovalMatrixItem.APPR_SEQUENCE).length);//previous inserted seq is parallel?
            // console.log("@@");

            let tmpCurrentSeq = sequence.seq
            let tmpCurrentApproverLength = sequence.approvalSelection.length
            let tmpFinalizedSeq = finalApprovalMatrixItem.APPR_SEQUENCE
            let tmpFinalizedApproverLength = finalApprovalMatrix.filter(filter => filter.APPR_SEQUENCE == finalApprovalMatrixItem.APPR_SEQUENCE).length

            // //round to first approver. If parallel, push to sequential.
            // if(tmpCurrentSeq != tmpFinalizedSeq && tmpCurrentApproverLength>1 && tmpFinalizedApproverLength==1){
            //   //Compare seq and parallel. Remain parallel.
            //   //Insert cummulate role
            //   cummulativeRole = finalApprovalMatrixItem.APPR_APPROVAL_ROLE + ", " + approver.Role;
            //   //delete old record.
            //   finalApprovalMatrix = finalApprovalMatrix.filter(obj => obj !== finalApprovalMatrixItem);
            // }else{
            //   //Stop the insert but update finalized role
            //   finalApprovalMatrixItem.APPR_APPROVAL_ROLE = finalApprovalMatrixItem.APPR_APPROVAL_ROLE + ", " + approver.Role;
            //   approverFound = true;
            // }

            //always round down except for "Finance Reviewer".
            //finance reviewer will always standalone and will not merge the approval rights with others.
            if (finalApprovalMatrixItem.APPR_APPROVAL_ROLE != 'Finance Reviewer' && approver.Role != 'Finance Reviewer') {
              cummulativeRole = finalApprovalMatrixItem.APPR_APPROVAL_ROLE + ", " + approver.Role
              finalApprovalMatrix = finalApprovalMatrix.filter(obj => obj !== finalApprovalMatrixItem)
            } else if (finalApprovalMatrixItem.APPR_APPROVAL_ROLE == 'Finance Reviewer' && approver.Role == 'Finance Reviewer') {
              cummulativeRole = finalApprovalMatrixItem.APPR_APPROVAL_ROLE
              finalApprovalMatrix = finalApprovalMatrix.filter(obj => obj !== finalApprovalMatrixItem)
            }
          }
          countIndex = countIndex + 1
        }

        if (!approverFound) {
          //insert new approver
          let tmpUserName = userList.filter(filter => filter.USER_ID == approver.SelectedUserId)
          let tmpApproverUserName = ""
          if (tmpUserName.length > 0) {
            tmpApproverUserName = tmpUserName[0].USER_FULL_NAME + "(" + tmpUserName[0].USER_EMAIL + ")"
          }
          let obj = {}
          obj["APPR_SEQUENCE"] = sequence.seq
          obj["APPR_USERID"] = approver.SelectedUserId
          obj["APPR_USER_NAME"] = tmpApproverUserName
          obj["APPR_DELEGATEE"] = ""
          if (cummulativeRole) {
            obj["APPR_APPROVAL_ROLE"] = cummulativeRole
          } else {
            obj["APPR_APPROVAL_ROLE"] = approver.Role
          }
          obj["APPR_DATE"] = null
          obj["APPR_STATUS"] = "Pending Approval"
          obj["OverallSeq"] = approver.OverallSeq
          finalApprovalMatrix.push(obj)

        }


      }
    }

    //console.log(finalApprovalMatrix);

    //Massage info
    //finalApprovalMatrix = finalApprovalMatrix.sort((a, b) => (a.APPR_SEQUENCE > b.APPR_SEQUENCE ? 1 : -1));
    finalApprovalMatrix = finalApprovalMatrix.sort(function (a, b) {
      if (a.APPR_SEQUENCE === b.APPR_SEQUENCE) {
        // Price is only important when cities are the same
        return a.OverallSeq > b.OverallSeq ? 1 : -1
      }
      return a.APPR_SEQUENCE > b.APPR_SEQUENCE ? 1 : -1
    })

    //console.log(finalApprovalMatrix);

    let seqIndex = 1
    let previousOriSeq = 0
    for (let finalApprovalMatrixItem of finalApprovalMatrix) {

      // massage sequence
      if (previousOriSeq == 0) {
        previousOriSeq = finalApprovalMatrixItem.APPR_SEQUENCE
        finalApprovalMatrixItem.APPR_SEQUENCE = seqIndex
      } else if (previousOriSeq == finalApprovalMatrixItem.APPR_SEQUENCE) {
        finalApprovalMatrixItem.APPR_SEQUENCE = seqIndex
      } else {
        previousOriSeq = finalApprovalMatrixItem.APPR_SEQUENCE
        seqIndex = seqIndex + 1
        finalApprovalMatrixItem.APPR_SEQUENCE = seqIndex
      }




      //massage roles
      let tempRole = finalApprovalMatrixItem.APPR_APPROVAL_ROLE.split(', ')
      tempRole = [...new Set(tempRole)]
      finalApprovalMatrixItem.APPR_APPROVAL_ROLE = tempRole.join(', ')

    }

    return finalApprovalMatrix
  }



  getShiftJISByteLength(s) {
    let returnVal = 0
    if (s) {
      returnVal = s.replace(/[^\x00-\x80｡｢｣､･ｦｧｨｩｪｫｬｭｮｯｰｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾐﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜﾝ ﾞ ﾟ]/g, 'xx').length
    } else {
      returnVal = 0
    }
    return returnVal
  }

  getDisplayApprovalRoleAutoSelectMessage(item) {
    let returnval = false
    if (item.Userid.length > 1 && item.SelectedUserId) {
      returnval = true
    }
    return returnval
  }

  isGeneralPage() {
    if (this.publicURL.includes(this.router.url.replace("/", "")))
      return true
    else
      return false
  }

  reload() {
    //this.router.navigate(['/refresh']);//if current page is already /refresh, it wont load the page if use this code

    if (this.isGeneralPage() && !this.router.url.includes("/Login"))
      this.cookieService.set("urlThatUserTryToRefresh", this.router.url)

    location.href = '/refresh'
  }

  reLogin() {
    console.log("RELOGIN")
    localStorage.setItem("activeUserId", "")
    window.location.reload()
  }



  getIPAdress() {
    let res = this.send.getRequest(this.getIPAddressURL)
    console.log(res)
    return res
  }


}
