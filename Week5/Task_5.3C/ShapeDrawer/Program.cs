using System;
using Microsoft.VisualBasic;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }
        public static void Main()
        {
            ShapeKind kindToAdd = ShapeKind.Circle;
            Window window = new Window("Shape Drawer", 800, 600);
            Drawing myDrawing;

            myDrawing = new Drawing();

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape myShape;
                    switch(kindToAdd)
                    {
                        case ShapeKind.Circle:
                            myShape = new MyCircle();
                            break;

                        case ShapeKind.Line:
                            myShape = new MyLine();
                            break;

                        default:
                            myShape = new MyRectangle();
                            break;
                    }
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();

                    myDrawing.AddShape(myShape);
                }

                Point2D myPoint = new Point2D()
                {
                    X = SplashKit.MouseX()
                    , Y = SplashKit.MouseY()
                };

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
                
                if ((SplashKit.KeyTyped(KeyCode.SKey)))
                {
                    myDrawing.Save("C:/Users/PC/Desktop/COS20007/Week_5/5.3C/ShapeDrawer/TextDrawing.txt");
                }

                if ((SplashKit.KeyTyped(KeyCode.OKey)))
                {
                    try
                    {
                        myDrawing.Load("C:/Users/PC/Desktop/COS20007/Week_5/5.3C/ShapeDrawer/TextDrawing.txt");
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", ex.Message);
                    }
                }

                myDrawing.Draw();

                SplashKit.RefreshScreen();
            }
            while (!window.CloseRequested);
        }
    }
}
