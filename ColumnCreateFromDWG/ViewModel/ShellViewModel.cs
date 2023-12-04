using Autodesk.Revit.DB;
using ColumnCreateFromDWG.Selecter;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;

namespace ColumnCreateFromDWG.ViewModel
{
    public class ShellViewModel : BindableBase
    {
        public List<string> DWGs { get; set; }
        public string SelectedDwg { get; set; }
        public List<string> Levels { get; set; }
        public string SelectedLevel {  get; set; }
        public IEnumerable<string> Layers { get; set; }
        public string SelectedLayer {  get; set; }
        public ShellViewModel(Document doc)
        {
            DWGs = new SelecterDWG().AsSelectDWG(doc);
            Levels = new SelecterLevel().AsSelectLevel(doc);
            Layers = new SelecterLayer().AsSelectLayer(doc);

            SelectedDwg = DWGs.FirstOrDefault(); //- вибор першого єлемента
            SelectedLevel = Levels.FirstOrDefault();
            //SelectedLayer = Layers.FirstOrDefault();
        }
    }
}
