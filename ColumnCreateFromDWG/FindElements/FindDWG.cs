using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColumnCreateFromDWG.FindElements
{
    public class FindDWG
    {
        public List<ImportInstance> FindDWGs(Document doc)
        {
            return new FilteredElementCollector(doc)
                .WhereElementIsNotElementType()
                .OfType<ImportInstance>()
                .ToList();
        }
    }
}
