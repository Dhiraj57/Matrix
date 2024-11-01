using MatrixEditor.Components;
using MatrixEditor.GameProject;
using MatrixEditor.Utilities;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MatrixEditor.Editors

{
    /// <summary>
    /// Interaction logic for GameEntityView.xaml
    /// </summary>
    public partial class GameEntityView : UserControl
    {
        private Action _undoAction;
        private string _propertyName;

        public static GameEntityView Instance { get; private set; }

        public GameEntityView()
        {
            InitializeComponent();
            DataContext = null;
            Instance = this;

            DataContextChanged += (_, __) =>
            {
                if (DataContext != null)
                {
                    (DataContext as MSEntity).PropertyChanged += (s, e) => _propertyName = e.PropertyName;
                }
            };
        }

        private Action GetRenameAction()
        {
            var mSEntity = DataContext as MSEntity;
            var selection = mSEntity.SelectedEntities.Select(entity => (entity, entity.Name)).ToList();

            return new Action(() =>
            {
                selection.ForEach(item => item.entity.Name = item.Name);
                (DataContext as MSEntity).Refresh();
            });
        }

        private Action GetIsEnabledAction()
        {
            var mSEntity = DataContext as MSEntity;
            var selection = mSEntity.SelectedEntities.Select(entity => (entity, entity.IsEnabled)).ToList();

            return new Action(() =>
            {
                selection.ForEach(item => item.entity.IsEnabled = item.IsEnabled);
                (DataContext as MSEntity).Refresh();
            });
        }

        private void OnNameTextBoxGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            _undoAction = GetRenameAction();
        }

        private void OnNameTextBoxLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (_propertyName == nameof(MSEntity.Name) && _undoAction != null)
            {
                var redoAction = GetRenameAction();
                Project.UndoRedo.Add(new UndoRedoAction(_undoAction, redoAction, "Rename game entity"));
                _propertyName = null;
            }
            _undoAction = null;
        }

        private void OnIsEnabledCheckBoxClick(object sender, RoutedEventArgs e)
        {
            var undoAction = GetIsEnabledAction();
            var mSEntity = DataContext as MSEntity;
            mSEntity.IsEnabled = (sender as CheckBox).IsChecked == true;
            var redoAction = GetIsEnabledAction();

            Project.UndoRedo.Add(new UndoRedoAction(undoAction, redoAction,
                mSEntity.IsEnabled == true ? "Enable game entity" : "Disable game entity"));
        }
    }
}
