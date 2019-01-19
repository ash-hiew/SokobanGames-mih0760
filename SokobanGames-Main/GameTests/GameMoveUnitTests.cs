using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GameNS;
using System.Collections;
using System.Collections.Generic;

namespace GameTests
{
    [TestClass]
    public class SokobanTests
    {
        public string leveltext = "#####              ," +
            "#   #              ," +
            "#$  #              ," +
            "###  $##           ," +
            "#  $ $ #           ," +
            "### # ## #   ######," +
            "#   # ## #####  ..#," +
            "# $  $          ..#," +
            "##### ### #@##  ..#," +
            "#     #########    ," +
            "#######            ";
        // File Loads

        public string moveleveltest = "#####" +
                                        ",#   #" +
                                        ",# @ #" +
                                        ",#   #" +
                                        ",#####";

        public string boxleveltest = "## ##" +
                                        ",# $ #" +
                                        ",# @ #" +
                                        ",#   #" +
                                        ",#####";

        public string goalleveltest = "##.##" +
                                        ",# $ #" +
                                        ",# @ #" +
                                        ",#   #" +
                                        ",#####";

        public string boxcantmoveleveltest = "#####" +
                                        ",# $ #" +
                                        ",# @ #" +
                                        ",#   #" +
                                        ",#####";

        public string wallleveltest = "#####" +
                                        ",# # #" +
                                        ",# @ #" +
                                        ",#   #" +
                                        ",#####";

        public string playerongoalleveltest = "#####" +
                                        ",# . #" +
                                        ",# @ #" +
                                        ",#   #" +
                                        ",#####";

        public string playermoveoffgoalleveltest = "#####" +
                                        ",#   #" +
                                        ",# + #" +
                                        ",#   #" +
                                        ",#####";

        public string boxoffgoalleveltest = "#####" +
                                        ",#   #" +
                                        ",# * #" +
                                        ",# @ #" +
                                        ",#####";

        public string undoPlayerOnGoalleveltest = "#####" +
                                        ",#   #" +
                                        ",# * #" +
                                        ",# @ #" +
                                        ",#####";

        public string undoGoalTest =     "#####" +
                                        ",# . #" +
                                        ",#   #" +
                                        ",# @ #" +
                                        ",#####";


        public string levelfinished = "#####" +
                                        ",# * #" +
                                        ",# * #" +
                                        ",# + #" +
                                        ",#####";

        public string levelnoload = "#####" +
                                        ",#   #" +
                                        ",#   #" +
                                        ",#   #" +
                                        ",#####";

        [TestMethod]

        public void CheckIfGameLoadsFile()
        {
            string[] expected = {"#####",
                                        ",#   #",
                                        ",# @ #",
                                        ",#   #",
                                        ",#####"};
            //GameNS.Game game = new Game(new MockFiler(leveltext));
            GameNS.Game game = new Game(null);

            game.Load(leveltext);
            string[] real = game.Level;

            string realString = real.ToString();
            string expectedString = expected.ToString();
            Assert.AreEqual(realString, expectedString, "Failed to Load");
        }

        [TestMethod]
        public void CheckIfGameLoadsFileNoPlayer()
        {
            //GameNS.Game game = new Game(new MockFiler(leveltext));
            GameNS.Game game = new Game(null);
            try {
                game.Load(levelnoload);
                Assert.Fail("level loaded");
            }
            catch (Exception)
            {

            }
        }

        [TestMethod]
        public void CheckColumnCount()
        {
            GameNS.Game game = new Game(null);
            int expected = 11;

            game.Load(leveltext);
            string[] Level = game.Level;
            int actual = game.GetColumnCount();

            Assert.AreEqual(expected, actual, "Column Count is not correct");
        }

        [TestMethod]
        public void CheckRowCount()
        {
            GameNS.Game game = new Game(null);
            int expected = 19;

            game.Load(leveltext);
            string[] Level = game.Level;
            int actual = game.GetRowCount();

            Assert.AreEqual(expected, actual, "Row Count is not correct");
        }

