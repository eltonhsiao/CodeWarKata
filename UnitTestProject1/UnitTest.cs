using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWarKata
{
    [TestClass]
    public class UnitTest1
    {
        public string Nico(string key, string message)
        {
            //coding and coding..
            int klen = key.Length;
            int mlen = message.Length;
            int range = (int)Math.Ceiling((double)mlen / klen);

            int[] coder = key.OrderBy(x => x).Select(e => key.IndexOf(e)).ToArray();

            //List<string> datalist = new List<string>();
            //datalist.AddRange(key.Select(x=>x.ToString()));
            //var ordered = datalist.OrderBy(x=>x, StringComparer.Ordinal);
            //List<int> mask = new List<int>();
            //foreach (var data in datalist)
            //{
            //    foreach (var o in ordered.Select((val, idx) => new { Index = idx, Value = val }))            
            //    {
            //        if (data == o.Value)
            //        {
            //            mask.Add(o.Index);
            //        }
            //    }
            //}
            var sortedKey = new string(key.OrderBy(x => x).ToArray());
            var mask = key.Select(e => sortedKey.IndexOf(e)).ToList();


            var arr = new string[range, klen];

            for (int i = 0; i < range; i++)
            {
                var sub = message.PadRight(klen * range).Substring(klen * i, klen);
                for (int j = 0; j < klen; j++)
                {
                    arr[i, mask[j]] = sub[j].ToString();
                }
            }

            return string.Join("", arr.Cast<string>());
        }

        public string[] result = new string[100000];
        public int t = 0;
        public int number = 0;
        public int nextBiggerNumber = -1;

        private void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            a ^= b;
            b ^= a;
            a ^= b;
        }

        public void GetPer(char[] list)
        {
            int x = list.Length - 1;
            GetPer(list, 0, x);
        }

        private void GetPer(char[] list, int k, int m)
        {
            if (k == m)
            {
                result[t++] = new string(list);
                //if (int.Parse(new string(list)) > number)
                //    nextBiggerNumber = int.Parse(new string(list));
            }
            else
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPer(list, k + 1, m);
                    if (int.Parse(new string(list)) > number)
                        nextBiggerNumber = int.Parse(new string(list));
                    Swap(ref list[k], ref list[i]);
                    
                }
        }

        public int NextBiggerNumber(int num)
        {
            number = num;
            nextBiggerNumber = -1;
            t = 0;
            result = new string[100000];
            var digits = num.ToString().OrderBy(x=>x).Select(digit => digit).ToArray();

            GetPer(digits);

            return nextBiggerNumber;
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(-1 , NextBiggerNumber(9));
            Assert.AreEqual(-1, NextBiggerNumber(11));

            Assert.AreEqual(21, NextBiggerNumber(12));

            Assert.AreEqual(-1, NextBiggerNumber(111));

            Assert.AreEqual(531, NextBiggerNumber(513));

            Assert.AreEqual(2071, NextBiggerNumber(2017));
            Assert.AreEqual(441, NextBiggerNumber(414));
            Assert.AreEqual(414, NextBiggerNumber(144));
        }
    }
}
