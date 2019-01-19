using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LevelDesignNS;
using FileHandlerNS;

namespace Sokoban {
    public delegate void MapChangedHandler(object sender, MapChangedEventArgs e);
    public partial class MapChangedEventArgs : EventArgs
    {
        public Parts Part { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public bool Setting { get; set; }
        public bool Clear { get; set; }
        public bool Check { get; set; }
    }

    class LevelDesignController : ILevelDesignController
    {

        protected MapChangedHandler MapChanged;


        protected ILevelDesignView DesignView;
        protected ILevelDesigner DesignModel;

        public LevelDesignController(ILevelDesignView view, ILevelDesigner model)
        {
            DesignView = view;
            DesignModel = model;
            MapChanged = new MapChangedHandler(SetMap);
            DesignView.MapChanged += MapChanged;
        }

        private void SetMap(object sender, MapChangedEventArgs e)
        {
            if(e.Setting)
            {
                DesignModel.SetSize(e.CoordX, e.CoordY);
            }
            else if (e.Check)
            {
                DesignView.SetErrors(DesignModel.DisplayErrorMessages());
            }
            else
            {
                DesignModel.SetItem(e.Part);
                DesignModel.PlaceItem(e.CoordX, e.CoordY);
            }
        }


        public char[,] GetMap()
        {
            return DesignModel.GetMap();
        }

        public void Load(char[,] map)
        {
            if (map != null)
            {
                DesignModel.SetMap(map);
                DesignView.Loaded(map);
            }

        }

        public void Start(Form parent)
        {
            DesignView.Start(parent);
        }

        public void Stop()
        {
            DesignView.Stop();
        }
    }
}
