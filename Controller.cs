using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MyGame
{
    class Controller : IController
    {
        private Hero _player  = new Hero();

        public Controller(Form form) : base(form)
        {
            Elements.Add(_player);
        }

        internal override void Started()
        {
            _player.Start();
        }

        internal override void Updated()
        {
             if (GetKey(Keys.Right))
                _player.Right();
            if (GetKey(Keys.Down))
                _player.Down();
            if (GetKey(Keys.Left))
                _player.Left();
            if (GetKey(Keys.Up))
                _player.Up();
        }

        internal override void Stoped()
        {
        }
    }

    public static class Con
    {
        public static void Consondeb()
        {
            if (NativeMethods.AllocConsole())
            {
                IntPtr stdHandle = NativeMethods.GetStdHandle(NativeMethods.STD_OUTPUT_HANDLE);
            }
            else
                Console.WriteLine("Консоль Активна!");
        }

        public partial class NativeMethods
        {
            public static Int32 STD_OUTPUT_HANDLE = -11;

            [System.Runtime.InteropServices.DllImportAttribute("kernel32.dll", EntryPoint = "GetStdHandle")]
            public static extern System.IntPtr GetStdHandle(Int32 nStdHandle);

            [System.Runtime.InteropServices.DllImportAttribute("kernel32.dll", EntryPoint = "AllocConsole")]

            [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]

            public static extern bool AllocConsole();
        }
    }

}

