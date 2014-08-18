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

        public string ExtractByhtmlTBLId(HtmlAgilityPack.HtmlDocument doc, string tbname, ByHtmlTBLId tblId)
        {
            WebDataController ctrl = new WebDataController(doc);
            StaffTbl[] sales = ctrl.ByHtmlTabelId(tblId.TblId);

            return "";
        }

        public string ExtractByMatching(HtmlAgilityPack.HtmlDocument doc, ByMatching m)
        {
            return "";
        }

    }
}
