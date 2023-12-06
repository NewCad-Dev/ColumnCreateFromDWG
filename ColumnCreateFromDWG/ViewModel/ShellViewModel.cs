using Autodesk.Revit.DB;
using ColumnCreateFromDWG.Core;
using ColumnCreateFromDWG.Creater;
using ColumnCreateFromDWG.Selecter;
using ColumnCreateFromDWG.Wrappers;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Document = Autodesk.Revit.DB.Document;

namespace ColumnCreateFromDWG.ViewModel
{
    public class ShellViewModel : BindableBase
    {
        private Document _doc;
        private readonly ActionHandler _actionHandler;
        private readonly SelecterDWG _dwgSelector;
        private readonly SelecterLevel _levelSelector;
        private readonly SelecterColumn _columnSelector;
        private readonly SelecterLayer _layerSelector;
        private readonly ColumnCreator _columnCreator;

        private ImportInstance _selectedDwg;
        private ObservableCollection<LayerWrapper> _layers;
        private LayerWrapper _selectedLayer;


        public List<ImportInstance> DWGs { get; set; }

        public ImportInstance SelectedDwg
        {
            get => _selectedDwg;
            set
            {
                SetProperty(ref _selectedDwg, value);
                UpdateLayers();
            }
        }

        public List<Level> Levels { get; set; }

        public Level SelectedLevel { get; set; }

        public ObservableCollection<LayerWrapper> Layers
        {
            get => _layers;
            set => SetProperty(ref _layers, value);
        }

        public LayerWrapper SelectedLayer
        {
            get => _selectedLayer;
            set => SetProperty(ref _selectedLayer, value);
        }

        public List<FamilySymbol> Columns { get; set; }

        public FamilySymbol SelectedColumn { get; set; }

        public DelegateCommand CreateColumns { get; set; }

        public ShellViewModel(
            Document doc,
            ActionHandler actionHandler,
            SelecterDWG dwgSelector,
            SelecterLevel levelSelector,
            SelecterColumn columnSelector,
            SelecterLayer layerSelector,
            ColumnCreator columnCreator)
        {
            _doc = doc;
            _actionHandler = actionHandler;
            _dwgSelector = dwgSelector;
            _levelSelector = levelSelector;
            _columnSelector = columnSelector;
            _layerSelector = layerSelector;
            _columnCreator = columnCreator;

            Initialization();

            CreateColumns = new DelegateCommand(CreateColumn);
        }

        private void Initialization()
        {
            DWGs = _dwgSelector.AsSelectDWG(_doc);
            Levels = _levelSelector.AsSelectLevel(_doc);
            Columns = _columnSelector.AsSelectColumn(_doc);

            SelectedDwg = DWGs.FirstOrDefault();
            SelectedLevel = Levels.FirstOrDefault();
            SelectedColumn = Columns.FirstOrDefault();
        }

        private void UpdateLayers()
        {
            if (SelectedDwg != null)
            {
                Layers = new ObservableCollection<LayerWrapper>(
                    _layerSelector.AsSelectLayer(SelectedDwg).Select(it => new LayerWrapper(it, _doc)));
            }

            SelectedLayer = Layers.FirstOrDefault();
        }

        private void CreateColumn()
        {
            _actionHandler.Run(application =>
            {
                var document = application.ActiveUIDocument.Document;

                using (var tr = new Transaction(document, "Create Column"))
                {
                    tr.Start();

                    var curves = _layerSelector.AsSelectLayer(_selectedDwg);

                    _columnCreator.Create(curves, SelectedLayer, SelectedLevel, SelectedColumn);

                    tr.Commit();
                }
            });
        }
    }
}
