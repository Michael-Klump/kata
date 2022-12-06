using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using static System.Formats.Asn1.AsnWriter;
using System.Threading;

namespace Greed_DiceGame
{
    [TestFixture]
    public class TestGreed_Dice
    {

        [Test]
        public void TestStraight()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 1, 2, 3, 4, 5, 6 });
            Assert.That(ActualPoints, Is.EqualTo(1200));
        }

        [Test]
        public void TestThreePairs()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 2, 2, 3, 3, 4, 4 });
            Assert.That(ActualPoints, Is.EqualTo(800));
        }

        [Test]
        public void TestTripleOnes()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 1, 1, 1, 2, 3, 4 });
            Assert.That(ActualPoints, Is.EqualTo(1000));
        }

        [Test]
        public void TestFourOnes()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 1, 1, 1, 1, 2, 3 });
            Assert.That(ActualPoints, Is.EqualTo(2000));
        }

        [Test]
        public void TestFiveOnes()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 1, 1, 1, 1, 1, 2 });
            Assert.That(ActualPoints, Is.EqualTo(4000));
        }

        [Test]
        public void TestSixOnes()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 1, 1, 1, 1, 1, 1 });
            Assert.That(ActualPoints, Is.EqualTo(8000));
        }

        [Test]
        public void TestTripleTwos()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 2, 2, 2, 4, 6, 6 });
            Assert.That(ActualPoints, Is.EqualTo(200));
        }

        [Test]
        public void TestFourTwos()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 2, 2, 2, 2, 3, 4 });
            Assert.That(ActualPoints, Is.EqualTo(400));
        }

        [Test]
        public void TestFiveTwos()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 2, 2, 2, 2, 2, 3 });
            Assert.That(ActualPoints, Is.EqualTo(800));
        }

        [Test]
        public void TestSixTwos()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 2, 2, 2, 2, 2, 2 });
            Assert.That(ActualPoints, Is.EqualTo(1600));
        }

        [Test]
        public void TestTripleThrees()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 3, 3, 3, 4, 6, 6 });
            Assert.That(ActualPoints, Is.EqualTo(300));
        }

        [Test]
        public void TestFourThrees()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 3, 3, 3, 3, 4, 6 });
            Assert.That(ActualPoints, Is.EqualTo(600));
        }

        [Test]
        public void TestFiveThrees()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 3, 3, 3, 3, 3, 4 });
            Assert.That(ActualPoints, Is.EqualTo(1200));
        }

        [Test]
        public void TestSixThrees()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 3, 3, 3, 3, 3, 3 });
            Assert.That(ActualPoints, Is.EqualTo(2400));
        }

        [Test]
        public void TestTripleFours()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 2, 3, 4, 4, 4, 6 });
            Assert.That(ActualPoints, Is.EqualTo(400));
        }

        [Test]
        public void TestFourFours()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 2, 3, 4, 4, 4, 4 });
            Assert.That(ActualPoints, Is.EqualTo(800));
        }

        [Test]
        public void TestFiveFours()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 2, 4, 4, 4, 4, 4 });
            Assert.That(ActualPoints, Is.EqualTo(1600));
        }

        [Test]
        public void TestSixFours()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 4, 4, 4, 4, 4, 4 });
            Assert.That(ActualPoints, Is.EqualTo(3200));
        }

        [Test]
        public void TestTripleFives()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 3, 4, 5, 5, 5, 6 });
            Assert.That(ActualPoints, Is.EqualTo(500));
        }

        [Test]
        public void TestFourFives()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 3, 4, 5, 5, 5, 5 });
            Assert.That(ActualPoints, Is.EqualTo(1000));
        }

        [Test]
        public void TestFiveFives()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 3, 5, 5, 5, 5, 5 });
            Assert.That(ActualPoints, Is.EqualTo(2000));
        }

        [Test]
        public void TestSixFives()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 5, 5, 5, 5, 5, 5 });
            Assert.That(ActualPoints, Is.EqualTo(4000));
        }

        [Test]
        public void TestTripleSixes()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 2, 3, 4, 6, 6, 6 });
            Assert.That(ActualPoints, Is.EqualTo(600));
        }

        [Test]
        public void TestFourSixes()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 2, 3, 6, 6, 6, 6 });
            Assert.That(ActualPoints, Is.EqualTo(1200));
        }

        [Test]
        public void TestFiveSixes()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 2, 6, 6, 6, 6, 6 });
            Assert.That(ActualPoints, Is.EqualTo(2400));
        }

        [Test]
        public void TestSixSixes()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 6, 6, 6, 6, 6, 6 });
            Assert.That(ActualPoints, Is.EqualTo(4800));
        }

        [Test]
        public void SingleOne()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 1, 2, 3, 4, 6, 6 });
            Assert.That(ActualPoints, Is.EqualTo(100));
        }

        [Test]
        public void DoubleOne()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 1, 1, 2, 3, 4, 6 });
            Assert.That(ActualPoints, Is.EqualTo(200));
        }

        [Test]
        public void SingleFive()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 2, 3, 3, 4, 5, 6 });
            Assert.That(ActualPoints, Is.EqualTo(50));
        }

        [Test]
        public void DoubleFives()
        {
            int ActualPoints = Greed_DiceGame.Score(new List<int> { 2, 3, 4, 5, 5, 6 });
            Assert.That(ActualPoints, Is.EqualTo(100));
        }
    }
}
