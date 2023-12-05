using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace ColumnCreateFromDWG.Abstraction
{
    public interface ISelector
    {
        List<string> Select(Document document);
    }
}