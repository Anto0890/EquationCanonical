using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Equation
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                while(true)
                {
                    Console.WriteLine(MakeCanonical(Console.ReadLine()));
                }
            }
            else 
            { // expecting only one file path, could be with spaces in it 
                var filePath = string.Join(" ", args);
                var lines = File.ReadAllLines(filePath);
                StringBuilder output = new StringBuilder();
                StringBuilder errors = new StringBuilder();
                foreach (var line in lines)
                {
                    try
                    {
                        output.AppendLine(MakeCanonical(line));
                    }
                    catch (Exception ex)
                    {
                        errors.Append("ERROR for ").AppendLine(line)
                              .AppendLine(ex.Message)
                              .AppendLine(ex.StackTrace);
                    }
                }
                var outputFilePath = filePath + ".out";
                var errorFilePath = filePath + ".error";
                File.WriteAllText(outputFilePath, output.ToString());
                if (errors.Length > 0)
                {
                    File.WriteAllText(errorFilePath, errors.ToString());
                }
            }
        }

        public static string MakeCanonical(string equation)
        {
            // split equation arguments to parts 
            if (BracketsAreCorrect(equation))
            {
                return Opimise(MoveToLeft(ExpandBrackets(equation)));
            }
            else {
                throw new Exception("Equation is not correct");
            }
            //throw new NotImplementedExceptio n();
        }

        public static string Opimise(string equation)
        {
            return equation;
            //throw new NotImplementedException();
        }

        public static string MoveToLeft(string equation)
        {
            return equation;
            //throw new NotImplementedException();
        }

        public static string ExpandBrackets(string equation)
        {
            string pattern = @"(\([^\(\)]+\))(\([^\(\)]+\))"; // (x^2 + 3.5xy)(45x + 5y) 

            Regex regMtch = new Regex(pattern, RegexOptions.Compiled | RegexOptions.Singleline );
            var match = regMtch.Match(equation);
            string res = "";
            while (match.Success)
            {
                res = MultiplyParts(match.Groups[1], match.Groups[2]);
                match = match.NextMatch();
            }

            return res;
            //throw new NotImplementedException();
        }

        private static string MultiplyParts(Group group1, Group group2)
        {
            string pattern = @"([-+]*[^-+\)\(]+)";
            Regex regMtch = new Regex(pattern, RegexOptions.Compiled | RegexOptions.Singleline);
            var match = regMtch.Match(group1.Value);
            List<Summand> left = new List<Summand>();
            while (match.Success)
            {
                left.Add(new Summand(match.Groups[1].Value));
                match = match.NextMatch();
            }

            match = regMtch.Match(group2.Value);
            List<Summand> right = new List<Summand>();
            while (match.Success)
            {
                left.Add(new Summand(match.Groups[1].Value));
                match = match.NextMatch();
            }
            

            throw new NotImplementedException();
        }


        /// <summary>
        /// Checks brackets and equal sign in given equation
        /// </summary>
        /// <param name="equation"></param>
        /// <returns></returns>
        public static bool BracketsAreCorrect(string equation)
        {
            var leftAndRightParts = equation.Split('=');
            if (leftAndRightParts.Length == 1) // no equal sign
            {
                bool firstBracketIsOpeninig = false;
                int? pairingIndex = null; // null if no brackets found
                foreach (char ch in equation.ToCharArray().Where(c => c.Equals('(') || c.Equals(')')))
                {
                    if (pairingIndex == null)
                    {
                        if (ch.Equals('(')) firstBracketIsOpeninig = true;
                        pairingIndex = 0;
                    }
                    pairingIndex = pairingIndex + (ch.Equals('(') ? 1 : -1);
                }
                return (firstBracketIsOpeninig && pairingIndex == 0) || pairingIndex == null;
            }
            else if (leftAndRightParts.Length == 2) // one equal sign
            {
                return BracketsAreCorrect(leftAndRightParts[0]) && BracketsAreCorrect(leftAndRightParts[1]);
            }
            else throw new ApplicationException("Equation is not correct: multiple equal sign");
        }

        /// <summary>
        /// Sort equation arguments to make it look the same as solution from test data 
        /// </summary>
        /// <param name="equation"></param>
        /// <returns></returns>
        public static string SortArguments(string equation)
        {
            return equation;
            //throw new NotImplementedException();
        }
    }
}
