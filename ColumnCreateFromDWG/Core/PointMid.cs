using Autodesk.Revit.DB;

namespace ColumnCreateFromDWG.Core
{
    public class PointMid
    {
        public XYZ MidPoint(double x1, double x2, double y1, double y2, double z1, double z2)
        {
            XYZ midPoint = new XYZ((x1 + x2) / 2, (y1 + y2) / 2, (z1 + z2) / 2);
            return midPoint;
        }
    }
}