        [TestMethod]
        public void CheckResetWorks()
        {
            GameNS.Game game = new Game(null);

            game.Load(moveleveltest);
            game.MakeMap(); // load the level
            Map expectedLevel = game.Map;
            game.Move(Direction.Up);
            game.Move(Direction.Down);
            game.Move(Direction.Left);
            int expectedMC = 0;
            game.PlayerMoves = new List<Direction> { };
            string expectedPM = game.GetMoveHistory();


            game.PlayerMoves = new List<Direction> { Direction.Up, Direction.Down, Direction.Left };

            game.Restart();
            Map realLevel = game.Map;
            string realPM = game.GetMoveHistory();
            int realMC = game.GetMoveCount();



            Assert.AreEqual(realLevel, expectedLevel, "Failed to reset Level");
            Assert.AreEqual(realMC, expectedMC, "Failed to reset Move Count");
            Assert.AreEqual(realPM, expectedPM, "Failed to reset Player Moves");
        }

        [TestMethod]
        public void TestMoveCount()
        {
            GameNS.Game game = new Game(null);
            game.Load(leveltext);
            game.MakeMap();
            int expected = 3;
            game.Move(Direction.Up);
            game.Move(Direction.Up);
            game.Move(Direction.Up);

            int real = game.GetMoveCount();

            Assert.AreEqual(expected, real, "Not the right move count");
        }

        [TestMethod]
        public void CheckPlayerMoveHistory() //
        {
            GameNS.Game game = new Game(null);
            string expected = "Up,Down,Left";
            game.PlayerMoves = new List<Direction> { Direction.Up, Direction.Down, Direction.Left };

            string real = game.GetMoveHistory();

            Assert.AreEqual(expected, real, "move history not displayed correctly");
        }

        [TestMethod]
        public void CheckUndoWorks() //need to find previous move, then move player in opposite direction
        {
            GameNS.Game game = new Game(null);
            game.Load(moveleveltest);
            game.MakeMap();
            game.Move(Direction.Up);
            game.Move(Direction.Down);
            game.Move(Direction.Up);
            int expectedMoveCount = game.GetMoveCount() - 1; // to see if move count also updates
            List<Direction> ExpectedL =new  List<Direction> { Direction.Up, Direction.Down };
            string ExpectedList = string.Join(",", ExpectedL.ToArray());
            MapItem expectedPlayerPosition = game.Map.Items[12];

            game.Undo(); //should find Up and move player Down. 
                         //check player postion now to see if moved correctly
                         //new location of Player
            MapItem real = game.FindPlayer();
            int RealMoveCount = game.GetMoveCount();
            string RealList = game.GetMoveHistory();

            Assert.AreEqual(expectedPlayerPosition, real, "didnt undo correctly");
            Assert.AreEqual(expectedMoveCount, RealMoveCount, "Move count doesnt match expected");
            Assert.AreEqual(ExpectedList, RealList, "List Doesnt Match");

        }

        [TestMethod]
        public void CheckUndoWorksMoreThanOnce() //needs to undo twice!~ first UP, then Left
        {
            GameNS.Game game = new Game(null);
            game.Load(moveleveltest);
            game.MakeMap();
            game.Move(Direction.Up);
            game.Move(Direction.Left);
            game.Move(Direction.Down);
            int expectedMoveCount = game.GetMoveCount() - 3; // to see if move count also updates
            List<Direction> ExpectedL = new List<Direction> {};
            string ExpectedList = "";
            


            game.Undo(); //RoundOne
            game.Undo(); //RoundTwo
            game.Undo(); //RoundThree
            MapItem expectedPlayerPosition = game.Map.Items[12];
            MapItem real = game.FindPlayer();
            int RealMoveCount = game.GetMoveCount();
            string RealList = game.GetMoveHistory();

            Assert.AreEqual(expectedPlayerPosition, real, "didnt undo correctly");
            Assert.AreEqual(expectedMoveCount, RealMoveCount, "Move count doesnt match expected");
            Assert.AreEqual(ExpectedList, RealList, "List Doesnt Match");

        }

