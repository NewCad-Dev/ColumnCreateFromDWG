using Autodesk.Revit.DB;
using System;

namespace ColumnCreateFromDWG.Wrappers
{
    public class LayerWrapper
    {
        private readonly Document _document;

        public GeometryObject GeometryObject { get; }

        public LayerWrapper(GeometryObject geometryObject, Document document)
        {
            _document = document;
            GeometryObject = geometryObject;
        }

        public override string ToString()
        {
            return (_document.GetElement(GeometryObject.GraphicsStyleId) as GraphicsStyle)?
                .GraphicsStyleCategory
                .Name ?? "-- Unknown --";
        }
    }
}