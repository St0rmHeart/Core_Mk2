using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    public static partial class EquipmentData
    {
        public static List<Equipment> Equipment { get; private set; } = new List<Equipment>();
        static EquipmentData()
        {
            WeaponInit();
            Equipment.AddRange(_equipmentWeapon);
        }
    }
}
