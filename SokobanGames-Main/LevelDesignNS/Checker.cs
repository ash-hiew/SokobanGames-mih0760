using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHandlerNS;

namespace LevelDesignNS
{
    public class Checker : IChecker
    {
        private string[] Errors { get; set; }
        private char[,] Map { get; set; }

        public void ErrorCheck()
        {
            if (!CheckPlayerExists())
            {
                Errors[0] = "No player found";
            }
            if (!CheckMultiplePlayers())
            {
                Errors[1] = "Too many players exist";
            }
            if (!CheckIfEqualBlocksAndGoals())
            {
                Errors[2] = "unequal number of blocks and goals";
            }
            if (CheckIfNoGoals())
            {
                Errors[3] = "no goals found";
            }
            if (!CheckIfBlockExists())
            {
                Errors[4] = "no blocks found";
            }
        }

        public string[] GetErrors()
        {
            return Errors;
        }

        private bool CheckPlayerExists()
        {
            if ((CountItems((char)Parts.Player) + (CountItems((char)Parts.PlayerOnGoal))) < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckMultiplePlayers()
        {
            if ((CountItems((char)Parts.Player) + (CountItems((char)Parts.PlayerOnGoal))) > 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckIfBlockExists()
        {
            if ((CountItems((char)Parts.Block) + (CountItems((char)Parts.BlockOnGoal))) < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckIfEqualBlocksAndGoals()
        {
            int numOfGoals = CountItems((char)Parts.Goal)
                            + CountItems((char)Parts.PlayerOnGoal)
                            + CountItems((char)Parts.BlockOnGoal);

            int numOfBlocks = CountItems((char)Parts.Block) + CountItems((char)Parts.BlockOnGoal);
            if (numOfGoals != numOfBlocks)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckIfNoGoals()
        {
            int numOfGoals = CountItems((char)Parts.Goal) 
                            + CountItems((char)Parts.PlayerOnGoal) 
                            + CountItems((char)Parts.BlockOnGoal);

            if (numOfGoals < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int CountItems(char part)
        {
            int count = 0;
            foreach (char item in Map)
            {
                if (item == part)
                {
                    count += 1;
                }
            }
            return count;
        }

        public void MapErrors(char[,] map)
        {
            Map = map;
            Errors = new string[5];
        }
    }
}
