using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary.Entities
{
    public class Expression
    {
        public double Calc(double x)
        {
            return Operation(InnerExpression1?.Calc(x) ?? 0, InnerExpression2?.Calc(x) ?? 0);
        }

        public Func<double, double, double> Operation { get; set; }
        public Expression? InnerExpression1 { get; set; }
        public Expression? InnerExpression2 { get; set; }
    }
}
