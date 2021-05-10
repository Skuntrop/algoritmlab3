using System;

namespace Lab3
{
    class Program
    {
        static void Main()
        {
            var t1 = new RPN("2*3");         
            if (t1.ToRPN() != "2,3,*")
                Console.WriteLine("Test 1 failed");

            var t2 = new RPN("x+y");
            if (t2.ToRPN() != "x,y,+")
                Console.WriteLine("Test 2 failed");

            var t3 = new RPN("x*5-2*y");
            if (t3.ToRPN() != "x,5,*,2,y,*,-")
                Console.WriteLine("Test 3 failed");

            var t4 = new RPN("x*y=35+5");
            if (t4.ToRPN() != "x,y,*,35,5,+,=")
                Console.WriteLine("Test 4 failed");

            var t5 = new RPN("(x-2)*(y+2)");
            if (t5.ToRPN() != "x,2,-,y,2,+,*")
                Console.WriteLine("Test 5 failed");

            var t6 = new RPN("x*y=30/2");
            if (t6.ToRPN() != "x,y,*,30,2,/,=")
                Console.WriteLine("Test 6 failed");

            var t7 = new RPN("-x+y*2");
            if (t7.ToRPN() != "-x,y,2,*,+")
                Console.WriteLine("Test 7 failed");

            var t8 = new RPN("sin(60)");
            if (t8.ToRPN() != "60,sin")
                Console.WriteLine("Test 8 failed");

            var t9 = new RPN("sin(60+x)");
            if (t9.ToRPN() != "60,x,+,sin")
                Console.WriteLine("Test 9 failed");

            var t10 = new RPN("cos(60*x/2)");
            if (t10.ToRPN() != "60,x,*,2,/,cos")
                Console.WriteLine("Test 10 failed");

            var t11 = new RPN("cos(60*-x/2)");
            if (t11.ToRPN() != "60,-x,*,2,/,cos")
                Console.WriteLine("Test 11 failed");

            var t12 = new RPN("tan(60-x/2)");
            if (t12.ToRPN() != "60,x,2,/,-,tan")
                Console.WriteLine("Test 12 failed");

            var t13 = new RPN("x^y/(5*z)+10");
            if (t13.ToRPN() != "x,y,^,5,z,*,/,10,+")
                Console.WriteLine("Test 13 failed");
        }
    }
}
