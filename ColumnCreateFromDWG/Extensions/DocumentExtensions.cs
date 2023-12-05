using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace ColumnCreateFromDWG.Extensions
{
    public static class DocumentExtensions
    {
        public static List<T> GetElements<T>(this Document document) where T : Element
        {
            return new FilteredElementCollector(document)
                .OfClass(typeof(T))
                .Cast<T>()
                .ToList();
        }

        public static List<T> GetElements<T>(this Document document, BuiltInCategory category) where T : Element
        {
            return document
                .GetElements<T>()
                .Where(it => it.Category.Id.Equals(new ElementId(category)))
                .ToList();
        }
    }
}