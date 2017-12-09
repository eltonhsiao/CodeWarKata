using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodeWarKata
{
    public class SlotsMachine
    {
        public string[] FirstReel { get; set; }

        public string[] SecondReel { get; set; }

        public string[] ThirdReel { get; set; }

        public string FirstSpin { get; set; }

        public string SecondSpin { get; set; }

        public string ThirdSpin { get; set; }

        public void SetReel(List<string[]> reels)
        {
            FirstReel = reels[0];
            SecondReel = reels[1];
            ThirdReel = reels[2];
        }

        public void SetSpinResult(int[] spins)
        {
            FirstSpin = FirstReel[spins[0]];
            SecondSpin = SecondReel[spins[1]];
            ThirdSpin = ThirdReel[spins[2]];
        }

        public int TotalScore()
        {
            if (FirstSpin == SecondSpin && SecondSpin == ThirdSpin)
                return ReelItemScore[FirstSpin] * 10;
            if (FirstSpin != SecondSpin && SecondSpin != ThirdSpin && ThirdSpin != FirstSpin)
                return 0;
            if (FirstSpin == "Wild" && SecondSpin == ThirdSpin)
                return ReelItemScore[ThirdSpin] * 2;
            if (SecondSpin == "Wild" && ThirdSpin == FirstSpin)
                return ReelItemScore[FirstSpin] * 2;
            if (ThirdSpin == "Wild" && FirstSpin == SecondSpin)
                return ReelItemScore[SecondSpin] * 2;
            if (FirstSpin == SecondSpin)
                return ReelItemScore[FirstSpin];
            return ReelItemScore[ThirdSpin];
        }

        private readonly Dictionary<string, int> ReelItemScore = new Dictionary<string, int>()
        {
            {"Wild", 10},
            {"Star", 9},
            {"Bell", 8},
            {"Shell", 7},
            {"Seven", 6},
            {"Cherry", 5},
            {"Bar", 4},
            {"King", 3},
            {"Queen", 2},
            {"Jack", 1}
        };
    }

    public class FruitMachine
    {
        public int Fruit(List<string[]> reels, int[] spins)
        {
            SlotsMachine slots = new SlotsMachine();
            slots.SetReel(reels);
            slots.SetSpinResult(spins);

            return slots.TotalScore();
        }
    }

    [TestFixture]
    class FruitMachineTest
    {
        [TestCase]
        public void BasicTest1()
        {
            FruitMachine kata = new FruitMachine();
            string[] reel = new string[] { "Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack" };
            List<string[]> reels = new List<string[]> { reel, reel, reel };
            int[] spins = new int[] { 0, 0, 0 };
            Assert.AreEqual(100, kata.Fruit(reels, spins));
        }

        [TestCase]
        public void BasicTest2()
        {
            FruitMachine kata = new FruitMachine();
            string[] reel1 = new string[] { "Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack" };
            string[] reel2 = new string[] { "Bar", "Wild", "Queen", "Bell", "King", "Seven", "Cherry", "Jack", "Star", "Shell" };
            string[] reel3 = new string[] { "Bell", "King", "Wild", "Bar", "Seven", "Jack", "Shell", "Cherry", "Queen", "Star" };
            List<string[]> reels = new List<string[]> { reel1, reel2, reel3 };
            int[] spins = new int[] { 5, 4, 3 };
            Assert.AreEqual(0, kata.Fruit(reels, spins));
        }

        [TestCase]
        public void BasicTest3()
        {
            FruitMachine kata = new FruitMachine();
            string[] reel1 = new string[] { "King", "Cherry", "Bar", "Jack", "Seven", "Queen", "Star", "Shell", "Bell", "Wild" };
            string[] reel2 = new string[] { "Bell", "Seven", "Jack", "Queen", "Bar", "Star", "Shell", "Wild", "Cherry", "King" };
            string[] reel3 = new string[] { "Wild", "King", "Queen", "Seven", "Star", "Bar", "Shell", "Cherry", "Jack", "Bell" };
            List<string[]> reels = new List<string[]> { reel1, reel2, reel3 };
            int[] spins = new int[] { 0, 0, 1 };
            Assert.AreEqual(3, kata.Fruit(reels, spins));
        }

        [TestCase]
        public void BasicTest4()
        {
            FruitMachine kata = new FruitMachine();
            string[] reel1 = new string[] { "King", "Jack", "Wild", "Bell", "Star", "Seven", "Queen", "Cherry", "Shell", "Bar" };
            string[] reel2 = new string[] { "Star", "Bar", "Jack", "Seven", "Queen", "Wild", "King", "Bell", "Cherry", "Shell" };
            string[] reel3 = new string[] { "King", "Bell", "Jack", "Shell", "Star", "Cherry", "Queen", "Bar", "Wild", "Seven" };
            List<string[]> reels = new List<string[]> { reel1, reel2, reel3 };
            int[] spins = new int[] { 0, 5, 0 };
            Assert.AreEqual(6, kata.Fruit(reels, spins));
        }

        [TestCase]
        public void BasicTest5()
        {
            FruitMachine kata = new FruitMachine();
            string[] reel1 = new string[] { "King", "Jack", "Wild", "Bell", "Star", "Seven", "Queen", "Cherry", "Shell", "Bar" };
            string[] reel2 = new string[] { "Star", "Bar", "Jack", "Seven", "Queen", "Wild", "King", "Bell", "Cherry", "Shell" };
            string[] reel3 = new string[] { "King", "Bell", "Jack", "Shell", "Star", "Cherry", "Queen", "Bar", "Wild", "Seven" };
            List<string[]> reels = new List<string[]> { reel1, reel2, reel3 };
            int[] spins = new int[] { 2, 5, 9 };
            Assert.AreEqual(10, kata.Fruit(reels, spins));
        }
    }
}
