using System;
using System.Runtime.InteropServices;

namespace OpenConsoleFramework
{
    public enum Key
    {
        Tab = 0x09,
        Enter = 0x0D,
        LeftShift = 0xA0,
        RightShift = 0xA1,
        LeftCtrl = 0xA2,
        RightCtrl = 0xA3,
        Alt = 0x12,
        Capslock = 0x14,
        Escape = 0x1B,
        Spacebar = 0x20,
        LeftArrow = 0x25,
        UpArrow = 0x26,
        RightArrow = 0x27,
        DownArrow = 0x28,
        Zero = 0x30,
        One = 0x31,
        Two = 0x32,
        Three = 0x33,
        Four = 0x34,
        Five = 0x35,
        Six = 0x36,
        Seven = 0x37,
        Eight = 0x38,
        Nine = 0x39,
        A = 0x41,
        B = 0x42,
        C = 0x43,
        D = 0x44,
        E = 0x45,
        F = 0x46,
        G = 0x47,
        H = 0x48,
        I = 0x49,
        J = 0x4A,
        K = 0x4B,
        L = 0x4C,
        M = 0x4D,
        N = 0x4E,
        O = 0x4F,
        P = 0x50,
        Q = 0x51,
        R = 0x52,
        S = 0x53,
        T = 0x54,
        U = 0x55,
        V = 0x56,
        W = 0x57,
        X = 0x58,
        Y = 0x59,
        Z = 0x5A,
        NumZero = 0x60,
        NumOne = 0x61,
        NumTwo = 0x62,
        NumThree = 0x63,
        NumFour = 0x64,
        NumFive = 0x65,
        NumSix = 0x66,
        NumSeven = 0x67,
        NumEight = 0x68,
        NumNine = 0x69
    }
    public static class Keyboard
    {
        [DllImport("user32.dll")]
        private static extern int GetAsyncKeyState(Int32 i);
        public static bool GetKeyDown(Key _Key)
        {
            return (GetAsyncKeyState((int)_Key) != 0 ? true : false);
        }
    }
}