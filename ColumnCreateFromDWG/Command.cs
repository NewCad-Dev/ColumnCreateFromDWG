using Autodesk.Revit.Attributes;
using ColumnCreateFromDWG.Core;
using ColumnCreateFromDWG.Creater;
using ColumnCreateFromDWG.Selecter;
using ColumnCreateFromDWG.View;
using ColumnCreateFromDWG.ViewModel;
using DryIoc;
using Prism.Commands;

namespace ColumnCreateFromDWG
{
    [Transaction(TransactionMode.Manual)]
    public class Command : BaseCommand
    {
        public override void RegisterCustomTypes()
        {
            Container.Register<SelecterDWG>();
            Container.Register<SelecterLayer>();
            Container.Register<SelecterLevel>();
            Container.Register<SelecterColumn>();

            Container.Register<ColumnCreator>();

            Container.Register<ShellViewModel>();
        }

        public override void Run()
        {
            var shellViewModel = Container.Resolve<ShellViewModel>();

            var shell = new Shell();
            shell.DataContext = shellViewModel;

            shell.Show();
        }
    }
}
