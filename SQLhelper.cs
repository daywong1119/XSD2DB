using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using xsd2sql;

namespace SQLhelper
{
    public class SQLhelper
    {
        private readonly SqlConnection connection;
        //private Dictionary<string, XsPrimaryKey> keyDict;
        private SqlCommand comm;

        //public SQLhelper(string connectionString, DataSet source, Dictionary<string, XsPrimaryKey> keys)
        //{
        //    connection = new SqlConnection(connectionString);
        //    dbServer = new Server(new ServerConnection(connection));
        //    sourceDataSet = source;
        //    this.keyDict = keys;
        //}

        public SQLhelper(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            //dbServer = new Server(new ServerConnection(connection));
        }

        public SQLhelper()
        {

        }


        public string GenerateCreateDatabaseSql(string databaseName)
        {
            //this.databaseName = databaseName;
            //datebase = dbServer.Databases[databaseName];
            //if (datebase != null) datebase.Drop();
            //datebase = new Database(dbServer, databaseName);
            //datebase.Create();

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

        //private void CreateTables(DataTableCollection tables)
        //{
        //    foreach (DataTable table in tables)
        //    {
        //        DropExistingTable(table.TableName);
        //        Table newTable = new Table(datebase, table.TableName);

        //        PopulateTable(ref newTable, table);
        //        SetPrimaryKeys(ref newTable, table);
        //        newTable.Create();
        //    }
        //}

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
                    // col_name col_type, 
                    sb.AppendFormat("{0} {1}, ", table.Columns[i], CLRTypeToSQLType(table.Columns[i].DataType));

                    //sb.Append(table.Columns[i]);
                    //sb.Append(" ");
                    //sb.Append(CLRTypeToSQLType(table.Columns[i].GetType()));
                    //sb.Append(", ");
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

                case "Int32":
                    return DataType.Int;

                case "Boolean":
                    return DataType.VarChar(2);

                case "DateTime":
                    return DataType.DateTime;

                case "xs:date":
                    return DataType.DateTime;

                case "Byte[]":
                    return DataType.VarBinaryMax;
            }

            return DataType.VarCharMax;
        }




































        //public void PopulateDatabase()
        //{
        //    //CreateTables(sourceDataSet.Tables);
        //    CreateRelationships();
        //}

        //private void CreateRelationships()
        //{
        //    foreach (DataTable table in sourceDataSet.Tables)
        //    {
        //        foreach (DataRelation rel in table.ChildRelations)
        //            CreateRelation(rel);
        //    }
        //}

        //private void CreateRelation(DataRelation relation)
        //{


        //    Table primaryTable = datebase.Tables[relation.ParentTable.TableName];
        //    Table childTable = datebase.Tables[relation.ChildTable.TableName];

        //    ForeignKey fkey = new ForeignKey(childTable, relation.RelationName);
        //    fkey.ReferencedTable = primaryTable.Name;

        //    fkey.DeleteAction = SQLActionTypeToSMO(relation.ChildKeyConstraint.DeleteRule);
        //    fkey.UpdateAction = SQLActionTypeToSMO(relation.ChildKeyConstraint.UpdateRule);


        //    for (int i = 0; i < relation.ChildColumns.Length; i++)
        //    {
        //        DataColumn col = relation.ChildColumns[i];
        //        ForeignKeyColumn fkc = new ForeignKeyColumn(fkey, col.ColumnName, relation.ParentColumns[i].ColumnName);

        //        fkey.Columns.Add(fkc);
        //    }

        //    fkey.Create();


        //}

        //private void PopulateTable(ref Table outputTable, DataTable inputTable)
        //{
        //    foreach (DataColumn column in inputTable.Columns)
        //    {
        //        CreateColumns(ref outputTable, column, inputTable);
        //    }
        //}

        //private void CreateColumns(ref Table outputTable, DataColumn inputColumn, DataTable inputTable)
        //{
        //    Column newColumn = new Column(outputTable, inputColumn.ColumnName);
        //    newColumn.DataType = CLRTypeToSQLType(inputColumn.DataType);
        //    newColumn.Identity = inputColumn.AutoIncrement;
        //    newColumn.IdentityIncrement = inputColumn.AutoIncrementStep;
        //    newColumn.IdentitySeed = inputColumn.AutoIncrementSeed;
        //    newColumn.Nullable = inputColumn.AllowDBNull;
        //    newColumn.UserData = inputColumn.DefaultValue;

        //    outputTable.Columns.Add(newColumn);
        //}

        //private void SetPrimaryKeys(ref Table outputTable, DataTable inputTable)
        //{

        //    if (!keyDict.ContainsKey(outputTable.Name)) return;

        //    XsPrimaryKey key = keyDict[outputTable.Name];
        //    Index newIndex = new Index(outputTable, key.KeyName);
        //    newIndex.IndexKeyType = IndexKeyType.DriPrimaryKey;
        //    newIndex.IsClustered = true;


        //    // set primary key to table
        //    foreach (string f in key.Fields)
        //    {
        //        newIndex.IndexedColumns.Add(new IndexedColumn(newIndex, f, false));
        //    }

        //    if (newIndex.IndexedColumns.Count > 0)
        //        outputTable.Indexes.Add(newIndex);


        //Index newIndex = new Index(outputTable, "PK" + outputTable.Name);
        //newIndex.IndexKeyType = IndexKeyType.DriPrimaryKey;
        //newIndex.IsClustered = false;

        //foreach (DataColumn keyColumn in inputTable.PrimaryKey)
        //{
        //    newIndex.IndexedColumns.Add(new IndexedColumn(newIndex, keyColumn.ColumnName, true));
        //}
        //if (newIndex.IndexedColumns.Count > 0)
        //    outputTable.Indexes.Add(newIndex);
        //}





        //private ForeignKeyAction SQLActionTypeToSMO(Rule rule)
        //{
        //    string ruleStr = rule.ToString();

        //    return (ForeignKeyAction)Enum.Parse(typeof(ForeignKeyAction), ruleStr);
        //}

        //private void DropExistingTable(string tableName)
        //{
        //    Table table = datebase.Tables[tableName];
        //    if (table != null) table.Drop();
        //}


    }
}