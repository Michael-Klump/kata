using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System.Threading;

namespace Greed_DiceGame
{

	public class Greed_DiceGame
	{
        private const int NUMBER_OF_DICE = 6;
        private const int NUMBER_OF_SIDES_PER_DIE = 6;
        private const int POINTS_FOR_SINGLE_ONE = 100;
        private const int POINTS_FOR_SINGLE_FIVE = 50;
        private const int POINTS_FOR_THREE_PAIRS = 800;
        private const int POINTS_FOR_STRAIGHT = 1200;
        private const int POINT_MULTIPLIER_FOR_QUADRUPLES = 2;
        private const int POINT_MULTIPLIER_FOR_QUINTUPLES = 4;
        private const int POINT_MULTIPLIER_FOR_SIXTUPLES = 8;
        private const int BASE_POINTS_FOR_TRIPLE_ONES = 1000;
        private const int BASE_POINTS_FOR_OTHER_TRIPLES = 100;

        public static int Score(List<int> DiceForPointCalculation)
		{
			int SumOfPoints = 0;

			try
            {
                if (!CheckForTooManyDiceException(DiceForPointCalculation)
                    && !CheckForDiceResultOutOfBoundsException(DiceForPointCalculation))
                {
                    DiceForPointCalculation.Sort();

                    if (CheckIfDuplicateDiceResultsArePresent(DiceForPointCalculation))
                    {
                        Dictionary<int, int> DiceResultCount = GetDiceResultCountDictionary(DiceForPointCalculation);

                        SumOfPoints = CalculatePointsForThreePairs(DiceResultCount);

                        SumOfPoints = CalculatePointsForEachDieSide(SumOfPoints, DiceResultCount);

                        SumOfPoints = CalculatePointsForStraight(DiceResultCount);
                    }
                }
            }
            catch (Exception ex)
			{
                System.Console.Error.WriteLine(ex.ToString());
			}
            return SumOfPoints;
        }

        private static int CalculatePointsForEachDieSide(int SumOfPoints, Dictionary<int, int> DiceResultCount)
        {
            for (int PossibleDiceResult = 1; PossibleDiceResult <= NUMBER_OF_SIDES_PER_DIE; PossibleDiceResult++)
            {
                if (DiceResultCount.ContainsKey(PossibleDiceResult))
                {
                    SumOfPoints += CalculatePointsForTriplesAndAbove(DiceResultCount, PossibleDiceResult);
                }
                else
                {
                    SumOfPoints += CalculatePointsForSingleOnesAndFives(DiceResultCount, PossibleDiceResult);
                }
            }

            return SumOfPoints;
        }

        private static Dictionary<int, int> GetDiceResultCountDictionary(List<int> DiceForPointCalculation)
        {
            Dictionary<int, int> DiceResultCount = new Dictionary<int, int>();
            foreach (int CurrentDieResult in DiceForPointCalculation)
            {
                if (!DiceResultCount.ContainsKey(CurrentDieResult))
                {
                    DiceResultCount.Add(CurrentDieResult, 1);
                }
                else
                {
                    DiceResultCount[CurrentDieResult]++;
                }
            }
            return DiceResultCount;
        }

        private static bool CheckIfDuplicateDiceResultsArePresent(List<int> DiceForPointCalculation)
        {
            if (DiceForPointCalculation.Count != DiceForPointCalculation.Distinct().Count())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int CalculatePointsForThreePairs(Dictionary<int, int> DiceResultCount)
        {
            if (!DiceResultCount.ContainsValue(1) && !DiceResultCount.ContainsValue(3) && !DiceResultCount.ContainsValue(4)
                && !DiceResultCount.ContainsValue(5) && !DiceResultCount.ContainsValue(6))
            {
                return POINTS_FOR_THREE_PAIRS;
            }
            else
            {
                return 0;
            }
        }

        private static int CalculatePointsForStraight(Dictionary<int, int> DiceResultCount)
        {
            if (DiceResultCount.ContainsValue(1) && DiceResultCount.ContainsValue(2) && DiceResultCount.ContainsValue(3)
                && DiceResultCount.ContainsValue(4) && !DiceResultCount.ContainsValue(5) && DiceResultCount.ContainsValue(6))
            {
                return POINTS_FOR_STRAIGHT;
            }
            else
            {
                return 0;
            }
        }

        private static int CalculatePointsForTriplesAndAbove(Dictionary<int, int> DiceResultCount, int PossibleDiceResult)
        {
            if (DiceResultCount[PossibleDiceResult] >= 3)
            {
                int SumOfPoints = CalculatePointsForTriples(PossibleDiceResult);

                return MultiplyPointsForQuadruplesAndAbove(SumOfPoints, DiceResultCount, PossibleDiceResult);
            }
            else
            {
                return 0;
            }
        }

        private static int MultiplyPointsForQuadruplesAndAbove(int SumOfPoints, Dictionary<int, int> DiceResultCount, int PossibleDiceResult)
        {
            if (DiceResultCount[PossibleDiceResult] == 4)
            {
                SumOfPoints *= POINT_MULTIPLIER_FOR_QUADRUPLES;
            }
            else if (DiceResultCount[PossibleDiceResult] == 5)
            {
                SumOfPoints *= POINT_MULTIPLIER_FOR_QUINTUPLES;
            }
            else if (DiceResultCount[PossibleDiceResult] == 6)
            {
                SumOfPoints *= POINT_MULTIPLIER_FOR_SIXTUPLES;
            }

            return SumOfPoints;
        }

        private static int CalculatePointsForTriples(int PossibleDiceResult)
        {
            if (PossibleDiceResult == 1)
            {
                return BASE_POINTS_FOR_TRIPLE_ONES;
            }
            else
            {
                return PossibleDiceResult * BASE_POINTS_FOR_OTHER_TRIPLES;
            }
        }

        private static int CalculatePointsForSingleOnesAndFives(Dictionary<int, int> DiceResultCount, int PossibleDiceResult)
        {
            if (PossibleDiceResult == 1)
            {
                return POINTS_FOR_SINGLE_ONE * DiceResultCount[PossibleDiceResult];
            }
            else if (PossibleDiceResult == 5)
            {
                return POINTS_FOR_SINGLE_FIVE * DiceResultCount[PossibleDiceResult];
            }
            else
            {
                return 0;
            }
        }

        private static bool CheckForTooManyDiceException(List<int> DiceForPointCalculation)
        {
            if (DiceForPointCalculation.Count <= NUMBER_OF_DICE)
            {
                return false;
            }
            else
            {
                throw new TooManyDiceException("Only " + NUMBER_OF_DICE + " or less dice are allowed.");
            }
        }

        private static bool CheckForDiceResultOutOfBoundsException(List<int> DiceForPointCalculation)
        {
            if (DiceForPointCalculation.Max() <= NUMBER_OF_SIDES_PER_DIE)
            {
                return false;
            }
            else
            {
                throw new DiceResultOutOfBoundsException("Only " + NUMBER_OF_SIDES_PER_DIE + "-sided dice are allowed, dice results cannot be greater than " + NUMBER_OF_SIDES_PER_DIE + ".");
            }
        }
    }
}
