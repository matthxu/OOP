// Please update the current implementation for week 7 so that it saves and restores the shapes from a new file named TestDrawing <studentID>,txt, instead of TestDrawing.txt

using SplashKitSDK;

namespace ShapeDrawer
{
    public static class ExtensionMethods
    {
        public static int ReadInteger(this StreamReader reader)
        {
            return Convert.ToInt32(reader.ReadLine());
        }
        public static float ReadSingle(this StreamReader reader)
        {
            return Convert.ToSingle(reader.ReadLine());
        }
        public static Color ReadColor(this StreamReader reader)
        {
            return Color.RGBColor(reader.ReadSingle(), reader.ReadSingle(),
            reader.ReadSingle());
        }
        public static void WriteColor(this StreamWriter writer, Color clr)
        {
            writer.WriteLine("{0}\n{1}\n{2}", clr.R, clr.G, clr.B);
        }
    }

    public abstract class Shape
    {
        // FIELDS
        private Color _color;
        private float _x;
        private float _y;
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
            set { _x = value; }
        }
        public float shapeY
        {
            get { return _y; }
            set { _y = value; }
        }
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        // CONSTRUCTORS
        // default constructor
        public Shape() : this(Color.Yellow)
        {
        }

        public Shape(int param)
        {
            _color = Color.Chocolate;
            _x = 0.0f;
            _y = 0.0f;
        }

        public Shape(Color color) // overloaded constructor (polymorphism)
        {
            _color = color;
            _x = 0.0f;
            _y = 0.0f;
        }

        // METHODS
        // prints shape fields and coordinates
        public abstract void Draw();

        public abstract void DrawOutline();

