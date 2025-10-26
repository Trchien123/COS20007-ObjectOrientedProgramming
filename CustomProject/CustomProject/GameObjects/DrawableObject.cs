using SplashKitSDK;

namespace CustomProject.GameObjects
{
    public abstract class DrawableObject : GameObject
    {
        protected double _xLocation;
        protected double _yLocation;
        protected Bitmap _image;

        public DrawableObject(double xLocation, double yLocation, string[] ids, string name, string description, string imagePath)
            : base(ids, name, description)
        {
            _xLocation = xLocation;
            _yLocation = yLocation;
            _image = SplashKit.LoadBitmap(ids[0], imagePath);
        }

        public virtual void Draw()
        {
            SplashKit.DrawBitmap(_image, _xLocation, _yLocation);
        }

        public double X { get => _xLocation; set => _xLocation = value; }
        public double Y { get => _yLocation; set => _yLocation = value; }
        public Bitmap Image => _image;
    }
}
