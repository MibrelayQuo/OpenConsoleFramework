using System;

namespace OpenConsoleFramework
{
    public static class Render
    {
        private static Glyph[,] BackBuffer;
        private static Glyph[,] ScreenBuffer;
        private static int Width;
        private static int Height;
        public static void Initialize(int _Width, int _Height, string _Title)
        {
            if (_Width > Console.LargestWindowWidth || _Width < 20)
                throw new Exception("Incorrect Width");
            if (_Height > Console.LargestWindowHeight || _Height < 20)
                throw new Exception("Incorrect Height");
            Console.SetBufferSize(_Width, _Height);
            Console.SetWindowSize(_Width, _Height);
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
            Console.CursorSize = 1;
            Console.CursorVisible = false;
            Console.Title = _Title;
            Console.TreatControlCAsInput = true;
            Console.Clear();
            BackBuffer = new Glyph[_Width, _Height];
            ScreenBuffer = new Glyph[_Width, _Height];
            Width = _Width;
            Height = _Height;
        }
        public static void Flush()
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    if (ScreenBuffer[x, y] != BackBuffer[x, y])
                    {
                        Print(new Point(x, y), BackBuffer[x, y]);
                        ScreenBuffer[x, y] = BackBuffer[x, y];
                    }
        }
        public static void Clear()
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    if(!(x == Width-1 && y == Height-1))
                    BackBuffer[x, y] = new Glyph();
        }
        public static void DrawBorder(Point _Start, Point _End,
            ConsoleColor _BorderColor = ConsoleColor.White, bool _DrawDownRightSymbol = true)
        {
            for(int x = _Start.X; x <= _End.X;x++)
                for(int y = _Start.Y; y <= _End.Y;y++)
                {
                    if(y == _Start.Y)
                    {
                        if (x == _Start.X)
                            BackBuffer[x, y] = new Glyph('╔', _BorderColor, ConsoleColor.Black);
                        else if (x == _End.X)
                            BackBuffer[x, y] = new Glyph('╗', _BorderColor, ConsoleColor.Black);
                        else
                            BackBuffer[x, y] = new Glyph('═', _BorderColor, ConsoleColor.Black);
                    }
                    else if(y == _End.Y)
                    {
                        if (_DrawDownRightSymbol)
                        {
                            if (x == _Start.X)
                                BackBuffer[x, y] = new Glyph('╚', _BorderColor, ConsoleColor.Black);
                            else if (x == _End.X)
                                BackBuffer[x, y] = new Glyph('╝', _BorderColor, ConsoleColor.Black);
                            else
                                BackBuffer[x, y] = new Glyph('═', _BorderColor, ConsoleColor.Black);
                        }
                        else
                        {
                            if (x == _Start.X)
                                BackBuffer[x, y] = new Glyph('╚', _BorderColor, ConsoleColor.Black);
                            else if (x != _End.X)
                                BackBuffer[x, y] = new Glyph('═', _BorderColor, ConsoleColor.Black);
                        }
                            
                    }
                    else
                    {
                        if(x == _Start.X || x == _End.X)
                            BackBuffer[x, y] = new Glyph('║', _BorderColor, ConsoleColor.Black);
                    }
                }
        }
        public static void Write(Point _Position, string _Text)
        {
            for (int i = 0; i < _Text.Length; i++)
                BackBuffer[_Position.X + i, _Position.Y] = new Glyph(_Text[i], ConsoleColor.White, ConsoleColor.Black);
        }
        public static void Write(Point _Position, Glyph _Glyph)
        {
            BackBuffer[_Position.X, _Position.Y] = _Glyph;
        }
        private static void Print(Point _Position, Glyph _Glyph)
        {
            Console.SetCursorPosition(_Position.X, _Position.Y);
            Console.BackgroundColor = _Glyph.BackgroundColor;
            Console.ForegroundColor = _Glyph.ForegroundColor;
            Console.Write(_Glyph.ToString());
        }
        public static void MoveBufferArea(Point _Start, Point _End, Point _NewPosition)
        {
            int tx = _NewPosition.X;
            int ty = _NewPosition.Y;
            for (int x = _Start.X; x <= _End.X; x++, tx++)
                for (int y = _Start.Y; y <= _End.Y; y++, ty++)
                {
                    BackBuffer[tx, ty] = BackBuffer[x, y];
                    BackBuffer[x, y] = new Glyph(' ', ConsoleColor.White, ConsoleColor.Black);
                }
        }
    }
}
