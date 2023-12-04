using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;

namespace ColumnCreateFromDWG.Creator
{
    public class SelecterDWG
    {
        public IList<ImportInstance> DwgForLayer;
        public IList<string> AsSelectDWG(Document doc)
        {
            IList<string> result = new List<string>();

            IList<ImportInstance> dwg = new FilteredElementCollector(doc)
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
