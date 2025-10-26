using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _endX;
        private float _endY;

        public MyLine(Color color, float x, float y, float endX, float endY) : base(color)
        {
            X = x;
            Y = y;
            _endX = endX;
            _endY = endY;
        }

        public MyLine() : this (Color.Red, 0.0f, 0.0f, 100.0f, 0.0f)
        { 
            Color = Color.Red;
            X = 0.0f;
            Y = 0.0f;
            _endX = 100.0f;
            _endY = 0.0f;
        }

        public float EndX
        {
            get => _endX;
            set => _endX = value;
        }

        public float EndY
        {
            get => _endY;
            set => _endY = value;
        }

        public override bool IsAt(Point2D point)
        {
            if (point.X >= X && point.X <= X + EndX)
            {
                if (point.Y >= Y - 2 && point.Y <= Y + 2)
                {
                    return true;
                }
            }
            return false;
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.DrawLine(Color, X, Y, X + EndX, Y + EndY);
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, 4);
            SplashKit.FillCircle(Color.Black, X + EndX, Y + EndY, 4);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
        }
    }
}
