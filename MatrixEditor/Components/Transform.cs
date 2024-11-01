using MatrixEditor.Common;
using System.Runtime.Serialization;
using System.Windows.Media.Media3D;

namespace MatrixEditor.Components
{
    [DataContract]
    class Transform : Component
    {
        private Vector3D _position;

        [DataMember]
        public Vector3D Position
        {
            get => _position;
            set
            {
                if (_position != value)
                {
                    _position = value;
                    OnPropertyChanged(nameof(Position));
                }
            }
        }

        private Vector3D _rotation;

        [DataMember]
        public Vector3D Rotation
        {
            get => _rotation;
            set
            {
                if (_rotation != value)
                {
                    _rotation = value;
                    OnPropertyChanged(nameof(Rotation));
                }
            }
        }

        private Vector3D _scale;

        [DataMember]
        public Vector3D Scale
        {
            get => _scale;
            set
            {
                if (_scale != value)
                {
                    _scale = value;
                    OnPropertyChanged(nameof(Scale));
                }
            }
        }

        public Transform(GameEntity owner) : base(owner) { }
    }
}