        [TestMethod]
        public void CheckUndoNoneInList() //needs to undo twice!~ first UP, then Left
        {
            GameNS.Game game = new Game(null);
            game.Load(moveleveltest);
            game.MakeMap();
            MapItem expectedPlayerPosition = game.FindPlayer();
            game.Move(Direction.Up);
            game.Move(Direction.Left);
            game.Move(Direction.Down);
            
            int expectedMoveCount = game.GetMoveCount() - 3; // to see if move count also updates
            List<Direction> ExpectedL = new List<Direction> { };
            string ExpectedList = ExpectedL.ToString();


            game.Undo(); //RoundOne
            game.Undo(); //RoundTwo
            game.Undo(); //RoundThree
            game.Undo(); //now none in list
            
            MapItem real = game.FindPlayer();
            int RealMoveCount = game.GetMoveCount();
            string RealList = game.PlayerMoves.ToString();

            Assert.AreEqual(expectedPlayerPosition, real, "didnt undo correctly");
            Assert.AreEqual(expectedMoveCount, RealMoveCount, "Move count doesnt match expected");
            Assert.AreEqual(ExpectedList, RealList, "List Doesnt Match");

        }

        [TestMethod]
        public void CheckUndoWorksWithBox() 
        {
            GameNS.Game game = new Game(null);
            game.Load(boxleveltest);
            game.MakeMap();
            game.Move(Direction.Up);



            game.Undo();
            MapItem expectedPlayerPosition = game.Map.Items[12];
            FilerNS.Parts ExpectedBox = FilerNS.Parts.Block;
            MapItem real = game.FindPlayer();
            FilerNS.Parts RealBox = game.WhatsAt(1, 2);


            Assert.AreEqual(expectedPlayerPosition, real, "didnt undo correctly");
            Assert.AreEqual(ExpectedBox, RealBox, "Box didnt move");

        }

        public string undoBoxR2 = "#####" +
                                        ",# $ #" +
                                        ",#   #" +
                                        ",# @ #" +
                                        ",#####";

        [TestMethod]
        public void CheckUndoWorksBoxRound2()  // sometimes player has moved beside a box, but hasnt moved it. This will test if the player will not move that box back when undo is pressed
        {
            GameNS.Game game = new Game(null);
            game.Load(undoBoxR2);
            game.MakeMap();
            game.Move(Direction.Up); //player now beside box

            game.Undo();
            MapItem expectedPlayerPosition = game.Map.Items[17];
            FilerNS.Parts ExpectedBox = FilerNS.Parts.Block;
            MapItem real = game.FindPlayer();
            FilerNS.Parts RealBox = game.WhatsAt(1, 2);


            Assert.AreEqual(expectedPlayerPosition, real, "didnt undo correctly");
            Assert.AreEqual(ExpectedBox, RealBox, "Box moved");
        }

        [TestMethod]
        public void CheckUndoWorksWithBoxAndPlayerOnGoal()
        {
            GameNS.Game game = new Game(null);
            game.Load(undoPlayerOnGoalleveltest);
            game.MakeMap();
            game.Move(Direction.Up); //player now on goal box off goal


            game.Undo();
            MapItem expectedPlayerPosition = game.Map.Items[17];
            FilerNS.Parts ExpectedBox = FilerNS.Parts.BlockOnGoal;
            MapItem real = game.FindPlayer();
            FilerNS.Parts RealBox = game.WhatsAt(2, 2);


            Assert.AreEqual(expectedPlayerPosition, real, "didnt undo correctly");
            Assert.AreEqual(ExpectedBox, RealBox, "Box didnt move");

        }
        public string undoBoxGoalPlayerLevelTest = "#####" +
                                        ",# . #" +
                                        ",# $ #" +
                                        ",# @ #" +
                                        ",#####";

