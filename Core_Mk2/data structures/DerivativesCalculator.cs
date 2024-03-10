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
        //_____________________КОНСТРУКТОР_____________________

        /// <summary>
        /// Стандарный конструктор для передачи потомкам
        /// </summary>
        /// <param name="character"> Персонаж, для которого нужно осуществить рассчет</param>
        protected DerivativesCalculator(Dictionary<ECharacteristic, int> characteristicDictionary) { this.characteristicDictionary = characteristicDictionary; }

        //_____________________ПОЛЯ_____________________

        //Все значения характеристик персонажа
        protected Dictionary<ECharacteristic, int> characteristicDictionary;

        //_____________________МЕТОДЫ_____________________

        /// <summary>
        /// вычислить значение заданной производной 
        /// </summary>
        /// <param name="characteristic"></param>
        /// <param name="derivative"></param>
        /// <returns></returns>
        public static float Get_A0(Dictionary<ECharacteristic, int> characteristicDictionary, ECharacteristic characteristic, EDerivative derivative)
        {
            //указание на подключение нужного модуля вычисления
            return (characteristic) switch
            {
                ECharacteristic.Strength => (derivative) switch
                {
                    EDerivative.Value => new StrengthValueModule(characteristicDictionary, ECharacteristic.Strength).CalculateDerivative(),
                    EDerivative.TerminationMult => new StrengthTerminationMultModule(characteristicDictionary, ECharacteristic.Strength).CalculateDerivative(),
                    EDerivative.AddTurnChance => new StrengthAddTurnChanceModule(characteristicDictionary, ECharacteristic.Strength).CalculateDerivative(),
                    EDerivative.Resistance => new StrengthResistanceModule(characteristicDictionary, ECharacteristic.Strength).CalculateDerivative(),
                    _ => throw new NotImplementedException(),
                },
                ECharacteristic.Dexterity => (derivative) switch
                {
                    EDerivative.Value => new DexterityValueModule(characteristicDictionary, ECharacteristic.Dexterity).CalculateDerivative(),
                    EDerivative.TerminationMult => new DexterityTerminationMultModule(characteristicDictionary, ECharacteristic.Dexterity).CalculateDerivative(),
                    EDerivative.AddTurnChance => new DexterityAddTurnChanceModule(characteristicDictionary, ECharacteristic.Dexterity).CalculateDerivative(),
                    _ => throw new NotImplementedException(),
                },
                ECharacteristic.Endurance => (derivative) switch
                {
                    EDerivative.Value => new EnduranceValueModule(characteristicDictionary, ECharacteristic.Endurance).CalculateDerivative(),
                    EDerivative.TerminationMult => new EnduranceTerminationMultModule(characteristicDictionary, ECharacteristic.Endurance).CalculateDerivative(),
                    EDerivative.AddTurnChance => new EnduranceAddTurnChanceModule(characteristicDictionary, ECharacteristic.Endurance).CalculateDerivative(),
                    EDerivative.MaxHealth => new EnduranceMaxHealthModule(characteristicDictionary).CalculateDerivative(),
                    EDerivative.CurrentHealth => new EnduranceMaxHealthModule(characteristicDictionary).CalculateDerivative(),
                    _ => throw new NotImplementedException(),
                },
                ECharacteristic.Fire => (derivative) switch
                {
                    EDerivative.Value => new FireValueModule(characteristicDictionary, ECharacteristic.Fire).CalculateDerivative(),
                    EDerivative.TerminationMult => new FireTerminationMultModule(characteristicDictionary, ECharacteristic.Fire).CalculateDerivative(),
                    EDerivative.AddTurnChance => new FireAddTurnChanceModule(characteristicDictionary, ECharacteristic.Fire).CalculateDerivative(),
                    EDerivative.MaxMana => new FireMaxManaModule(characteristicDictionary, ECharacteristic.Fire).CalculateDerivative(),
                    EDerivative.CurrentMana => new FireCurrentManaModule(characteristicDictionary, ECharacteristic.Fire).CalculateDerivative(),
                    EDerivative.Resistance => new FireResistanceModule(characteristicDictionary, ECharacteristic.Fire).CalculateDerivative(),
                    _ => throw new NotImplementedException(),
                },
                ECharacteristic.Water => (derivative) switch
                {
                    EDerivative.Value => new WaterValueModule(characteristicDictionary, ECharacteristic.Water).CalculateDerivative(),
                    EDerivative.TerminationMult => new WaterTerminationMultModule(characteristicDictionary, ECharacteristic.Water).CalculateDerivative(),
                    EDerivative.AddTurnChance => new WaterAddTurnChanceModule(characteristicDictionary, ECharacteristic.Water).CalculateDerivative(),
                    EDerivative.MaxMana => new WaterMaxManaModule(characteristicDictionary, ECharacteristic.Water).CalculateDerivative(),
                    EDerivative.CurrentMana => new WaterCurrentManaModule(characteristicDictionary, ECharacteristic.Water).CalculateDerivative(),
                    EDerivative.Resistance => new WaterResistanceModule(characteristicDictionary, ECharacteristic.Water).CalculateDerivative(),
                    _ => throw new NotImplementedException(),
                },
                ECharacteristic.Air => (derivative) switch
                {
                    EDerivative.Value => new AirValueModule(characteristicDictionary, ECharacteristic.Air).CalculateDerivative(),
                    EDerivative.TerminationMult => new AirTerminationMultModule(characteristicDictionary, ECharacteristic.Air).CalculateDerivative(),
                    EDerivative.AddTurnChance => new AirAddTurnChanceModule(characteristicDictionary, ECharacteristic.Air).CalculateDerivative(),
                    EDerivative.MaxMana => new AirMaxManaModule(characteristicDictionary, ECharacteristic.Air).CalculateDerivative(),
                    EDerivative.CurrentMana => new AirCurrentManaModule(characteristicDictionary, ECharacteristic.Air).CalculateDerivative(),
                    EDerivative.Resistance => new AirResistanceModule(characteristicDictionary, ECharacteristic.Air).CalculateDerivative(),
                    _ => throw new NotImplementedException(),
                },
                ECharacteristic.Earth => (derivative) switch
                {
                    EDerivative.Value => new EarthValueModule(characteristicDictionary, ECharacteristic.Earth).CalculateDerivative(),
                    EDerivative.TerminationMult => new EarthTerminationMultModule(characteristicDictionary, ECharacteristic.Earth).CalculateDerivative(),
                    EDerivative.AddTurnChance => new EarthAddTurnChanceModule(characteristicDictionary, ECharacteristic.Earth).CalculateDerivative(),
                    EDerivative.MaxMana => new EarthMaxManaModule(characteristicDictionary, ECharacteristic.Earth).CalculateDerivative(),
                    EDerivative.CurrentMana => new EarthCurrentManaModule(characteristicDictionary, ECharacteristic.Earth).CalculateDerivative(),
                    EDerivative.Resistance => new EarthResistanceModule(characteristicDictionary, ECharacteristic.Earth).CalculateDerivative(),
                    _ => throw new NotImplementedException(),
                },
                _ => throw new NotImplementedException(),
            };
        }

        /// <summary>
        ///Расчет каждой производной осуществляет отдельный класс с возможностью установки уникальной формулы
        /// </summary>
        public abstract float CalculateDerivative();
    }

    public class EnduranceMaxHealthModule : DerivativesCalculator
    {
        public EnduranceMaxHealthModule(
            Dictionary<ECharacteristic, int> characteristicDictionary) : base(characteristicDictionary) { }

        public override float CalculateDerivative()
        {
            float charValue = characteristicDictionary[ECharacteristic.Endurance];
            charValue = 20 + 1.2f * charValue + (float)Math.Pow(charValue, 0.9) * 2;
            return charValue;
        }
    }
    /// <summary>
    /// Стандартный модуль рассчета базового значения производной value
    /// </summary>
    public abstract class UniversalValueModule : DerivativesCalculator
    {
        public UniversalValueModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary)
        {
            this.characteristic = characteristic;
        }

        protected ECharacteristic characteristic;
        public override float CalculateDerivative()
        {
            float charValue = characteristicDictionary[characteristic];
            return charValue;
        }
    }
    public class StrengthValueModule : UniversalValueModule
    {
        public StrengthValueModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class DexterityValueModule : UniversalValueModule
    {
        public DexterityValueModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class EnduranceValueModule : UniversalValueModule
    {
        public EnduranceValueModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class FireValueModule : UniversalValueModule
    {
        public FireValueModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class WaterValueModule : UniversalValueModule
    {
        public WaterValueModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class AirValueModule : UniversalValueModule
    {
        public AirValueModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class EarthValueModule : UniversalValueModule
    {
        public EarthValueModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }

    /// <summary>
    /// Стандартный модуль рассчета базового значения производной AddTurnChance
    /// </summary>
    public abstract class UniversalAddTurnChanceModule : DerivativesCalculator
    {
        public UniversalAddTurnChanceModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary)
        {
            this.characteristic = characteristic;
        }

        protected ECharacteristic characteristic;
        public override float CalculateDerivative()
        {
            float charValue = characteristicDictionary[characteristic];
            charValue = (float)Math.Pow(charValue, 0.6) / 100;
            return charValue;
        }
    }
    public class StrengthAddTurnChanceModule : UniversalAddTurnChanceModule
    {
        public StrengthAddTurnChanceModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class DexterityAddTurnChanceModule : UniversalAddTurnChanceModule
    {
        public DexterityAddTurnChanceModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class EnduranceAddTurnChanceModule : UniversalAddTurnChanceModule
    {
        public EnduranceAddTurnChanceModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class FireAddTurnChanceModule : UniversalAddTurnChanceModule
    {
        public FireAddTurnChanceModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class WaterAddTurnChanceModule : UniversalAddTurnChanceModule
    {
        public WaterAddTurnChanceModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class AirAddTurnChanceModule : UniversalAddTurnChanceModule
    {
        public AirAddTurnChanceModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class EarthAddTurnChanceModule : UniversalAddTurnChanceModule
    {
        public EarthAddTurnChanceModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }

    /// <summary>
    /// Стандартный модуль рассчета базового значения производной value
    /// </summary>
    public abstract class UniversalTerminationMultModule : DerivativesCalculator
    {
        public UniversalTerminationMultModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary)
        {

            this.characteristic = characteristic;
        }

        protected ECharacteristic characteristic;
        public override float CalculateDerivative()
        {
            float charValue = characteristicDictionary[characteristic];
            charValue = 1 + (float)Math.Pow(charValue, 0.93) / 100;
            return charValue;
        }
    }
    public class StrengthTerminationMultModule : UniversalTerminationMultModule
    {
        public StrengthTerminationMultModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class DexterityTerminationMultModule : UniversalTerminationMultModule
    {
        public DexterityTerminationMultModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class EnduranceTerminationMultModule : UniversalTerminationMultModule
    {
        public EnduranceTerminationMultModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class FireTerminationMultModule : UniversalTerminationMultModule
    {
        public FireTerminationMultModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class WaterTerminationMultModule : UniversalTerminationMultModule
    {
        public WaterTerminationMultModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class AirTerminationMultModule : UniversalTerminationMultModule
    {
        public AirTerminationMultModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class EarthTerminationMultModule : UniversalTerminationMultModule
    {
        public EarthTerminationMultModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }

    /// <summary>
    /// Стандартный модуль рассчета базового значения производной value
    /// </summary>
    public abstract class UniversalResistanceModule : DerivativesCalculator
    {
        public UniversalResistanceModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary)
        {
            this.characteristic = characteristic;
        }

        protected ECharacteristic characteristic;
        public override float CalculateDerivative()
        {
            float charValue = characteristicDictionary[characteristic];
            charValue = (float)Math.Pow(charValue, 0.5) / 100;
            return charValue;
        }
    }
    public class StrengthResistanceModule : UniversalResistanceModule
    {
        public StrengthResistanceModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class FireResistanceModule : UniversalResistanceModule
    {
        public FireResistanceModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class WaterResistanceModule : UniversalResistanceModule
    {
        public WaterResistanceModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class AirResistanceModule : UniversalResistanceModule
    {
        public AirResistanceModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class EarthResistanceModule : UniversalResistanceModule
    {
        public EarthResistanceModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }

    /// <summary>
    /// Стандартный модуль рассчета базового значения производной value
    /// </summary>
    public abstract class UniversalMaxManaModule : DerivativesCalculator
    {
        public UniversalMaxManaModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary)
        {
            this.characteristic = characteristic;
        }

        protected ECharacteristic characteristic;
        public override float CalculateDerivative()
        {
            float charValue = characteristicDictionary[characteristic];
            charValue = 15 + charValue + (float)Math.Pow(charValue, 0.5);
            return charValue;
        }
    }
    public class FireMaxManaModule : UniversalMaxManaModule
    {
        public FireMaxManaModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class WaterMaxManaModule : UniversalMaxManaModule
    {
        public WaterMaxManaModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class AirMaxManaModule : UniversalMaxManaModule
    {
        public AirMaxManaModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class EarthMaxManaModule : UniversalMaxManaModule
    {
        public EarthMaxManaModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }

    /// <summary>
    /// Стандартный модуль рассчета базового значения производной value
    /// </summary>
    public abstract class UniversalCurrentManaModule : DerivativesCalculator
    {
        public UniversalCurrentManaModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary)
        {
            this.characteristic = characteristic;
        }

        protected ECharacteristic characteristic;
        public override float CalculateDerivative()
        {
            float charValue = characteristicDictionary[characteristic];
            charValue = charValue / 10 + (float)Math.Pow(charValue, 0.6);
            return charValue;
        }
    }
    public class FireCurrentManaModule : UniversalCurrentManaModule
    {
        public FireCurrentManaModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class WaterCurrentManaModule : UniversalCurrentManaModule
    {
        public WaterCurrentManaModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class AirCurrentManaModule : UniversalCurrentManaModule
    {
        public AirCurrentManaModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
    public class EarthCurrentManaModule : UniversalCurrentManaModule
    {
        public EarthCurrentManaModule(
            Dictionary<ECharacteristic, int> characteristicDictionary,
            ECharacteristic characteristic) : base(characteristicDictionary, characteristic) { }
    }
}
