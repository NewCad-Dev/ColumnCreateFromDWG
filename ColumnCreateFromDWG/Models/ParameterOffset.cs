using Autodesk.Revit.DB;
using Prism.Mvvm;

namespace ColumnCreateFromDWG.Models
{
    public class ParameterOffset : BindableBase
    {
        private double _baseOffset;
        private double _topOffset;

        public double BaseOffset
        {
            get => _baseOffset;
            set => SetProperty(ref _baseOffset, value);
        }
        public double TopOffset
        {
            get => _topOffset;
            set => SetProperty(ref _topOffset, value);
        }

        public void ChangeOffsetColumns(Document doc, FamilyInstance column)
        {
            Parameter baseOffset = column.get_Parameter(BuiltInParameter.FAMILY_BASE_LEVEL_OFFSET_PARAM);
            double topOffset = column.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_OFFSET_PARAM).AsDouble();

            double baseOffsetMM = UnitUtils.Convert(BaseOffset, UnitTypeId.Feet, UnitTypeId.Millimeters);

            baseOffset.Set(baseOffsetMM);
        }
    }
}
