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
        private readonly Arena _arena;
        public void UpdateData()
        {
            HeroName.Text = _arena._player.Character.Name;
            HeroLevel.Text = "Lvl " + _arena._player.Character.Level;
            HeroLvlExact.Text = _arena._player.Character.Xp + "/" + Character.levelBoundaries[_arena._player.Character.Level - 1];

            //Strength
            HeroStrengthData.Text =
                "Значение: " + (int)_arena._player.Data[ECharacteristic.Strength][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (_arena._player.Data[ECharacteristic.Strength][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (_arena._player.Data[ECharacteristic.Strength][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Физ. сопротивление: " + (_arena._player.Data[ECharacteristic.Strength][EDerivative.Resistance].FinalValue * 100).ToString("F1") + "%";

            //Endurance
            HeroEnduranceData.Text =
                "Значение: " + (int)_arena._player.Data[ECharacteristic.Endurance][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (_arena._player.Data[ECharacteristic.Endurance][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (_arena._player.Data[ECharacteristic.Endurance][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Здоровье: " +
                _arena._player.Data[ECharacteristic.Endurance][EDerivative.CurrentHealth].FinalValue.ToString("F0")
                + " / " +
                _arena._player.Data[ECharacteristic.Endurance][EDerivative.MaxHealth].FinalValue.ToString("F0");

            //Dexterity
            HeroDexterityData.Text =
                "Значение: " + (int)_arena._player.Data[ECharacteristic.Dexterity][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (_arena._player.Data[ECharacteristic.Dexterity][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (_arena._player.Data[ECharacteristic.Dexterity][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%";


            //fire
            HeroFireData.Text = 
                "Значение: " + (int)_arena._player.Data[ECharacteristic.Fire][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (_arena._player.Data[ECharacteristic.Fire][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (_arena._player.Data[ECharacteristic.Fire][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Мана: " +
                _arena._player.Data[ECharacteristic.Fire][EDerivative.CurrentMana].FinalValue.ToString("F1")
                + " / " +
                _arena._player.Data[ECharacteristic.Fire][EDerivative.MaxMana].FinalValue.ToString("F1") + "\n" +
                "Cопротивление: " + (_arena._player.Data[ECharacteristic.Fire][EDerivative.Resistance].FinalValue * 100).ToString("F1") + "%";
            //Water
            HeroWaterData.Text =
                "Значение: " + (int)_arena._player.Data[ECharacteristic.Water][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (_arena._player.Data[ECharacteristic.Water][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (_arena._player.Data[ECharacteristic.Water][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Мана: " +
                _arena._player.Data[ECharacteristic.Water][EDerivative.CurrentMana].FinalValue.ToString("F1")
                + " / " +
                _arena._player.Data[ECharacteristic.Water][EDerivative.MaxMana].FinalValue.ToString("F1") + "\n" +
                "Cопротивление: " + (_arena._player.Data[ECharacteristic.Water][EDerivative.Resistance].FinalValue * 100).ToString("F1") + "%";
            //Earth
            HeroEarthData.Text =
                "Значение: " + (int)_arena._player.Data[ECharacteristic.Earth][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (_arena._player.Data[ECharacteristic.Earth][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (_arena._player.Data[ECharacteristic.Earth][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Мана: " +
                _arena._player.Data[ECharacteristic.Earth][EDerivative.CurrentMana].FinalValue.ToString("F1")
                + " / " +
                _arena._player.Data[ECharacteristic.Earth][EDerivative.MaxMana].FinalValue.ToString("F1") + "\n" +
                "Cопротивление: " + (_arena._player.Data[ECharacteristic.Earth][EDerivative.Resistance].FinalValue * 100).ToString("F1") + "%";
            //Air
            HeroAirData.Text =
                "Значение: " + (int)_arena._player.Data[ECharacteristic.Air][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (_arena._player.Data[ECharacteristic.Air][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (_arena._player.Data[ECharacteristic.Air][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Мана: " +
                _arena._player.Data[ECharacteristic.Air][EDerivative.CurrentMana].FinalValue.ToString("F1")
                + " / " +
                _arena._player.Data[ECharacteristic.Air][EDerivative.MaxMana].FinalValue.ToString("F1") + "\n" +
                "Cопротивление: " + (_arena._player.Data[ECharacteristic.Air][EDerivative.Resistance].FinalValue * 100).ToString("F1") + "%";





            EnemyName.Text = _arena._enemy.Character.Name;
            EnemyLevel.Text = "Lvl " + _arena._enemy.Character.Level;
            EnemyLvlExact.Text = _arena._enemy.Character.Xp + "/" + Character.levelBoundaries[_arena._enemy.Character.Level - 1];

            //Strength
            EnemyStrengthData.Text =
                "Значение: " + (int)_arena._enemy.Data[ECharacteristic.Strength][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (_arena._enemy.Data[ECharacteristic.Strength][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (_arena._enemy.Data[ECharacteristic.Strength][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Физ. сопротивление: " + (_arena._enemy.Data[ECharacteristic.Strength][EDerivative.Resistance].FinalValue * 100).ToString("F1") + "%";

            //Endurance
            EnemyEnduranceData.Text =
                "Значение: " + (int)_arena._enemy.Data[ECharacteristic.Endurance][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (_arena._enemy.Data[ECharacteristic.Endurance][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (_arena._enemy.Data[ECharacteristic.Endurance][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Здоровье: " +
                _arena._enemy.Data[ECharacteristic.Endurance][EDerivative.CurrentHealth].FinalValue.ToString("F0")
                + " / " +
                _arena._enemy.Data[ECharacteristic.Endurance][EDerivative.MaxHealth].FinalValue.ToString("F0");

            //Dexterity
            EnemyDexterityData.Text =
                "Значение: " + (int)_arena._enemy.Data[ECharacteristic.Dexterity][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (_arena._enemy.Data[ECharacteristic.Dexterity][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (_arena._enemy.Data[ECharacteristic.Dexterity][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%";


            //fire
            EnemyFireData.Text =
                "Значение: " + (int)_arena._enemy.Data[ECharacteristic.Fire][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (_arena._enemy.Data[ECharacteristic.Fire][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (_arena._enemy.Data[ECharacteristic.Fire][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Мана: " +
                _arena._enemy.Data[ECharacteristic.Fire][EDerivative.CurrentMana].FinalValue.ToString("F1")
                + " / " +
                _arena._enemy.Data[ECharacteristic.Fire][EDerivative.MaxMana].FinalValue.ToString("F1") + "\n" +
                "Cопротивление: " + (_arena._enemy.Data[ECharacteristic.Fire][EDerivative.Resistance].FinalValue * 100).ToString("F1") + "%";
            //Water
            EnemyWaterData.Text =
                "Значение: " + (int)_arena._enemy.Data[ECharacteristic.Water][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (_arena._enemy.Data[ECharacteristic.Water][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (_arena._enemy.Data[ECharacteristic.Water][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Мана: " +
                _arena._enemy.Data[ECharacteristic.Water][EDerivative.CurrentMana].FinalValue.ToString("F1")
                + " / " +
                _arena._enemy.Data[ECharacteristic.Water][EDerivative.MaxMana].FinalValue.ToString("F1") + "\n" +
                "Cопротивление: " + (_arena._enemy.Data[ECharacteristic.Water][EDerivative.Resistance].FinalValue * 100).ToString("F1") + "%";
            //Earth
            EnemyEarthData.Text =
                "Значение: " + (int)_arena._enemy.Data[ECharacteristic.Earth][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (_arena._enemy.Data[ECharacteristic.Earth][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (_arena._enemy.Data[ECharacteristic.Earth][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Мана: " +
                _arena._enemy.Data[ECharacteristic.Earth][EDerivative.CurrentMana].FinalValue.ToString("F1")
                + " / " +
                _arena._enemy.Data[ECharacteristic.Earth][EDerivative.MaxMana].FinalValue.ToString("F1") + "\n" +
                "Cопротивление: " + (_arena._enemy.Data[ECharacteristic.Earth][EDerivative.Resistance].FinalValue * 100).ToString("F1") + "%";
            //Air
            EnemyAirData.Text =
                "Значение: " + (int)_arena._enemy.Data[ECharacteristic.Air][EDerivative.Value].FinalValue + "\n" +
                "Бонус совмещения: " + (_arena._enemy.Data[ECharacteristic.Air][EDerivative.TerminationMult].FinalValue * 100 - 100).ToString("F1") + "%\n" +
                "Шанс доп. хода: " + (_arena._enemy.Data[ECharacteristic.Air][EDerivative.AddTurnChance].FinalValue * 100).ToString("F1") + "%\n" +
                "Мана: " +
                _arena._enemy.Data[ECharacteristic.Air][EDerivative.CurrentMana].FinalValue.ToString("F1")
                + " / " +
                _arena._enemy.Data[ECharacteristic.Air][EDerivative.MaxMana].FinalValue.ToString("F1") + "\n" +
                "Cопротивление: " + (_arena._enemy.Data[ECharacteristic.Air][EDerivative.Resistance].FinalValue * 100).ToString("F1") + "%";
        }

        #region Log methods
        private void LogStepExecution(object sender, EEvent args)
        {
            if (sender is CharacterSlot owner)
            {
                listBox1.Items.Add(owner.GetName + " закончил ход!");
            }
        }
        private void LogDeath(object sender, EEvent args)
        {
            if (sender is CharacterSlot owner)
            {
                listBox1.Items.Add(owner.GetName + "УМЕР!");
            }
        }
        private void LogDamageEmitting(object sender, (EEvent, EDamageType damageType, double value) data)
        {
            if (sender is CharacterSlot owner)
            {
                listBox1.Items.Add(owner.GetName + " испускает " + data.value.ToString("F1") + " едениц " + data.damageType + " урона.");
            }
        }
        private void LogDamageBlocking(object sender, (EEvent, EDamageType damageType, double value) data)
        {
            if (sender is CharacterSlot owner)
            {
                listBox1.Items.Add(owner.GetName + " блокирует " + data.value.ToString("F1") + " едениц " + data.damageType + " урона.");
            }
        }
        private void LogDamageTaking(object sender, (EEvent, EDamageType damageType, double value) data)
        {
            if (sender is CharacterSlot owner)
            {
                listBox1.Items.Add(owner.GetName + " получает " + (-data.value).ToString("F1") + " едениц " + data.damageType + " урона.");
            }
        }
        private void LogDeltaXP(object sender, (EEvent, double value) arg)
        {
            if (sender is CharacterSlot owner)
            {
                if (arg.value > 0 ) listBox1.Items.Add(owner.GetName + " получает " + arg.value.ToString("F1") + " опыта ");
                else listBox1.Items.Add(owner.GetName + " теряет " + (-arg.value).ToString("F1") + " опыта ");
            }
        }
        private void LogDeltaHP(object sender, (EEvent, double value) arg)
        {
            if (sender is CharacterSlot owner)
            {
                if (arg.value > 0) listBox1.Items.Add(owner.GetName + " восстанавливает " + arg.value.ToString("F1") + " здоровья ");
                else listBox1.Items.Add(owner.GetName + " теряет " + (-arg.value).ToString("F1") + " здоровья ");
            }
        }
        private void LogDeltaGold(object sender, (EEvent, double value) arg)
        {
            if (sender is CharacterSlot owner)
            {
                if (arg.value > 0) listBox1.Items.Add(owner.GetName + " получает " + arg.value.ToString("F1") + " золота ");
                else listBox1.Items.Add(owner.GetName + " теряет " + arg.value.ToString("F1") + " золота ");
            }
        }
        private void LogDeltaFireMana(object sender, (EEvent, double value) arg)
        {
            if (sender is CharacterSlot owner)
            {
                if (arg.value > 0) listBox1.Items.Add(owner.GetName + " получает " + arg.value.ToString("F1") + " маны огня ");
                else listBox1.Items.Add(owner.GetName + " теряет " + arg.value.ToString("F1") + " маны огня ");
            }
        }
        private void LogDeltaWaterMana(object sender, (EEvent, double value) arg)
        {
            if (sender is CharacterSlot owner)
            {
                if (arg.value > 0) listBox1.Items.Add(owner.GetName + " получает " + arg.value.ToString("F1") + " маны воды ");
                else listBox1.Items.Add(owner.GetName + " теряет " + arg.value.ToString("F1") + " маны воды ");
            }
        }
        private void LogDeltaEarthMana(object sender, (EEvent, double value) arg)
        {
            if (sender is CharacterSlot owner)
            {
                if (arg.value > 0) listBox1.Items.Add(owner.GetName + " получает " + arg.value.ToString("F1") + " маны земли ");
                else listBox1.Items.Add(owner.GetName + " теряет " + arg.value.ToString("F1") + " маны земли ");
            }
        }
        private void LogDeltaAirMana(object sender, (EEvent, double value) arg)
        {
            if (sender is CharacterSlot owner)
            {
                if (arg.value > 0) listBox1.Items.Add(owner.GetName + " получает " + arg.value.ToString("F1") + " маны воздуха ");
                else listBox1.Items.Add(owner.GetName + " теряет " + arg.value.ToString("F1") + " маны воздуха ");
            }
        }
        #endregion
        public Form1(Arena arena)
        {
            _arena = arena;
            #region log Init
            //подписка логирующих методов на ивенты
            _arena._player.StepExecution += LogStepExecution;
            _arena._enemy.StepExecution += LogStepExecution;

            _arena._player.Death += LogDeath;
            _arena._enemy.Death += LogDeath;

            _arena._player.DamageEmitting += LogDamageEmitting;
            _arena._enemy.DamageEmitting += LogDamageEmitting;

            _arena._player.DamageBlocking += LogDamageBlocking;
            _arena._enemy.DamageBlocking += LogDamageBlocking;

            _arena._player.DamageTaking += LogDamageTaking;
            _arena._enemy.DamageTaking += LogDamageTaking;

            _arena._player.DeltaXP += LogDeltaXP;
            _arena._enemy.DeltaXP += LogDeltaXP;

            _arena._player.DeltaHP += LogDeltaHP;
            _arena._enemy.DeltaHP += LogDeltaHP;

            _arena._player.DeltaGold += LogDeltaGold;
            _arena._enemy.DeltaGold += LogDeltaGold;

            _arena._player.DeltaFireMana += LogDeltaFireMana;
            _arena._enemy.DeltaFireMana += LogDeltaFireMana;

            _arena._player.DeltaWaterMana += LogDeltaWaterMana;
            _arena._enemy.DeltaWaterMana += LogDeltaWaterMana;

            _arena._player.DeltaEarthMana += LogDeltaEarthMana;
            _arena._enemy.DeltaEarthMana += LogDeltaEarthMana;

            _arena._player.DeltaAirMana += LogDeltaAirMana;
            _arena._enemy.DeltaAirMana += LogDeltaAirMana;
            #endregion

            InitializeComponent();
            UpdateData();

            var uselessInt = 3;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            EStoneType stoneType = (EStoneType)comboBox1.SelectedItem;
            int.TryParse(textBox1.Text, out int amount) ;
            _arena.StoneCombination(stoneType, amount);
            listBox1.Items.Add("---------------------------------------------------");
            UpdateData();
        }
    }
}