        public abstract bool isAt(int xInput, int yInput);

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteColor(Color);
            writer.WriteLine(shapeX);
            writer.WriteLine(shapeY);
        }

        public virtual void LoadFrom(StreamReader reader)
        {
            Color = reader.ReadColor();
            shapeX = reader.ReadInteger();
            shapeY = reader.ReadInteger();
        }


    }

    public class Drawing
    {
        // fields
        private List<Shape> _shapes { get; }
        private Color _background;

        // constructor
        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }
        // default constructor
        public Drawing() : this(Color.White)
        {
        }

        // properties
        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }
        public int ShapesCount
        {
            get { return _shapes.Count(); }
        }
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> SelectedShapes = new List<Shape>();
                foreach (Shape s in _shapes)
                {
                    if (s.Selected)
                    {
                        SelectedShapes.Add(s);
                    }
                }
                return SelectedShapes;
            }
        }

        //methods
        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }
        }
        public void SelectShapesAt()
        {
            Point2D mousePosition = SplashKit.MousePosition(); // returns position of mouse in current window, as x and y in double
            foreach (Shape s in _shapes)
            {
                if (s.isAt((int)mousePosition.X, (int)mousePosition.Y))
                {
                    s.Selected = true;
                }
                else
                {
                    s.Selected = false;
                }
            }
        }
        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }
        public bool RemoveShape(Shape shape)
        {
            return _shapes.Remove(shape);
        }

        public virtual void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            try
            {
                writer.WriteColor(Background);
                writer.WriteLine(ShapesCount);

                foreach (Shape s in _shapes)
                {
                    s.SaveTo(writer);
                }
            }
            finally
            {
                writer.Close();
            }
        }

        public void Load(string filename)
        {
            StreamReader reader = new(filename);
            try
            {
                int count;
                string kind;
                Shape s;
                Background = reader.ReadColor();
                count = reader.ReadInteger();
                _shapes.Clear();

                for (int i = 0; i < count; i++)
                {
                    kind = reader.ReadLine();
                    switch (kind)
                    {
                        case "Rectangle":
                            s = new MyRectangle();
                            break;
                        case "Circle":
                            s = new MyCircle();
                            break;
                        case "Line":
                            s = new MyLine();
                            break;
                        default:
                            throw new InvalidDataException("Unknown shape kind: " + kind);
                    }
                    s.LoadFrom(reader);
                    _shapes.Add(s);
                }
            }
            finally
            {
                reader.Close();

            }
        }

    }

    public class MyRectangle : Shape
    {
        // fields
        private int _width;
        private int _height;

        // properties
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

        // constructor
        public MyRectangle(Color color, float x, float y, int width, int height) : base(color)
        {
            _width = width;
            _height = height;
            // shapeX = x;
            // shapeY = y;
        }
        // default constructor
        public MyRectangle() : this(Color.Green, 0.0f, 0.0f, 175, 175)
        {
        }

        // methods
        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillRectangle(Color, shapeX, shapeY, _width, _height);
        }
        public override void DrawOutline()
        {
            float OutlineOffset = 10; // 5 + 5 (last student digit)
            SplashKit.FillRectangle(Color.Black, shapeX - OutlineOffset, shapeY - OutlineOffset, _width + (OutlineOffset * 2), _height + (OutlineOffset * 2));
        }
        public override bool isAt(int xInput, int yInput)
        {
            return xInput >= shapeX && xInput <= shapeX + _width && yInput >= shapeY && yInput <= shapeY + _height; // returns true/false if arguments are within parameters of x1,x2,y1,y2        
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(Width);
            writer.WriteLine(Height);
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Width = reader.ReadInteger();
            Height = reader.ReadInteger();
        }



    }

    public class MyCircle : Shape
    {
        // field
        private int _radius;

        // properties
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        // constructor
        public MyCircle(int param) : base(param)
        {
            _radius = 50;
        }
        public MyCircle(Color color, int radius) : base(color)
        {
            _radius = radius;
        }
        // default constructor
        public MyCircle() : this(Color.Blue, 125)
        {
        }

        // methods
        public override void Draw() // overrides base class (Shape)
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillCircle(Color, shapeX, shapeY, _radius);
        }
        public override void DrawOutline()
        {
            float OutlineOffset = 2;
            SplashKit.FillCircle(Color.Black, shapeX, shapeY, _radius + OutlineOffset);
        }
        // determining if pointer is within circle
        public override bool isAt(int xInput, int yInput)
        {
            // using splashkit class methods
            Circle CircleLocation = SplashKit.CircleAt(shapeX, shapeY, _radius);
            Point2D mousePt = SplashKit.MousePosition();
            return SplashKit.PointInCircle(mousePt, CircleLocation);
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

    public class MyLine : Shape
    {
        // field
        private int _lineLength = 200;
        private int _radius = 4;

        // property
        public int LineEnd
        {
            get { return _lineLength; }
            set { _lineLength = value; }
        }
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }
        // constructor
        public MyLine(Color color) : base(color)
        {
        }
        // default constructor
        public MyLine() : this(Color.Red)
        {
        }

        // methods
        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.DrawLine(Color, shapeX, shapeY, shapeX + _lineLength, shapeY);
        }
        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color, shapeX, shapeY, _radius);
            SplashKit.FillCircle(Color, shapeX + _lineLength, shapeY, _radius);
        }
        public override bool isAt(int x, int y)
        {
            // provides 5 pixel leeway in y coordinates
            return x >= shapeX && x <= shapeX + _lineLength && y > shapeY - 5 && y < shapeY + 5;
        }
        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(LineEnd);
            writer.WriteLine(Radius);
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            LineEnd = reader.ReadInteger();
            Radius = reader.ReadInteger();
        }
    }

    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
            // Triangle
        }

        public static void Main()
        {
            ShapeKind kindToAdd = ShapeKind.Rectangle;
            Drawing myDrawing = new Drawing();
            Window window = new Window("Shape Drawer", 800, 600);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                Point2D mousePosition = SplashKit.MousePosition(); // returns position of mouse in current window, as x and y in double

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;
                    switch (kindToAdd)
                    {
                        case ShapeKind.Circle:
                            newShape = new MyCircle(145);
                            break;
                        case ShapeKind.Rectangle:
                            newShape = new MyRectangle();
                            break;
                        default:
                            newShape = new MyLine();
                            break;
                    }
                    if (kindToAdd != ShapeKind.Line)
                    {
                        newShape.shapeX = (float)mousePosition.X;
                        newShape.shapeY = (float)mousePosition.Y;
                        myDrawing.AddShape(newShape);

                    }
                    else
                    {
                        // drawing parallel lines
                        int offset = 0;
                        for (int i = 0; i <= 4; i++)
                        {
                            newShape = new MyLine();
                            newShape.shapeX = (float)mousePosition.X;
                            newShape.shapeY = (float)mousePosition.Y + offset;
                            myDrawing.AddShape(newShape);
                            offset += 15;
                        }
                    }

                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = Color.Random();
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapesAt();
                }

                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    myDrawing.SelectShapesAt();
                    if (myDrawing.SelectedShapes.Count() > 0)
                    { // prevents access to empty lists
                        myDrawing.RemoveShape(myDrawing.SelectedShapes[0]);
                    }
                }

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

                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    myDrawing.Save("C:/Users/Matthew/Desktop/testDrawing105645875.txt");
                }

                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        myDrawing.Load("C:/Users/Matthew/Desktop/testDrawing105645875.txt");
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", e.Message);
                    }
                }


                if (SplashKit.KeyTyped(KeyCode.EscapeKey))
                {
                    SplashKit.ClearScreen();
                }
                // myShape.Draw();
                myDrawing.Draw();

                SplashKit.RefreshScreen();

            } while (!window.CloseRequested);
        }
    }
}
