using System;

namespace OpenConsoleFramework
{
#pragma warning disable CS0660 // Тип определяет оператор == или оператор !=, но не переопределяет Object.Equals(object o)
#pragma warning disable CS0661 // Тип определяет оператор == или оператор !=, но не переопределяет Object.GetHashCode()
    public struct Point
#pragma warning restore CS0661 // Тип определяет оператор == или оператор !=, но не переопределяет Object.GetHashCode()
#pragma warning restore CS0660 // Тип определяет оператор == или оператор !=, но не переопределяет Object.Equals(object o)
    {
        public int X;
        public int Y;
        public Point(int _X, int _Y)
        {
            X = _X;
            Y = _Y;
        }
        public static Point operator +(Point _First, Point _Second)
        {
            return new Point(_First.X + _Second.X,_First.Y + _Second.Y);
        }
        public static Point operator -(Point _First, Point _Second)
        {
            return new Point(_First.X - _Second.X, _First.Y - _Second.Y);
        }
        public static Point operator /(Point _First, int _Second)
        {
            return new Point(_First.X / _Second, _First.Y / _Second);
        }
        public static bool operator ==(Point _First, Point _Second)
        {
            if (_First.X != _Second.X) return false;
            if (_First.Y != _Second.Y) return false;
            return true;
        }
        public static bool operator !=(Point _First, Point _Second)
        {
            if (_First.X != _Second.X) return true;
            if (_First.Y != _Second.Y) return true;
            return false;
        }
        public bool InRange(Point _Start, Point _End)
        {
            if (X < _Start.X)
                return false;
            if (X > _End.X)
                return false;
            if (Y < _Start.Y)
                return false;
            if (Y > _End.Y)
                return false;
            return true;
        }
        public override string ToString()
        {
            return $"({X},{Y})";
        }
        public static Point Zero = new Point(0, 0);
    }
#pragma warning disable CS0660 // Тип определяет оператор == или оператор !=, но не переопределяет Object.Equals(object o)
#pragma warning disable CS0661 // Тип определяет оператор == или оператор !=, но не переопределяет Object.GetHashCode()
    public struct Glyph
    {
        public char Symbol;
        public ConsoleColor ForegroundColor;
        public ConsoleColor BackgroundColor;
        public Glyph(char _Symbol, ConsoleColor _ForegroundColor, ConsoleColor _BackgroundColor)
        {
            Symbol = _Symbol;
            ForegroundColor = _ForegroundColor;
            BackgroundColor = _BackgroundColor;
        }
        public static bool operator ==(Glyph _First, Glyph _Second)
        {
            if (_First.Symbol != _Second.Symbol) return false;
            if (_First.ForegroundColor != _Second.ForegroundColor) return false;
            if (_First.BackgroundColor != _Second.BackgroundColor) return false;
            return true;
        }
        public static bool operator !=(Glyph _First, Glyph _Second)
        {
            if (_First.Symbol != _Second.Symbol)
                return true;
            if (_First.ForegroundColor != _Second.ForegroundColor)
                return true;
            if (_First.BackgroundColor != _Second.BackgroundColor)
                return true;
            return false;
        }
        public override string ToString()
        {
            return Symbol.ToString();
        }
        public static Glyph Empty = new Glyph(' ', ConsoleColor.White, ConsoleColor.Black);
    }
}