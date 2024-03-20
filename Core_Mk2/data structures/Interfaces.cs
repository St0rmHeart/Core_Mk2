using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    public interface IEffect
    {
        public string Name { get; }
        public string Description { get; }
        public void Installation(CharacterSlot owner, CharacterSlot enemy);
        public IEffect Clone();
    }

    public interface ILogicalModule
    {
        public bool CheckCondition(CharacterSlot owner, CharacterSlot enemy);
    }
}