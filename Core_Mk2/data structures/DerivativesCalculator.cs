using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    /// <summary>
    /// Калькулятор производных
    /// </summary>
    public abstract class DerivativesCalculator
    {
        #region _________________________ПОЛЯ_________________________
        private readonly CommonParameter _derivative;
        protected Dictionary<ECharacteristic, ValueParameter> DerivativeValueValues { get { return _derivative.DerivativeValueValues; } }
        protected ECharacteristic Characteristic { get { return _derivative.Characteristic; } }
        protected EDerivative Derivative { get { return _derivative.Derivative; } }
        #endregion

        #region ______________________КОНСТРУКТОР______________________
        protected DerivativesCalculator(CommonParameter derivative) { _derivative = derivative; }
        #endregion

        #region _____________________МЕТОДЫ_____________________
        protected float GetCharacteristicValue(ECharacteristic characteristic)
        {
            return _derivative.DerivativeValueValues[characteristic].FinalValue;
        }

        /// <summary>
        /// Вычислят актуальное значение <see cref="EVariable.A0"/> указанного <see cref="CommonParameter"/> с учетом актуальных значений всех <see cref="ValueParameter"/>.
        /// </summary>
        /// <param name="derivative">Параметр, значение <see cref="EVariable.A0"/> которого необходимо рассчитать</param>
        /// <returns>Значение <see cref="EVariable.A0"/> переменной.</returns>
        public static float CalculateNewA0(CommonParameter derivative)
        {
            //определеяем, на какой модуль нам необходимо сослаться
            ECharacteristic currentCharacteristic = derivative.Characteristic;
            EDerivative currentDerivative = derivative.Derivative;

            //указание на подключение нужного модуля вычисления
            return (currentCharacteristic) switch
            {
                ECharacteristic.Strength => (currentDerivative) switch
                {
                    EDerivative.TerminationMult => new StrengthTerminationMultModule(derivative).CalculateDerivative(),
                    EDerivative.AddTurnChance => new StrengthAddTurnChanceModule(derivative).CalculateDerivative(),
                    EDerivative.Resistance => new StrengthResistanceModule(derivative).CalculateDerivative(),
                    _ => throw new NotImplementedException(),
                },
                ECharacteristic.Dexterity => (currentDerivative) switch
                {
                    EDerivative.TerminationMult => new DexterityTerminationMultModule(derivative).CalculateDerivative(),
                    EDerivative.AddTurnChance => new DexterityAddTurnChanceModule(derivative).CalculateDerivative(),
                    _ => throw new NotImplementedException(),
                },
                ECharacteristic.Endurance => (currentDerivative) switch
                {
                    EDerivative.TerminationMult => new EnduranceTerminationMultModule(derivative).CalculateDerivative(),
                    EDerivative.AddTurnChance => new EnduranceAddTurnChanceModule(derivative).CalculateDerivative(),
                    EDerivative.MaxHealth => new EnduranceMaxHealthModule(derivative).CalculateDerivative(),
                    EDerivative.CurrentHealth => new EnduranceMaxHealthModule(derivative).CalculateDerivative(),
                    _ => throw new NotImplementedException(),
                },
                ECharacteristic.Fire => (currentDerivative) switch
                {
                    EDerivative.TerminationMult => new FireTerminationMultModule(derivative).CalculateDerivative(),
                    EDerivative.AddTurnChance => new FireAddTurnChanceModule(derivative).CalculateDerivative(),
                    EDerivative.MaxMana => new FireMaxManaModule(derivative).CalculateDerivative(),
                    EDerivative.CurrentMana => new FireCurrentManaModule(derivative).CalculateDerivative(),
                    EDerivative.Resistance => new FireResistanceModule(derivative).CalculateDerivative(),
                    _ => throw new NotImplementedException(),
                },
                ECharacteristic.Water => (currentDerivative) switch
                {
                    EDerivative.TerminationMult => new WaterTerminationMultModule(derivative).CalculateDerivative(),
                    EDerivative.AddTurnChance => new WaterAddTurnChanceModule(derivative).CalculateDerivative(),
                    EDerivative.MaxMana => new WaterMaxManaModule(derivative).CalculateDerivative(),
                    EDerivative.CurrentMana => new WaterCurrentManaModule(derivative).CalculateDerivative(),
                    EDerivative.Resistance => new WaterResistanceModule(derivative).CalculateDerivative(),
                    _ => throw new NotImplementedException(),
                },
                ECharacteristic.Air => (currentDerivative) switch
                {
                    EDerivative.TerminationMult => new AirTerminationMultModule(derivative).CalculateDerivative(),
                    EDerivative.AddTurnChance => new AirAddTurnChanceModule(derivative).CalculateDerivative(),
                    EDerivative.MaxMana => new AirMaxManaModule(derivative).CalculateDerivative(),
                    EDerivative.CurrentMana => new AirCurrentManaModule(derivative).CalculateDerivative(),
                    EDerivative.Resistance => new AirResistanceModule(derivative).CalculateDerivative(),
                    _ => throw new NotImplementedException(),
                },
                ECharacteristic.Earth => (currentDerivative) switch
                {
                    EDerivative.TerminationMult => new EarthTerminationMultModule(derivative).CalculateDerivative(),
                    EDerivative.AddTurnChance => new EarthAddTurnChanceModule(derivative).CalculateDerivative(),
                    EDerivative.MaxMana => new EarthMaxManaModule(derivative).CalculateDerivative(),
                    EDerivative.CurrentMana => new EarthCurrentManaModule(derivative).CalculateDerivative(),
                    EDerivative.Resistance => new EarthResistanceModule(derivative).CalculateDerivative(),
                    _ => throw new NotImplementedException(),
                },
                _ => throw new NotImplementedException(),
            };
        }

        /// <summary>
        ///Производит рассчет <see cref="EVariable.A0"/> для <see cref="CalculateNewA0(CommonParameter)"/>.
        ///Метод переопределён для каждого уникального <see cref="CommonParameter"/>.
        /// </summary>
        public abstract float CalculateDerivative();
        #endregion
    }





    #region Потомки DerivativesCalculator
    /// <summary>
    /// Производит рассчет <see cref="EVariable.A0"/> параметра MaxHealth
    /// </summary>
    public class EnduranceMaxHealthModule : DerivativesCalculator
    {
        public EnduranceMaxHealthModule(CommonParameter derivative) : base(derivative) { }

        public override float CalculateDerivative()
        {
            float charValue = GetCharacteristicValue(Characteristic);
            charValue = 20 + 1.2f * charValue + (float)Math.Pow(charValue, 0.9) * 2;
            return charValue;
        }
    }

    /// <summary>
    /// Производит стандартный рассчет <see cref="EVariable.A0"/> для производной <see cref="EDerivative.AddTurnChance"/>
    /// </summary>
    public abstract class UniversalAddTurnChanceModule : DerivativesCalculator
    {
        public UniversalAddTurnChanceModule(CommonParameter derivative) : base(derivative) { }

        public override float CalculateDerivative()
        {
            float charValue = GetCharacteristicValue(Characteristic);
            charValue = (float)Math.Pow(charValue, 0.6) / 100;
            return charValue;
        }
    }
    public class StrengthAddTurnChanceModule : UniversalAddTurnChanceModule
    {
        public StrengthAddTurnChanceModule(CommonParameter derivative) : base(derivative) { }
    }
    public class DexterityAddTurnChanceModule : UniversalAddTurnChanceModule
    {
        public DexterityAddTurnChanceModule(CommonParameter derivative) : base(derivative) { }
    }
    public class EnduranceAddTurnChanceModule : UniversalAddTurnChanceModule
    {
        public EnduranceAddTurnChanceModule(CommonParameter derivative) : base(derivative) { }
    }
    public class FireAddTurnChanceModule : UniversalAddTurnChanceModule
    {
        public FireAddTurnChanceModule(CommonParameter derivative) : base(derivative) { }
    }
    public class WaterAddTurnChanceModule : UniversalAddTurnChanceModule
    {
        public WaterAddTurnChanceModule(CommonParameter derivative) : base(derivative) { }
    }
    public class AirAddTurnChanceModule : UniversalAddTurnChanceModule
    {
        public AirAddTurnChanceModule(CommonParameter derivative) : base(derivative) { }
    }
    public class EarthAddTurnChanceModule : UniversalAddTurnChanceModule
    {
        public EarthAddTurnChanceModule(CommonParameter derivative) : base(derivative) { }
    }

    /// <summary>
    /// Производит стандартный рассчет <see cref="EVariable.A0"/> для производной <see cref="EDerivative.TerminationMult"/>
    /// </summary>
    public abstract class UniversalTerminationMultModule : DerivativesCalculator
    {
        public UniversalTerminationMultModule(CommonParameter derivative) : base(derivative) { }
        public override float CalculateDerivative()
        {
            float charValue = GetCharacteristicValue(Characteristic);
            charValue = 1 + (float)Math.Pow(charValue, 0.93) / 100;
            return charValue;
        }
    }
    public class StrengthTerminationMultModule : UniversalTerminationMultModule
    {
        public StrengthTerminationMultModule(CommonParameter derivative) : base(derivative) { }
    }
    public class DexterityTerminationMultModule : UniversalTerminationMultModule
    {
        public DexterityTerminationMultModule(CommonParameter derivative) : base(derivative) { }
    }
    public class EnduranceTerminationMultModule : UniversalTerminationMultModule
    {
        public EnduranceTerminationMultModule(CommonParameter derivative) : base(derivative) { }
    }
    public class FireTerminationMultModule : UniversalTerminationMultModule
    {
        public FireTerminationMultModule(CommonParameter derivative) : base(derivative) { }
    }
    public class WaterTerminationMultModule : UniversalTerminationMultModule
    {
        public WaterTerminationMultModule(CommonParameter derivative) : base(derivative) { }
    }
    public class AirTerminationMultModule : UniversalTerminationMultModule
    {
        public AirTerminationMultModule(CommonParameter derivative) : base(derivative) { }
    }
    public class EarthTerminationMultModule : UniversalTerminationMultModule
    {
        public EarthTerminationMultModule(CommonParameter derivative) : base(derivative) { }
    }

    /// <summary>
    /// Производит стандартный рассчет <see cref="EVariable.A0"/> для производной <see cref="EDerivative.Resistance"/>
    /// </summary>
    public abstract class UniversalResistanceModule : DerivativesCalculator
    {
        public UniversalResistanceModule(CommonParameter derivative) : base(derivative) { }

        
        public override float CalculateDerivative()
        {
            float charValue = GetCharacteristicValue(Characteristic);
            charValue = (float)Math.Pow(charValue, 0.5) / 100;
            return charValue;
        }
    }
    public class StrengthResistanceModule : UniversalResistanceModule
    {
        public StrengthResistanceModule(CommonParameter derivative) : base(derivative) { }
    }
    public class FireResistanceModule : UniversalResistanceModule
    {
        public FireResistanceModule(CommonParameter derivative) : base(derivative) { }
    }
    public class WaterResistanceModule : UniversalResistanceModule
    {
        public WaterResistanceModule(CommonParameter derivative) : base(derivative) { }
    }
    public class AirResistanceModule : UniversalResistanceModule
    {
        public AirResistanceModule(CommonParameter derivative) : base(derivative) { }
    }
    public class EarthResistanceModule : UniversalResistanceModule
    {
        public EarthResistanceModule(CommonParameter derivative) : base(derivative) { }
    }

    /// <summary>
    /// Производит стандартный рассчет <see cref="EVariable.A0"/> для производной <see cref="EDerivative.MaxMana"/>
    /// </summary>
    public abstract class UniversalMaxManaModule : DerivativesCalculator
    {
        public UniversalMaxManaModule(CommonParameter derivative) : base(derivative) { }
        public override float CalculateDerivative()
        {
            float charValue = GetCharacteristicValue(Characteristic);
            charValue = 15 + charValue + (float)Math.Pow(charValue, 0.5);
            return charValue;
        }
    }
    public class FireMaxManaModule : UniversalMaxManaModule
    {
        public FireMaxManaModule(CommonParameter derivative) : base(derivative) { }
    }
    public class WaterMaxManaModule : UniversalMaxManaModule
    {
        public WaterMaxManaModule(CommonParameter derivative) : base(derivative) { }
    }
    public class AirMaxManaModule : UniversalMaxManaModule
    {
        public AirMaxManaModule(CommonParameter derivative) : base(derivative) { }
    }
    public class EarthMaxManaModule : UniversalMaxManaModule
    {
        public EarthMaxManaModule(CommonParameter derivative) : base(derivative) { }
    }

    /// <summary>
    /// Производит стандартный рассчет <see cref="EVariable.A0"/> для производной <see cref="EDerivative.CurrentMana"/>
    /// </summary>
    public abstract class UniversalCurrentManaModule : DerivativesCalculator
    {
        public UniversalCurrentManaModule(CommonParameter derivative) : base(derivative) { }

        
        public override float CalculateDerivative()
        {
            float charValue = GetCharacteristicValue(Characteristic);
            charValue = charValue / 10 + (float)Math.Pow(charValue, 0.6);
            return charValue;
        }
    }
    public class FireCurrentManaModule : UniversalCurrentManaModule
    {
        public FireCurrentManaModule(CommonParameter derivative) : base(derivative) { }
    }
    public class WaterCurrentManaModule : UniversalCurrentManaModule
    {
        public WaterCurrentManaModule(CommonParameter derivative) : base(derivative) { }
    }
    public class AirCurrentManaModule : UniversalCurrentManaModule
    {
        public AirCurrentManaModule(CommonParameter derivative) : base(derivative) { }
    }
    public class EarthCurrentManaModule : UniversalCurrentManaModule
    {
        public EarthCurrentManaModule(CommonParameter derivative) : base(derivative) { }
    }
    #endregion
}
