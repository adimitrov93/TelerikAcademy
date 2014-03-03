using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public class AdvancedInteractionMenager : InteractionManager
    {
        public AdvancedInteractionMenager()
            : base()
        {

        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person;

            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    person = base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
            }

            return person;
        }

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }

            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location;

            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    location = base.CreateLocation(locationTypeString, locationName);
                    break;
            }

            return location;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(actor, commandWords[2]);
                    break;
                case "craft":
                    HandleCraftInteraction(actor, commandWords[2], commandWords[3]);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        private void HandleGatherInteraction(Person actor, string itemName)
        {
            var actorLocation = actor.Location as IGatheringLocation;

            if (actorLocation != null)
            {
                if (actor.ListInventory().Any(item => item.ItemType == actorLocation.RequiredItem))
                {
                    Item item = actorLocation.ProduceItem(itemName);

                    this.AddToPerson(actor, item);
                }
            }
        }

        private void HandleCraftInteraction(Person actor, string itemType, string itemName)
        {
            if (itemType == "armor")
            {
                if (actor.ListInventory().Any(item => item.ItemType == ItemType.Iron))
                {
                    Item item = new Armor(itemName);

                    this.AddToPerson(actor, item);
                }
            }
            else if (itemType == "weapon")
            {
                if (actor.ListInventory().Any(item => item.ItemType == ItemType.Iron) &&
                    actor.ListInventory().Any(item => item.ItemType == ItemType.Wood))
                {
                    Item item = new Weapon(itemName);

                    this.AddToPerson(actor, item);
                }
            }
        }
    }
}
