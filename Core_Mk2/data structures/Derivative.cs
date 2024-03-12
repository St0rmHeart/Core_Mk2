using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    /// <summary>
    /// Абстрактный предок любого параметра, содержащий общие черты потомков.
    /// </summary>
    public abstract class Parameter
    {
        #region _____________________ПОЛЯ_____________________
        //Массив переменных для рассчета FinalValue, переменные массива соотносятся с перменными в рассчетной формуле конечного значения парамтра.
        protected float[] _variables = new float[] { 0, 1, 0, 1, 0, 1, 0 };

        //Итоговое значение параметра
        public float FinalValue { get; private set; }
        #endregion

        #region ______________________СВОЙСТВА______________________
        //Геттер и сеттер для некоторых "Current" производых
        public float CurrentValue { get { return FinalValue; } set { FinalValue = value; } }
        #endregion

        #region _____________________МЕТОДЫ_____________________
        /// <summary>
        /// Произвести перерассчет итогового значения производной
        /// </summary>
        protected void SetFinalValue()
        {
            FinalValue = ((_variables[0] * _variables[1] + _variables[2]) * _variables[3] + _variables[4]) * _variables[5] + _variables[6];
        }

        /// <summary>
        /// Изменить значение одной из переменных, участвующих в рассчете финального значения производной.
        /// </summary>
        /// <param name="variable">Имя переменной.</param>
        /// <param name="value">Значение, на которое производится изменение.</param>
        public abstract void ChangeVariable(EVariable variable, float value);
        #endregion
    }
    /// <summary>
    /// Параметр, используемый для оперирования только с <see cref="EDerivative.Value"/> у каждой из <see cref="ECharacteristic"/>.
    /// Имеет возможность подписывать на событие своего изменения <see cref="CommonParameter"/>
    /// </summary>
    public class ValueParameter : Parameter
    {
        #region _____________________EVENT_____________________
        /// <summary>
        /// Событие изменеия значения поля <see cref="Parameter.FinalValue"/> у <see cref="ValueParameter"/>.
        /// </summary>
        public event EventHandler ValueDerivativeUpdate;
        #endregion

        #region ______________________КОНСТРУКТОР______________________
        /// <summary>
        /// Конструктор <see cref="ValueParameter"/>, просто присваивающий в <see cref="EVariable.A0"/> значение какой-либо характеристики <see cref="Character"/>.
        /// </summary>
        /// <param name="baseValue">Значение характеристики.</param>
        public ValueParameter(float baseValue)
        {
            _variables[0] = baseValue;
            SetFinalValue();
        }
        #endregion

        #region _____________________МЕТОДЫ_____________________
        /// <summary>
        /// Реализует изменение любой из переменных для рассчета <see cref="Parameter.FinalValue"/> с его динамическим изменением и уведомлением всех подписанных <see cref="CommonParameter"/>.
        /// </summary>
        /// <param name="variable">Имя переменой, которую нужно изменить.</param>
        /// <param name="value">Величина изменения.</param>
        /// <exception cref="ArgumentOutOfRangeException">В случае если переданы невозможные значения <see cref="EVariable.None"/> или <see cref="EVariable.A0"/></exception>
        public override void ChangeVariable(EVariable variable, float value)
        {
            if (variable == EVariable.None || variable == EVariable.A0) throw new ArgumentOutOfRangeException("Значение " + nameof(variable) + " недопустимо.");
            _variables[(int)variable - 1] += value;
            SetFinalValue();
            ValueDerivativeUpdate?.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }

    /// <summary>
    /// Параметр, используемый для оперирования с любой <see cref="EDerivative"/>, кроме <see cref="EDerivative.Value"/> у каждой из <see cref="ECharacteristic"/>.
    /// Может подписываться на событие изменения <see cref="ValueParameter"/> и динамически обновлять совё значение при изменили любого из отслеживаемых <see cref="ValueParameter"/>.
    /// </summary>
    public class CommonParameter : Parameter
    {
        #region _________________________ПОЛЯ_________________________
        //CommonParameter знает о том, к какой производной какой характеристики он пренадлежит, а так же имеет ссылки на все ValueParameter.
        //
        public ECharacteristic Characteristic { get; private set; }
        //
        public EDerivative Derivative { get; private set; }
        //
        public Dictionary<ECharacteristic, ValueParameter> DerivativeValueValues { get; private set; }
        #endregion

        #region ______________________КОНСТРУКТОР______________________
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
            DerivativeValueValues = derivativeValueValues;
            Characteristic = characteristic;
            Derivative = derivative;
            UpdateA0(this, EventArgs.Empty);
            //получение списка всех ValueParameter, на которые нужно подписаться
            var subscriptionsList = ENUMS_STATIC_DATA.derivative_Subscriptions[characteristic][derivative];
            foreach (var subscription in subscriptionsList)
            {
                derivativeValueValues[subscription].ValueDerivativeUpdate += UpdateA0;
            }
        }
        #endregion

        #region _____________________МЕТОДЫ_____________________
        /// <summary>
        /// Обновляет значение переменной <see cref="EVariable.A0"/>, используя актуальные значения всех <see cref="ValueParameter"/>.
        /// </summary>
        public void UpdateA0(object sender, EventArgs args)
        {
            float NewA0 = DerivativesCalculator.CalculateNewA0(this);
            _variables[0] = NewA0;
            SetFinalValue();
        }

        /// <summary>
        /// Реализует изменение любой из переменных для рассчета <see cref="Parameter.FinalValue"/> с его динамическим изменением.
        /// </summary>
        /// <param name="variable">Имя переменой, которую нужно изменить.</param>
        /// <param name="value">Величина изменения.</param>
        /// <exception cref="ArgumentOutOfRangeException">В случае если переданы невозможные значения <see cref="EVariable.None"/> или <see cref="EVariable.A0"/></exception>
        public override void ChangeVariable(EVariable variable, float value)
        {
            if (variable == EVariable.None || variable == EVariable.A0) throw new ArgumentOutOfRangeException("Значение " + nameof(variable) + " недопустимо.");
            _variables[(int)variable - 1] += value;
            SetFinalValue();
        }
        #endregion
    }
}
