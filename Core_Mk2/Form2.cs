using Core_Mk2.Properties;
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
    public partial class Form2 : Form
    {
        public Character testHero;
        public Character testEnemy;
        public Arena arena;
        public TableLayoutPanel StoneGrid;
        public Image SkullImage = Image.FromFile("D:/Work/GitHub/Core_Mk2/Core_Mk2/Resources/SkullIcon.png");
        public Image GoldImage = Image.FromFile("D:/Work/GitHub/Core_Mk2/Core_Mk2/Resources/GoldIcon.png");
        public Image XPImage = Image.FromFile("D:/Work/GitHub/Core_Mk2/Core_Mk2/Resources/XPIcon.png");
        public Image AirImage = Image.FromFile("D:/Work/GitHub/Core_Mk2/Core_Mk2/Resources/AirIcon.png");
        public Image FireImage = Image.FromFile("D:/Work/GitHub/Core_Mk2/Core_Mk2/Resources/FireIcon.png");
        public Image WaterImage = Image.FromFile("D:/Work/GitHub/Core_Mk2/Core_Mk2/Resources/WaterIcon.png");
        public Image EarthImage = Image.FromFile("D:/Work/GitHub/Core_Mk2/Core_Mk2/Resources/EarthIcon.png");
        public Form2()
        {
            InitializeComponent();

            var CBuilder = new Character.CBuilder();
            var PPMBuilder = new PassiveParameterModifier.PPMBuilder();
            var TPMBuilder = new TriggerParameterModifier.TPMBuilder();
            var LMEBuilder = new LogicalModuleEffect.LMEBuilder();


            var sword = new Equipment(EBodyPart.Weapon, "Древний Эльфийский Меч");

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
                .AddValue(0.05f)
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



            testHero = CBuilder
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

            testEnemy = CBuilder
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
            arena.InitializeGrid();

            StoneGrid = new System.Windows.Forms.TableLayoutPanel();
            StoneGrid.AutoSize = true;
            StoneGrid.ColumnCount = arena.GetGridSize();
            StoneGrid.RowCount = arena.GetGridSize();
            StoneGrid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            StoneGrid.Location = new System.Drawing.Point(10, 10);
            StoneGrid.Show();
            Controls.Add(StoneGrid);
        }
        private PictureBox CreateStone()
        {
            PictureBox Stone = new PictureBox();
            Stone.Dock = DockStyle.Fill;
            Stone.Margin = new System.Windows.Forms.Padding(0);
            Stone.Click += new EventHandler(StoneClick);
            Stone.Dock = DockStyle.Fill;
            return Stone;
        }
        private Image GetPicture(EStoneType stoneType)
        {
            switch (stoneType)
            {
                case EStoneType.Skull:
                    return SkullImage;
                case EStoneType.Gold:
                    return GoldImage;
                case EStoneType.Experience:
                    return XPImage;
                case EStoneType.FireStone:
                    return FireImage;
                case EStoneType.WaterStone:
                    return WaterImage;
                case EStoneType.AirStone:
                    return AirImage;
                case EStoneType.EarthStone:
                    return EarthImage;
                default:
                    return SkullImage;
            }
        }
        private void StoneClick(object sender, EventArgs e)
        {
            PictureBox Stone = sender as PictureBox;
            Stone.BackColor = Color.Blue;
            for (int i = Math.Max(StoneGrid.GetCellPosition(Stone).Column - 1, 0); i <= Math.Min(StoneGrid.GetCellPosition(Stone).Column + 1, arena.GetGridSize()-1); i++)
                for (int j = Math.Max(StoneGrid.GetCellPosition(Stone).Row - 1, 0); j <= Math.Min(StoneGrid.GetCellPosition(Stone).Row + 1, arena.GetGridSize()-1); j++)
                    if ((StoneGrid.GetControlFromPosition(i, j).BackColor == Color.Blue)&&!((i==StoneGrid.GetCellPosition(Stone).Column)&&(j==StoneGrid.GetCellPosition(Stone).Row)))
                    {
                        arena.SwapStones(i, j, StoneGrid.GetCellPosition(Stone).Column, StoneGrid.GetCellPosition(Stone).Row);
                        StoneGrid.GetControlFromPosition(i, j).BackColor = Color.Transparent;
                        Stone.BackColor = Color.Transparent;
                    }
            UpdateGrid();
            timer1.Start();
        }
        private void DrawStone(int x, int y)
        {
            PictureBox l = StoneGrid.GetControlFromPosition(x, y) as PictureBox;
            l.Image = GetPicture(arena.GetStoneGrid()[x,y]);
        }
        private void UpdateGrid()
        {
            for (int i = 0; i < arena.GetGridSize(); i++)
                for (int j = 0; j < arena.GetGridSize(); j++)
                    DrawStone(i, j);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < arena.GetGridSize(); i++)
            {
                StoneGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32));
                StoneGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
                for (int j = 0; j < arena.GetGridSize(); j++)
                    StoneGrid.Controls.Add(CreateStone(), i, j);
            }
            UpdateGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            arena.ScanField();
            UpdateGrid();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            arena.ScanField();
            UpdateGrid();
            timer1.Stop();
        }
    }
}
