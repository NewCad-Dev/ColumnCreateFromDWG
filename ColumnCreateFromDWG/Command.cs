using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ColumnCreateFromDWG.View;
using ColumnCreateFromDWG.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColumnCreateFromDWG
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;

            var shell = new Shell();
            var viewModel = new ShellViewModel(doc);

            shell.DataContext = viewModel;

            shell.Show();

            return Result.Succeeded;
        }
    }
}
