using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _16_05_20_pract
{
    class Program
    {
        private static string[] cases =
        {
@"var a
mov a 2
add a 4
var b = 4
div b a",

@"var a
mov a 1
add a 2
sub a 8
mul a 12
div a 3",

@"var zero
var one = 1
div one zero",

@"var pos = 4
var neg = -38
sub pos neg",

@"var aa = 1
sub a 1",

@"var greater = 2
var lesser = 1
soup greater lesser"
        };
        
        static void Main(string[] args)
        {
            Calculator calc = new Calculator(Console.WriteLine);
            foreach (string input in cases)
            {
                calc.ProcessCase(input);
                calc.Clear();
            }
            Console.ReadLine();
        }
    }
}