using Autodesk.Revit.DB;
using ColumnCreateFromDWG.FindElements;
using System.Collections.Generic;
using System.Linq;

namespace ColumnCreateFromDWG.Selecter
{
    public class SelecterDWG
    {
        public List<string> AsSelectDWG(Document doc)
        {
            List<string> result = new List<string>();

            List<ImportInstance> dwg = new FindDWG().FindDWGs(doc);

            foreach (ImportInstance imp in dwg)
            {
                result.Add(imp.Category.Name);
            }

            return result;
        }
    }
}
