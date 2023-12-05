using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;

namespace ColumnCreateFromDWG.Selecter
{
    public class SelecterLayer
    {
        public List<GeometryObject> AsSelectLayer(ImportInstance importInstance)
        {
            var result = new List<GeometryObject>();

            GeometryElement geoElem = importInstance.get_Geometry(new Options());

            foreach (GeometryObject geoObj in geoElem)
            {
                if (geoObj is GeometryInstance)
                {
                    GeometryInstance geoInst = (GeometryInstance)geoObj;
                    GeometryElement geoElement = geoInst.GetInstanceGeometry();

                    if (geoElement != null)
                    {
                        foreach (GeometryObject obj in geoElement)
                        {
                            result.Add(obj);
                        }
                    }
                }
            }


            var res = result.Where(s => FilterLayer(importInstance.Document, s)).ToList();

            return res;
        }

        private bool FilterLayer(Document document, GeometryObject geometryObject)
        {
            var gStyle = document.GetElement(geometryObject.GraphicsStyleId) as GraphicsStyle;
            return gStyle.GraphicsStyleCategory.Name.Contains("C_");
        }
    }
}
