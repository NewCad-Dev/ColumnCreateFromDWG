using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;

namespace ColumnCreateFromDWG.Models
{
    public class ParameterOffset
    {
        public void ChangeOffsetColumns(FamilyInstance column, double baseOffset, double topOffset)
        {
            Parameter offsetBase = column.get_Parameter(BuiltInParameter.FAMILY_BASE_LEVEL_OFFSET_PARAM);
            Parameter offsetTop = column.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_OFFSET_PARAM);

            double baseOffsetMM = UnitUtils.Convert(baseOffset, UnitTypeId.Millimeters, UnitTypeId.Feet);
            double topOffsetMM = UnitUtils.Convert(topOffset, UnitTypeId.Millimeters, UnitTypeId.Feet);

            offsetBase.Set(baseOffsetMM);
            offsetTop.Set(topOffsetMM);
        }
    }
}
