using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using ColumnCreateFromDWG.Core;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ColumnCreateFromDWG.Creater
{
    public class ColumnCreator
    {
        private readonly PointMid pointMid = new PointMid();
        public void Create(
            IList<GeometryObject> curves,
            GeometryObject selectedLayer,
            Level colLevel,
            FamilySymbol familySymbol)
        {
            var doc = familySymbol.Document;

            if (!familySymbol.IsActive)
                familySymbol.Activate();

            foreach (var curve in curves)
            {
                GraphicsStyle graphStyle = doc.GetElement(curve.GraphicsStyleId) as GraphicsStyle;
                string layer = graphStyle.GraphicsStyleCategory.Name;

                //TODO: FIX IT!

                //if (layer == selectedLayer)
                //{
                //    if (curve is PolyLine polyLine)
                //    {
                //        Outline pOutLine = polyLine.GetOutline();
                //        XYZ firstP = pOutLine.MaximumPoint;
                //        XYZ secondP = pOutLine.MinimumPoint;
                //        XYZ lineMid = pointMid.MidPoint(firstP.X, secondP.X, firstP.Y, secondP.Y, firstP.Z, secondP.Z);

                //        doc.Create.NewFamilyInstance(lineMid, familySymbol, colLevel, StructuralType.Column);
                //    }

                //    else if (curve is Arc arc)
                //    {
                //        doc.Create.NewFamilyInstance(arc.Center, familySymbol, colLevel, StructuralType.Column);
                //    }
                //}
            }
        }
    }
}
