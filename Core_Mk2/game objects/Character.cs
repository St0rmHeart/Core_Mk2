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
                if (Equipment.ContainsKey(bodyPart))
                {
                    return Equipment[bodyPart];
                }
                else
                {
                    return null;
                }
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
            foreach (ECharacteristic characteristic in CONSTANT.CHAR_DER_PAIRS.Keys)
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
            while (Xp >= levelBoundaries[Level-1])
            {
                Level++;
                _charPoints += 4;
            }
        }
        #endregion

        #region СТРОИТЕЛЬ
        /// <summary>
        /// Строитель персонажа. Строитель кеширует настройки, устанавливаемые через его методы и может создавать персонажа по указанным настройкам.
        /// </summary>
        public class CBuilder
        {
            #region _____________________ПОЛЯ_____________________
            //имя
            private string _name;
            //опыт
            private int _xp;
            //характеристики
            private Dictionary<ECharacteristic, int> _characteristics = new Dictionary<ECharacteristic, int>();
            //снаряжение
            private Dictionary<EBodyPart, Equipment> _equipment = new Dictionary<EBodyPart, Equipment>();
            #endregion

            #region _____________________КОНСТРУКТОР_____________________
            /// <summary>
            /// Конструктр строителя персонажа. При вызове устанавливает параметры по умолчанию через Reset();
            /// </summary>
            public CBuilder()
            {
                Reset();
            }
            #endregion

            #region _____________________МЕТОДЫ_____________________
            /// <summary>
            /// Установить Имя персонажа
            /// </summary>
            /// <param name="name">Имя персонажа</param>
            /// <returns></returns>
            public CBuilder With_Name(string name)
            {
                //обработчик исключений
                if (name == null || name == "") throw new ArgumentNullException("Не введено имя персонажа");

                //
                _name = name;
                return this;
            }

            /// <summary>
            /// Установить очки опыта персонажа
            /// </summary>
            /// <param name="xp">Количество очков опыта</param>
            /// <returns></returns>
            public CBuilder With_XP(int xp)
            {
                //обработчик исключений
                if (xp < 0) throw new ArgumentOutOfRangeException("Опыт не может быть отрицательным");

                //
                _xp = xp;
                return this;
            }

            /// <summary>
            /// Установить значение характеристики
            /// </summary>
            /// <param name="characteristic">характеристика</param>
            /// <param name="value">Устанавливаемое значение</param>
            /// <returns></returns>
            public CBuilder With_Characteristic(ECharacteristic characteristic, int value)
            {
                //обработчик исключений
                if (value < 0) throw new ArgumentOutOfRangeException("Значение характеристики не может быть отрицательным");
                if (characteristic == ECharacteristic.None) throw new ArgumentOutOfRangeException("Недопустимое использование None.");

                //
                _characteristics[characteristic] = value;
                return this;
            }

            /// <summary>
            /// Установить снаряжение
            /// </summary>
            /// <param name="bodyPart">Ячейка снаряжения</param>
            /// <param name="equipment">Устанавливаемяй объект снаряжения</param>
            /// <returns></returns>
            public CBuilder With_Equipment(EBodyPart bodyPart, Equipment equipment)
            {
                //обработчик исключений
                if (bodyPart == EBodyPart.None) throw new ArgumentOutOfRangeException("Недопустимое использование None.");
                if (equipment == null) throw new ArgumentOutOfRangeException("Не указано снаряжение");

                //
                if (_equipment.ContainsKey(bodyPart))
                {
                    _equipment[bodyPart] = equipment;
                }
                else
                {
                    _equipment.Add(bodyPart, equipment);
                }
                return this;
            }

            /// <summary>
            /// Сборс настроек строителя в значения по умолчанию
            /// </summary>
            public CBuilder Reset()
            {
                _name = "";
                _xp = 0;
                _characteristics.Clear();
                foreach (ECharacteristic characteristic in CONSTANT.CHAR_DER_PAIRS.Keys)
                {
                    _characteristics.Add(characteristic, 0);
                }
                _equipment.Clear();
                return this;
            }

            /// <summary>
            /// Создать персонажа по указанным настройкам
            /// </summary>
            /// <returns></returns>
            public Character Build()
            {
                //обработчик исключений
                if (_name == "") throw new ArgumentNullException("В настройках не было указано имя персонажа");

                //
                var character = new Character(_name);
                character.AddExp(_xp);
                character.Characteristics = new Dictionary<ECharacteristic, int>(_characteristics);
                character.Equipment = new Dictionary<EBodyPart, Equipment>(_equipment);
                return character;
            }
            #endregion
        }
        #endregion
    }
}
