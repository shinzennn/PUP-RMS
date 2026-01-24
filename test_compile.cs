using System;

namespace PUP_RMS.Test
{
    public class TestCompilation
    {
        public static void Main()
        {
            // Simple test to check if ResponsiveHelper compiles
            float test = PUP_RMS.Helper.ResponsiveHelper.GetScaleFactor(null);
            Console.WriteLine($"Scale factor: {test}");
        }
    }
}