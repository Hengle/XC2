using GameDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drivers
{
    // curtosey of https://stackoverflow.com/questions/33336540/how-to-use-linq-to-find-all-combinations-of-n-items-from-a-set-of-numbers
    public static class Ex
    {
        public static IEnumerable<IEnumerable<T>> DifferentCombinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
              elements.SelectMany((e, i) =>
                elements.Skip(i + 1).DifferentCombinations(k - 1).Select(c => (new[] { e }).Concat(c)));
        }

        //https://stackoverflow.com/questions/545703/combination-of-listlistint
        public static void Recurse<TList>(int[] selected, int index, IEnumerable<TList> remaining) where TList : IEnumerable<int>
        {
            IEnumerable<int> nextList = remaining.FirstOrDefault();
            if (nextList == null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (int i in selected)
                {
                    sb.Append(i).Append(',');
                }
                if (sb.Length > 0) sb.Length--;
                Console.WriteLine(sb);
            }
            else
            {
                foreach (int i in nextList)
                {
                    selected[index] = i;
                    Recurse(selected, index + 1, remaining.Skip(1));
                }
            }
        }
    }
}
