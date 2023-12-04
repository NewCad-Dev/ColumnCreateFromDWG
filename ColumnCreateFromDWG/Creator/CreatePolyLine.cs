using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using ColumnCreateFromDWG.Core;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ColumnCreateFromDWG.Creater
{
    public class CreatePolyLine
    {
        private readonly PointMid pointMid = new PointMid();
        public void CreateColumnsFromPolylines(Document doc, IList<PolyLine> lines, string selectedLayer, Level colLevel, FamilySymbol familySymbol)
        {
            foreach (PolyLine line in lines)
            {
                GraphicsStyle graphStyle = doc.GetElement(line.GraphicsStyleId) as GraphicsStyle;
                string layer = graphStyle.GraphicsStyleCategory.Name;

                if (layer == selectedLayer)
                {
                    Outline pOutLine = line.GetOutline();
                    XYZ firstP = pOutLine.MaximumPoint;
                    XYZ secondP = pOutLine.MinimumPoint;
                    XYZ lineMid = pointMid.MidPoint(firstP.X, secondP.X, firstP.Y, secondP.Y, firstP.Z, secondP.Z);

                    using (Transaction tr = new Transaction(doc, "Create Columns"))
                    {
                        tr.Start();
                        try
                        {
                            if (!familySymbol.IsActive)
                                familySymbol.Activate();
                            doc.Create.NewFamilyInstance(lineMid, familySymbol, colLevel, StructuralType.Column);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, ex.ToString());
                        }
                        tr.Commit();
                    }
                }
            }
        }
    }
}
