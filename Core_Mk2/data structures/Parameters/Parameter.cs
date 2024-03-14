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
        public float FinalValue { get; protected set; }
        #endregion


        #region _____________________МЕТОДЫ_____________________
        /// <summary>
        /// Произвести перерассчет итогового значения производной
        /// </summary>
        protected virtual void SetFinalValue()
        {
            FinalValue = ((_variables[0] * _variables[1] + _variables[2]) * _variables[3] + _variables[4]) * _variables[5] + _variables[6];
        }

        /// <summary>
        /// Изменить значение одной из переменных, участвующих в рассчете финального значения производной.
        /// </summary>
        /// <param name="variable">Имя переменной.</param>
        /// <param name="value">Значение, на которое производится изменение.</param>
        public virtual void ChangeVariable(EVariable variable, float value)
        {
            if (variable == EVariable.None || variable == EVariable.A0) throw new ArgumentOutOfRangeException("Значение " + nameof(variable) + " недопустимо.");
            _variables[(int)variable - 1] += value;
            SetFinalValue();
        }
        #endregion
    }
}
