using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _radius;
        public int Radius
        {
            get => _radius;
            set => _radius = value;
        }

        public MyCircle(Color color, int radius) : base(color)
        {
            _radius = radius;
        }

        public MyCircle() : this (Color.Blue, 50)
        {
            _radius = 50;
            Color = Color.Blue;
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, _radius + 2);
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }

            SplashKit.FillCircle(Color, X, Y, _radius);
        }

        public override bool IsAt(Point2D point)
        {
            if (point.X > X - _radius && point.X < X + _radius)
            {
                if (point.Y > Y - _radius && point.Y < Y + _radius)
                {
                    return true;
                }
            }
            return false;
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(Radius);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Radius = reader.ReadInteger();
        }
    }
}
