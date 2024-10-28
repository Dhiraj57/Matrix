using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MatrixEditor.GameProject
{
    /// <summary>
    /// Interaction logic for NewProjectView.xaml
    /// </summary>
    public partial class NewProjectView : UserControl
    {
        public NewProjectView()
        {
            InitializeComponent();
        }

        private void OnCreateButtonClick(object sender, RoutedEventArgs e)
        {
            var template = DataContext as NewProject;
            var projectPath = template.CreateProject(templateListBox.SelectedItem as ProjectTemplate);

            bool dialogResult = false;
            var win = Window.GetWindow(this);

            if(!string.IsNullOrEmpty(projectPath))
            {
                dialogResult = true;
                var project = OpenProject.Open(new ProjectData() {  ProjectName = template.ProjectName, ProjectPath = projectPath });
                win.DataContext = project;
            }

            win.DialogResult = dialogResult;
            win.Close();
        }
    }
}
