using SplashKitSDK;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        private Color _color;
        private float _x;
        private float _y;
        private bool _selected;

        public Shape(Color color)
        {
            _color = color;
            _x = _y = 0.0f;
        }

        public Shape() : this (Color.Yellow)
        {
            _color = Color.Yellow;
            _x = _y = 0.0f;
        }

        public bool Selected
        {
            get => _selected;
            set => _selected = value;
        }

        public Color Color
        {
            get => _color;
            set => _color = value;
        }

        public float X
        {
            get => _x;
            set => _x = value;
        }

        public float Y
        {
            get => _y;
            set => _y = value;
        }

        public abstract void Draw();

        public abstract bool IsAt(Point2D point);

        public abstract void DrawOutline();

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteColor(Color);
            writer.WriteLine(X);
            writer.WriteLine(Y);
        }

        public virtual void LoadFrom(StreamReader reader)
        {
            Color = reader.ReadColor();
            X = reader.ReadInteger();
            Y = reader.ReadInteger();
        }
    } 
}
