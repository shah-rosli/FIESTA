
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FIESTA_Backend.Models.Common;
namespace FIESTA_Backend.Models
{
    public class UserAccess
    {
        public string user_id { get; set; }
        public string user_name { get; set; }
        public List<UserMenu> menu_list { get; set; }
    }

    public class UserMenu
    {
        public decimal menu_id { get; set; }
        public string menu_name { get; set; }
        public decimal parent_id { get; set; }
        public decimal sequence { get; set; }
        public string icon { get; set; }
        public string link { get; set; }
        public System.Data.EnumerableRowCollection access_right { get; set; }
//        public List<Company_Acess_Right> access_right { get; set; }
      
    }

}

