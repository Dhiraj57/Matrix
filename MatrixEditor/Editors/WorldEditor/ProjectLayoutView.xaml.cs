using MatrixEditor.Components;
using MatrixEditor.Editors;
using MatrixEditor.GameProject;
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
            var entity = (sender as ListBox).SelectedItems[0];
            GameEntityView.Instance.DataContext = entity;
        }
    }
}
