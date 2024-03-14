using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    /// <summary>
    /// Параметр, используемый для оперирования с <see cref="EDerivative"/>
    /// Может подписываться на событие изменения <see cref="ValueParameter"/> и динамически обновлять совё значение при изменили любого из отслеживаемых <see cref="ValueParameter"/>.
    /// </summary>
    public class CommonParameter : Parameter
    {
        //модуль калькулятора, для рассчета А0
        private readonly CalculatorA0 _moduleA0;

        /// <summary>
        /// Конструктор, заполняющий все поля, определяющие функционирование параметра
        /// </summary>
        /// <param name="derivativeValueValues">Ссылки на все <see cref="ValueParameter"/> персонажа.</param>
        /// <param name="characteristic">Характеристика <see cref="ECharacteristic"/>, к корторой относится данный <see cref="CommonParameter"/></param>
        /// <param name="derivative">Производная <see cref="EDerivative"/>, к корторой относится данный <see cref="CommonParameter"/></param>
        public CommonParameter(
            Dictionary<ECharacteristic, ValueParameter> derivativeValueValues,
            ECharacteristic characteristic,
            EDerivative derivative)
        {
            _moduleA0 = CalculatorA0.GetModule(characteristic, derivative, derivativeValueValues);
            UpdateA0(this, EventArgs.Empty);
            //получение списка всех ValueParameter, на которые нужно подписаться
            var subscriptionsList = ENUMS_STATIC_DATA.derivative_Subscriptions[characteristic][derivative];
            foreach (var subscription in subscriptionsList)
            {
                derivativeValueValues[subscription].ValueDerivativeUpdate += UpdateA0;
            }
        }

        /// <summary>
        /// Обновляет значение переменной <see cref="EVariable.A0"/>, используя актуальные значения всех <see cref="ValueParameter"/>.
        /// </summary>
        public void UpdateA0(object sender, EventArgs args)
        {
            _variables[0] = _moduleA0.CalculateA0();
            SetFinalValue();
        }

    }
}