        [TestMethod]
        public void CheckUndoWorksWithBoxOnGoalAndPlayer()
        { 
            //should output noraml player, box and goal
            GameNS.Game game = new Game(null);
            game.Load(undoBoxGoalPlayerLevelTest);
            game.MakeMap();
            game.Move(Direction.Up); //creating move lis


            game.Undo();
            MapItem expectedPlayerPosition = game.Map.Items[17];
            FilerNS.Parts ExpectedBox = FilerNS.Parts.Block;
            FilerNS.Parts ExpectedGoal = FilerNS.Parts.Goal;
            MapItem real = game.FindPlayer();
            FilerNS.Parts RealBox = game.WhatsAt(2, 2);
            FilerNS.Parts RealGoal = game.WhatsAt(1, 2); 


            Assert.AreEqual(expectedPlayerPosition, real, "didnt undo correctly");
            Assert.AreEqual(ExpectedBox, RealBox, "Box didnt move");
            Assert.AreEqual(ExpectedGoal, RealGoal, "Box on Goal didnt update to Goal");
        }

        public string undoBoxGoalPlayerGoalLevelTest = "#####" +
                                        ",# . #" +
                                        ",# * #" +
                                        ",# @ #" +
                                        ",#####";

        [TestMethod]
        public void CheckUndoWorksWithBoxOnGoalAndPlayerOnGoal()
        {
            //should output normal player, boxOnGoal and goal
            GameNS.Game game = new Game(null);
            game.Load(undoBoxGoalPlayerGoalLevelTest);
            game.MakeMap();
            game.Move(Direction.Up); //creating move lis


            game.Undo();
            MapItem expectedPlayerPosition = game.Map.Items[17];
            FilerNS.Parts ExpectedBox = FilerNS.Parts.BlockOnGoal;
            FilerNS.Parts ExpectedGoal = FilerNS.Parts.Goal;
            MapItem real = game.FindPlayer();
            FilerNS.Parts RealBox = game.WhatsAt(2, 2);
            FilerNS.Parts RealGoal = game.WhatsAt(1, 2);


            Assert.AreEqual(expectedPlayerPosition, real, "didnt undo correctly");
            Assert.AreEqual(ExpectedBox, RealBox, "Box didnt move");
            Assert.AreEqual(ExpectedGoal, RealGoal, "Box on Goal didnt update to Goal");
        }
        
        
        [TestMethod]
        public void CheckUndoWorksWithPlayerAndGoal() //need to find previous move, then move player in opposite direction
        {
            GameNS.Game game = new Game(null);
            game.Load(undoGoalTest);
            game.MakeMap();
            game.Move(Direction.Up); //creating move list
            MapItem expectedPlayerPosition = game.Map.Items[17];
            FilerNS.Parts ExpectedEmpty = FilerNS.Parts.Empty;
            FilerNS.Parts ExpectedGoal = FilerNS.Parts.Goal;

            game.Undo();
            
            MapItem real = game.FindPlayer();
            FilerNS.Parts RealEmpty = game.WhatsAt(2, 2);
            FilerNS.Parts RealGoal = game.WhatsAt(1, 2);


            Assert.AreEqual(expectedPlayerPosition, real, "didnt undo correctly");
            Assert.AreEqual(ExpectedEmpty, RealEmpty, "Old Player Pos didnt update to Empty");
            Assert.AreEqual(ExpectedGoal, RealGoal, "Goal moved");

        }

        [TestMethod]
        public void CheckUndoWorksWithPlayerOntoGoal() //test what happens when player moves back onto goal
        {
            GameNS.Game game = new Game(null);
            game.Load(playermoveoffgoalleveltest);
            game.MakeMap();
            game.Move(Direction.Up);//creating move lis
            MapItem expectedPlayerPosition = game.Map.Items[12];
            FilerNS.Parts ExpectedType = FilerNS.Parts.PlayerOnGoal;
            FilerNS.Parts ExpectedEmpty = FilerNS.Parts.Empty;

            game.Undo();

            MapItem real = game.FindPlayer();
            FilerNS.Parts RealEmpty = game.WhatsAt(1, 2);
            FilerNS.Parts RealType = game.WhatsAt(real.CordX, real.CordY);

            Assert.AreEqual(expectedPlayerPosition, real, "didnt undo correctly.");
            Assert.AreEqual(ExpectedEmpty, RealEmpty, "Old Player Pos didnt update to Empty");
            Assert.AreEqual(ExpectedType, RealType, "Didnt  Update Type");
        }                               


