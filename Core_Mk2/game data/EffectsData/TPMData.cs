using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    public static partial class EffectData
    {
        public static readonly List<TriggerParameterModifier> TPMEffects = new List<TriggerParameterModifier>();
        private static void TPMInit()
        {
            var TPMbuilder = new TriggerParameterModifier.TPMBuilder();

            var currentEffect = TPMbuilder
                .Name("Нарaстающая ярость.")
                .Description(
                    "При нанесении более 7 едениц физического урона ваша сила увеличиваете на 5% на 2 хода.\n" +
                    "Может складываться до 4х раз.")
                .TriggerlogicalModule(new LM_02_damageThreshold(damageType: EDamageType.PhysicalDamage, threshold: 7))
                .TicklogicalModule(new LM_CONSTANT_TRUE())
                .Duration(2)
                .MaxStack(4)
                .ComposeLink(EPlayerType.Self)
                .ComposeLink(ECharacteristic.Strength)
                .ComposeLink(EDerivative.Value)
                .ComposeLink(EVariable.C1)
                .AddLink()
                .AddValue(0.05)
                .ComposeTriggerEvent(EPlayerType.Enemy)
                .ComposeTriggerEvent(EEvent.DamageTaking)
                .AddTriggerEvent()
                .ComposeTickEvent(EPlayerType.Self)
                .ComposeTickEvent(EEvent.StepExecution)
                .AddTickEventt()
                .Build();
            TPMEffects.Add(currentEffect);
        }
    }
}