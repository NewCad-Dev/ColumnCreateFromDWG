using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColumnCreateFromDWG.Creator
{
    public class SelecterLayer
    {
        public IEnumerable<string> AsSelectLayer(Document doc)
        {
            IList<string> result = new List<string>();

            if (DwgForLayer.Count > 0)
            {
                foreach (ImportInstance imp in DwgForLayer)
                {
                    if (imp.Category.Name == CreateColumn_Form.dwg)
                    {
                        pLines.Clear();
                        pArc.Clear();

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
                                            pLines.Add(obj as PolyLine);
                                        }

                                        if (obj is Arc)
                                        {
                                            result.Add(layer);
                                            pArc.Add(obj as Arc);
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