        [TestMethod]
        public void CheckUndoWallTest()
        {
            GameNS.Game game = new Game(null);
            game.Load(wallleveltest);
            game.MakeMap();
            game.Move(Direction.Down);
            game.Move(Direction.Up);

            MapItem expectedPlayerPosition = game.Map.Items[17];
            FilerNS.Parts ExpectedEmpty = FilerNS.Parts.Empty;
            FilerNS.Parts ExpectedWall = FilerNS.Parts.Wall;

            game.Undo();

            MapItem real = game.FindPlayer();
            FilerNS.Parts RealEmpty = game.WhatsAt(2, 2);
            FilerNS.Parts RealWall = game.WhatsAt(1, 2);


            Assert.AreEqual(expectedPlayerPosition, real, "didnt undo correctly");
            Assert.AreEqual(ExpectedEmpty, RealEmpty, "Old Player Pos didnt update to Empty");
            Assert.AreEqual(ExpectedWall, RealWall, "Goal moved");

        }

        [TestMethod]
        public void GameStart() // to initialise Map class //need to fix
        {
            GameNS.Game game = new Game(null);
            game.Load(leveltext);
            game.MakeMap();
            Map expectedMap = game.Map;
            Map realMap = game.Map;

            Assert.AreEqual(expectedMap, realMap, "Map not created");
        }

        [TestMethod]
        public void FindNormalPlayer() // to find Player if not on Goal
        {
            GameNS.Game game = new Game(null);
            game.Load(leveltext);
            game.MakeMap();
            MapItem expected = game.Map.Items[163]; //location of Player
            MapItem real = game.FindPlayer();

            Assert.AreEqual(expected, real, "Not the right move count");
        }

        [TestMethod]
        public void FindPlayerOnGoal() // to find Player is on Goal AKA '+' symbol test
        {
            GameNS.Game game = new Game(null);
            game.Load(playermoveoffgoalleveltest);
            game.MakeMap();
            MapItem expected = game.Map.Items[12]; //location of Player On Goal
            MapItem real = game.FindPlayer();
            Assert.AreEqual(expected, real, "Player Not Found");

        }

        [TestMethod]
        public void WhatsAtWorks() // to see if the function works
        {
            GameNS.Game game = new Game(null);
            game.Load(leveltext);
            game.MakeMap();
            FilerNS.Parts expected = FilerNS.Parts.Wall;

            FilerNS.Parts real = game.WhatsAt(0, 2);


            Assert.AreEqual(expected, real, "Wrong Part found");
        }

        public string WhatsAtEmptyTest = "##P##" +
                                        ",# * #" +
                                        ",# + #" +
                                        ",#   #" +
                                        ",#####";

        [TestMethod]
        public void WhatsAtReturnsEmpty() // if foreign character found return empty
        {
            GameNS.Game game = new Game(null);
            game.Load(WhatsAtEmptyTest);
            game.MakeMap();
            FilerNS.Parts expected = FilerNS.Parts.Empty;

            FilerNS.Parts real = game.WhatsAt(0, 2);


            Assert.AreEqual(expected, real, "Wrong Part found");
        }

        [TestMethod]
        public void MovePlayerUp() // to move player up
        {
            GameNS.Game game = new Game(null);
            game.Load(moveleveltest);
            game.MakeMap();
            game.Move(Direction.Up);
            MapItem expectedPlayerPosition = game.Map.Items[7]; //new location of Player
            MapItem real = game.FindPlayer();

            Assert.AreEqual(expectedPlayerPosition, real, "Player didnt move up");
        }

