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
using xsd2sql.entity;
namespace xsd2sql
{
    public class WebDataController
    {
        HtmlAgilityPack.HtmlDocument doc;
        public WebDataController(HtmlAgilityPack.HtmlDocument doc)
        {
            this.doc = doc;
        }

        public StaffTbl[] ByHtmlTabelId(String id)
        {
            HtmlNode nodes = doc.DocumentNode.SelectSingleNode("//table[@id='" + id + "']");

            HtmlNodeCollection n =nodes.SelectNodes("//tr//th//");


            foreach (HtmlNode node in nodes.ChildNodes)
            {
                //MessageBox.Show(node.InnerText);




                if (node.NodeType == HtmlNodeType.Element)
                {
                    



                    //Console.WriteLine(node);
                }
            }

            //return a StaffTbl Array
        }

        public void ByMatchingId(String id) { }
        public void ByMatchingString(String startString, String endString) { }
    }
}