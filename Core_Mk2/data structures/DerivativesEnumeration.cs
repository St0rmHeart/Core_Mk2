using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    /// <summary>
    /// Универсальный класс с полем - двойным словарём - набором производных характеристик - и инструментами взаимодействия
    /// </summary>
    public partial class DerivativesEnumeration
    {
        #region _____________________ПОЛЯ_____________________
        /// <summary>
        /// Структура: Характеристика <see cref="ECharacteristic"/>, её производная <see cref="EDerivative"/>, значение, представляемое <see cref="Parameter"/>
        /// </summary>
        private Dictionary<ECharacteristic, Dictionary<EDerivative, Parameter>> _statList = new Dictionary<ECharacteristic, Dictionary<EDerivative, Parameter>>();
        #endregion

        #region _____________________КОНСТРУКТОР_____________________
        /// <summary>
        /// Конструктор перечисления всех производных всех характеристик
        /// </summary>
        /// <param name="character"></param>
        public DerivativesEnumeration(Character character)
        {
            //инициируем словарь для хранения всех DerivativeValue этотго персонажа, являющихся финальными значениями характеристик
            var derivativeValueValues = new Dictionary<ECharacteristic, ValueParameter >();
            //сперва заполняем значения всех характеристик в _statList
            foreach (ECharacteristic characteristic in ENUMS_STATIC_DATA.char_der_pairs.Keys)
            {
                //создаём в _statList новый словарь для характеристики characteristic
                _statList.Add(characteristic, new Dictionary<EDerivative, Parameter>());
                //создаём новый экземпляр DerivativeValue
                ValueParameter newDerivative = new ValueParameter(character[characteristic]);
                //помещаем ссылку на созданный экземпляр в _statList
                _statList[characteristic].Add(EDerivative.Value, newDerivative);
                //помещаем ссылку на созданный экземпляр в derivativeValueValues
                derivativeValueValues.Add(characteristic, newDerivative);
            }
            
            foreach (ECharacteristic characteristic in ENUMS_STATIC_DATA.char_der_pairs.Keys)
            {
                List<EDerivative> derList = ENUMS_STATIC_DATA.char_der_pairs[characteristic];
                derList.Remove(EDerivative.Value);
                foreach (EDerivative derivative in derList)
                {
                    _statList[characteristic].Add(derivative, new CommonParameter(derivativeValueValues, characteristic, derivative));
                }
            }
        }
        #endregion

        #region ______________________СВОЙСТВА______________________
        /// <summary>
        /// Итератор, дающий доступ к производным указанной характеристики
        /// </summary>
        /// <param name="characteristic">Характеристика, производные которой будут возвращены</param>
        /// <returns>Словарь производных указанной характеристики</returns>
        public Dictionary<EDerivative, Parameter> this[ECharacteristic characteristic]
        {
            get { return _statList[characteristic]; }
        }
        #endregion
    }
}
