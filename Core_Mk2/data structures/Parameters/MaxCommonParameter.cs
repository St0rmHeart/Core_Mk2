using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    /// <summary>
    /// Параметр, используемый для оперирования с <see cref="EDerivative.MaxHealth"/> и <see cref="EDerivative.MaxMana"/>.
    /// При уменьшении своего значения, при необходимости уменьшает значение соответсвующего <see cref="CurrentParameter"/>.
    /// </summary>
    public class MaxCommonParameter : CommonParameter
    {
        public MaxCommonParameter(
            Dictionary<ECharacteristic, ValueParameter> derivativeValueValues,
            ECharacteristic characteristic,
            EDerivative derivative,
            CurrentParameter currentCommonParameter
            )
            : base(derivativeValueValues, characteristic, derivative) { _currentCommonParameter = currentCommonParameter; }
        private readonly CurrentParameter _currentCommonParameter;

        protected override void SetFinalValue()
        {
            FinalValue = ((_variables[0] * _variables[1] + _variables[2]) * _variables[3] + _variables[4]) * _variables[5] + _variables[6];
            if ( _currentCommonParameter != null && _currentCommonParameter.CurrentValue > FinalValue)
                _currentCommonParameter.CurrentValue = FinalValue;
        }
    }
}
