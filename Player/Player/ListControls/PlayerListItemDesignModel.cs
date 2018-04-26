using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    public class PlayerListItemDesignModel : PlayerListItemViewModel
    {
        public static PlayerListItemDesignModel Instance => new PlayerListItemDesignModel();

        public PlayerListItemDesignModel()
        {
            Title = "Noname";
            TotalMinutes = 5.0;
            TotalSeconds = 30.0; 
            

        }


    }
}
