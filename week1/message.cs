namespace HelloWorld
{
    public class Message
    {
        string _text;

        public Message(string txt)
        {
            _text = txt;
        }
        public void Print()
        {
            Console.WriteLine(_text);
        }
        public void setMessage(string txt)
        {
            _text = txt;
        }
        public string getMessage()
        {
            return _text;
        }
    }
}