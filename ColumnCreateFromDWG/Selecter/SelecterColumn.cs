using Autodesk.Revit.DB;
using ColumnCreateFromDWG.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace ColumnCreateFromDWG.Selecter
{
    public class SelecterColumn
    {
        public List<FamilySymbol> AsSelectColumn(Document doc) 
            => doc.GetElements<FamilySymbol>(BuiltInCategory.OST_StructuralColumns);
    }
}
