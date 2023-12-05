using Autodesk.Revit.DB;
using ColumnCreateFromDWG.Creater;
using ColumnCreateFromDWG.Selecter;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;

namespace ColumnCreateFromDWG.ViewModel
{
    public class ShellViewModel : BindableBase
    {
        private Document _doc;
        public List<string> DWGs { get; set; }
        public string SelectedDwg { get; set; }
        public List<string> Levels { get; set; }
        public string SelectedLevel {  get; set; }
        public IEnumerable<string> Layers { get; set; }
        public string SelectedLayer {  get; set; }
        public List<string> Columns { get; set; }
        public string SelectedColumn { get; set; }

        public DelegateCommand CreateColumns { get; set; }

        public ShellViewModel(Document doc)
        {
            DWGs = new SelecterDWG().AsSelectDWG(doc);
            Levels = new SelecterLevel().AsSelectLevel(doc);
            Columns = new SelecterColumn().AsSelectColumn(doc);

            SelectedDwg = DWGs.FirstOrDefault(); //- вибор першого елемента
            SelectedLevel = Levels.FirstOrDefault();
            SelectedColumn = Columns.FirstOrDefault();

            if(SelectedDwg != null)
            {
                Layers = new SelecterLayer().AsSelectLayer(doc, SelectedDwg);
            }

            SelectedLayer = Layers.FirstOrDefault();

            CreateColumns = new DelegateCommand(CreateColumn);
        }

        private void CreateColumn()
        {
            var createColumnPolyLine = new CreatePolyLine();
            var createColumnArc = new CreateArc();

            createColumnArc.CreateColumnsFromArcs(_doc, );
            createColumnPolyLine.CreateColumnsFromPolylines();
        }
    }
}
