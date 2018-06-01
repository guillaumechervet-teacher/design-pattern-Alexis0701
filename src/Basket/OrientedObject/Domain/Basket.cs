using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.OrientedObject.Domain
{
    public class Basket
    {
        private readonly IList<BasketLine> _basketLines;

        public Basket(IList<BasketLine> basketLines)
        {
            _basketLines = basketLines;
        }

        public int Calculate()
        {
            var total = 0;
            foreach (var basketLine in _basketLines)
            {
                total += basketLine.Calculate();
            }

            return total;
        }

    }
}
