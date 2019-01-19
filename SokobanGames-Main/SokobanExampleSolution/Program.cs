using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHandlerNS;
using GameNS;
using LevelDesignNS;
using System.Windows.Forms;

namespace Sokoban
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Game Player
            IGameView gameView = new GameFormView();
            Game gameModel = new Game();
            GameController gameController = new GameController(gameModel, gameView);
            GameBoardForm gameBoard = new GameBoardForm( gameView, gameController);

            // File Handler
            IFiler filer = new Filer();
            ISaver saver = (ISaver)filer;
            ILoader loader = (ILoader)filer;

            FilerForm filerView = new FilerForm();
            IGameFiler gameFiler = new GameFiler();            
            FilerController filerControl = new FilerController(saver, loader, filer, gameFiler, gameModel, filerView);

            // Level Designer
            ILevelDesignView designView = new LevelDesignerForm();
            IChecker designCheck = new Checker();
            ILevelDesigner designModel = new LevelDesigner(designCheck);

            ILevelDesignController designController = new LevelDesignController(designView, designModel);
            

            BaseForm baseForm = new BaseForm(gameBoard, filerControl, designController);
            Application.Run(baseForm);
        }
    }
}
