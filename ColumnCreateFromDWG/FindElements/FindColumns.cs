using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColumnCreateFromDWG.FindElements
{
    public class FindColumns
    {
        public FamilySymbol FindColumnSymbolByName(Document doc, string columnName)
        {
            return new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_StructuralColumns)
                .WhereElementIsElementType()
                .Cast<FamilySymbol>()
                .FirstOrDefault(symbol => symbol.Name == columnName);
        }
    }
}
