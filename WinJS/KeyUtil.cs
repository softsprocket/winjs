using System;

namespace WinJS {
    public static class KeyUtil {
        public static string read () {
            var ch = Console.ReadKey ();

            if (ch.Key == ConsoleKey.Enter) {  
                Console.CursorTop += 1;
                Console.CursorLeft = 0;

                return "\n"; 
            }
            return ch.KeyChar.ToString ();
        }
    }
}
