using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MathLibrary.Entities
{
    public class Token
    {
        public Regex TokenRegex { get; set; }
        public int NextMatchIndex { get; set; }
        public Func<string, Expression?, Expression?, Expression> FormExpression { get; set; }

    }

    public class TokenMatch
    {
        public string Substring { get; set; }
        public Func<string, Expression?, Expression?, Expression> FormExpression { get; set; }
        public TokenMatch(Token parentToken, string substring)
        {
            Substring = substring;
            FormExpression = parentToken.FormExpression;
        }
    }
}
