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
        /// Структура: Характеристика <see cref="ECharacteristic"/>, её производная <see cref="EDerivative"/>, значение, представляемое <see cref="Derivative"/>
        /// </summary>
        private Dictionary<ECharacteristic, Dictionary<EDerivative, Derivative>> _statList = new Dictionary<ECharacteristic, Dictionary<EDerivative, Derivative>>();
        #endregion

        #region _____________________КОНСТРУКТОР_____________________
        /// <summary>
        /// Конструктор перечисления всех производных всех характеристик
        /// </summary>
        /// <param name="character"></param>
        public DerivativesEnumeration(Character character)
        {
            Dictionary<ECharacteristic, int> characteristicDictionary = new Dictionary<ECharacteristic, int>(character.Characteristics);

            foreach (ECharacteristic characteristic in ENUMS_STATIC_DATA.CHAR_DER_PAIRS.Keys)
            {
                _statList.Add(characteristic, new Dictionary<EDerivative, Derivative>());
                float A0 = DerivativesCalculator.Get_A0(characteristicDictionary, characteristic, EDerivative.Value);
                _statList[characteristic].Add(EDerivative.Value, new Derivative(A0));
            }

            characteristicDictionary.Clear();

            foreach (ECharacteristic characteristic in ENUMS_STATIC_DATA.CHAR_DER_PAIRS.Keys)
            {
                characteristicDictionary.Add(characteristic, (int)_statList[characteristic][EDerivative.Value].FinalValue);
            }

            foreach (ECharacteristic characteristic in ENUMS_STATIC_DATA.CHAR_DER_PAIRS.Keys)
            {
                List<EDerivative> derList = ENUMS_STATIC_DATA.CHAR_DER_PAIRS[characteristic];
                derList.Remove(EDerivative.Value);
                foreach (EDerivative derivative in ENUMS_STATIC_DATA.CHAR_DER_PAIRS[characteristic])
                {
                    float A0 = DerivativesCalculator.Get_A0(characteristicDictionary, characteristic, derivative);
                    _statList[characteristic].Add(derivative, new Derivative(A0));
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
        public Dictionary<EDerivative, Derivative> this[ECharacteristic characteristic]
        {
            get { return _statList[characteristic]; }
        }
        #endregion
    }
}
