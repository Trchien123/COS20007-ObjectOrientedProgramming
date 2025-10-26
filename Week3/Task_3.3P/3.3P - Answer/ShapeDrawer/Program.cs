using System;
using Microsoft.VisualBasic;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            Drawing myDrawing;

            myDrawing = new Drawing();

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                Point2D myPoint = new Point2D()
                {
                    X = SplashKit.MouseX(),
                    Y = SplashKit.MouseY()
                };

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape myShape = new Shape();
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();

                    myDrawing.AddShape(myShape);
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomColor();
                }
                
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapesAt(myPoint);
                }

                if ((SplashKit.KeyTyped(KeyCode.DeleteKey)) | (SplashKit.KeyTyped(KeyCode.BackspaceKey)))
                {
                    foreach (Shape shape in myDrawing.SelectedShapes)
                    {
                        myDrawing.RemoveShape(shape);
                    }
                }

                myDrawing.Draw();

                SplashKit.RefreshScreen();
            }
            while (!window.CloseRequested);
        }
    }
}
