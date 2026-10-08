using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace my.com.idt.score.Model
{
    public class JsonRequest
    {

        public JsonRequest()
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
        public string WarningsMsg { get; set; }
        public string ErrorMsg { get; set; }

        //public DataTable Data { get; set; }

        //public object data { get; set;  }
        public List<object> Data { get; set; }

//        "InfoMsg": null
//"SuccessMsg": null
//"WarningsMsg": null
//"ErrorMsg": null

     



        #endregion
    }

}