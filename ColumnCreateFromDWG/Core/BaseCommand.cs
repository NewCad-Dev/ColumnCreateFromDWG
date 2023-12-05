using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DryIoc;
using System;
using System.Windows;

namespace ColumnCreateFromDWG.Core
{
    public abstract class BaseCommand : IExternalCommand
    {
        public Container Container;

        public Document Document { get; set; }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document = commandData.Application.ActiveUIDocument.Document;

            Container = new Container();

            Container.RegisterInstance(commandData.Application);
            Container.RegisterInstance(commandData.Application.ActiveUIDocument);
            Container.RegisterInstance(commandData.Application.ActiveUIDocument.Document);

            Container.Register<ActionHandler>();
            Container.Register<MyEventHandler>();

            RegisterCustomTypes();

            try
            {
                Run();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

                return Result.Failed;
            }

            return Result.Succeeded;
        }

        public abstract void RegisterCustomTypes();

        public abstract void Run();
    }
}
