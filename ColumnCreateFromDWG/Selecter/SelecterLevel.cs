using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;

namespace ColumnCreateFromDWG.Selecter
{
    public class SelecterLevel
    {
        public List<string> AsSelectLevel(Document doc)
        {
            List<string> result = new List<string>();

            List<Level> levels = new FilteredElementCollector(doc)
                .OfClass(typeof(Level))
                .Cast<Level>()
                .ToList();

            foreach (Level level in levels)
            {
                result.Add(level.Name);
            }

            return result;
        }
    }
}
