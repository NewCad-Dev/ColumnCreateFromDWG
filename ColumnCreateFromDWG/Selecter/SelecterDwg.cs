using Autodesk.Revit.DB;

using System.Collections.Generic;

using ColumnCreateFromDWG.Extensions;

namespace ColumnCreateFromDWG.Selecter
{
    public class SelecterDWG
    {
        public SelecterDWG()
        {
        }

        public List<ImportInstance> AsSelectDWG(Document doc) => doc.GetElements<ImportInstance>();
    }
}
