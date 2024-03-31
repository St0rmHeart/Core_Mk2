using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    public static partial class EquipmentData
    {
        private static readonly List<Equipment> _equipmentWeapon = new List<Equipment>();

        private static void WeaponInit()
        {
            var currentEquipment = new Equipment("Древний Эльфийский Меч", EBodyPart.Weapon);
            currentEquipment.Effects.Add(
                new PassiveParameterModifier.PPMBuilder()
                .Name("Живучесть.")
                .Description("Увеличивает максимальное здоровье на 10.")
                .ComposeLink(EPlayerType.Self)
                .ComposeLink(ECharacteristic.Endurance)
                .ComposeLink(EDerivative.MaxHealth)
                .ComposeLink(EVariable.C2)
                .AddLink()
                .AddValue(10)
                .BuildWithReset());

            currentEquipment.Effects.Add(
                new TriggerParameterModifier.TPMBuilder()
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
                .Build());

            currentEquipment.Effects.Add(
                new LogicalModuleEffect.LMEBuilder()
                .Name("Стена огня")
                .Description(
                    "!!ДЛЯ ТЕСТА!! При поглощении маны земли. !!ДЛЯ ТЕСТА!!\n" +
                    "Теперь урон наносится вашей красной мане. Каждый ход уменьшает запас красной маны на 2." +
                    "Длится пока красная мана не опустится до нуля.")
                .TriggerlogicalModule(new LM_01_deltaThreshold(threshold: 0))
                .TicklogicalModule(new LM_03_manaShieldTickModule(element: ECharacteristic.Fire, costOfMaintenance: 2))
                .AddTriggerEvent(EPlayerType.Self, EEvent.DeltaEarthMana)
                .AddTickEventt(EPlayerType.Self, EEvent.DamageAccepting)
                .AddTickEventt(EPlayerType.Self, EEvent.StepExecution)
                .Build());


            _equipmentWeapon.Add(currentEquipment);
        }
    }
}
