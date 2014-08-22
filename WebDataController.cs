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
        private Boolean isMatchingStarted = false;
        private List<String> matchingTitleBuffer;
        private List<String> matchingDataBuffer;
        private HtmlAgilityPack.HtmlDocument doc;
        public WebDataController(HtmlAgilityPack.HtmlDocument doc) { this.doc = doc; }

        public List<string[]> ByHtmlTabelId(String id, List<String> colNames)
        {
            List<String> tables = GetTableString(id);
            List<string[]> tablesData = TablesToDataByMichael(tables, colNames);
            return tablesData;
        }

        public void StartMatchingBuffer()
        {
            isMatchingStarted = true;
            matchingTitleBuffer = new List<string>();
            matchingDataBuffer = new List<string>();
        }
        public List<string[]> getMatchingResult()
        {
            List<string[]> result = new List<string[]>();
            result.Add(matchingTitleBuffer.ToArray());
            result.Add(matchingDataBuffer.ToArray());
            isMatchingStarted = false;
            return result;
        }

        public void ByMatchingId(String id)
        {
            Boolean isMatched = false;
            HtmlNodeCollection nodeCollection = doc.DocumentNode.SelectNodes("//*");
            foreach (HtmlNode node in nodeCollection)
            {
                HtmlAttributeCollection attrs = node.Attributes;
                foreach (HtmlAttribute attr in attrs)
                { //MessageBox.Show("Matching "+attr.Value+" vs "+id);
                    if (attr.Value.Equals(id))
                        isMatched = true;
                }
                if (isMatched)
                {//MessageBox.Show("FOUND = "+node.InnerText);
                    matchingTitleBuffer.Add(id);
                    matchingDataBuffer.Add(node.InnerText);
                    isMatched = false;
                }
            }
        }

        public void ByMatchingString(String filedName, String startString, String endString)
        {
            int indexStart;
            int indexEnd;
            String data = doc.DocumentNode.InnerHtml.Trim();
            indexStart = data.IndexOf(startString);
            if (indexStart != -1)
            {
                String subData = data.Substring(indexStart);
                indexEnd = subData.IndexOf(endString);
                if (indexEnd != -1)
                {//MessageBox.Show(data.Substring(indexStart + startString.Length, indexEnd - startString.Length));
                    matchingTitleBuffer.Add(filedName);
                    matchingDataBuffer.Add(data.Substring(indexStart + startString.Length, indexEnd - startString.Length));

                }
            }
        }

        //Get every <table>...</table> in the HTML Documents
        private List<String> GetTableString(String id)
        {
            List<String> listOfTable = new List<String>();
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//table[@id='" + id + "']");
            foreach (HtmlNode node in nodes)
            {
                listOfTable.Add(node.InnerHtml.Trim().ToString());
            }
            return listOfTable;
        }

        //Convert <Tabel>...</Table> Html String to List<StaffTbl> object
        private List<List<String>> TablesToData(List<String> listOfTables)//, List<String> ListOfColumnName)
        {
            List<List<String>> rows = new List<List<String>>();
            for (int i = 0; i < listOfTables.Count; i++)
            {
                String tableText = listOfTables[i];
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(tableText);
                HtmlNodeCollection trCollection = doc.DocumentNode.SelectNodes("./tr");
                foreach (HtmlNode trNode in trCollection)
                {
                    List<String> row = new List<String>();
                    HtmlNodeCollection tdCollection = trNode.SelectNodes("./td");
                    foreach (HtmlNode tdNode in tdCollection)
                    {
                        row.Add(tdNode.InnerText.ToString());
                    }
                    rows.Add(row);
                }
            }
            return rows;
        }


        //By Michael
        public List<string[]> TablesToDataByMichael(List<String> listOfTables, List<String> colNames) //
        {
            List<int> indexList = new List<int>();
            List<string[]> rows = new List<string[]>();
            for (int i = 0; i < listOfTables.Count; i++)
            {
                String tableText = listOfTables[i];
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(tableText);

                HtmlNodeCollection thCollect = doc.DocumentNode.SelectNodes("//tr//th");
                //List<String> row = new List<String>();
                String[] row = new String[colNames.Count];
                foreach (HtmlNode tdNode in thCollect)
                {
                    //User Defind Header list compare with actual table cols
                    for (int j = 0; j < colNames.Count; j++)
                    {
                        String header = colNames[j];
                        if (String.Equals(tdNode.InnerText.ToString(), header))
                        {
                            indexList.Add(j);
                            row[j] = header;
                        }
                    }
                    //row.Add(tdNode.InnerText.ToString());
                }
                rows.Add(row);//ADD header row

                HtmlNodeCollection trCollection = doc.DocumentNode.SelectNodes("./tr");
                foreach (HtmlNode trNode in trCollection)
                {
                    // header add to array[0], to identify array structure
                    row = new String[colNames.Count];
                    HtmlNodeCollection tdCollection = trNode.SelectNodes("./td");
                    for (int k = 0; k < tdCollection.Count; k++)
                    {
                        HtmlNode tdNode = tdCollection[k];
                        row[indexList[k]] = tdNode.InnerText.ToString();
                    }
                    // foreach (HtmlNode tdNode in tdCollection){
                    //   row.Add(tdNode.InnerText.ToString());}
                    rows.Add(row.ToArray());
                }
            }
            return rows;
        }

    }
}