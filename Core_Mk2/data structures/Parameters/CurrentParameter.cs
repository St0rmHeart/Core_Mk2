using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    /// <summary>
    /// Параметр, используемый для оперирования с <see cref="EDerivative.CurrentHealth"/> и <see cref="EDerivative.CurrentMana"/>
    /// </summary>
    public class CurrentParameter : Parameter
    {
        /// <summary>
        /// Сонструктор задающий А0
        /// </summary>
        /// <param name="derivativeValueValues">Ссылки на все <see cref="ValueParameter"/> персонажа.</param>
        /// <param name="characteristic">Характеристика <see cref="ECharacteristic"/>, к корторой относится данный <see cref="CommonParameter"/></param>
        /// <param name="derivative">Производная <see cref="EDerivative"/>, к корторой относится данный <see cref="CommonParameter"/></param>
        public CurrentParameter(Dictionary<ECharacteristic, ValueParameter> derivativeValueValues,
            ECharacteristic characteristic,
            EDerivative derivative) : base()
        {
            _variables[0] = CalculatorA0.GetModule(characteristic, derivative, derivativeValueValues).CalculateA0();
        }

        #region ______________________СВОЙСТВА______________________
        //Геттер и сеттер для "Current" производых
        public float CurrentValue { get { return FinalValue; } set { FinalValue = value; } }
        #endregion
    }
}
