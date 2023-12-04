using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;

namespace ColumnCreateFromDWG.Selecter
{
    public class SelecterDWG
    {
        public List<ImportInstance> DwgForLayer { get; set; }
        public List<string> AsSelectDWG(Document doc)
        {
            List<string> result = new List<string>();

            List<ImportInstance> dwg = new FilteredElementCollector(doc)
                .WhereElementIsNotElementType()
                .OfType<ImportInstance>()
                .ToList();

            DwgForLayer = dwg;

            foreach (ImportInstance imp in dwg)
            {
                result.Add(imp.Category.Name);
            }

            return result;
        }
    }
}
