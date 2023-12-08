using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;

namespace ColumnCreateFromDWG.Models
{
    public class ParameterOffset
    {
        public void ChangeOffsetColumns(Document doc, FamilyInstance column, string baseOffset, string topOffset)
        {
            Parameter offsetBase = column.get_Parameter(BuiltInParameter.FAMILY_BASE_LEVEL_OFFSET_PARAM);
            Parameter offsetTop = column.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_OFFSET_PARAM);

            if (Double.TryParse(baseOffset, out double bOffset) && Double.TryParse(topOffset, out double tOffset))
            {
                bOffset = Double.Parse(baseOffset);
                tOffset = Double.Parse(topOffset);
            }
            else
            {
                TaskDialog.Show("Error", "Error. Please enter a valid number.");
                return;
            }

            double baseOffsetMM = UnitUtils.Convert(bOffset, UnitTypeId.Millimeters, UnitTypeId.Feet);
            double topOffsetMM = UnitUtils.Convert(tOffset, UnitTypeId.Millimeters, UnitTypeId.Feet);

            offsetBase.Set(baseOffsetMM);
            offsetTop.Set(topOffsetMM);
        }
    }
}
