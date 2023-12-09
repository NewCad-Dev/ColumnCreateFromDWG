using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using ColumnCreateFromDWG.Core;
using ColumnCreateFromDWG.Models;
using ColumnCreateFromDWG.Wrappers;
using System.Collections.Generic;

namespace ColumnCreateFromDWG.Creater
{
    public class ColumnCreator
    {
        private readonly PointMid pointMid = new PointMid();
        public void Create(
            IList<GeometryObject> curves,
            LayerWrapper selectedLayer,
            Level colLevel,
            FamilySymbol familySymbol,
            double baseOffset,
            double topOffset)
        {
            var doc = familySymbol.Document;

            if (!familySymbol.IsActive)
                familySymbol.Activate();

            foreach (var curve in curves)
            {
                GraphicsStyle graphStyle = doc.GetElement(curve.GraphicsStyleId) as GraphicsStyle;
                string layer = graphStyle.GraphicsStyleCategory.Name;

                //TODO: FIX IT!

                if (layer == selectedLayer.ToString())
                {
                    if (curve is PolyLine polyLine)
                    {
                        Outline pOutLine = polyLine.GetOutline();
                        XYZ firstP = pOutLine.MaximumPoint;
                        XYZ secondP = pOutLine.MinimumPoint;
                        XYZ lineMid = pointMid.MidPoint(firstP.X, secondP.X, firstP.Y, secondP.Y, firstP.Z, secondP.Z);

                        FamilyInstance column = doc.Create.NewFamilyInstance(lineMid, familySymbol, colLevel, StructuralType.Column);

                        ParameterOffset offset = new ParameterOffset();

                        offset.ChangeOffsetColumns(column, baseOffset, topOffset);
                    }

                    else if (curve is Arc arc)
                    {
                        doc.Create.NewFamilyInstance(arc.Center, familySymbol, colLevel, StructuralType.Column);
                    }
                }
            }
        }
    }
}
