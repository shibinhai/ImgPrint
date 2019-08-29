using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class Common
    {

        #region MD5加密

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sDataIn"></param>
        /// <param name="move">给空即可</param>
        /// <returns></returns>
        public static string GetMD532(string sDataIn, string move)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytValue, bytHash;
            bytValue = System.Text.Encoding.UTF8.GetBytes(move + sDataIn);
            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            string sTemp = "";
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("x").PadLeft(2, '0');
            }
            return sTemp;
        }

        #endregion

        /// <summary>
        /// 增加一条操作日志数据
        /// </summary>
        public static void Add(string userName, string beiZhu)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into OpLog(");
                strSql.Append("username,beizhu)");
                strSql.Append(" values (");
                strSql.Append("@username,@beizhu)");
                SqlParameter[] parameters = {
					new SqlParameter("@username",userName),
					new SqlParameter("@beizhu", beiZhu)};
                DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
            catch (Exception)
            {

            }
        }

        public static string GetAppSetingServerIp()
        {
            return ConfigurationManager.AppSettings["serverIp"].ToString();
        }


        #region XSSFWorkbook ReadExcel

        public static DataTable ReadExcel(string filePath)
        {
            DataTable dt = new DataTable();
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                ISheet sheet = null;
                if (filePath.Contains(".xlsx"))
                {
                    XSSFWorkbook workbook = new XSSFWorkbook(fs);
                    sheet = workbook.GetSheetAt(0);
                }
                else
                {
                    //HSSFWorkbook workbook = new HSSFWorkbook(fs);
                    //sheet = workbook.GetSheetAt(0);
                    throw new Exception("只支持.xlsx格式的excel");
                }

                sheet.ForceFormulaRecalculation = true;

                //表头  
                IRow header = sheet.GetRow(sheet.FirstRowNum);
                List<int> columns = new List<int>();
                for (int i = 0; i < header.LastCellNum; i++)
                {
                    object obj = GetValueTypeForXLSX(header.GetCell(i) as XSSFCell);
                    if (obj == null || obj.ToString() == string.Empty)
                    {
                        dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
                        //continue;  
                    }
                    else
                        dt.Columns.Add(new DataColumn(obj.ToString()));
                    columns.Add(i);
                }
                //数据
                for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                {
                    DataRow dr = dt.NewRow();
                    bool hasValue = false;
                    foreach (int j in columns)
                    {
                        dr[j] = GetValueTypeForXLSX(sheet.GetRow(i).GetCell(j) as XSSFCell);
                        if (dr[j] != null && dr[j].ToString() != string.Empty)
                        {
                            hasValue = true;
                        }
                    }
                    if (hasValue)
                    {
                        dt.Rows.Add(dr);
                    }
                }
            }
            return dt;
        }
        /// <summary>  
        /// 获取单元格类型(xlsx)  
        /// </summary>  
        /// <param name="cell"></param>  
        /// <returns></returns>  
        private static object GetValueTypeForXLSX(XSSFCell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.Blank:
                    return null;
                case CellType.Boolean:
                    return cell.BooleanCellValue;
                case CellType.Numeric:
                    return cell.NumericCellValue;
                case CellType.String:
                    return cell.StringCellValue;
                case CellType.Error:
                    return cell.ErrorCellValue;
                case CellType.Formula:
                    return cell.NumericCellValue;
                default:
                    return "=" + cell.CellFormula;
            }
        }

        #endregion
    }
}
