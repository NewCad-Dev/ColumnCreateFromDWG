using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using ColumnCreateFromDWG.Core;
using ColumnCreateFromDWG.Selecter;
using ColumnCreateFromDWG.View;
using ColumnCreateFromDWG.ViewModel;
using DryIoc;

namespace ColumnCreateFromDWG
{
    [Transaction(TransactionMode.Manual)]
    public class Command : BaseCommand
    {
        /*public override void RegisterCustomTypes()
        {
            Container.Register<SelecterDWG>();
            Container.Register<SelecterLayer>();
            Container.Register<SelecterLevel>();

            Container.Register<ShellViewModel>();
        }*/

        public override void Run()
        {
            var shellViewModel = Container.Resolve<ShellViewModel>();

            var shell = new Shell();
            shell.DataContext = shellViewModel;

            shell.Show();
        }
    }
}
