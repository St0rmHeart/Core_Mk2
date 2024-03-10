using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    /// <summary>
    /// Класс, в хором хранится вся информация, определющая персонажа
    /// </summary>
    public partial class Character
    {
        #region _____________________ПОЛЯ_____________________

        //границы перехода на новый уровень
        public static readonly int[] levelBoundaries = { 0, 100, 150, 250, 400, 600, 900, 1400, 2000, 2800, 3700 };
        //имя 
        public string Name { get; private set; }
        //уровень 
        public int Level { get; private set; }
        //накопленный опыт на уровне 
        public int Xp { get; set; }
        //накопленное золото+
        public int Gold { get; set; }
        //количество очков характеристик (за каждый уровень даётся 4 очка)
        private int _charPoints;

        //базовые характеристики
        public Dictionary<ECharacteristic, int> Characteristics { get; private set; } = new Dictionary<ECharacteristic, int>();
        //итератор по характеристикам
        public int this[ECharacteristic characteristic]
        {
            get { return Characteristics[characteristic]; }
            set { Characteristics[characteristic] = value; }
        }

        //используемые перки
        //private List<Perk> usedPerks = new List<Perk>();

        //носимое снаряжение
        public Dictionary<EBodyPart, Equipment> Equipment { get; private set; } = new Dictionary<EBodyPart, Equipment>();
        //итератор по снаряжению
        public Equipment this[EBodyPart bodyPart]
        {
            get
            {
                //возвращает предмет саряжения, либо null если в указанной ячейке ничего не одето
                if (Equipment.ContainsKey(bodyPart)) return Equipment[bodyPart];
                else return null;
            }
            set
            {
                switch ((value != null, Equipment.ContainsKey(bodyPart)))
                {
                    //если в указанной ячейку уже что-то одето - устанавливается ссылка на новый объект снаряжения 
                    case (true, true): Equipment[bodyPart] = value; break;
                    //если указаная ячейка пустая - в неё одевается снаряжение
                    case (true, false): Equipment.Add(bodyPart, value); break;
                }
            }
        }

        //используемые заклинания
        //private List<Spell> usedSpells = new List<Spell>();
        #endregion

        #region _____________________КОНСТРУКТОР_____________________
        /// <summary>
        /// Базовый конструктор персонажа.
        /// </summary>
        /// <param name="name">Имя персонажа</param>
        private Character(string name)
        {
            Name = name;
            Level = 1;
            foreach (ECharacteristic characteristic in ENUMS_STATIC_DATA.ECHARACTERISTIC)
            {
                Characteristics.Add(characteristic, 0);
            }
        }
        #endregion

        #region _____________________МЕТОДЫ_____________________

        /// <summary>
        /// Начислить персонажу опыт
        /// </summary>
        /// <param name="exp">количество начисляемого опыта</param>
        public void AddExp(int exp)
        {
            Xp += exp;
            while (Xp >= levelBoundaries[Level])
            {
                Level++;
                _charPoints += 4;
            }
        }
        #endregion
    }
}
