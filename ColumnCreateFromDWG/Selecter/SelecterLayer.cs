using Autodesk.Revit.DB;
using ColumnCreateFromDWG.FindElements;
using ColumnCreateFromDWG.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace ColumnCreateFromDWG.Selecter
{
    public class SelecterLayer
    {
        public IEnumerable<string> AsSelectLayer(Document doc, string selectedDWG)
        {
            List<string> result = new List<string>();
            List<ImportInstance> dwg = new FindDWG().FindDWGs(doc);

            if (dwg.Count > 0)
            {
                foreach (ImportInstance imp in dwg)
                {
                    if (imp.Category.Name == selectedDWG)
                    {
                        GeometryElement geoElem = imp.get_Geometry(new Options());

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
                                        GraphicsStyle gStyle = doc.GetElement(obj.GraphicsStyleId) as GraphicsStyle;
                                        string layer = gStyle.GraphicsStyleCategory.Name;

                                        if (obj is PolyLine)
                                        {
                                            result.Add(layer);

                                        }

                                        if (obj is Arc)
                                        {
                                            result.Add(layer);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            IEnumerable<string> res = result.Where(s => s.Contains("C_"));

            return res;
        }
    }
}
