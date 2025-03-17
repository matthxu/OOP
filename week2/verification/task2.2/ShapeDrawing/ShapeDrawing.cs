// [OOP] Task 2.2 | Matthew Xu

public class Shape
{
    // FIELDS
    private string _color;
    private float _x;
    private float _y;
    private float _x2;
    private float _y2;
    private int _width;
    private int _height;

    // PROPERTIES
    public string Color 
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
        _color = "Color.Chocolate";
        _x = 0.0f;
        _y = 0.0f;
        _x2 = _x += _width;
        _y2 = _y += _height;
        
    }
    // METHODS
    // prints shape fields and coordinates
    public void Draw() {
        Console.WriteLine("Color is " + _color);
        Console.WriteLine("Position X is " + _x);
        Console.WriteLine("Position Y is " + _y);
        Console.WriteLine("Width is " + _width);
        Console.WriteLine("Height is " + _height);
    }

    public void ComputePerimeter() {
        int perimeter = (_width + _height)*2;
        Console.WriteLine($"Perimeter is {perimeter}");
    }

    public bool isAt(int xInput, int yInput) {
        return xInput >= _x && xInput <= _x2 && yInput <= _y && yInput >= _y2; // returns true/false if arguments are within parameters of x1,x2,y1,y2
    }
}