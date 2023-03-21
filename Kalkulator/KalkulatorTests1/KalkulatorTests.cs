using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator.KalkulatorTests
{
    public class KalkulatorTests
    {
        public static void TestAdd()
        {
            int result = Kalkulator.Dodawanie(2, 3);
            if (result != 5)
            {
                Console.WriteLine("Add test failed. Expected 5, but got " + result);
            }
            else
            {
                Console.WriteLine("Add test passed.");
            }
        }

        public static void TestSubtract()
        {
            int result = Kalkulator.Odejmowanie(5, 2);
            if (result != 3)
            {
                Console.WriteLine("Subtract test failed. Expected 3, but got " + result);
            }
            else
            {
                Console.WriteLine("Subtract test passed.");
            }
        }

        public static void TestMultiply()
        {
            int result = Kalkulator.Mnozenie(2, 3);
            if (result != 6)
            {
                Console.WriteLine("Multiply test failed. Expected 6, but got " + result);
            }
            else
            {
                Console.WriteLine("Multiply test passed.");
            }
        }

        public static void TestDivide()
        {
            int result = Kalkulator.Dzielenie(10, 2);
            if (result != 5)
            {
                Console.WriteLine("Divide test failed. Expected 5, but got " + result);
            }
            else
            {
                Console.WriteLine("Divide test passed.");
            }
        }

        public static void TestDivideByZero()
        {
            try
            {
                Kalkulator.Dzielenie(10, 0);
                Console.WriteLine("Divide by zero test failed. Expected ArgumentException, but no exception was thrown.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Divide by zero test passed. Expected exception was thrown: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Divide by zero test failed. Unexpected exception was thrown: " + ex.Message);
            }
        }
    }
}