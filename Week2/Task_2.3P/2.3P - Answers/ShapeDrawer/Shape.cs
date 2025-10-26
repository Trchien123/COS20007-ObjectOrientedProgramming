using SplashKitSDK;

namespace ShapeDrawer
{
    internal class Shape
    {
        private Color _color;
        private float _x;
        private float _y;
        private int _width;
        private int _height;
        private bool _selected;

        public Shape()
        {
            _color = Color.Green;
            _x = _y = 0.0f;
            _width = _height = 100;
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

        public int Width
        {
            get => _width;
            set => _width = value;
        }

        public int Height
        {
            get => _height;
            set => _height = value;
        }

        public void Draw()
        {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        public bool IsAt(Point2D point)
        {
            if (point.X >= _x && point.X <= _x + _width)
            {
                if (point.Y >= _y && point.Y <= _y + _height)
                {
                    return true;
                }
            }
            return false;
        }

        public void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, _x - 2, _y - 2, _width + 4, _height + 4);
        }
    } 
}
