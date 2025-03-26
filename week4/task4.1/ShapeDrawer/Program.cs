using SplashKitSDK;
namespace ShapeDrawer
{
    public class Shape
    {
        // FIELDS
        private Color _color;
        private float _x;
        private float _y;
        private float _x2;
        private float _y2;
        private int _width;
        private int _height;

        // PROPERTIES
        public Color Color 
        {
            get { return _color; }
            set { _color = value; }
        }
        public float shapeX
        {
            get { return _x; }
            set 
            { 
                _x = value;
                _x2 = _x + _width; // adjust x2 so that shape coordinates are accurate
            }
        }
        public float shapeY
        {
            get { return _y; }
            set 
            { 
                _y = value;
                _y2 = _y + _height; // adjust y2 so when _y changes, _y2 is accurate
            }
        }
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public int Height 
        {
            get { return _height; }
            set { _height = value; }
        }

        // CONSTRUCTOR
        public Shape(int param)
        {
            _width = param;
            _height = param;
            _color = Color.Chocolate;
            _x = 0.0f;
            _y = 0.0f; 
            _x2 = _x + _width;
            _y2 = _y + _height;
            
        }
        // METHODS
        // prints shape fields and coordinates
        public void Draw() {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
            // Console.WriteLine("Color is " + _color);
            Console.WriteLine("Position X is " + _x);
            Console.WriteLine("Position X2 is " + _x2);
            Console.WriteLine("Position Y is " + _y);
            Console.WriteLine("Position Y2 is " + _y2);
            // Console.WriteLine("Width is " + _width);
            // Console.WriteLine("Height is " + _height);
        }

        public void ComputePerimeter() {
            int perimeter = (_width + _height)*2;
            Console.WriteLine($"Perimeter is {perimeter}");
        }

        public bool isAt(int xInput, int yInput) {
            return xInput >= _x && xInput <= _x2 && yInput >= _y && yInput <= _y2; // returns true/false if arguments are within parameters of x1,x2,y1,y2
        }
    }
    public class Program
    {
        public static void Main()
        {
            Shape myShape = new Shape(175);
            Window window = new Window("Shape Drawer", 800, 600);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                Point2D mousePosition = SplashKit.MousePosition(); // returns position of mouse in current window, as x and y in double
                Console.WriteLine("x" + mousePosition.X);
                Console.WriteLine("y" + mousePosition.Y);

                if (SplashKit.MouseClicked(MouseButton.LeftButton)) {
                    myShape.shapeX = (float)mousePosition.X;
                    myShape.shapeY = (float)mousePosition.Y;
                }
                if (SplashKit.KeyTyped(KeyCode.SpaceKey) && myShape.isAt((int)mousePosition.X, (int)mousePosition.Y)) {
                    myShape.Color = Color.Random();
                }
                myShape.Draw();

                SplashKit.RefreshScreen();

            } while (!window.CloseRequested);
        }
    }
}
