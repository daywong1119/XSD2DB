using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Serialization;
using System.Collections;
using HtmlAgilityPack; 
namespace xsd2sql
{
    public partial class Form1 : Form
    {
        StringBuilder sb = new StringBuilder();
        string openfilePath;
        List<string> sqlScript;
        string dbName;
        string conn = "Data Source=localhost;User ID=sa;Password=Hi88geK!";

        public Form1()
        {
            InitializeComponent();
            InitGui();
        }

        private void InitGui()
        {
            txtPath.ReadOnly = false;
            btnCreateDB.Enabled = false;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            DataSet dataset = new DataSet();
            XmlReader reader = null;
            try
            {
                //XmlReader reader2 = XmlReader.Create(@"data\demo2.xsd");

                reader = XmlReader.Create(openfilePath);
                XmlDocument doc = new XmlDocument();

                doc.Load(reader);
                XmlNodeReader xnr = new XmlNodeReader(doc);
                dataset.ReadXml(xnr);
                dbName = dataset.DataSetName;
                //pKeyDict.Clear();

                List<string> commandS = new List<string>();

                Dictionary<string, XsPrimaryKey> pKeyDict = new Dictionary<string, XsPrimaryKey>();
                Dictionary<string, XsPrimaryKey> fKeyDict = new Dictionary<string, XsPrimaryKey>();

                SQLhelper.SQLhelper dbHelper = new SQLhelper.SQLhelper();
                commandS.Add(dbHelper.GenerateCreateDatabaseSql(dataset.DataSetName));
                pKeyDict = KeyHandler(doc, XsdTypePolicy.XS_KEY);
                fKeyDict = KeyHandler(doc, XsdTypePolicy.XS_KEY_REF);
                commandS.Add(dbHelper.CreateTableAndColumn(dataset, pKeyDict, fKeyDict));


                // save sql to local
                //File.WriteAllLines(@"C:\temp\sql.txt", commandS.ToArray());


                MessageBox.Show("SQL script generated");
                txtContent.Clear();
                for (int i = 0; i < commandS.Count; i++)
                {
                    txtContent.Text += commandS[i].ToString();
                }

                btnCreateDB.Enabled = true;
                sqlScript = commandS;
                //if ((MessageBox.Show("Do you want to create database?", "Options", MessageBoxButtons.YesNo)) == DialogResult.Yes)
                //{
                //    dbHelper.ExecuteSql(commandS.ToArray());
                //    MessageBox.Show("Database Created");
                //}

            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurs, Invalid Operation.\n" + ex.ToString(), "Error");
                return;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (dataset != null || dataset.Tables.Count > 0)
                    dataset.Clear();
            }
        }

        private Dictionary<string, XsPrimaryKey> KeyHandler(XmlDocument document, string tagName)
        {
            string relatedTable = null;
            XmlNodeList NodeList = null;
            List<string> fieldsList = null;
            XsPrimaryKey key = null;
            Dictionary<string, XsPrimaryKey> dbKeyS = new Dictionary<string, XsPrimaryKey>();


            XmlNamespaceManager mgr = new XmlNamespaceManager(document.NameTable);
            mgr.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
            XmlNodeList nodesByKeyTag = document.GetElementsByTagName(tagName);
            if (tagName == XsdTypePolicy.XS_KEY)
            {
                // Search Primary Key
                foreach (XmlNode node in nodesByKeyTag)
                {
                    if (node.SelectNodes(XsdTypePolicy.XS_SELECTOR, mgr).Count > 0)
                    {
                        relatedTable = node.SelectNodes(XsdTypePolicy.XS_SELECTOR, mgr)[0].Attributes["xpath"].Value;
                    }

                    NodeList = node.SelectNodes(XsdTypePolicy.XS_FIELD, mgr);
                    if (NodeList.Count > 0)
                    {
                        fieldsList = new List<string>();
                        foreach (XmlNode n in NodeList)
                        {
                            fieldsList.Add(n.Attributes["xpath"].Value);
                        }
                    }

                    // parse to dict
                    key = new XsPrimaryKey()
                    {
                        KeyName = node.Attributes["name"].Value,
                        Selector = relatedTable,
                        Fields = (fieldsList == null || fieldsList.Count > 0) ? fieldsList.ToArray() : null,
                        Keys = xsd2sql.XsPrimaryKey.KeyType.IsPrimaryKey,
                        ReferPrimaryKey = null
                    };

                    dbKeyS.Add(relatedTable, key);
                }

            }

            if (tagName == XsdTypePolicy.XS_KEY_REF)
            {
                // Search forigne key
                foreach (XmlNode node in nodesByKeyTag)
                {
                    if (node.SelectNodes(XsdTypePolicy.XS_SELECTOR, mgr).Count > 0)
                    {
                        relatedTable = node.SelectNodes(XsdTypePolicy.XS_SELECTOR, mgr)[0].Attributes["xpath"].Value;
                    }

                    NodeList = node.SelectNodes(XsdTypePolicy.XS_FIELD, mgr);
                    if (NodeList.Count > 0)
                    {
                        fieldsList = new List<string>();
                        foreach (XmlNode n in NodeList)
                        {
                            fieldsList.Add(n.Attributes["xpath"].Value);
                        }
                    }

                    // parse to dict
                    key = new XsPrimaryKey()
                    {
                        KeyName = node.Attributes["name"].Value,
                        Selector = relatedTable,
                        Fields = (fieldsList == null || fieldsList.Count > 0) ? fieldsList.ToArray() : null,
                        Keys = xsd2sql.XsPrimaryKey.KeyType.IsForeignKey,
                        ReferPrimaryKey = node.Attributes["refer"].Value
                    };

                    dbKeyS.Add(relatedTable, key);
                }
            }

            return dbKeyS;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPath.Text))
            {
                MessageBox.Show("Please select file");
                return;
            }

