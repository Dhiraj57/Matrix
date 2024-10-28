using MatrixEditor.Common;
using MatrixEditor.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MatrixEditor.GameProject
{
    [DataContract]
    public class ProjectTemplate
    {
        [DataMember]
        public string ProjectType { get; set; }

        [DataMember]
        public string ProjectFile { get; set; }

        [DataMember]
        public List<string> Folders { get; set; }

        [DataMember]
        public byte[] Icon { get; set; }

        [DataMember]
        public byte[] Screenshot { get; set; }

        [DataMember]
        public string IconFilePath { get; set; }

        [DataMember]
        public string ScreenshotFilePath { get; set; }

        [DataMember]
        public string ProjectFilePath { get; set; }
    }

    internal class NewProject : ViewModelBase
    {
        // TODO: get path from the installation location
        private string _templatePath = @"..\..\MatrixEditor\ProjectTemplates";
        private string _projectName = "NewProject";

        public string ProjectName
        {
            get => _projectName;

            set
            {
                if (_projectName != value)
                {
                    _projectName = value;
                    OnPropertyChanged(nameof(ProjectName));
                }
            }
        }

        private string _projectPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\MatrixProject\";

        public string ProjectPath
        {
            get => _projectPath;
            set
            {
                if (_projectPath != value)
                {
                    _projectPath = value;
                    OnPropertyChanged(nameof(Path));
                }
            }
        }

        private ObservableCollection<ProjectTemplate> _projectTemplates = new ObservableCollection<ProjectTemplate>();
        public ReadOnlyObservableCollection<ProjectTemplate> ProjectTemplates { get; }

        public NewProject()
        {
            ProjectTemplates = new ReadOnlyObservableCollection<ProjectTemplate>(_projectTemplates);

            try
            {
                var templateFiles = Directory.GetFiles(_templatePath, "template.xml", SearchOption.AllDirectories);
                Debug.Assert(templateFiles.Any());

                foreach (var file in templateFiles)
                {
                    var template = Serializer.FromFile<ProjectTemplate>(file);
                    template.IconFilePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(file), "Icon.png"));
                    template.ScreenshotFilePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(file), "Screenshot.png")); 
                    template.ProjectFilePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(file), template.ProjectFile));

                    template.Icon = File.ReadAllBytes(template.IconFilePath);
                    template.Screenshot = File.ReadAllBytes(template.ScreenshotFilePath);

                    _projectTemplates.Add(template);
                }
            }
            catch(Exception ex) 
            {
                Debug.WriteLine(ex.Message);
                // TODO: log error
            }
        }
    }
}
