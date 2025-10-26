using SplashKitSDK;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace ShapeDrawer
{
    internal class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Color Background
        {
            get => _background;
            set => _background = value;
        }

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        public Drawing() : this (Color.White)
        {
            _shapes = new List<Shape>();
            _background  = Color.White;
        }

        public int ShapeCount
        {
            get => _shapes.Count;
        }

        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        public void RemoveShape(Shape shape)
        {
            _= _shapes?.Remove(shape);
        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            for (int i = 0; i < _shapes.Count; i++)
            {
                if (_shapes[i].Selected)
                {
                    _shapes[i].DrawOutline();
                }
                _shapes[i].Draw();
            }
        }

        public void SelectShapesAt(Point2D point)
        {
            foreach (Shape s in _shapes)
            {
                s.Selected = s.IsAt(point);
            }
        }

        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach (Shape s in _shapes)
                {
                    if (s.Selected)
                    {
                        result.Add(s);
                    }
                }
                return result;
            }
        }
    }
}
