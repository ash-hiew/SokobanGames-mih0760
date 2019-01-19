using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNS{
    public class Map
    {
        public List<MapItem> Items { get; set; }
        public List<MapItem> Updates = new List<MapItem>();


        public Map(string[] level)
        {
            ResetMap(level);               
        }

        public void Update( int x, int y, char sign)
        {        
            var updateItem = Items.FirstOrDefault(item => item.PosX == x && item.PosY == y);
            if (updateItem == null)
            {
                //throw error
            }
            else
            {
                updateItem.Sign = sign;
                Updates.Add(updateItem);
            }
        }

        public void ResetMap(string []level)
        {
            Items = new List<MapItem>();
            int x = 0;
            foreach (string row in level)
            {
                int y = 0;
                foreach (char sign in row)
                {
                    Items.Add(new MapItem(x, y, sign));
                    y++;
                }
                x++;
            }
        }
    }
}
