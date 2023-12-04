using Autodesk.Revit.UI;
using System;
using System.Windows;

namespace ColumnCreateFromDWG.Core
{
    public class MyEventHandler : IExternalEventHandler
    {
        public Action<UIApplication> Action { get; set; }

        public void Execute(UIApplication app)
        {
            try
            {
                Action.Invoke(app);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public string GetName() => "Parametric External Event";
    }
}
