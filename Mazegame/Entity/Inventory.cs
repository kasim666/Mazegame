using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazegame.Entity
{
    public class Inventory
    {
        private Money gold;
        protected Dictionary<string, Item> itemList;


        public Inventory()
        {
            gold = new Money();
            itemList = new Dictionary<string, Item>();
        }

        public Money GetMoney()
        {

            return gold;
        }

        public void AddMoney(int goldPieces)
        {
            gold.Add(goldPieces);
        }

        public bool RemoveMoney(int goldPieces)
        {
            return gold.Subtract(goldPieces);
        }

        public virtual bool AddItem(Item theItem)
        {
             itemList[theItem.Label] = theItem;
            return true;
        }
        public Item FindItem(string itemName)
        {
             if (itemList.ContainsKey(itemName))
                  return itemList[itemName];
            return null;
        }
        public Item RemoveItem(string itemName)
        {

            if (itemList.ContainsKey(itemName))
            {
                Item theItem = itemList[itemName];
                itemList.Remove(itemName);
                return theItem;
            }
           return null;
        }

       
        public bool ContainsItem(string itemName)
        {
            if (itemList.ContainsKey(itemName))
                return true;
            else return false;
        }

        private string printItemList()
        {
            if (itemList.Count == 0)
                return "No items here";
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Append("Items here ::");
            foreach (string item in itemList.Keys)
            {
                returnMsg.Append(" [" + item + "]");
            }
            return returnMsg.ToString();
        }

        public override string ToString()
        {
            return printItemList() + "\n" + gold.ToString();
        }
    }

    public class ItemNotFoundException : Exception
    {
        private string message;

        public ItemNotFoundException()
            : base()
        {
        }

        public ItemNotFoundException(string message)
        {
            this.message = message;
        }

        public string GetMessage()
        {
            return this.message;
        }
    }
}
