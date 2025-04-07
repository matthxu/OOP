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
        private bool _selected;

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
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
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
            if (_selected == true) {
                DrawOutline();
            }
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
            // Console.WriteLine("Color is " + _color);
            // Console.WriteLine("Position X is " + _x);
            // Console.WriteLine("Position X2 is " + _x2);
            // Console.WriteLine("Position Y is " + _y);
            // Console.WriteLine("Position Y2 is " + _y2);
            // Console.WriteLine("Width is " + _width);
            // Console.WriteLine("Height is " + _height);
        }

        public void DrawOutline() {
            float OutlineOffset = 10; // 5 + 5 (last student digit)
            SplashKit.FillRectangle(Color.Black, _x - OutlineOffset, _y - OutlineOffset, _width + (OutlineOffset * 2), _height + (OutlineOffset * 2));
        }

        public void ComputePerimeter() {
            int perimeter = (_width + _height)*2;
            Console.WriteLine($"Perimeter is {perimeter}");
        }

        public bool isAt(int xInput, int yInput) {
            return xInput >= _x && xInput <= _x2 && yInput >= _y && yInput <= _y2; // returns true/false if arguments are within parameters of x1,x2,y1,y2
        }

        public void isAt_Newpt() {
                Point2D mousePosition = SplashKit.MousePosition(); // returns position of mouse in current window, as x and y in double
                double pointX = mousePosition.X + 10;
                double pointY = mousePosition.Y + 20;
            if (pointX >= _x && pointX <= _x2 && pointY >= _y && pointY <= _y2) {
                Console.WriteLine("Inside box");
            } else {
                Console.WriteLine("Outside box");
            }
            }
        }
    
    public class Drawing
    {
        // fields
        private List<Shape> _shapes { get; }
        private Color _background;

        // constructor
        public Drawing (Color background) {
            _shapes = new List<Shape>();
            _background = background;
        }
        // default constructor
        public Drawing() :this( Color.White ) {
        }

        // properties
        public Color Background {
            get { return _background; }
            set { _background = value; }
        }
        public int ShapesCount {
            get { return _shapes.Count(); }
        }
        public List<Shape> SelectedShapes {
            get 
            {
                List<Shape> SelectedShapes = new List<Shape>();
                foreach (Shape s in _shapes) {
                    if (s.Selected) {
                        SelectedShapes.Add(s);
                    }
                }
                return SelectedShapes;
            }   
        }
        //methods

        public void Draw() {
            SplashKit.ClearScreen(_background);
            foreach(Shape shape in _shapes) {
                shape.Draw();
            }
        }
        public void SelectShapesAt() {
            Point2D mousePosition = SplashKit.MousePosition(); // returns position of mouse in current window, as x and y in double
            foreach (Shape s in _shapes) {
                if (s.isAt((int)mousePosition.X, (int)mousePosition.Y)) {
                    s.Selected = true;
                } else {
                    s.Selected = false;
                }
            }
        }
        public void AddShape(Shape shape) {
            _shapes.Add(shape);
        }
        public bool RemoveShape(Shape shape) {
            return _shapes.Remove(shape);
        }
    }



    public class Program
    {
        public static void Main()
        {
            Drawing myDrawing = new Drawing();
            Window window = new Window("Shape Drawer", 800, 600);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                Point2D mousePosition = SplashKit.MousePosition(); // returns position of mouse in current window, as x and y in double

                if (SplashKit.MouseClicked(MouseButton.LeftButton)) {
                    Shape shape = new Shape(175);
                    shape.shapeX = (float)mousePosition.X;
                    shape.shapeY = (float)mousePosition.Y;
                    myDrawing.AddShape(shape);
                    // myShape.shapeX = (float)mousePosition.X;
                    // myShape.shapeY = (float)mousePosition.Y;
                    // myShape.isAt_Newpt();
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey)) {
                    myDrawing.Background = Color.Random();
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton)) {
                    myDrawing.SelectShapesAt();
                }

                // if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey)) {
                //     myDrawing.SelectShapesAt();
                //     if (myDrawing.SelectedShapes.Count() > 0) { // prevents access to empty lists
                //     myDrawing.RemoveShape(myDrawing.SelectedShapes[0]);
                //     }
                // }
                if (myDrawing.ShapesCount > 3 && (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))) {
                    myDrawing.SelectShapesAt();
                    if (myDrawing.SelectedShapes.Count() > 0) { // prevents access to empty lists
                    myDrawing.RemoveShape(myDrawing.SelectedShapes[0]);
                    }
                }
                // myShape.Draw();
                myDrawing.Draw();

                SplashKit.RefreshScreen();

            } while (!window.CloseRequested);
        }
    }
}
