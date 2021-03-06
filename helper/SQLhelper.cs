﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using xsd2sql;
using xsd2sql.DataSetObject;

namespace SQLhelper
{
    public class SQLhelper
    {
        private readonly SqlConnection connection;
        private SqlCommand comm;

        public SQLhelper(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public SQLhelper()
        {

        }


        public string GenerateCreateDatabaseSql(string databaseName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("IF EXISTS ( SELECT [name] FROM sys.databases WHERE [name] = '" + databaseName + "' )");
            sb.AppendLine("DROP DATABASE " + databaseName + ";");
            sb.AppendLine();
            sb.AppendLine("CREATE DATABASE " + databaseName + ";");

            return sb.ToString();

        }

        public void ExecuteSql(string[] sqlCommand)
        {
            try
            {
                connection.Open();
                foreach (string s in sqlCommand)
                {
                    comm = new SqlCommand(s.ToString(), connection);
                    comm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void ExecuteSql(string sqlCommand)
        {
            try
            {
                connection.Open();
                comm = new SqlCommand(sqlCommand, connection);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public DataSet QueryAllTablesFromDatabase(string dbName)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            StringBuilder sb = new StringBuilder();
            DataSet ds = new DataSet();
            sb.AppendLine("USE " + dbName + ";");
            sb.AppendLine("SELECT TABLE_NAME,COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS;");


            connection.Open();


            da = new SqlDataAdapter(sb.ToString(), connection);
            da.Fill(ds);
            connection.Close();
            return ds;

        }

        public DataSet QueryAllRecordsFromTable(string dbName, string tableName)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            StringBuilder sb = new StringBuilder();
            DataSet ds = new DataSet();
            sb.AppendLine("USE " + dbName + ";");
            sb.AppendLine("SELECT * FROM " + tableName + ";");

            connection.Open();

            da = new SqlDataAdapter(sb.ToString(), connection);
            da.Fill(ds);
            connection.Close();
            return ds;
        }

        public string CreateTableAndColumn(DataSet sourceDataSet, Dictionary<string, XsPrimaryKey> pKeyDict, Dictionary<string, XsPrimaryKey> fKeyDict)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("use " + sourceDataSet.DataSetName + ";");
            foreach (DataTable table in sourceDataSet.Tables)
            {
                sb.AppendLine("IF OBJECT_ID('dbo." + table.TableName + "') is not null");
                sb.AppendLine("drop Table dbo." + table.TableName + ";");
                sb.AppendLine();
                sb.Append("Create table ");
                sb.AppendLine(table.TableName);
                sb.Append("(");

                for (int i = 0; i < table.Columns.Count; i++)
                {
                    //if type = datetime then not add (100)
                    if ((CLRTypeToSQLType(table.Columns[i].DataType)).Name.ToLower() == DataType.DateTime.Name)
                    {
                        // col_name col_type, 
                        sb.AppendFormat("{0} {1}, ", table.Columns[i], (CLRTypeToSQLType(table.Columns[i].DataType)).Name.ToLower());
                    }
                    //if type = integer then not add (100)
                    else if ((CLRTypeToSQLType(table.Columns[i].DataType)).Name.ToLower() == DataType.Int.Name)
                    {
                        sb.AppendFormat("{0} {1}, ", table.Columns[i], (CLRTypeToSQLType(table.Columns[i].DataType)).Name.ToLower());
                    }
                    //if type != datetime then add (100)
                    else
                    {
                        sb.AppendFormat("{0} {1}, ", table.Columns[i], (CLRTypeToSQLType(table.Columns[i].DataType)).Name.ToLower() + " (100)");
                    }

                }

                //sb.Length -= 2;

                //bool needKeySep = false;

                XsPrimaryKey tempKey = null;
                //Create primary key
                if (pKeyDict.ContainsKey(table.TableName))
                {
                    tempKey = pKeyDict[table.TableName];

                    if (tempKey.Fields == null || tempKey.Fields.Length == 0)
                        throw new ArgumentNullException("Primary Key[" + tempKey.KeyName + "] does not have fields");

                    //needKeySep = true;
                    sb.AppendLine();
                    sb.AppendFormat("CONSTRAINT {0} PRIMARY KEY ({1}) "
                        , tempKey.KeyName
                        , string.Join(", ", tempKey.Fields));

                    // above appendformat function replace below for loop generate fields to sql
                    //sb.Append("\r\n CONSTRAINT " + tempKey.KeyName + " PRIMARY KEY (");

                    //for (int i = 0; i < tempKey.Fields.Length; i++)
                    //{
                    //    sb.Append(tempKey.Fields[i] + ", ");
                    //}

                    //sb.Length -= 2;
                    //sb.AppendLine(")");
                }

                // Create FOREIGN Key
                if (fKeyDict.ContainsKey(table.TableName))
                {
                    sb.Append(",");
                    tempKey = fKeyDict[table.TableName];

                    if (tempKey.Fields == null || tempKey.Fields.Length == 0)
                        throw new ArgumentNullException("Foreign Key[" + tempKey.KeyName + "] does not have fields");

                    XsPrimaryKey refKey = pKeyDict.Values.Where(x => x.KeyName == tempKey.ReferPrimaryKey).FirstOrDefault();

                    sb.AppendLine();
                    sb.AppendFormat("CONSTRAINT {0} FOREIGN KEY ({1}) REFERENCES {2} ({3})"
                        , tempKey.KeyName
                        , string.Join(", ", tempKey.Fields)
                        , refKey.Selector
                        , string.Join(", ", refKey.Fields));


                    // above appendformat function replace below for loop generate fields to sql
                    //sb.Append("\r\n ,CONSTRAINT " + tempKey.KeyName + " FOREIGN KEY (");

                    //for (int i = 0; i < tempKey.Fields.Length; i++)
                    //{
                    //    sb.Append(tempKey.Fields[i] + ", ");
                    //}

                    //sb.Length -= 2;
                    //sb.AppendLine(")");

                    //sb.Append(" REFERENCES ");

                    //;

                    //sb.Append(refKey.Selector + " (" +  + ") ");
                }


                sb.Append(");");
                sb.AppendLine();
                sb.AppendLine();
            }

            return sb.ToString();
        }

        /*
            CREATE TABLE Student
            (
                        SID varchar(10) NOT NULL,
                        Name varchar(10) NOT NULL,
                        EnrollmentDate Datetime,
                        StudyYear Datetime,
                        CONSTRAINT PKStudent PRIMARY KEY (SID)
			
            );
            
            
            Create table Registration
            (
                        SID varchar(10),
                        ModuleID varchar NOT NULL,
                        Title Datetime,
                        ModuleOutline Datetime,
                        Year int,
                        Grade varchar(10),
                        CONSTRAINT PKRegistration PRIMARY KEY (SID, ModuleID, Year),
                        CONSTRAINT FKStudent FOREIGN KEY (SID) REFERENCES Student(SID)
            );
         */


        private DataType CLRTypeToSQLType(Type type)
        {
            switch (type.Name)
            {
                case "String":
                    return DataType.VarCharMax;

                case "Int64":
                    return DataType.Int;

                case "Boolean":
                    return DataType.VarChar(2);

                case "DateTime":
                    return DataType.DateTime;

                case "Decimal":
                    return DataType.VarCharMax;
            }

            return DataType.VarCharMax;
        }

        //// DbTbl get this parameter
        //public string InsertStaff(string dbName, string tableName, StaffTbl[] staffList)
        //{
        //    ByHtmlTBLId htmlId = new ByHtmlTBLId();
        //    List<string> fieldName = new List<string>();
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("use " + dbName + ";");
        //    foreach (StaffTbl tl in staffList)
        //    {
        //        sb.AppendLine("insert into " + tableName);
        //        sb.AppendLine("(" + htmlId.ColMatchList.Where(x => x.FieldName == tl.StaffId) + ", " + htmlId.ColMatchList.Where(x => x.FieldName == tl.StaffName) + ", " + htmlId.ColMatchList.Where(x => x.FieldName == tl.JoinYear.ToString()) + ")");
        //        sb.AppendLine("values ('" + tl.StaffId + "', " + "'" + tl.StaffName + "', " + tl.JoinYear + ");");
        //    }

        //    return sb.ToString();
        //}


        public static string GenerateInsertSql(string tblName, ByHtmlTBLId htmlTblId, List<string[]> data)
        {
            StringBuilder sb = new StringBuilder();

            string[] heads = data[0];
            Dictionary<int, string> mapDict = new Dictionary<int, string>();
            int idx = -1;
            foreach (string s in heads)
            {
                idx = Array.IndexOf(htmlTblId.HeaderNameList, s);
                if (idx < 0) continue;
                mapDict[idx] = s;
            }

            sb.AppendFormat("INSERT INTO {0} ({1}) ", tblName, string.Join(", ", htmlTblId.FieldNameList));

            // data
            sb.Append(" VALUES ");
            List<string[]> rawData = data.Skip(1).ToList();
            string valueStr = null;
            List<string> values = new List<string>();
            List<string> temp = new List<string>();
            foreach (KeyValuePair<int, string> kvp in mapDict)
            {
                valueStr += "(";
                for (int i = 0; i < rawData.Count; i++)
                {
                    temp.Add(AddQuote(rawData[kvp.Key][i]));
                }

                valueStr += string.Join(", ", temp.ToArray());

                valueStr += ")";
                values.Add(valueStr);
                valueStr = null;
                temp.Clear();
            }

            string st = string.Join(", ", values.ToArray());
            sb.Append(st);
            sb.Append(";");
            return sb.ToString();



            /*
            insert into StaffTBL
            (staffId, staffName, joinYear)
            values
            ('6', 'abc', 2014),
            ('4', 'abc', 2014),
            ('5', 'abc', 2014);
             */
        }

        public static string GenerateInsertSql(string tblName, ByMatching matching, List<string[]> data)
        {
            StringBuilder sb = new StringBuilder();

            string[] headers = data[0];
            sb.AppendFormat("INSERT INTO {0} ({1}) ", tblName, string.Join(", ", headers));

            // data
            sb.Append(" VALUES ");
            List<string[]> rawData = data.Skip(1).ToList();
            string valueStr = null;
            List<string> values = new List<string>();
            List<string> temp = new List<string>();
            valueStr += "(";

            foreach (string[] strArry in rawData)
            {
                for (int i = 0; i < strArry.Length; i++)
                {
                    temp.Add(AddQuote(strArry[i]));
                }
            }
            valueStr += string.Join(", ", temp.ToArray());

            valueStr += ")";
            values.Add(valueStr);
            valueStr = null;
            temp.Clear();

            string st = string.Join(", ", values.ToArray());
            sb.Append(st);
            sb.Append(";");
            return sb.ToString();



            /*
            INSERT INTO OrderTBL
            (orderId, orderDate, orderAmt, staffId)
            values
            (N'IN000001', N'2012-01-24', N'10000', N'SA1234'),
            (N'IN000002', N'2012-01-30', N'20000', N'SA1234');
             */
        }

        public static string AddQuote(string s)
        {
            if (s == null) return null;

            return string.Format("N'{0}'", s.Replace("'", "''"));
        }
    }
}