        [TestMethod]
        public void MovePlayerDown() // to move player Down
        {
            GameNS.Game game = new Game(null);
            game.Load(moveleveltest);
            game.MakeMap();
            game.Move(Direction.Down);
            MapItem expectedPlayerPosition = game.Map.Items[17]; //new location of Player
            MapItem real = game.FindPlayer();

            Assert.AreEqual(expectedPlayerPosition, real, "Player didnt move down");
        }

        [TestMethod]
        public void MovePlayerAddsDirectionToList() // to test if Direction List Works
        {
            GameNS.Game game = new Game(null);
            game.Load(moveleveltest);
            game.MakeMap();
            List<Direction> Expected = new List<Direction> { Direction.Up, Direction.Left };
            string expectedList = string.Join(",", Expected.ToArray());

            game.Move(Direction.Up);
            game.Move(Direction.Left);
            string real = game.GetMoveHistory();

            Assert.AreEqual(expectedList, real, "List didnt update with right moves");
        }

        [TestMethod]
        public void MovePlayerAddsToMoveCount() // to test if MoveCount Works
        {
            GameNS.Game game = new Game(null);
            game.Load(moveleveltest);
            game.MakeMap();
            int expected = 2;

            game.Move(Direction.Up);
            game.Move(Direction.Left);
            int real = game.GetMoveCount();

            Assert.AreEqual(expected, real, "List didnt update with right moves");
        }

        [TestMethod]
        public void MovePlayerLeft() // to move player Left
        {
            GameNS.Game game = new Game(null);
            game.Load(moveleveltest);
            game.MakeMap();
            game.Move(Direction.Left);
            MapItem expectedPlayerPosition = game.Map.Items[11]; //new location of Player
            MapItem real = game.FindPlayer();

            Assert.AreEqual(expectedPlayerPosition, real, "Player didnt move left");
        }

        [TestMethod]
        public void MovePlayerRight() // to move player Right
        {
            GameNS.Game game = new Game(null);
            game.Load(moveleveltest);
            game.MakeMap();
            game.Move(Direction.Right);
            MapItem expectedPlayerPosition = game.Map.Items[13]; //new location of Player
            MapItem real = game.FindPlayer();

            Assert.AreEqual(expectedPlayerPosition, real, "Player didnt move right");
        }

        [TestMethod]
        public void MovePlayerOntoGoal() // to move player onto Goal
        {
            GameNS.Game game = new Game(null);
            game.Load(playerongoalleveltest);
            game.MakeMap();
            game.Move(Direction.Up);
            MapItem expectedPlayerPosition = game.Map.Items[7]; //new location of Player On Goal
            MapItem real = game.FindPlayer();

            Assert.AreEqual(expectedPlayerPosition, real, "Player didnt move onto Goal and update");
        }

        [TestMethod]
        public void MovePlayerOffGoal() // to move player off Goal and update that floor to goal (and
                                        //player from + to @)
        {
            GameNS.Game game = new Game(null);
            game.Load(playermoveoffgoalleveltest);
            game.MakeMap();
            game.Move(Direction.Up);
            MapItem expectedPlayerPosition = game.Map.Items[7]; //new location of Player Off Goal
            FilerNS.Parts expectedPlayerSign = FilerNS.Parts.Player;


            MapItem real = game.FindPlayer();
            FilerNS.Parts realPlayerSign = game.WhatsAt(1, 2);

            Assert.AreEqual(expectedPlayerPosition, real, "Player didnt move off Goal and update");
            Assert.AreEqual(expectedPlayerSign, realPlayerSign, "Sign didnt Update");
        }
        public string boundsleveltest = "## ##" +
                                        ",#   #" +
                                        ",# @ #" +
                                        ",#   #" +
                                        ",#####";

