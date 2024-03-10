using System;

namespace Core_Mk2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.HeroPanel = new System.Windows.Forms.Panel();
            this.HeroEnduranceData = new System.Windows.Forms.Label();
            this.HeroDexterityData = new System.Windows.Forms.Label();
            this.HeroStrengthData = new System.Windows.Forms.Label();
            this.HeroAirData = new System.Windows.Forms.Label();
            this.HeroWaterData = new System.Windows.Forms.Label();
            this.HeroEarthData = new System.Windows.Forms.Label();
            this.HeroFireData = new System.Windows.Forms.Label();
            this.HeroEnduranceLabel = new System.Windows.Forms.Label();
            this.HeroDexterityLabel = new System.Windows.Forms.Label();
            this.HeroWaterLabel = new System.Windows.Forms.Label();
            this.HeroFireLabel = new System.Windows.Forms.Label();
            this.HeroAirLabel = new System.Windows.Forms.Label();
            this.HeroEarthLabel = new System.Windows.Forms.Label();
            this.HeroStrengthLabel = new System.Windows.Forms.Label();
            this.HeroCharacteristics = new System.Windows.Forms.Label();
            this.HeroLvlExact = new System.Windows.Forms.Label();
            this.HeroLevel = new System.Windows.Forms.Label();
            this.HeroName = new System.Windows.Forms.Label();
            this.EnemyPanel = new System.Windows.Forms.Panel();
            this.EnemyEnduranceData = new System.Windows.Forms.Label();
            this.EnemyDexterityData = new System.Windows.Forms.Label();
            this.EnemyStrengthData = new System.Windows.Forms.Label();
            this.EnemyAirData = new System.Windows.Forms.Label();
            this.EnemyWaterData = new System.Windows.Forms.Label();
            this.EnemyEarthData = new System.Windows.Forms.Label();
            this.EnemyFireData = new System.Windows.Forms.Label();
            this.EnemyEnduranceLabel = new System.Windows.Forms.Label();
            this.EnemyDexterityLabel = new System.Windows.Forms.Label();
            this.EnemyWaterLabel = new System.Windows.Forms.Label();
            this.EnemyFireLabel = new System.Windows.Forms.Label();
            this.EnemyAirLabel = new System.Windows.Forms.Label();
            this.EnemyEarthLabel = new System.Windows.Forms.Label();
            this.EnemyStrengthLabel = new System.Windows.Forms.Label();
            this.EnemyCharacteristics = new System.Windows.Forms.Label();
            this.EnemyLvlExact = new System.Windows.Forms.Label();
            this.EnemyLevel = new System.Windows.Forms.Label();
            this.EnemyName = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.activePlayer = new System.Windows.Forms.Label();
            this.HeroPanel.SuspendLayout();
            this.EnemyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeroPanel
            // 
            this.HeroPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
            this.HeroPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HeroPanel.Controls.Add(this.HeroEnduranceData);
            this.HeroPanel.Controls.Add(this.HeroDexterityData);
            this.HeroPanel.Controls.Add(this.HeroStrengthData);
            this.HeroPanel.Controls.Add(this.HeroAirData);
            this.HeroPanel.Controls.Add(this.HeroWaterData);
            this.HeroPanel.Controls.Add(this.HeroEarthData);
            this.HeroPanel.Controls.Add(this.HeroFireData);
            this.HeroPanel.Controls.Add(this.HeroEnduranceLabel);
            this.HeroPanel.Controls.Add(this.HeroDexterityLabel);
            this.HeroPanel.Controls.Add(this.HeroWaterLabel);
            this.HeroPanel.Controls.Add(this.HeroFireLabel);
            this.HeroPanel.Controls.Add(this.HeroAirLabel);
            this.HeroPanel.Controls.Add(this.HeroEarthLabel);
            this.HeroPanel.Controls.Add(this.HeroStrengthLabel);
            this.HeroPanel.Controls.Add(this.HeroCharacteristics);
            this.HeroPanel.Controls.Add(this.HeroLvlExact);
            this.HeroPanel.Controls.Add(this.HeroLevel);
            this.HeroPanel.Controls.Add(this.HeroName);
            this.HeroPanel.Location = new System.Drawing.Point(12, 12);
            this.HeroPanel.Name = "HeroPanel";
            this.HeroPanel.Size = new System.Drawing.Size(714, 1056);
            this.HeroPanel.TabIndex = 0;
            // 
            // HeroEnduranceData
            // 
            this.HeroEnduranceData.AutoSize = true;
            this.HeroEnduranceData.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeroEnduranceData.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.HeroEnduranceData.Location = new System.Drawing.Point(54, 435);
            this.HeroEnduranceData.Name = "HeroEnduranceData";
            this.HeroEnduranceData.Size = new System.Drawing.Size(225, 72);
            this.HeroEnduranceData.TabIndex = 44;
            this.HeroEnduranceData.Text = "Значение:\nБонус совмещения:\nШанс Доп. Хода:";
            // 
            // HeroDexterityData
            // 
            this.HeroDexterityData.AutoSize = true;
            this.HeroDexterityData.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeroDexterityData.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.HeroDexterityData.Location = new System.Drawing.Point(54, 291);
            this.HeroDexterityData.Name = "HeroDexterityData";
            this.HeroDexterityData.Size = new System.Drawing.Size(225, 72);
            this.HeroDexterityData.TabIndex = 43;
            this.HeroDexterityData.Text = "Значение:\nБонус совмещения:\nШанс Доп. Хода:";
            // 
            // HeroStrengthData
            // 
            this.HeroStrengthData.AutoSize = true;
            this.HeroStrengthData.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeroStrengthData.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.HeroStrengthData.Location = new System.Drawing.Point(54, 122);
            this.HeroStrengthData.Name = "HeroStrengthData";
            this.HeroStrengthData.Size = new System.Drawing.Size(225, 96);
            this.HeroStrengthData.TabIndex = 42;
            this.HeroStrengthData.Text = "Значение:\nБонус совмещения:\nШанс Доп. Хода:\nСопротивление:";
            // 
            // HeroAirData
            // 
            this.HeroAirData.AutoSize = true;
            this.HeroAirData.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeroAirData.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.HeroAirData.Location = new System.Drawing.Point(379, 910);
            this.HeroAirData.Name = "HeroAirData";
            this.HeroAirData.Size = new System.Drawing.Size(225, 120);
            this.HeroAirData.TabIndex = 41;
            this.HeroAirData.Text = "Значение:\nБонус совмещения:\nШанс Доп. Хода:\nМана:\nСопротивление:";
            // 
            // HeroWaterData
            // 
            this.HeroWaterData.AutoSize = true;
            this.HeroWaterData.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeroWaterData.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.HeroWaterData.Location = new System.Drawing.Point(379, 728);
            this.HeroWaterData.Name = "HeroWaterData";
            this.HeroWaterData.Size = new System.Drawing.Size(225, 120);
            this.HeroWaterData.TabIndex = 40;
            this.HeroWaterData.Text = "Значение:\nБонус совмещения:\nШанс Доп. Хода:\nМана:\nСопротивление:";
            // 
            // HeroEarthData
            // 
            this.HeroEarthData.AutoSize = true;
            this.HeroEarthData.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeroEarthData.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.HeroEarthData.Location = new System.Drawing.Point(34, 910);
            this.HeroEarthData.Name = "HeroEarthData";
            this.HeroEarthData.Size = new System.Drawing.Size(225, 120);
            this.HeroEarthData.TabIndex = 39;
            this.HeroEarthData.Text = "Значение:\nБонус совмещения:\nШанс Доп. Хода:\nМана:\nСопротивление:";
            // 
            // HeroFireData
            // 
            this.HeroFireData.AutoSize = true;
            this.HeroFireData.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeroFireData.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.HeroFireData.Location = new System.Drawing.Point(44, 728);
            this.HeroFireData.Name = "HeroFireData";
            this.HeroFireData.Size = new System.Drawing.Size(225, 120);
            this.HeroFireData.TabIndex = 38;
            this.HeroFireData.Text = "Значение:\nБонус совмещения:\nШанс Доп. Хода:\nМана:\nСопротивление:";
            // 
            // HeroEnduranceLabel
            // 
            this.HeroEnduranceLabel.AutoSize = true;
            this.HeroEnduranceLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeroEnduranceLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.HeroEnduranceLabel.Location = new System.Drawing.Point(32, 402);
            this.HeroEnduranceLabel.Name = "HeroEnduranceLabel";
            this.HeroEnduranceLabel.Size = new System.Drawing.Size(210, 33);
            this.HeroEnduranceLabel.TabIndex = 37;
            this.HeroEnduranceLabel.Text = "Выносливость:";
            // 
            // HeroDexterityLabel
            // 
            this.HeroDexterityLabel.AutoSize = true;
            this.HeroDexterityLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeroDexterityLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.HeroDexterityLabel.Location = new System.Drawing.Point(28, 258);
            this.HeroDexterityLabel.Name = "HeroDexterityLabel";
            this.HeroDexterityLabel.Size = new System.Drawing.Size(144, 33);
            this.HeroDexterityLabel.TabIndex = 33;
            this.HeroDexterityLabel.Text = "Ловкость:";
            // 
            // HeroWaterLabel
            // 
            this.HeroWaterLabel.AutoSize = true;
            this.HeroWaterLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeroWaterLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.HeroWaterLabel.Location = new System.Drawing.Point(350, 695);
            this.HeroWaterLabel.Name = "HeroWaterLabel";
            this.HeroWaterLabel.Size = new System.Drawing.Size(261, 33);
            this.HeroWaterLabel.TabIndex = 27;
            this.HeroWaterLabel.Text = "Мастерство Воды:";
            // 
            // HeroFireLabel
            // 
            this.HeroFireLabel.AutoSize = true;
            this.HeroFireLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeroFireLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.HeroFireLabel.Location = new System.Drawing.Point(15, 695);
            this.HeroFireLabel.Name = "HeroFireLabel";
            this.HeroFireLabel.Size = new System.Drawing.Size(254, 33);
            this.HeroFireLabel.TabIndex = 21;
            this.HeroFireLabel.Text = "Мастерство Огня:";
            // 
            // HeroAirLabel
            // 
            this.HeroAirLabel.AutoSize = true;
            this.HeroAirLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeroAirLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.HeroAirLabel.Location = new System.Drawing.Point(350, 877);
            this.HeroAirLabel.Name = "HeroAirLabel";
            this.HeroAirLabel.Size = new System.Drawing.Size(300, 33);
            this.HeroAirLabel.TabIndex = 15;
            this.HeroAirLabel.Text = "Мастерство Воздуха:";
            // 
            // HeroEarthLabel
            // 
            this.HeroEarthLabel.AutoSize = true;
            this.HeroEarthLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeroEarthLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.HeroEarthLabel.Location = new System.Drawing.Point(15, 877);
            this.HeroEarthLabel.Name = "HeroEarthLabel";
            this.HeroEarthLabel.Size = new System.Drawing.Size(283, 33);
            this.HeroEarthLabel.TabIndex = 9;
            this.HeroEarthLabel.Text = "Мастерство Земли:";
            // 
            // HeroStrengthLabel
            // 
            this.HeroStrengthLabel.AutoSize = true;
            this.HeroStrengthLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeroStrengthLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.HeroStrengthLabel.Location = new System.Drawing.Point(28, 89);
            this.HeroStrengthLabel.Name = "HeroStrengthLabel";
            this.HeroStrengthLabel.Size = new System.Drawing.Size(94, 33);
            this.HeroStrengthLabel.TabIndex = 4;
            this.HeroStrengthLabel.Text = "Сила:";
            // 
            // HeroCharacteristics
            // 
            this.HeroCharacteristics.AutoSize = true;
            this.HeroCharacteristics.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeroCharacteristics.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.HeroCharacteristics.Location = new System.Drawing.Point(3, 56);
            this.HeroCharacteristics.Name = "HeroCharacteristics";
            this.HeroCharacteristics.Size = new System.Drawing.Size(255, 33);
            this.HeroCharacteristics.TabIndex = 3;
            this.HeroCharacteristics.Text = "ХАРАКТЕРИСТИКИ";
            // 
            // HeroLvlExact
            // 
            this.HeroLvlExact.AutoSize = true;
            this.HeroLvlExact.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeroLvlExact.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.HeroLvlExact.Location = new System.Drawing.Point(320, 13);
            this.HeroLvlExact.Name = "HeroLvlExact";
            this.HeroLvlExact.Size = new System.Drawing.Size(29, 22);
            this.HeroLvlExact.TabIndex = 2;
            this.HeroLvlExact.Text = "lvl";
            // 
            // HeroLevel
            // 
            this.HeroLevel.AutoSize = true;
            this.HeroLevel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeroLevel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.HeroLevel.Location = new System.Drawing.Point(260, 13);
            this.HeroLevel.Name = "HeroLevel";
            this.HeroLevel.Size = new System.Drawing.Size(29, 22);
            this.HeroLevel.TabIndex = 1;
            this.HeroLevel.Text = "lvl";
            // 
            // HeroName
            // 
            this.HeroName.AutoSize = true;
            this.HeroName.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeroName.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.HeroName.Location = new System.Drawing.Point(3, 0);
            this.HeroName.Name = "HeroName";
            this.HeroName.Size = new System.Drawing.Size(214, 44);
            this.HeroName.TabIndex = 0;
            this.HeroName.Text = "HeroName";
            // 
            // EnemyPanel
            // 
            this.EnemyPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
            this.EnemyPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnemyPanel.Controls.Add(this.EnemyEnduranceData);
            this.EnemyPanel.Controls.Add(this.EnemyDexterityData);
            this.EnemyPanel.Controls.Add(this.EnemyStrengthData);
            this.EnemyPanel.Controls.Add(this.EnemyAirData);
            this.EnemyPanel.Controls.Add(this.EnemyWaterData);
            this.EnemyPanel.Controls.Add(this.EnemyEarthData);
            this.EnemyPanel.Controls.Add(this.EnemyFireData);
            this.EnemyPanel.Controls.Add(this.EnemyEnduranceLabel);
            this.EnemyPanel.Controls.Add(this.EnemyDexterityLabel);
            this.EnemyPanel.Controls.Add(this.EnemyWaterLabel);
            this.EnemyPanel.Controls.Add(this.EnemyFireLabel);
            this.EnemyPanel.Controls.Add(this.EnemyAirLabel);
            this.EnemyPanel.Controls.Add(this.EnemyEarthLabel);
            this.EnemyPanel.Controls.Add(this.EnemyStrengthLabel);
            this.EnemyPanel.Controls.Add(this.EnemyCharacteristics);
            this.EnemyPanel.Controls.Add(this.EnemyLvlExact);
            this.EnemyPanel.Controls.Add(this.EnemyLevel);
            this.EnemyPanel.Controls.Add(this.EnemyName);
            this.EnemyPanel.Location = new System.Drawing.Point(1194, 13);
            this.EnemyPanel.Name = "EnemyPanel";
            this.EnemyPanel.Size = new System.Drawing.Size(714, 1056);
            this.EnemyPanel.TabIndex = 1;
            // 
            // EnemyEnduranceData
            // 
            this.EnemyEnduranceData.AutoSize = true;
            this.EnemyEnduranceData.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnemyEnduranceData.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.EnemyEnduranceData.Location = new System.Drawing.Point(54, 435);
            this.EnemyEnduranceData.Name = "EnemyEnduranceData";
            this.EnemyEnduranceData.Size = new System.Drawing.Size(225, 72);
            this.EnemyEnduranceData.TabIndex = 44;
            this.EnemyEnduranceData.Text = "Значение:\nБонус совмещения:\nШанс Доп. Хода:";
            // 
            // EnemyDexterityData
            // 
            this.EnemyDexterityData.AutoSize = true;
            this.EnemyDexterityData.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnemyDexterityData.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.EnemyDexterityData.Location = new System.Drawing.Point(54, 291);
            this.EnemyDexterityData.Name = "EnemyDexterityData";
            this.EnemyDexterityData.Size = new System.Drawing.Size(225, 72);
            this.EnemyDexterityData.TabIndex = 43;
            this.EnemyDexterityData.Text = "Значение:\nБонус совмещения:\nШанс Доп. Хода:";
            // 
            // EnemyStrengthData
            // 
            this.EnemyStrengthData.AutoSize = true;
            this.EnemyStrengthData.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnemyStrengthData.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.EnemyStrengthData.Location = new System.Drawing.Point(54, 122);
            this.EnemyStrengthData.Name = "EnemyStrengthData";
            this.EnemyStrengthData.Size = new System.Drawing.Size(225, 96);
            this.EnemyStrengthData.TabIndex = 42;
            this.EnemyStrengthData.Text = "Значение:\nБонус совмещения:\nШанс Доп. Хода:\nСопротивление:";
            // 
            // EnemyAirData
            // 
            this.EnemyAirData.AutoSize = true;
            this.EnemyAirData.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnemyAirData.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.EnemyAirData.Location = new System.Drawing.Point(379, 910);
            this.EnemyAirData.Name = "EnemyAirData";
            this.EnemyAirData.Size = new System.Drawing.Size(225, 120);
            this.EnemyAirData.TabIndex = 41;
            this.EnemyAirData.Text = "Значение:\nБонус совмещения:\nШанс Доп. Хода:\nМана:\nСопротивление:";
            // 
            // EnemyWaterData
            // 
            this.EnemyWaterData.AutoSize = true;
            this.EnemyWaterData.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnemyWaterData.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.EnemyWaterData.Location = new System.Drawing.Point(379, 728);
            this.EnemyWaterData.Name = "EnemyWaterData";
            this.EnemyWaterData.Size = new System.Drawing.Size(225, 120);
            this.EnemyWaterData.TabIndex = 40;
            this.EnemyWaterData.Text = "Значение:\nБонус совмещения:\nШанс Доп. Хода:\nМана:\nСопротивление:";
            // 
            // EnemyEarthData
            // 
            this.EnemyEarthData.AutoSize = true;
            this.EnemyEarthData.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnemyEarthData.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.EnemyEarthData.Location = new System.Drawing.Point(34, 910);
            this.EnemyEarthData.Name = "EnemyEarthData";
            this.EnemyEarthData.Size = new System.Drawing.Size(225, 120);
            this.EnemyEarthData.TabIndex = 39;
            this.EnemyEarthData.Text = "Значение:\nБонус совмещения:\nШанс Доп. Хода:\nМана:\nСопротивление:";
            // 
            // EnemyFireData
            // 
            this.EnemyFireData.AutoSize = true;
            this.EnemyFireData.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnemyFireData.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.EnemyFireData.Location = new System.Drawing.Point(44, 728);
            this.EnemyFireData.Name = "EnemyFireData";
            this.EnemyFireData.Size = new System.Drawing.Size(225, 120);
            this.EnemyFireData.TabIndex = 38;
            this.EnemyFireData.Text = "Значение:\nБонус совмещения:\nШанс Доп. Хода:\nМана:\nСопротивление:";
            // 
            // EnemyEnduranceLabel
            // 
            this.EnemyEnduranceLabel.AutoSize = true;
            this.EnemyEnduranceLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnemyEnduranceLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.EnemyEnduranceLabel.Location = new System.Drawing.Point(32, 402);
            this.EnemyEnduranceLabel.Name = "EnemyEnduranceLabel";
            this.EnemyEnduranceLabel.Size = new System.Drawing.Size(210, 33);
            this.EnemyEnduranceLabel.TabIndex = 37;
            this.EnemyEnduranceLabel.Text = "Выносливость:";
            // 
            // EnemyDexterityLabel
            // 
            this.EnemyDexterityLabel.AutoSize = true;
            this.EnemyDexterityLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnemyDexterityLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.EnemyDexterityLabel.Location = new System.Drawing.Point(28, 258);
            this.EnemyDexterityLabel.Name = "EnemyDexterityLabel";
            this.EnemyDexterityLabel.Size = new System.Drawing.Size(144, 33);
            this.EnemyDexterityLabel.TabIndex = 33;
            this.EnemyDexterityLabel.Text = "Ловкость:";
            // 
            // EnemyWaterLabel
            // 
            this.EnemyWaterLabel.AutoSize = true;
            this.EnemyWaterLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnemyWaterLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.EnemyWaterLabel.Location = new System.Drawing.Point(350, 695);
            this.EnemyWaterLabel.Name = "EnemyWaterLabel";
            this.EnemyWaterLabel.Size = new System.Drawing.Size(261, 33);
            this.EnemyWaterLabel.TabIndex = 27;
            this.EnemyWaterLabel.Text = "Мастерство Воды:";
            // 
            // EnemyFireLabel
            // 
            this.EnemyFireLabel.AutoSize = true;
            this.EnemyFireLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnemyFireLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.EnemyFireLabel.Location = new System.Drawing.Point(15, 695);
            this.EnemyFireLabel.Name = "EnemyFireLabel";
            this.EnemyFireLabel.Size = new System.Drawing.Size(254, 33);
            this.EnemyFireLabel.TabIndex = 21;
            this.EnemyFireLabel.Text = "Мастерство Огня:";
            // 
            // EnemyAirLabel
            // 
            this.EnemyAirLabel.AutoSize = true;
            this.EnemyAirLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnemyAirLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.EnemyAirLabel.Location = new System.Drawing.Point(350, 877);
            this.EnemyAirLabel.Name = "EnemyAirLabel";
            this.EnemyAirLabel.Size = new System.Drawing.Size(300, 33);
            this.EnemyAirLabel.TabIndex = 15;
            this.EnemyAirLabel.Text = "Мастерство Воздуха:";
            // 
            // EnemyEarthLabel
            // 
            this.EnemyEarthLabel.AutoSize = true;
            this.EnemyEarthLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnemyEarthLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.EnemyEarthLabel.Location = new System.Drawing.Point(15, 877);
            this.EnemyEarthLabel.Name = "EnemyEarthLabel";
            this.EnemyEarthLabel.Size = new System.Drawing.Size(283, 33);
            this.EnemyEarthLabel.TabIndex = 9;
            this.EnemyEarthLabel.Text = "Мастерство Земли:";
            // 
            // EnemyStrengthLabel
            // 
            this.EnemyStrengthLabel.AutoSize = true;
            this.EnemyStrengthLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnemyStrengthLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.EnemyStrengthLabel.Location = new System.Drawing.Point(28, 89);
            this.EnemyStrengthLabel.Name = "EnemyStrengthLabel";
            this.EnemyStrengthLabel.Size = new System.Drawing.Size(94, 33);
            this.EnemyStrengthLabel.TabIndex = 4;
            this.EnemyStrengthLabel.Text = "Сила:";
            // 
            // EnemyCharacteristics
            // 
            this.EnemyCharacteristics.AutoSize = true;
            this.EnemyCharacteristics.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnemyCharacteristics.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.EnemyCharacteristics.Location = new System.Drawing.Point(3, 56);
            this.EnemyCharacteristics.Name = "EnemyCharacteristics";
            this.EnemyCharacteristics.Size = new System.Drawing.Size(255, 33);
            this.EnemyCharacteristics.TabIndex = 3;
            this.EnemyCharacteristics.Text = "ХАРАКТЕРИСТИКИ";
            // 
            // EnemyLvlExact
            // 
            this.EnemyLvlExact.AutoSize = true;
            this.EnemyLvlExact.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnemyLvlExact.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.EnemyLvlExact.Location = new System.Drawing.Point(320, 13);
            this.EnemyLvlExact.Name = "EnemyLvlExact";
            this.EnemyLvlExact.Size = new System.Drawing.Size(29, 22);
            this.EnemyLvlExact.TabIndex = 2;
            this.EnemyLvlExact.Text = "lvl";
            // 
            // EnemyLevel
            // 
            this.EnemyLevel.AutoSize = true;
            this.EnemyLevel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnemyLevel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.EnemyLevel.Location = new System.Drawing.Point(260, 13);
            this.EnemyLevel.Name = "EnemyLevel";
            this.EnemyLevel.Size = new System.Drawing.Size(29, 22);
            this.EnemyLevel.TabIndex = 1;
            this.EnemyLevel.Text = "lvl";
            // 
            // EnemyName
            // 
            this.EnemyName.AutoSize = true;
            this.EnemyName.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnemyName.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.EnemyName.Location = new System.Drawing.Point(3, 0);
            this.EnemyName.Name = "EnemyName";
            this.EnemyName.Size = new System.Drawing.Size(250, 44);
            this.EnemyName.TabIndex = 0;
            this.EnemyName.Text = "EnemyName";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            Core_Mk2.EStoneType.Skull,
            Core_Mk2.EStoneType.Gold,
            Core_Mk2.EStoneType.Experience,
            Core_Mk2.EStoneType.FireStone,
            Core_Mk2.EStoneType.WaterStone,
            Core_Mk2.EStoneType.AirStone,
            Core_Mk2.EStoneType.EarthStone});
            this.comboBox1.Location = new System.Drawing.Point(835, 316);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(146, 32);
            this.comboBox1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.textBox1.Location = new System.Drawing.Point(996, 316);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(63, 33);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.StartButton.Location = new System.Drawing.Point(835, 365);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(224, 35);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "Ход";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
            this.listBox1.Font = new System.Drawing.Font("Century Gothic", 10.75F);
            this.listBox1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Location = new System.Drawing.Point(732, 406);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(456, 650);
            this.listBox1.TabIndex = 6;
            // 
            // activePlayer
            // 
            this.activePlayer.AutoSize = true;
            this.activePlayer.Location = new System.Drawing.Point(872, 45);
            this.activePlayer.Name = "activePlayer";
            this.activePlayer.Size = new System.Drawing.Size(35, 13);
            this.activePlayer.TabIndex = 7;
            this.activePlayer.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Core_Mk2.Properties.Resources.фон_1;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.activePlayer);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.EnemyPanel);
            this.Controls.Add(this.HeroPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "прототип ядра";
            this.HeroPanel.ResumeLayout(false);
            this.HeroPanel.PerformLayout();
            this.EnemyPanel.ResumeLayout(false);
            this.EnemyPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel HeroPanel;
        private System.Windows.Forms.Label HeroName;
        private System.Windows.Forms.Label HeroLevel;
        private System.Windows.Forms.Label HeroLvlExact;
        private System.Windows.Forms.Label HeroCharacteristics;
        private System.Windows.Forms.Label HeroStrengthLabel;
        private System.Windows.Forms.Label HeroEarthLabel;
        private System.Windows.Forms.Label HeroAirLabel;
        private System.Windows.Forms.Label HeroWaterLabel;
        private System.Windows.Forms.Label HeroFireLabel;
        private System.Windows.Forms.Label HeroEnduranceLabel;
        private System.Windows.Forms.Label HeroDexterityLabel;
        private System.Windows.Forms.Label HeroFireData;
        private System.Windows.Forms.Label HeroAirData;
        private System.Windows.Forms.Label HeroWaterData;
        private System.Windows.Forms.Label HeroEarthData;
        private System.Windows.Forms.Label HeroStrengthData;
        private System.Windows.Forms.Label HeroDexterityData;
        private System.Windows.Forms.Label HeroEnduranceData;
        private System.Windows.Forms.Panel EnemyPanel;
        private System.Windows.Forms.Label EnemyEnduranceData;
        private System.Windows.Forms.Label EnemyDexterityData;
        private System.Windows.Forms.Label EnemyStrengthData;
        private System.Windows.Forms.Label EnemyAirData;
        private System.Windows.Forms.Label EnemyWaterData;
        private System.Windows.Forms.Label EnemyEarthData;
        private System.Windows.Forms.Label EnemyFireData;
        private System.Windows.Forms.Label EnemyEnduranceLabel;
        private System.Windows.Forms.Label EnemyDexterityLabel;
        private System.Windows.Forms.Label EnemyWaterLabel;
        private System.Windows.Forms.Label EnemyFireLabel;
        private System.Windows.Forms.Label EnemyAirLabel;
        private System.Windows.Forms.Label EnemyEarthLabel;
        private System.Windows.Forms.Label EnemyStrengthLabel;
        private System.Windows.Forms.Label EnemyCharacteristics;
        private System.Windows.Forms.Label EnemyLvlExact;
        private System.Windows.Forms.Label EnemyLevel;
        private System.Windows.Forms.Label EnemyName;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label activePlayer;
    }
}

