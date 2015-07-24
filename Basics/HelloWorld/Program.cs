using Gameduino;
using System.Threading;

namespace HelloWorld
{
    public class Program
    {
        public static void Main()
        {
            GD2.Init();

            GD2.ClearColorRGB(0x103000);
            GD2.Clear();
            GD2.DisplayText(240, 136, 31, GD2.Options.Center, "Hello, Netduino!");
            GD2.Swap();
        }
    }
}
