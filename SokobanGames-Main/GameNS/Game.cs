using System.Collections.Generic;
using System.Linq;
using FileHandlerNS;

namespace GameNS
{
    public class Game : IGame
    {
        private string[] Level { get; set; }
        private Map Map;
        private List<Direction> PlayerMoves = new List<Direction>();
        private int MoveCount = 0;
        private List<bool> BlockMoved = new List<bool>();

        public void SetLevel(string[] level)
        {
            Level = level;
        }

        public int GetColumnCount()
        {           
            return Level.Length;
        }

        public int GetRowCount()
        {
            return Level[0].Length;
        }

        public int GetMoveCount()
        {
            return MoveCount;
        }

        public string GetMoveHistory()
        {
            string MoveHistory = "";
            int length = PlayerMoves.Count();
            if (length <= 5)
            {
                MoveHistory = string.Join(", ", PlayerMoves.ToArray());
            }
            else
            {
                
                MoveHistory = string.Join(", ", PlayerMoves.GetRange(length - 5, 5).ToArray());
            }
            
            return MoveHistory;
        }

        public bool IsFinished()
        {
            int blockOnGoalCount = Map.Items.Where( x => x.Sign.Equals('*')).Count();
            int GoalsCount = Map.Items.Where( x => x.Sign.Equals('.')).Count();
            int PlayerOnGoalCount = Map.Items.Where(x => x.Sign.Equals('+')).Count();

            return blockOnGoalCount >= 1 && GoalsCount == 0 && PlayerOnGoalCount == 0;          
        } 

        public void Move(Direction moveDirection)
        {
            var player = GetPlayerLocation();
            var x = player.PosX; 
            var y = player.PosY;
            int playerDestX = 0; //player destination
            int playerDestY = 0; //player destination
            int otherDestX = 0;
            int otherDestY = 0;

            switch (moveDirection)
            {
                case Direction.Up:
                    playerDestX = x - 1; 
                    otherDestX = x - 2; 
                    playerDestY = y; 
                    otherDestY = y;
                    break;
                case Direction.Down:
                    playerDestX = x + 1;
                    otherDestX = x + 2;
                    playerDestY = y;
                    otherDestY = y;
                    break;
                case Direction.Right:
                    playerDestX = x;
                    otherDestX = x;
                    playerDestY = y + 1;
                    otherDestY = y + 2;
                    break;
                case Direction.Left:
                    playerDestX = x;
                    otherDestX = x;
                    playerDestY = y - 1;
                    otherDestY = y - 2;
                    break;
                default:
                    break;
            }
            MovePlayer(player, playerDestX, otherDestX, playerDestY, otherDestY);
            PlayerMoves.Add(moveDirection);

        }

        private void MovePlayer(MapItem player,int toX, int afterToX, int toY, int afterToY)
        {
            if (toX >= 0) //to stop player falling off map edge
            {
                if (WhatsAt(toX, toY) == Parts.Empty)
                {
                    if(player.Sign == '+')
                    {
                        Map.Update(player.PosX, player.PosY, (char)Parts.Goal);
                    }
                    else
                    {
                        Map.Update(player.PosX, player.PosY, (char)Parts.Empty);
                    }
                    Map.Update(toX, toY, (char)Parts.Player);
                    BlockMoved.Add(false);
                    MoveCount++;
                }
                else if ((WhatsAt(toX, toY) == Parts.Block || WhatsAt(toX, toY) == Parts.BlockOnGoal) && (afterToX >= 0)) // to move a block as well
                {
                    if (WhatsAt(afterToX, afterToY) == Parts.Empty) //can move block
                    {
                        if (WhatsAt(toX, toY) == Parts.BlockOnGoal)
                        {
                            Map.Update(toX, toY, (char)Parts.PlayerOnGoal);
                        }
                        else
                        {
                            Map.Update(toX, toY, player.Sign);
                            MoveCount++;
                        }//new playerpos
                        Map.Update(afterToX, afterToY, (char)Parts.Block); //new block pos
                        Map.Update(player.PosX, player.PosY, (char)Parts.Empty); //old playerpos now empty
                    }
                    else if (WhatsAt(afterToX, afterToY) == Parts.Goal) // move block on goal
                    {
                        if (WhatsAt(toX, toY) == Parts.BlockOnGoal)
                        {
                            Map.Update(toX, toY, (char)Parts.PlayerOnGoal);
                        }
                        else
                        {
                            Map.Update(toX, toY, player.Sign);
                            MoveCount++;
                        }
                        Map.Update(afterToX, afterToY, (char)Parts.BlockOnGoal);
                        Map.Update(player.PosX, player.PosY, (char)Parts.Empty);
                    }
                    BlockMoved.Add(true);
                }
                else if (WhatsAt(toX, toY) == Parts.Goal) // to move player onto goal
                {
                    Map.Update(toX, toY, (char)Parts.PlayerOnGoal);
                    Map.Update(player.PosX, player.PosY, (char)Parts.Empty);
                    BlockMoved.Add(false);
                    MoveCount++;
                }
                //else they dont move / no update 
            }
        }

