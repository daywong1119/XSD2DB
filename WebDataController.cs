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
		
		public void ByHtmlTabelId(String id){
			HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//table[@id='"+id+"']"); 
			foreach (HtmlNode node in nodes) 
			{ 
				MessageBox.Show(node.InnerText.Trim()); 
			} 
		}	
		
		public void ByMatchingId(String id){}
		public void ByMatchingString(String startString, String endString){}
	}
}