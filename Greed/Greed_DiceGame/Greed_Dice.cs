using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Greed_DiceGame
{

	public class Greed_DiceGame
	{
        private const int NUMBER_OF_DICE = 6;
        private const int NUMBER_OF_SIDES_PER_DIE = 6;

        public static int Score(List<int> DiceForPointCalculation)
		{
			int SumOfPoints = 0;

			try
			{
				if (DiceForPointCalculation.Count <= NUMBER_OF_DICE)
				{

					if (DiceForPointCalculation.Max() <= NUMBER_OF_SIDES_PER_DIE)
                    {

                        DiceForPointCalculation.Sort();

                        if (DiceForPointCalculation.Count != DiceForPointCalculation.Distinct().Count())
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

                            if (!DiceResultCount.ContainsValue(1) && !DiceResultCount.ContainsValue(3) && !DiceResultCount.ContainsValue(4)
                                && !DiceResultCount.ContainsValue(5) && !DiceResultCount.ContainsValue(6))
                            {
                                SumOfPoints = 800;
                            }
                            else
                            {
                                for (int PossibleDiceResult = 1; PossibleDiceResult <= NUMBER_OF_SIDES_PER_DIE; PossibleDiceResult++)
                                {
                                    if (DiceResultCount.ContainsKey(PossibleDiceResult))
                                    {
                                        if (DiceResultCount[PossibleDiceResult] >= 3)
                                        {
                                            if (PossibleDiceResult == 1)
                                            {
                                                SumOfPoints += 1000;
                                            }
                                            else
                                            {
                                                SumOfPoints = PossibleDiceResult * 100;
                                            }

                                            if (DiceResultCount[PossibleDiceResult] == 4)
                                            {
                                                SumOfPoints *= 2;
                                            }
                                            else if (DiceResultCount[PossibleDiceResult] == 5)
                                            {
                                                SumOfPoints *= 4;
                                            }
                                            else if (DiceResultCount[PossibleDiceResult] == 6)
                                            {
                                                SumOfPoints *= 8;
                                            }
                                        }
                                        else
                                        {
                                            if (PossibleDiceResult == 1)
                                            {
                                                SumOfPoints += 100 * DiceResultCount[PossibleDiceResult];
                                            }
                                            else if (PossibleDiceResult == 5)
                                            {
                                                SumOfPoints += 50 * DiceResultCount[PossibleDiceResult];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            SumOfPoints = 1200;
                        }
                    }
                    else
                    {
                        throw new DiceResultOutOfBoundsException("Only " + NUMBER_OF_SIDES_PER_DIE + "-sided dice are allowed, dice results cannot be greater than " + NUMBER_OF_SIDES_PER_DIE + ".");
                    }
                }
                else
				{
                    throw new TooManyDiceException("Only " + NUMBER_OF_DICE + " or less dice are allowed.");
                }
            } 
			catch (Exception ex)
			{
                System.Console.Error.WriteLine(ex.ToString());
			}
            return SumOfPoints;
        }
    }
}
