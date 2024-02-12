using MathLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MathLibrary.Logic
{
    public class Compiler
    {
        private static List<Token> tokens = new List<Token>()
        {
            new Token(){TokenRegex = new Regex(@"\d+[.,]\d+", RegexOptions.Compiled), FormExpression = (substr, e1, e2) => 
                new Expression(){ Operation = (v1, v2) => Convert.ToDouble(substr.Replace(',','.'))} }, //constant token
            //new Token(){TokenRegex = new Regex()}
        };
    }
}
