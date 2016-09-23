using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity.Utility;

namespace Mazegame.Entity
{
   public  class FiniteInventory:Inventory
    {
       private int weightLimit;

       public FiniteInventory(int weightLimit)
           : base()
       {
           this.weightLimit = weightLimit;
       }

       public int GetWeightLimit()
       {
           return weightLimit;
       }

      // public void Setweight(int weight)
      // {
       //    weightLimit = WeightLimit.GetInstance().GetModifier(weightLimit);
      // }

       public double GetTotalWeightInHand()
       {
           double currentWeight = 0;
           foreach (Item theItem in this.itemList.Values)
           {
               currentWeight += theItem.Weight;
           }
           return currentWeight;
       }

       public override bool AddItem(Item theItem)
       {
          /// Console.WriteLine("weightLimit = "+weightLimit);
           if (weightLimit > theItem.Weight + GetTotalWeightInHand())
               return base.AddItem(theItem);
           return false;
       }

    }
}
