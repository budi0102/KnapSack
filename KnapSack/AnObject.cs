using System;
using System.Collections.Generic;
using System.Text;

namespace KnapSack
{
    public class AnObject
    {
        public int Weight { get; set; }

        public int Value { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
