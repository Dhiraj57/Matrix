using MatrixEditor.Components;
using MatrixEditor.Editors;
using MatrixEditor.GameProject;
using MatrixEditor.Utilities;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MatrixEditor.Editors
{
    /// <summary>
    /// Interaction logic for ProjectLayoutView.xaml
    /// </summary>
    public partial class ProjectLayoutView : UserControl
    {
        public ProjectLayoutView()
        {
            InitializeComponent();
        }

        private void OnAddGameEntityButtonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var scene = button.DataContext as Scene;
            scene.AddGameEntityCommand.Execute(new GameEntity(scene) { Name = "Empty Game Entity"});
        }

        private void OnGameEntitiesListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;

            var newSelection = listBox.SelectedItems.Cast<GameEntity>().ToList();
            var previousSelection = newSelection.Except(e.AddedItems.Cast<GameEntity>()).Concat(e.RemovedItems.Cast<GameEntity>()).ToList();

            Project.UndoRedo.Add(new UndoRedoAction(
                () =>
                {
                    listBox.UnselectAll();
                    previousSelection.ForEach(x => (listBox.ItemContainerGenerator.ContainerFromItem(x) as ListBoxItem).IsSelected = true);
                },
                () =>
                {
                    listBox.UnselectAll();
                    newSelection.ForEach(x => (listBox.ItemContainerGenerator.ContainerFromItem(x) as ListBoxItem).IsSelected = true);
                },
                "Selection changed"
                ));

            MSGameEntity mSGameEntity = null;
            if(newSelection.Any())
            {
                mSGameEntity = new MSGameEntity(newSelection);
            }

            GameEntityView.Instance.DataContext = mSGameEntity;
        }
    }
}
