using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazegame.Entity.Utility
{
    public class NonPlayerCharacterCollection 
    {
        private  Dictionary<string, NonPlayerCharacter> characterList;

        public NonPlayerCharacterCollection() : base()
        {
            characterList = new Dictionary<string, NonPlayerCharacter>();
        }

        public override string ToString()
        {
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Append("Characters ::");
            if (characterList.Count == 0)
                returnMsg.Append(" No characters");
            else
            {
                foreach (string name in characterList.Keys)
                    returnMsg.Append(" << " + name + " >>");
            }
            
            return returnMsg.ToString();
        }

        public void AddNonPlayerCharacter(NonPlayerCharacter theNPC)
        {
            characterList.Add(theNPC.Name, theNPC);
        }

        public bool RemoveNonPlayerCharacter(string name)
        {
            return characterList.Remove(name);
        }

        public bool IsHostile(String nameToFind)
        {

            foreach (string name in characterList.Keys)
                if (name == nameToFind && this.characterList[nameToFind].Hostile)
                    return true;
            return false;
        }

        public bool HasHostile()
        {

            foreach (NonPlayerCharacter npc in characterList.Values)
                if (npc.Hostile)
                    return true;
            return false;
        }

    }
}