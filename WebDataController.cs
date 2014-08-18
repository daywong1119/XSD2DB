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
	public class WebDataController
	{
		HtmlAgilityPack.HtmlDocument doc;
		public WebDataController(HtmlAgilityPack.HtmlDocument doc)
		{
			this.doc = doc;
		}

        public List<String> ByHtmlTabelId(String id)
        {
            List<String> listOfTable = new List<String>();
			HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//table[@id='"+id+"']"); 
			foreach (HtmlNode node in nodes) 
			{ 
			//	MessageBox.Show(node.InnerText.Trim()); 
                MessageBox.Show(node.InnerHtml.ToString());
                listOfTable.Add(node.InnerHtml.ToString());
            }
            return listOfTable;
		}
	
        
        public void TablesToData(List <String>listOfTables,List<String> ListOfColumnName){
            for(int i = 0;i < listOfTables.Count; i++){
                String tableText = listOfTables[i];
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(tableText);
                MessageBox.Show("TABLE EXTRACT:" + tableText);
            }
        }
		
		public void ByMatchingId(String id){}
		public void ByMatchingString(String startString, String endString){}
	}
}