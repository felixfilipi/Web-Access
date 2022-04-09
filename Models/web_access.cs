using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace web_form_1.Models
{   
    [Table("web_access")]
    public class web_access
    {
        [Key, Column(Order = 1)]
        public string RPT_CD { get; set; }
        public string USER_ID { get; set; }
        public string FLAG_STS { get; set; }
        public string FLAG_ACCESS { get; set; }
        public DateTime STRT_EFF_DT { get; set; }
        public string DURATION { get; set; }
        public DateTime STRT_END_DT { get; set; }
        public string NO_EREQUEST { get; set; }
        public string NAMA_LAPORAN { get; set; }

        public static List<web_access> getData()
        {
            OracleDbContext context = new OracleDbContext();
            return context.Database.SqlQuery<web_access>
                (@"SELECT RPT_CD, USER_ID, NVL(STRT_EFF_DT, TO_DATE('01-01-0001','DD-MM-YYYY')) AS STRT_EFF_DT, NO_EREQUEST FROM BCAMIS01.WEB_ACCESS").ToList();
        }
        public static List<web_access> searchData(string USER_ID)
        {
            OracleDbContext context = new OracleDbContext();
            return context.Database.SqlQuery<web_access>
                (@"SELECT RPT_CD, USER_ID, NVL(STRT_EFF_DT, TO_DATE('01-01-0001', 'DD-MM-YYYY')) AS STRT_EFF_DT, NO_EREQUEST FROM BCAMIS01.WEB_ACCESS WHERE UPPER(USER_ID)
                = UPPER(:USER_ID)", USER_ID).ToList();
        }

        public static List<web_access> insertData(string REPORT_NAME, string RPT_CD, string USER_ID, DateTime CURRENT_DATE, string NO_EREQUEST)
        {
            OracleDbContext context = new OracleDbContext();
            return context.Database.SqlQuery<web_access>
                (@"INSERT INTO BCAMIS01.WEB_ACCESS(RPT_CD, USER_ID, STRT_EFF_DT, NO_EREQUEST) 
                VALUES(:RPT_CD, :USER_ID, :CURRENT_DATE ,:NO_EREQUEST)", RPT_CD, USER_ID, CURRENT_DATE, NO_EREQUEST).ToList();
        }

        public static List<web_access> deleteData(string RPT_CD, string USER_ID)
        {
            OracleDbContext context = new OracleDbContext();
            return context.Database.SqlQuery<web_access>
                (@"DELETE FROM BCAMIS01.WEB_ACCESS WHERE RPT_CD = :RPT_CD OR RPT_CD IS NULL AND USER_ID = :USER_ID", RPT_CD, USER_ID).ToList();
        }

        public static List<web_access> getReportName()
        {
            OracleDbContext context = new OracleDbContext();
            return context.Database.SqlQuery<web_access>
                (@"SELECT NAMA_LAPORAN FROM TEMP_TABLE_WEB_ACCESS").ToList();
        }

        public static List<web_access> getReportCode(string REPORT_NAME)
        {
            OracleDbContext context = new OracleDbContext();
            return context.Database.SqlQuery<web_access>
                (@"SELECT RPT_CD FROM TEMP_TABLE_WEB_ACCESS WHERE NAMA_LAPORAN = :REPORT_NAME", REPORT_NAME).ToList();
        }

        public static List<web_access> getReport()
        {
            OracleDbContext context = new OracleDbContext();
            return context.Database.SqlQuery<web_access>
                (@"SELECT NAMA_LAPORAN, RPT_CD FROM TEMP_TABLE_WEB_ACCESS").ToList();
        }
    }
}