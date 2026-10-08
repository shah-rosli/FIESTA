using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FIESTA_Backend.Models
{
    public class JsonReturn
    {

        public JsonReturn()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //        status : (number)
        //statusHeader : (string)
        //statusDestail : (string)
        //Data(table)


        #region Properties
        public string InfoMsg { get; set; }
        public string SuccessMsg { get; set; }
        public string WarningMsg { get; set; }
        public string ErrorMsg { get; set; }

        //public DataTable Data { get; set; }

        //public object data { get; set;  }
        public object Data { get; set; }

        public List<object> DataList { get; set; }

//        "InfoMsg": null
//"SuccessMsg": null
//"WarningsMsg": null
//"ErrorMsg": null

     



        #endregion
    }

}