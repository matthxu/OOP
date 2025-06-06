﻿using System;
namespace ClockApp
{
    public class Counter
    {
        private int _count;
        public int Ticks
        {
            get { return _count; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Counter(string name)
        {
            _name = name;
            _count = 0;
        }

        public void Increment()
        {
            _count++;
        }

        public void Reset()
        {
            _count = 0;
        }
    }
}
