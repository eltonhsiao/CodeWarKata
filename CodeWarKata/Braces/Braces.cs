using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWarKata
{
    [TestClass]
    public class Braces
    {
        private static readonly Dictionary<char, char> BracesPair = new Dictionary<char, char>
        {
            {')', '('},
            {'}', '{'},
            {']', '['}
        };

        public static bool ValidBraces(string braces)
        {
            var stack = new Stack<char>();

            foreach (var brace in braces)
            {
                if (BracesPair.ContainsKey(brace) && stack.Any())
                {
                    char leftBrace;
                    BracesPair.TryGetValue(brace, out leftBrace);
                    if (leftBrace != stack.Pop())
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(brace);
                }
            }

            return stack.Count == 0;
        }

        [TestMethod]
        public void Valid_Input_Braces_Should_Return_True()
        {
            Assert.AreEqual(true, ValidBraces("()"));

            Assert.AreEqual(true, ValidBraces("(){}"));

            Assert.AreEqual(true, ValidBraces("({})"));

            Assert.AreEqual(true, ValidBraces("(){}[]"));

            Assert.AreEqual(true, ValidBraces("([{}])"));
        }

        [TestMethod]
        public void Invalid_Input_Braces_Should_Return_False()
        {
            Assert.AreEqual(false, ValidBraces("("));

            Assert.AreEqual(false, ValidBraces("(()"));

            Assert.AreEqual(false, ValidBraces("({)}"));

            Assert.AreEqual(false, ValidBraces("[({})](]"));

            Assert.AreEqual(false, ValidBraces(")(}{]["));

            Assert.AreEqual(false, ValidBraces("}}]]))}])"));
        }
    }
}
