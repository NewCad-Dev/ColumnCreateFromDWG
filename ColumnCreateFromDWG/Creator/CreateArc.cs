using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ColumnCreateFromDWG.Creater
{
    public class CreateArc
    {
        public void CreateColumnsFromArcs(Document doc, IList<Arc> pArc, string selectedLayer, Level colLevel, FamilySymbol fs)
        {
            foreach (Arc arc in pArc)
            {
                GraphicsStyle gStyle = doc.GetElement(arc.GraphicsStyleId) as GraphicsStyle;
                string layer = gStyle.GraphicsStyleCategory.Name;

                if (layer == selectedLayer)
                {
                    using (Transaction tr = new Transaction(doc, "Create Columns"))
                    {
                        tr.Start();
                        try
                        {
                            if (!fs.IsActive)
                                fs.Activate();

                            doc.Create.NewFamilyInstance(arc.Center, fs, colLevel, StructuralType.Column);
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