        [TestMethod]
        public void CantMovePlayerOutOfBounds() // if no wall box cant fall off map boundry
        {
            GameNS.Game game = new Game(null);
            game.Load(boundsleveltest);
            game.MakeMap();
            game.Move(Direction.Up);
            game.Move(Direction.Up);
            game.Move(Direction.Up);
            MapItem expectedPlayerPosition = game.Map.Items[2]; //new location of Player Off Goal
            FilerNS.Parts expectedPlayerSign = FilerNS.Parts.Player;


            MapItem real = game.FindPlayer();
            FilerNS.Parts realPlayerSign = game.WhatsAt(0, 2);

            Assert.AreEqual(expectedPlayerPosition, real, "Player didnt move correctly");
            Assert.AreEqual(expectedPlayerSign, realPlayerSign, "Sign didnt Update");
        }

        [TestMethod]
        public void CantMoveBoxOutOfBounds() // if no wall box cant fall off map boundry
        {
            GameNS.Game game = new Game(null);
            game.Load(boxleveltest);
            game.MakeMap();
            game.Move(Direction.Up);
            game.Move(Direction.Up);
            game.Move(Direction.Up);
            MapItem expectedPlayerPosition = game.Map.Items[7]; //new location of Player Off Goal
            FilerNS.Parts expectedBox = FilerNS.Parts.Block;
            FilerNS.Parts expectedPlayerSign = FilerNS.Parts.Player;


            MapItem real = game.FindPlayer();
            FilerNS.Parts realPlayerSign = game.WhatsAt(1, 2);
            FilerNS.Parts realBox = game.WhatsAt(0, 2);

            Assert.AreEqual(expectedPlayerPosition, real, "Player didnt move correctly");
            Assert.AreEqual(expectedPlayerSign, realPlayerSign, "Sign didnt Update");
            Assert.AreEqual(expectedBox, realBox, "Box moved outofbounds");
        }


        [TestMethod]
        public void CantMovePlayer() // if a wall or something in box way / cant move
        {
            GameNS.Game game = new Game(null);
            game.Load(wallleveltest);
            game.MakeMap();
            game.Move(Direction.Up);
            FilerNS.Parts expectedWallType = FilerNS.Parts.Wall; //unchanged location of Wall!
            MapItem expectedPlayerPosition = game.Map.Items[12]; //new / unchanged location of Player

            FilerNS.Parts wallCheck = game.WhatsAt(1, 2);
            MapItem realPlayer = game.FindPlayer();

            Assert.AreEqual(wallCheck, expectedWallType, "The Wall has changed");
            Assert.AreEqual(expectedPlayerPosition, realPlayer, "Player Updated when it shouldnt");
        }

        [TestMethod]
        public void MoveBox() // to move box if beside player up
        {
            GameNS.Game game = new Game(null);
            game.Load(boxleveltest);
            game.MakeMap();
            game.Move(Direction.Up);
            FilerNS.Parts expectedBoxType = FilerNS.Parts.Block; //new location of Box
            MapItem expectedPlayerPosition = game.Map.Items[7]; //new location of Player

            FilerNS.Parts realBoxCheck = game.WhatsAt(0, 2);
            MapItem realPlayer = game.FindPlayer();

            Assert.AreEqual(expectedBoxType, realBoxCheck, "Box didnt update correctly");
            Assert.AreEqual(expectedPlayerPosition, realPlayer, "Player Didnt Update");
        }

        [TestMethod]
        public void MoveBoxOntoGoal() // to move box up if above player
        {
            GameNS.Game game = new Game(null);
            game.Load(goalleveltest);
            game.MakeMap();
            game.Move(Direction.Up);
            FilerNS.Parts expectedBoxType = FilerNS.Parts.BlockOnGoal; //new location of BoxOnGoal
            MapItem expectedPlayerPosition = game.Map.Items[7]; //new location of Player

            FilerNS.Parts realBoxCheck = game.WhatsAt(0, 2);
            MapItem realPlayer = game.FindPlayer();

            Assert.AreEqual(expectedBoxType, realBoxCheck, "BoxOnGoal didnt update correctly");
            Assert.AreEqual(expectedPlayerPosition, realPlayer, "Player Didnt Update");
        }

