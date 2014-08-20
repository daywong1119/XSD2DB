using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xsd2sql.DataSetObject;
using HtmlAgilityPack;
using xsd2sql.entity;

namespace xsd2sql.helper
{
    public class DatabaseExtractHelper
    {

        public StaffTbl[] ExtractByTbl(HtmlAgilityPack.HtmlDocument doc, ByHtmlTBLId tbl)
        {
            // store the extracted data result for return
            List<StaffTbl> dataList = new List<StaffTbl>();

            // prepare / to ready reading the html by the table object[ByHtmlTBLId]
            HtmlNode nodes = doc.DocumentNode.SelectSingleNode("//table[@id='" + tbl.TblId + "']");

            StaffTbl staffTblData = null;

            // start to extract header names and match the table object headers, read the index
            HtmlNodeCollection headers = nodes.SelectNodes("//tr//th//");
            foreach (HtmlNode n in headers)
            {
                // read the header text here


                // use the related index to search the right data
                // use matched index to loop the //tr//td  to extract data to the StaffTbl
                // here may use a loop to save the data as an object
                staffTblData = new StaffTbl();
                staffTblData.StaffName = ""; // here set the value to related property
                // etc.


                // add to datalist
                dataList.Add(staffTblData);
            }

            // return the result set
            return dataList.ToArray();
        }

        public string ExtractByMatching(HtmlAgilityPack.HtmlDocument doc, ByMatching m)
        {
            return "";
        }

    }
}
