using Autodesk.Revit.DB;
using ColumnCreateFromDWG.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace ColumnCreateFromDWG.Selecter
{
    public class SelecterLayer
    {
        private List<ImportInstance> dwgForLayer = new SelecterDWG().DwgForLayer;
        public IEnumerable<string> AsSelectLayer(Document doc)
        {
            List<string> result = new List<string>();

            if (dwgForLayer.Count > 0)
            {
                foreach (ImportInstance imp in dwgForLayer)
                {
                    if (imp.Category.Name == new ShellViewModel(doc).SelectedDwg)
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
