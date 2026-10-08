using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Backend.Models
{
   public class EPRERPOUTBOUND
    {
        public EPRERPOUTBOUND()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        
            #region TableName
            public static string TableName
        {
            get { return "epr_erp_outbound"; }
        }
        public static string MasterTableName
        {
            get { return "epr_epr_master"; }
        }
        #endregion

        #region Properties
        public decimal EPR_ERP_OUTBOUND_ID { get; set; }
        public string EPR_NUMBER { get; set; }
        public DateTime EPR_ERP_OUTBOUND_DATE { get; set; }
        public string EPR_ERP_OUTBOUND_TYPE { get; set; }
        public string EPR_ERP_OUTBOUND_STATUS { get; set; }
        public string EPR_ERP_OUTBOUND_ERROR{ get; set; }
        public string EPR_ERP_FILE_NAME { get; set; }

        #endregion Properties

        #region ColumnNames
        public class ColumnNames
        {
            public static string EPR_ERP_OUTBOUND_ID = EPRERPOUTBOUND.TableName + ".EPR_ERP_OUTBOUND_ID";
            public static string EPR_NUMBER = EPRERPOUTBOUND.TableName + ".EPR_NUMBER";
            public static string EPR_ERP_OUTBOUND_DATE = EPRERPOUTBOUND.TableName + ".EPR_ERP_OUTBOUND_DATE";
            public static string EPR_ERP_OUTBOUND_TYPE = EPRERPOUTBOUND.TableName + ".EPR_ERP_OUTBOUND_TYPE";
            public static string EPR_ERP_OUTBOUND_STATUS = EPRERPOUTBOUND.TableName + ".EPR_ERP_OUTBOUND_STATUS";
            public static string EPR_ERP_OUTBOUND_ERROR = EPRERPOUTBOUND.TableName + ".EPR_ERP_OUTBOUND_ERROR";
            public static string EPR_ERP_FILE_NAME = EPRERPOUTBOUND.TableName + ".EPR_ERP_FILE_NAME";
        }
        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(EPRERPOUTBOUND.ColumnNames.EPR_ERP_OUTBOUND_ID, "EPR_ERP_OUTBOUND_ID");
            map.Add(EPRERPOUTBOUND.ColumnNames.EPR_NUMBER, "EPR_NUMBER");
            map.Add(EPRERPOUTBOUND.ColumnNames.EPR_ERP_OUTBOUND_DATE, "EPR_ERP_OUTBOUND_DATE");
            map.Add(EPRERPOUTBOUND.ColumnNames.EPR_ERP_OUTBOUND_TYPE, "EPR_ERP_OUTBOUND_TYPE");
            map.Add(EPRERPOUTBOUND.ColumnNames.EPR_ERP_OUTBOUND_STATUS, "EPR_ERP_OUTBOUND_STATUS");
            map.Add(EPRERPOUTBOUND.ColumnNames.EPR_ERP_OUTBOUND_ERROR, "EPR_ERP_OUTBOUND_ERROR");
            map.Add(EPRERPOUTBOUND.ColumnNames.EPR_ERP_FILE_NAME, "EPR_ERP_FILE_NAME");

            return map;
        }
        #endregion
    }
}
