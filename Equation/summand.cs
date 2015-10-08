using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Equation
{
    public class Summand
    {
        public double k = 1;
        public Dictionary<char, int> varInPower = new Dictionary<char, int>();

        public Summand() {}

        public Summand(string text)
        {
            
        }

        public Summand Multiply(this Summand a, Summand v)
        {
            Summand r = new Summand();
            r.k =  k = a.k * v.k;
            r.varInPower = a.varInPower.Concat(v.varInPower)
                            .ToLookup(pair => pair.Key, pair => pair.Value)
                            .ToDictionary(group => group.Key, group => group.Sum()); ;
            return r;
        }

       
    }


}
