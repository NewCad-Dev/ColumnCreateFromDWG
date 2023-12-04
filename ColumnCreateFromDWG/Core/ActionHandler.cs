using Autodesk.Revit.UI;
using System;

namespace ColumnCreateFromDWG.Core
{
    public class ActionHandler
    {
        private readonly MyEventHandler _eventHandler;
        private readonly ExternalEvent _externalEvent;

        public ActionHandler(MyEventHandler eventHandler)
        {
            _eventHandler = eventHandler;
            _externalEvent = ExternalEvent.Create(eventHandler);
        }

        public void Run(Action<UIApplication> action)
        {
            _eventHandler.Action = action;
            _externalEvent.Raise();
        }
    }
}