        public void Restart()
        {
            Map.ResetMap(Level);
            PlayerMoves = new List<Direction> { };
            BlockMoved = new List<bool> { };
            MoveCount = 0;
        }

        public void Undo() //similar to UndoMove(), but this time, reverse needs to pull a block with it etc
        {
            var player = GetPlayerLocation();
            var x = player.PosX; //this should be in Player Move maybe? and return the co-ords?
            int y = player.PosY;
            int newPosX; //players old destination
            int newPosY; //players old destination
            int inFrontOfX;
            int inFrontOfY;

            if (PlayerMoves.Count >= 1)
            {
                Direction lastMove = PlayerMoves.Last();
                if (lastMove == Direction.Up) //should move down
                {
                    newPosX = x + 1;
                    inFrontOfX = x - 1;
                    newPosY = y;
                    inFrontOfY = y;
                    UndoMove(player, newPosX, newPosY, inFrontOfX, inFrontOfY);
                }
                else if (lastMove == Direction.Down) //should move up
                {
                    newPosX = x - 1;
                    inFrontOfX = x + 1;
                    newPosY = y;
                    inFrontOfY = y;
                    UndoMove(player, newPosX, newPosY, inFrontOfX, inFrontOfY);
                }
                else if (lastMove == Direction.Left) //should move right
                {
                    newPosY = y + 1;
                    inFrontOfY = y - 1;
                    newPosX = x;
                    inFrontOfX = x;
                    UndoMove(player, newPosX, newPosY, inFrontOfX, inFrontOfY);
                }
                else
                {
                    newPosY = y - 1;
                    inFrontOfY = y + 1;
                    newPosX = x;
                    inFrontOfX = x;
                    UndoMove(player, newPosX, newPosY, inFrontOfX, inFrontOfY); //should move left
                }
                PlayerMoves.RemoveAt(PlayerMoves.Count - 1);
                BlockMoved.RemoveAt(BlockMoved.Count - 1);
                MoveCount--;
            }
        }