            try
            {
                txtContent.Text = File.ReadAllText(openfilePath);
            }
            catch
            {
                MessageBox.Show("File cannot read");
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //dialogOpenFile.ShowDialog();
            if (dialogOpenFile.ShowDialog() == DialogResult.OK)
            {
                openfilePath = Path.GetFullPath(dialogOpenFile.FileName);
                txtPath.Text = openfilePath;
            }
        }

        private void btnCreateDB_Click(object sender, EventArgs e)
        {
            DataSet tableDS = new DataSet();
            DataSet columnDS = new DataSet();
            SQLhelper.SQLhelper dbHelper = new SQLhelper.SQLhelper(conn);
            dbHelper.ExecuteSql(sqlScript.ToArray());
            MessageBox.Show("Database Created");
            btnCreateDB.Enabled = false;
            tableDS = dbHelper.QueryAllTablesFromDatabase(dbName);
            for (int i = 0; i < tableDS.Tables.Count; i++)
            {
                tableDataGV.DataSource = tableDS.Tables[i];
            }

            tableDataGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

	
		//Use to store how many webpage Should be visit in order to grab data
		private ArrayList mFileBuffer = new ArrayList();
	
        private void btnReadTamplate_Click(object sender, EventArgs e)
        {
            //Read XML and Loop through elements
            if (string.IsNullOrEmpty(txtPath.Text))
            {
                MessageBox.Show("Please select file");
                return;
            }

            try
            {
                txtContent.Clear();
                txtContent.Text = File.ReadAllText(openfilePath);
            }
            catch
            {
                MessageBox.Show("File cannot read");
            }

            try
            {
				//Read XML
                XmlReader reader = XmlReader.Create(openfilePath);
                XmlSerializer serializer = new XmlSerializer(typeof(DatabaseObject));
                DatabaseObject db = (DatabaseObject)serializer.Deserialize(reader);
                //MessageBox.Show(db.DbTables[1].ToString());
				for (int i = 0; i < db.DbTables.Length; i++)//Tables Looper
                {
                    //MessageBox.Show(db.DbTables[i].HtmlFile[i].FileNames[i].ToString());
					//.MatchingS[i].ByStrS[i].StartStr
                    //MessageBox.Show(db.DbTables[i].TableName.ToString());
					//MessageBox.Show("db.DbTables[i].HtmlFile.Length=" + db.DbTables[i].HtmlFile.Length);
					
					if(db.DbTables[i].getHtmlFilesCount() == 0 ){
						MessageBox.Show("Webpage path is not defined,please define <htmlFile> tag");
						return;
					}				
					if(db.DbTables[i].HtmlFile[0].getFilenamesCount() == 0){
						MessageBox.Show("Webpage path is not defined,please define <filename> tag");
						return;
					}
					
					//Filename looper
					for(int j = 0; j < db.DbTables[i].HtmlFile[0].getFilenamesCount(); j++){
						String x = db.DbTables[i].HtmlFile[0].FileNames[j];
						mFileBuffer.Add(x);
					}

					for(int k = 0; k < mFileBuffer.Count ; k++){
						//Parse hmtlfile
						String filename = mFileBuffer[k].ToString();
						MessageBox.Show("Parsing html file:"+ filename);
						HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
						doc.Load(@"assets/"+filename);
						
						WebDataController ctrl = new WebDataController(doc);
						ctrl.ByHtmlTabelId("staff");
					}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
