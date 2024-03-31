using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core_Mk2
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region GameData
            var CBuilder = new Character.CBuilder();
            var PPMBuilder = new PassiveParameterModifier.PPMBuilder();
            var TPMBuilder = new TriggerParameterModifier.TPMBuilder();
            var LMEBuilder = new LogicalModuleEffect.LMEBuilder();


            var sword = new Equipment("Древний Эльфийский Меч", EBodyPart.Weapon);

            var newPassiveEffect = PPMBuilder
                .Name("Живучесть.")
                .Description("Увеличивает максимальное здоровье на 10.")
                .ComposeLink(EPlayerType.Self)
                .ComposeLink(ECharacteristic.Endurance)
                .ComposeLink(EDerivative.MaxHealth)
                .ComposeLink(EVariable.C2)
                .AddLink()
                .AddValue(10)
                .BuildWithReset();
            sword.Effects.Add(newPassiveEffect);

            var newTriggerParameter = TPMBuilder
                .Name("Наростающая ярость.")
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
            sword.Effects.Add(newTriggerParameter);

            var newLogicalModuleEffect = LMEBuilder
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
                .Build();
            sword.Effects.Add(newLogicalModuleEffect);



            var testHero = CBuilder
                .With_Name("Огн. Рыцарь")
                .With_XP(1874)
                .With_Characteristic(ECharacteristic.Strength, 55)
                .With_Characteristic(ECharacteristic.Dexterity, 40)
                .With_Characteristic(ECharacteristic.Endurance, 95)
                .With_Characteristic(ECharacteristic.Fire, 175)
                .With_Characteristic(ECharacteristic.Water, 5)
                .With_Characteristic(ECharacteristic.Air, 80)
                .With_Characteristic(ECharacteristic.Earth, 15)
                .With_Equipment(sword.BodyPart, sword)
                .Build();

            CBuilder.Reset();

            var testEnemy = CBuilder
                .With_Name("Тролль")
                .With_XP(3000)
                .With_Characteristic(ECharacteristic.Strength, 130)
                .With_Characteristic(ECharacteristic.Dexterity, 15)
                .With_Characteristic(ECharacteristic.Endurance, 150)
                .With_Characteristic(ECharacteristic.Fire, 20)
                .With_Characteristic(ECharacteristic.Water, 20)
                .With_Characteristic(ECharacteristic.Air, 15)
                .With_Characteristic(ECharacteristic.Earth, 60)
                .Build();

            var arena = new Arena(testHero, testEnemy);
            #endregion


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form2(arena));
            //Application.Run(new Form1(arena));

            var f1 = new Form1(arena);
            var f2 = new Form2(arena);
            f1.Show();
            Application.Run(new Form2(arena));
        }
    }
}