        private void UndoMove(MapItem player, int newX, int newY, int inFrontX, int inFrontY)
        {
            // if no object in front of player, just move player back
            if (((BlockMoved[BlockMoved.Count() - 1] == false) && (WhatsAt(inFrontX, inFrontY) == Parts.Block || WhatsAt(inFrontX, inFrontY) == Parts.BlockOnGoal)) || WhatsAt(inFrontX, inFrontY) == Parts.Empty || WhatsAt(inFrontX, inFrontY) == Parts.Wall)
            {
                if (WhatsAt(newX, newY) == Parts.Goal) //for where player is moving
                {
                    Map.Update(newX, newY, (char)Parts.PlayerOnGoal); // to keep player sign the same

                }
                else
                {
                    Map.Update(newX, newY, (char)Parts.Player); // update to normal player sign
                }
                Map.Update(player.PosX, player.PosY, (char)Parts.Empty); // replace player's 'old position' to empty
            }
            else if ((WhatsAt(inFrontX, inFrontY) == Parts.Block || WhatsAt(inFrontX, inFrontY) == Parts.BlockOnGoal) && (BlockMoved[BlockMoved.Count()-1] == true)) // to move a block back as well (if not on goal currently)
            {
                if (WhatsAt(player.PosX, player.PosY) == Parts.PlayerOnGoal) //can move block onto Goal
                {
                    //check player destination type
                    if (WhatsAt(newX, newY) == Parts.Goal) //for where player is moving
                    {
                        Map.Update(newX, newY, player.Sign); // to keep player sign same
                    }
                    else
                    {
                        Map.Update(newX, newY, (char)Parts.Player); // update to normal player sign
                    }
                    if (WhatsAt(inFrontX, inFrontY) == Parts.Block)
                    {
                        Map.Update(inFrontX, inFrontY, (char)Parts.Empty); //where block was, now empty
                    }
                    else
                    {
                        Map.Update(inFrontX, inFrontY, (char)Parts.Goal);
                    }
                    Map.Update(player.PosX, player.PosY, (char)Parts.BlockOnGoal); //old playerongoal is now blockongoal
                }
                else //it must be an empty space
                {
                    if (WhatsAt(newX, newY) == Parts.Goal) //for where player is moving
                    {
                        Map.Update(newX, newY, player.Sign); // to keep player sign same
                    }
                    else
                    {
                        Map.Update(newX, newY, (char)Parts.Player); // update to normal player sign
                    }
                    if (WhatsAt(inFrontX, inFrontY) == Parts.Block)
                    {
                        Map.Update(inFrontX, inFrontY, (char)Parts.Empty); //where block was, now empty
                    }
                    else
                    {
                        Map.Update(inFrontX, inFrontY, (char)Parts.Goal);
                    }
                    Map.Update(player.PosX, player.PosY, (char)Parts.Block); //old playerongoal now  blockongoal
                }
            }
            else if (WhatsAt(inFrontX, inFrontY) == Parts.Goal) // so goal doesnt move
            {
                if (WhatsAt(player.PosX, player.PosY) == Parts.PlayerOnGoal) //can move block onto Goal
                {
                    //check player destination type
                    Map.Update(player.PosX, player.PosY, (char)Parts.Goal); //old player pos now Goal

                }
                else //it must be an empty space
                {
                    Map.Update(player.PosX, player.PosY, (char)Parts.Empty); //old player pos now empty
                }
                if (WhatsAt(newX, newY) == Parts.Goal) //for where player is moving
                {
                    Map.Update(newX, newY, (char)Parts.PlayerOnGoal); // to keep player sign same
                }
                else
                {
                    Map.Update(newX, newY, (char)Parts.Player); // update to normal player sign //same
                }
            }
            
        }

        public Parts WhatsAt(int row, int column)
        {
            int columnCount = GetColumnCount();
            var item = Map.Items[row * columnCount + column]; 
            switch (item.Sign)
            {
                case '#':
                    return Parts.Wall;
                            
                case '$':
                    return Parts.Block;
                            
                case '+':
                    return Parts.PlayerOnGoal;
                            
                case '@':
                    return Parts.Player;
                           
                case ' ':
                    return Parts.Empty;
                            
                case '.':
                    return Parts.Goal;
                            
                case '*':
                    return Parts.BlockOnGoal;

                default:
                    return Parts.Empty;                       
            }
             
        }

        public List<MapItem> CreateMap()
        {
            Map = new Map(Level);
            return Map.Items;
        }

        public Map GetMap()
        {
            return Map;
        }

        public MapItem GetPlayerLocation()
        {
            return (from x in Map.Items where (x.Sign == (char)Parts.Player || x.Sign == (char)Parts.PlayerOnGoal) select x).FirstOrDefault();
        }
    }
}




