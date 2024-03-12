using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core_Mk2
{
    public partial class Form1 : Form
    {
        public Character testHero;
        public Character testEnemy;
        public Arena arena;
        public void UpdateData()
        {
            HeroName.Text = testHero.Name;
            HeroLevel.Text = "Lvl " + testHero.Level;
            HeroLvlExact.Text = testHero.Xp + "/" + Character.levelBoundaries[testHero.Level - 1];

            //Strength
            HeroStrengthData.Text =
                "Значение: " + (int)arena._player.Data[ECharacteristic.Strength][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (arena._player.Data[ECharacteristic.Strength][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (arena._player.Data[ECharacteristic.Strength][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Физ. сопротивление: " + (arena._player.Data[ECharacteristic.Strength][EDerivative.Resistance].FinalValue * 100).ToString("F1") + "%";

            //Endurance
            HeroEnduranceData.Text =
                "Значение: " + (int)arena._player.Data[ECharacteristic.Endurance][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (arena._player.Data[ECharacteristic.Endurance][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (arena._player.Data[ECharacteristic.Endurance][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Здоровье: " +
                arena._player.Data[ECharacteristic.Endurance][EDerivative.CurrentHealth].FinalValue.ToString("F0")
                + " / " +
                arena._player.Data[ECharacteristic.Endurance][EDerivative.MaxHealth].FinalValue.ToString("F0");

            //Dexterity
            HeroDexterityData.Text =
                "Значение: " + (int)arena._player.Data[ECharacteristic.Dexterity][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (arena._player.Data[ECharacteristic.Dexterity][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (arena._player.Data[ECharacteristic.Dexterity][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%";


            //fire
            HeroFireData.Text = 
                "Значение: " + (int)arena._player.Data[ECharacteristic.Fire][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (arena._player.Data[ECharacteristic.Fire][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (arena._player.Data[ECharacteristic.Fire][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Мана: " +
                arena._player.Data[ECharacteristic.Fire][EDerivative.CurrentMana].FinalValue.ToString("F1")
                + " / " +
                arena._player.Data[ECharacteristic.Fire][EDerivative.MaxMana].FinalValue.ToString("F1") + "\n" +
                "Cопротивление: " + (arena._player.Data[ECharacteristic.Fire][EDerivative.Resistance].FinalValue * 100).ToString("F1") + "%";
            //Water
            HeroWaterData.Text =
                "Значение: " + (int)arena._player.Data[ECharacteristic.Water][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (arena._player.Data[ECharacteristic.Water][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (arena._player.Data[ECharacteristic.Water][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Мана: " +
                arena._player.Data[ECharacteristic.Water][EDerivative.CurrentMana].FinalValue.ToString("F1")
                + " / " +
                arena._player.Data[ECharacteristic.Water][EDerivative.MaxMana].FinalValue.ToString("F1") + "\n" +
                "Cопротивление: " + (arena._player.Data[ECharacteristic.Water][EDerivative.Resistance].FinalValue * 100).ToString("F1") + "%";
            //Earth
            HeroEarthData.Text =
                "Значение: " + (int)arena._player.Data[ECharacteristic.Earth][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (arena._player.Data[ECharacteristic.Earth][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (arena._player.Data[ECharacteristic.Earth][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Мана: " +
                arena._player.Data[ECharacteristic.Earth][EDerivative.CurrentMana].FinalValue.ToString("F1")
                + " / " +
                arena._player.Data[ECharacteristic.Earth][EDerivative.MaxMana].FinalValue.ToString("F1") + "\n" +
                "Cопротивление: " + (arena._player.Data[ECharacteristic.Earth][EDerivative.Resistance].FinalValue * 100).ToString("F1") + "%";
            //Air
            HeroAirData.Text =
                "Значение: " + (int)arena._player.Data[ECharacteristic.Air][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (arena._player.Data[ECharacteristic.Air][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (arena._player.Data[ECharacteristic.Air][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Мана: " +
                arena._player.Data[ECharacteristic.Air][EDerivative.CurrentMana].FinalValue.ToString("F1")
                + " / " +
                arena._player.Data[ECharacteristic.Air][EDerivative.MaxMana].FinalValue.ToString("F1") + "\n" +
                "Cопротивление: " + (arena._player.Data[ECharacteristic.Air][EDerivative.Resistance].FinalValue * 100).ToString("F1") + "%";





            EnemyName.Text = testEnemy.Name;
            EnemyLevel.Text = "Lvl " + testEnemy.Level;
            EnemyLvlExact.Text = testEnemy.Xp + "/" + Character.levelBoundaries[testEnemy.Level - 1];

            //Strength
            EnemyStrengthData.Text =
                "Значение: " + (int)arena._enemy.Data[ECharacteristic.Strength][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (arena._enemy.Data[ECharacteristic.Strength][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (arena._enemy.Data[ECharacteristic.Strength][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Физ. сопротивление: " + (arena._enemy.Data[ECharacteristic.Strength][EDerivative.Resistance].FinalValue * 100).ToString("F1") + "%";

            //Endurance
            EnemyEnduranceData.Text =
                "Значение: " + (int)arena._enemy.Data[ECharacteristic.Endurance][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (arena._enemy.Data[ECharacteristic.Endurance][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (arena._enemy.Data[ECharacteristic.Endurance][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Здоровье: " +
                arena._enemy.Data[ECharacteristic.Endurance][EDerivative.CurrentHealth].FinalValue.ToString("F0")
                + " / " +
                arena._enemy.Data[ECharacteristic.Endurance][EDerivative.MaxHealth].FinalValue.ToString("F0");

            //Dexterity
            EnemyDexterityData.Text =
                "Значение: " + (int)arena._enemy.Data[ECharacteristic.Dexterity][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (arena._enemy.Data[ECharacteristic.Dexterity][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (arena._enemy.Data[ECharacteristic.Dexterity][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%";


            //fire
            EnemyFireData.Text =
                "Значение: " + (int)arena._enemy.Data[ECharacteristic.Fire][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (arena._enemy.Data[ECharacteristic.Fire][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (arena._enemy.Data[ECharacteristic.Fire][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Мана: " +
                arena._enemy.Data[ECharacteristic.Fire][EDerivative.CurrentMana].FinalValue.ToString("F1")
                + " / " +
                arena._enemy.Data[ECharacteristic.Fire][EDerivative.MaxMana].FinalValue.ToString("F1") + "\n" +
                "Cопротивление: " + (arena._enemy.Data[ECharacteristic.Fire][EDerivative.Resistance].FinalValue * 100).ToString("F1") + "%";
            //Water
            EnemyWaterData.Text =
                "Значение: " + (int)arena._enemy.Data[ECharacteristic.Water][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (arena._enemy.Data[ECharacteristic.Water][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (arena._enemy.Data[ECharacteristic.Water][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Мана: " +
                arena._enemy.Data[ECharacteristic.Water][EDerivative.CurrentMana].FinalValue.ToString("F1")
                + " / " +
                arena._enemy.Data[ECharacteristic.Water][EDerivative.MaxMana].FinalValue.ToString("F1") + "\n" +
                "Cопротивление: " + (arena._enemy.Data[ECharacteristic.Water][EDerivative.Resistance].FinalValue * 100).ToString("F1") + "%";
            //Earth
            EnemyEarthData.Text =
                "Значение: " + (int)arena._enemy.Data[ECharacteristic.Earth][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (arena._enemy.Data[ECharacteristic.Earth][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (arena._enemy.Data[ECharacteristic.Earth][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Мана: " +
                arena._enemy.Data[ECharacteristic.Earth][EDerivative.CurrentMana].FinalValue.ToString("F1")
                + " / " +
                arena._enemy.Data[ECharacteristic.Earth][EDerivative.MaxMana].FinalValue.ToString("F1") + "\n" +
                "Cопротивление: " + (arena._enemy.Data[ECharacteristic.Earth][EDerivative.Resistance].FinalValue * 100).ToString("F1") + "%";
            //Air
            EnemyAirData.Text =
                "Значение: " + (int)arena._enemy.Data[ECharacteristic.Air][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (arena._enemy.Data[ECharacteristic.Air][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (arena._enemy.Data[ECharacteristic.Air][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Мана: " +
                arena._enemy.Data[ECharacteristic.Air][EDerivative.CurrentMana].FinalValue.ToString("F1")
                + " / " +
                arena._enemy.Data[ECharacteristic.Air][EDerivative.MaxMana].FinalValue.ToString("F1") + "\n" +
                "Cопротивление: " + (arena._enemy.Data[ECharacteristic.Air][EDerivative.Resistance].FinalValue * 100).ToString("F1") + "%";
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Проверяем, была ли нажата клавиша ESC
            if (e.KeyCode == Keys.Escape)
            {
                // Закрываем приложение
                Close();
            }
        }
        #region Log methods
        private void LogStepExecution(object sender, EventArgs args)
        {
            if (sender is CharacterSlot owner)
            {
                listBox1.Items.Add(owner.GetName + " закончил ход!");
            }
        }
        private void LogDeath(object sender, EventArgs args)
        {
            if (sender is CharacterSlot owner)
            {
                listBox1.Items.Add(owner.GetName + "УМЕР!");
            }
        }
        private void LogDamageEmitting(object sender, (EDamageType damageType, float value) data)
        {
            if (sender is CharacterSlot owner)
            {
                listBox1.Items.Add(owner.GetName + " испускает " + data.value.ToString("F1") + " едениц " + data.damageType + " урона.");
            }
        }
        private void LogDamageBlocking(object sender, (EDamageType damageType, float value) data)
        {
            if (sender is CharacterSlot owner)
            {
                listBox1.Items.Add(owner.GetName + " блокирует " + data.value.ToString("F1") + " едениц " + data.damageType + " урона.");
            }
        }
        private void LogDamageTaking(object sender, (EDamageType damageType, float value) data)
        {
            if (sender is CharacterSlot owner)
            {
                listBox1.Items.Add(owner.GetName + " получает " + (-data.value).ToString("F1") + " едениц " + data.damageType + " урона.");
            }
        }
        private void LogDeltaXP(object sender,  float value)
        {
            if (sender is CharacterSlot owner)
            {
                if (value > 0 ) listBox1.Items.Add(owner.GetName + " получает " + value.ToString("F1") + " опыта ");
                else listBox1.Items.Add(owner.GetName + " теряет " + (-value).ToString("F1") + " опыта ");
            }
        }
        private void LogDeltaHP(object sender, float value)
        {
            if (sender is CharacterSlot owner)
            {
                if (value > 0) listBox1.Items.Add(owner.GetName + " восстанавливает " + value.ToString("F1") + " здоровья ");
                else listBox1.Items.Add(owner.GetName + " теряет " + (-value).ToString("F1") + " здоровья ");
            }
        }
        private void LogDeltaGold(object sender, float value)
        {
            if (sender is CharacterSlot owner)
            {
                if (value > 0) listBox1.Items.Add(owner.GetName + " получает " + value.ToString("F1") + " золота ");
                else listBox1.Items.Add(owner.GetName + " теряет " + value.ToString("F1") + " золота ");
            }
        }
        private void LogDeltaFireMana(object sender, float value)
        {
            if (sender is CharacterSlot owner)
            {
                if (value > 0) listBox1.Items.Add(owner.GetName + " получает " + value.ToString("F1") + " маны огня ");
                else listBox1.Items.Add(owner.GetName + " теряет " + value.ToString("F1") + " маны огня ");
            }
        }
        private void LogDeltaWaterMana(object sender, float value)
        {
            if (sender is CharacterSlot owner)
            {
                if (value > 0) listBox1.Items.Add(owner.GetName + " получает " + value.ToString("F1") + " маны воды ");
                else listBox1.Items.Add(owner.GetName + " теряет " + value.ToString("F1") + " маны воды ");
            }
        }
        private void LogDeltaEarthMana(object sender, float value)
        {
            if (sender is CharacterSlot owner)
            {
                if (value > 0) listBox1.Items.Add(owner.GetName + " получает " + value.ToString("F1") + " маны земли ");
                else listBox1.Items.Add(owner.GetName + " теряет " + value.ToString("F1") + " маны земли ");
            }
        }
        private void LogDeltaAirMana(object sender, float value)
        {
            if (sender is CharacterSlot owner)
            {
                if (value > 0) listBox1.Items.Add(owner.GetName + " получает " + value.ToString("F1") + " маны воздуха ");
                else listBox1.Items.Add(owner.GetName + " теряет " + value.ToString("F1") + " маны воздуха ");
            }
        }
        #endregion
        public Form1()
        {
            var characterBuilder = new Character.CharacterBuilder();
            var effectBuilder = new EffectBuilder();

            var sword = new Equipment(EBodyPart.Weapon, "Древний Эльфийский Меч");
            Effect newEffect = effectBuilder
                .WithValue(10)
                .WithDuration(5)
                .WithTriggerThreshold(8)
                .WithMaxStack(3)
                .WithLink(EPlayerType.Player, ECharacteristic.Strength, EDerivative.Value, EVariable.C2)
                .WithTriggerEvent(EPlayerType.Player, EEvent.DeltaGold)
                .WithTickEvent(EPlayerType.Player, EEvent.StepExecution)
                .Build();
            sword.Effects.Add(newEffect);

            testHero = characterBuilder
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

            characterBuilder.Reset();

            testEnemy = characterBuilder
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

            arena = new Arena(testHero, testEnemy);

            #region log Init
            //подписка логирующих методов на ивенты
            arena._player.StepExecution += LogStepExecution;
            arena._enemy.StepExecution += LogStepExecution;

            arena._player.Death += LogDeath;
            arena._enemy.Death += LogDeath;

            arena._player.DamageEmitting += LogDamageEmitting;
            arena._enemy.DamageEmitting += LogDamageEmitting;

            arena._player.DamageBlocking += LogDamageBlocking;
            arena._enemy.DamageBlocking += LogDamageBlocking;

            arena._player.DamageTaking += LogDamageTaking;
            arena._enemy.DamageTaking += LogDamageTaking;

            arena._player.DeltaXP += LogDeltaXP;
            arena._enemy.DeltaXP += LogDeltaXP;

            arena._player.DeltaHP += LogDeltaHP;
            arena._enemy.DeltaHP += LogDeltaHP;

            arena._player.DeltaGold += LogDeltaGold;
            arena._enemy.DeltaGold += LogDeltaGold;

            arena._player.DeltaFireMana += LogDeltaFireMana;
            arena._enemy.DeltaFireMana += LogDeltaFireMana;

            arena._player.DeltaWaterMana += LogDeltaWaterMana;
            arena._enemy.DeltaWaterMana += LogDeltaWaterMana;

            arena._player.DeltaEarthMana += LogDeltaEarthMana;
            arena._enemy.DeltaEarthMana += LogDeltaEarthMana;

            arena._player.DeltaAirMana += LogDeltaAirMana;
            arena._enemy.DeltaAirMana += LogDeltaAirMana;
            #endregion

            InitializeComponent();
            KeyDown += MainForm_KeyDown;
            UpdateData();

            var uselessInt = 3;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            EStoneType stoneType = (EStoneType)comboBox1.SelectedItem;
            int.TryParse(textBox1.Text, out int amount) ;
            arena.StoneCombination(stoneType, amount);
            listBox1.Items.Add("---------------------------------------------------");
            UpdateData();
        }
    }
}
