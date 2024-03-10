using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    /// <summary>
    /// Класс, содержащий в себе все данные для вычисления параметра персонажа
    /// </summary>
    public class Derivative
    {
        #region _____________________ПОЛЯ_____________________
        //
        private float[] _variables = new float[] { 0, 1, 0, 1, 0, 1, 0 };

        //
        public float FinalValue { get; private set; }
        #endregion

        #region ______________________КОНСТРУКТОР______________________
        /// <summary>
        /// Конструктор производного параметра.
        /// </summary>
        /// <param name="baseVaalue">Базовое значение производного параметра.</param>
        public Derivative(float baseVaalue) { _variables[0] = baseVaalue; SetFinalValue(); }
        #endregion

        #region ______________________СВОЙСТВА______________________
        //Установить новое базовое значение
        public float BaseValue { set { _variables[0] = value; SetFinalValue(); } }

        //Геттер и сеттер для некоторых "Current" производых
        public float CurrentValue { get { return FinalValue; } set { FinalValue = value; } }
        #endregion

        #region _____________________МЕТОДЫ_____________________
        /// <summary>
        /// Произвести перерассчет итогового значения производной
        /// </summary>
        private void SetFinalValue()
        {
            FinalValue = ((_variables[0] * _variables[1] + _variables[2]) * _variables[3] + _variables[4]) * _variables[5] + _variables[6];
        }

        /// <summary>
        /// Изменить значение одной из переменнхы, участвующих в рассчете финального значения производной.
        /// </summary>
        /// <param name="variable">Имя переменной.</param>
        /// <param name="value">Значение, на которое производится изменение.</param>
        public void ChangeVariable(EVariable variable, float value)
        {
            _variables[(int)variable] += value;
            SetFinalValue();
        }
        #endregion
    }
}
