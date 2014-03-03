using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public abstract class GatheringLocation : Location, IGatheringLocation
    {
        public GatheringLocation(string name, LocationType locationType, ItemType gatheringItemType, ItemType requiredGatheringType)
            : base(name, locationType)
        {
            this.GatheredType = gatheringItemType;
            this.RequiredItem = requiredGatheringType;
        }

        public ItemType GatheredType { get; private set; }

        public ItemType RequiredItem { get; private set; }

        public abstract Item ProduceItem(string name);
    }
}
