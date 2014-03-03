﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public class Wood : Item
    {
        private const int GeneralWoodValue = 2;

        public Wood(string name, Location location = null)
            : base(name, Wood.GeneralWoodValue, ItemType.Wood, location)
        {

        }

        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction == "drop")
            {
                if (this.Value > 0)
                {
                    Value--;
                }
            }
            
            base.UpdateWithInteraction(interaction);
        }
    }
}
