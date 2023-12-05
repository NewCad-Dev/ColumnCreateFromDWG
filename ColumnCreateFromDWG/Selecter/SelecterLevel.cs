using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;
using ColumnCreateFromDWG.Extensions;

namespace ColumnCreateFromDWG.Selecter
{
    public class SelecterLevel
    {
        public List<Level> AsSelectLevel(Document doc) => doc.GetElements<Level>();
    }
}
