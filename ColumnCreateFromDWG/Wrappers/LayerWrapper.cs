using Autodesk.Revit.DB;
using System;

namespace ColumnCreateFromDWG.Wrappers
{
    public class LayerWrapper : IEquatable<LayerWrapper>
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

        public bool Equals(LayerWrapper other) => other != null && this.ToString() == other.ToString();

        public override bool Equals(object obj) => Equals(obj as LayerWrapper);

        public override int GetHashCode() => GeometryObject.GetHashCode();
    }
}