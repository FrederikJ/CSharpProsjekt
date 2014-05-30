using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CSharpProsjekt.SpillKlasser
{
    /// <summary>
    /// KeyBordInfo.cs av Tommy Langhelle
    /// Programmering 3 - C# Projekt
    /// 
    /// Klasse for når du trykker på piltatastene
    /// http://sanity-free.org/17/obtaining_key_state_info_in_dotnet_csharp_getkeystate_implementation.html
    /// </summary>
    public class KeyboardInfo
    {
        private KeyboardInfo() { }
        [DllImport("user32")]
        private static extern short GetKeyState(int vKey);
        public static KeyStateInfo GetKeyState(Keys key)
        {
            short keyState = GetKeyState((int)key);
            byte[] bits = BitConverter.GetBytes(keyState);
            bool toggled = bits[0] > 0, pressed = bits[1] > 0;
            return new KeyStateInfo(key, pressed, toggled);
        }
    }

    public struct KeyStateInfo
    {
        Keys key;
        bool isPressed,
            isToggled;
        public KeyStateInfo(Keys _key, bool _ispressed, bool _istoggled)
        {
            key = _key;
            isPressed = _ispressed;
            isToggled = _istoggled;
        }

        public Keys Key
        {
            get { return key; }
        }

        public bool IsPressed
        {
            get { return isPressed; }
        }

        public bool IsToggled
        {
            get { return isToggled; }
        }
    }
}