        [TestMethod]
        public void MoveBoxOffGoal() // to move box off goal and up if above player
        {
            GameNS.Game game = new Game(null);
            game.Load(boxoffgoalleveltest);
            game.MakeMap();
            game.Move(Direction.Up);
            FilerNS.Parts expectedBoxType = FilerNS.Parts.Block; //new location of BoxOnGoal
            MapItem expectedPlayerPosition = game.Map.Items[12]; //new location of Player

            FilerNS.Parts realBoxCheck = game.WhatsAt(1, 2);
            MapItem realPlayer = game.FindPlayer();

            Assert.AreEqual(expectedBoxType, realBoxCheck, "BoxOnGoal didnt update correctly");
            Assert.AreEqual(expectedPlayerPosition, realPlayer, "Player Didnt Update");
        }

        [TestMethod]
        public void CantMoveBox() // if a wall or something in box way / cant move
        {
            GameNS.Game game = new Game(null);
            game.Load(boxcantmoveleveltest);
            game.MakeMap();
            game.Move(Direction.Up);
            FilerNS.Parts expectedBoxType = FilerNS.Parts.Block; //new / unchanged location of Box
            FilerNS.Parts expectedWallType = FilerNS.Parts.Wall; //unchanged location of Wall!
            MapItem expectedPlayerPosition = game.Map.Items[12]; //new / unchanged location of Player

            FilerNS.Parts realBoxCheck = game.WhatsAt(1, 2);
            FilerNS.Parts wallCheck = game.WhatsAt(0, 2);
            MapItem realPlayer = game.FindPlayer();

            Assert.AreEqual(wallCheck, expectedWallType, "The Wall has changed");
            Assert.AreEqual(expectedBoxType, realBoxCheck, "Box updated when it shouldnt");
            Assert.AreEqual(expectedPlayerPosition, realPlayer, "Player Updated when it shouldnt");
        }

        [TestMethod]
        public void IsFinishedWorks() // to see if all boxes on goal!
        {
            GameNS.Game game = new Game(null);
            game.Load(boxoffgoalleveltest);
            game.MakeMap();
            bool expected = true;

            bool real = game.IsFinished();

            Assert.AreEqual(expected, real, "Isfinished not Working");
        }

        [TestMethod]
        public void IsFinishedTestPlayerOnGoal()
        {
            GameNS.Game game = new Game(null);
            game.Load(levelfinished);
            game.MakeMap();
            bool expected = false;


            bool real = game.IsFinished();

            Assert.AreEqual(expected, real, "Isfinished not working for playerongoal");
        }

        [TestMethod]
        public void IsFinishedTestNotFinished()
        {
            GameNS.Game game = new Game(null);
            game.Load(moveleveltest);
            game.MakeMap();
            bool expected = false;


            bool real = game.IsFinished();

            Assert.AreEqual(expected, real, "Isfinished not working correctly");
        }

        [TestMethod]
        public void BoxMovedIsWorkingForFalse()
        {
            GameNS.Game game = new Game(null);
            game.Load(moveleveltest);
            game.MakeMap();
            int expected = 1;
            bool expectedBool = false;

            game.Move(Direction.Up);

            int real = game.BoxMoved.Count;
            bool realBool = game.BoxMoved[0];

            Assert.AreEqual(expected, real, "Isfinished not working correctly");
            Assert.AreEqual(expectedBool, realBool, "not correct value");
        }

        [TestMethod]
        public void BoxMovedIsWorkingForTrue()
        {
            GameNS.Game game = new Game(null);
            game.Load(boxleveltest);
            game.MakeMap();
            int expected = 1;
            bool expectedBool = true;

            game.Move(Direction.Up);

            int real = game.BoxMoved.Count;
            bool realBool = game.BoxMoved[0];

            Assert.AreEqual(expected, real, "Isfinished not working correctly");
            Assert.AreEqual(expectedBool, realBool, "not correct value");
        }

        



    }
}


