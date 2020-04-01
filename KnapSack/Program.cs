using System;
using System.Collections.Generic;
using System.Linq;

namespace KnapSack
{
    class Program
    {
        static void Main(string[] args)
        {
            var pencil = new AnObject() { Value = 1, Weight = 2, Name = "Pencil" };
            var eraser = new AnObject() { Value = 3, Weight = 2, Name = "Eraser" };
            var pen = new AnObject() { Value = 3, Weight = 1, Name = "Pen" };
            var objects = new List<AnObject>() { eraser, pencil, pen };
            int knapsackCapacity = 4;
            var table = new Dictionary<Tuple<AnObject, int>, SumValue>();
            for (int i = 0; i < objects.Count; i++)
            {
                var anObject = objects[i];
                for (int j = 0; j <= knapsackCapacity; j++)
                {
                    // if excluded
                    var previous = new SumValue();
                    if (i - 1 >= 0)
                    {
                        var previousObject = objects[i - 1];
                        var prevSumValue = table[new Tuple<AnObject, int>(previousObject, j)];
                        previous = new SumValue(prevSumValue)
                        {
                            IsUsed = false
                        }; // create new object to prevent updating previous data.
                    }

                    // if included
                    var weight = j;
                    var current = new SumValue() { IsUsed = true };
                    if (weight >= anObject.Weight)
                    {
                        weight -= anObject.Weight;
                        current.Sum += anObject.Value;
                        current.Data.Add(anObject);
                    }

                    if (weight > 0 && i - 1 >= 0)
                    {
                        var previousObject = objects[i - 1];
                        var prevSumValue = table[new Tuple<AnObject, int>(previousObject, weight)];
                        current.Sum += prevSumValue.Sum;
                        foreach (var data in prevSumValue.Data)
                        {
                            current.Data.Add(data);
                        }
                    }

                    // get max
                    SumValue max = previous.Sum > current.Sum || current.Sum == 0
                        ? previous
                        : current;
                    table[new Tuple<AnObject, int>(anObject, j)] = max;
                }
            }

            var result = table.Values.Where(sv => sv.IsUsed == true).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
