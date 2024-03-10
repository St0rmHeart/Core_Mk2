using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    public partial class Character
    {
        /// <summary>
        /// Строитель персонажа. Строитель кеширует настройки, устанавливаемые через его методы и может создавать персонажа по указанным настройкам.
        /// </summary>
        public class CharacterBuilder
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
            public CharacterBuilder() { Reset(); }
            #endregion

            #region _____________________МЕТОДЫ_____________________
            /// <summary>
            /// Установить Имя персонажа
            /// </summary>
            /// <param name="name">Имя персонажа</param>
            /// <returns></returns>
            public CharacterBuilder With_Name(string name)
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
            public CharacterBuilder With_XP(int xp)
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
            public CharacterBuilder With_Characteristic(ECharacteristic characteristic, int value)
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
            public CharacterBuilder WithEquipment(EBodyPart bodyPart, Equipment equipment)
            {
                //обработчик исключений
                if (bodyPart == EBodyPart.None) throw new ArgumentOutOfRangeException("Недопустимое использование None.");
                if (equipment == null) throw new ArgumentOutOfRangeException("Не указано снаряжение");

                //
                if (_equipment.ContainsKey(bodyPart))
                    _equipment[bodyPart] = equipment;
                else
                    _equipment.Add(bodyPart, equipment);
                return this;
            }

            /// <summary>
            /// Сборс настроек строителя в значения по умолчанию
            /// </summary>
            /// <returns></returns>
            public CharacterBuilder Reset()
            {
                _name = "";
                _xp = 0;
                _characteristics.Clear();
                foreach (ECharacteristic characteristic in ENUMS_STATIC_DATA.ECHARACTERISTIC)
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
    }
}
