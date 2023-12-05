using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;

namespace ColumnCreateFromDWG.Selecter
{
    public class SelecterColumn
    {
        public List<string> AsSelectColumn(Document doc)
        {
            List<string> result = new List<string>();

            List<Element> columns = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_StructuralColumns)
                .WhereElementIsElementType()
                .ToList();

            foreach (Element element in columns)
            {
                result.Add(element.Name);
            }

            return result;
        }
    }
}
