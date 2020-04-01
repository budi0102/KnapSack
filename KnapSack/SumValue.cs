using System;
using System.Collections.Generic;
using System.Text;

namespace KnapSack
{
    public class SumValue
    {
        public SumValue()
        {
            this.Sum = 0;
            this.IsUsed = true;
            this.Data = new List<object>();
        }

        public SumValue(int sum, bool isUsed, IList<object> data)
        {
            Sum = sum;
            IsUsed = isUsed;
            Data = data;
        }

        public SumValue(SumValue other)
            : this(other.Sum, other.IsUsed, other.Data)
        {
        }

        public int Sum { get; set; }

        public bool IsUsed { get; set; }

        public IList<object> Data { get; }

        public override string ToString()
        {
            return $"Sum ={this.Sum}, IsUsed={this.IsUsed}, Data={string.Join(",", this.Data)}";
        }
    }
}
