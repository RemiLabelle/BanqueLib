namespace WinFormsSimulerCompte
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GroupBoxData = new GroupBox();
            CheckBoxGele = new CheckBox();
            TextBoxSolde = new TextBox();
            TextBoxDetenteur = new TextBox();
            TextBoxNumero = new TextBox();
            LabelSolde = new Label();
            LabelDetenteur = new Label();
            LabelNumero = new Label();
            GroupBoxTransaction = new GroupBox();
            RadioButton4 = new RadioButton();
            RadioButton3 = new RadioButton();
            RadioButton2 = new RadioButton();
            RadioButton1 = new RadioButton();
            ButtonRandom = new Button();
            ButtonResetMontant = new Button();
            NumericUpDownMontant = new NumericUpDown();
            TextBoxLog = new TextBox();
            ButtonDeposer = new Button();
            ButtonRetirer = new Button();
            ButtonVider = new Button();
            ButtonResetCompte = new Button();
            GroupBoxData.SuspendLayout();
            GroupBoxTransaction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownMontant).BeginInit();
            SuspendLayout();
            // 
            // GroupBoxData
            // 
            GroupBoxData.Controls.Add(CheckBoxGele);
            GroupBoxData.Controls.Add(TextBoxSolde);
            GroupBoxData.Controls.Add(TextBoxDetenteur);
            GroupBoxData.Controls.Add(TextBoxNumero);
            GroupBoxData.Controls.Add(LabelSolde);
            GroupBoxData.Controls.Add(LabelDetenteur);
            GroupBoxData.Controls.Add(LabelNumero);
            GroupBoxData.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            GroupBoxData.Location = new Point(12, 12);
            GroupBoxData.Name = "GroupBoxData";
            GroupBoxData.Size = new Size(338, 156);
            GroupBoxData.TabIndex = 0;
            GroupBoxData.TabStop = false;
            GroupBoxData.Text = "Données du compte";
            // 
            // CheckBoxGele
            // 
            CheckBoxGele.AutoSize = true;
            CheckBoxGele.Font = new Font("Segoe UI", 10F);
            CheckBoxGele.Location = new Point(238, 34);
            CheckBoxGele.Name = "CheckBoxGele";
            CheckBoxGele.Size = new Size(55, 23);
            CheckBoxGele.TabIndex = 6;
            CheckBoxGele.Text = "Gelé";
            CheckBoxGele.UseVisualStyleBackColor = true;
            CheckBoxGele.Click += CheckBoxGele_Clicked;
            // 
            // TextBoxSolde
            // 
            TextBoxSolde.Location = new Point(118, 108);
            TextBoxSolde.Name = "TextBoxSolde";
            TextBoxSolde.ReadOnly = true;
            TextBoxSolde.Size = new Size(198, 25);
            TextBoxSolde.TabIndex = 5;
            // 
            // TextBoxDetenteur
            // 
            TextBoxDetenteur.Font = new Font("Segoe UI", 10F);
            TextBoxDetenteur.Location = new Point(118, 70);
            TextBoxDetenteur.Name = "TextBoxDetenteur";
            TextBoxDetenteur.Size = new Size(198, 25);
            TextBoxDetenteur.TabIndex = 4;
            // 
            // TextBoxNumero
            // 
            TextBoxNumero.Location = new Point(118, 32);
            TextBoxNumero.Name = "TextBoxNumero";
            TextBoxNumero.ReadOnly = true;
            TextBoxNumero.Size = new Size(100, 25);
            TextBoxNumero.TabIndex = 3;
            // 
            // LabelSolde
            // 
            LabelSolde.AutoSize = true;
            LabelSolde.Font = new Font("Segoe UI", 10F);
            LabelSolde.Location = new Point(53, 111);
            LabelSolde.Name = "LabelSolde";
            LabelSolde.Size = new Size(49, 19);
            LabelSolde.TabIndex = 2;
            LabelSolde.Text = "Solde :";
            // 
            // LabelDetenteur
            // 
            LabelDetenteur.AutoSize = true;
            LabelDetenteur.Font = new Font("Segoe UI", 10F);
            LabelDetenteur.Location = new Point(24, 73);
            LabelDetenteur.Name = "LabelDetenteur";
            LabelDetenteur.Size = new Size(78, 19);
            LabelDetenteur.TabIndex = 1;
            LabelDetenteur.Text = "Détenteur :";
            // 
            // LabelNumero
            // 
            LabelNumero.AutoSize = true;
            LabelNumero.Font = new Font("Segoe UI", 10F);
            LabelNumero.Location = new Point(36, 35);
            LabelNumero.Name = "LabelNumero";
            LabelNumero.Size = new Size(66, 19);
            LabelNumero.TabIndex = 0;
            LabelNumero.Text = "Numéro :";
            // 
            // GroupBoxTransaction
            // 
            GroupBoxTransaction.Controls.Add(RadioButton4);
            GroupBoxTransaction.Controls.Add(RadioButton3);
            GroupBoxTransaction.Controls.Add(RadioButton2);
            GroupBoxTransaction.Controls.Add(RadioButton1);
            GroupBoxTransaction.Controls.Add(ButtonRandom);
            GroupBoxTransaction.Controls.Add(ButtonResetMontant);
            GroupBoxTransaction.Controls.Add(NumericUpDownMontant);
            GroupBoxTransaction.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            GroupBoxTransaction.Location = new Point(385, 12);
            GroupBoxTransaction.Name = "GroupBoxTransaction";
            GroupBoxTransaction.Size = new Size(308, 156);
            GroupBoxTransaction.TabIndex = 1;
            GroupBoxTransaction.TabStop = false;
            GroupBoxTransaction.Text = "Montant";
            // 
            // RadioButton4
            // 
            RadioButton4.AutoSize = true;
            RadioButton4.Font = new Font("Segoe UI", 10F);
            RadioButton4.Location = new Point(176, 112);
            RadioButton4.Name = "RadioButton4";
            RadioButton4.Size = new Size(98, 23);
            RadioButton4.TabIndex = 6;
            RadioButton4.Text = "100 à 1000";
            RadioButton4.UseVisualStyleBackColor = true;
            // 
            // RadioButton3
            // 
            RadioButton3.AutoSize = true;
            RadioButton3.Font = new Font("Segoe UI", 10F);
            RadioButton3.Location = new Point(176, 84);
            RadioButton3.Name = "RadioButton3";
            RadioButton3.Size = new Size(82, 23);
            RadioButton3.TabIndex = 5;
            RadioButton3.Text = "10 à 100";
            RadioButton3.UseVisualStyleBackColor = true;
            // 
            // RadioButton2
            // 
            RadioButton2.AutoSize = true;
            RadioButton2.Font = new Font("Segoe UI", 10F);
            RadioButton2.Location = new Point(176, 56);
            RadioButton2.Name = "RadioButton2";
            RadioButton2.Size = new Size(66, 23);
            RadioButton2.TabIndex = 4;
            RadioButton2.Text = "1 à 10";
            RadioButton2.UseVisualStyleBackColor = true;
            // 
            // RadioButton1
            // 
            RadioButton1.AutoSize = true;
            RadioButton1.Checked = true;
            RadioButton1.Font = new Font("Segoe UI", 10F);
            RadioButton1.Location = new Point(176, 28);
            RadioButton1.Name = "RadioButton1";
            RadioButton1.Size = new Size(58, 23);
            RadioButton1.TabIndex = 3;
            RadioButton1.TabStop = true;
            RadioButton1.Text = "0 à 1";
            RadioButton1.UseVisualStyleBackColor = true;
            // 
            // ButtonRandom
            // 
            ButtonRandom.Font = new Font("Segoe UI", 10F);
            ButtonRandom.Location = new Point(23, 105);
            ButtonRandom.Name = "ButtonRandom";
            ButtonRandom.Size = new Size(86, 29);
            ButtonRandom.TabIndex = 2;
            ButtonRandom.Text = "Random";
            ButtonRandom.UseVisualStyleBackColor = true;
            // 
            // ButtonResetMontant
            // 
            ButtonResetMontant.Font = new Font("Segoe UI", 10F);
            ButtonResetMontant.Location = new Point(23, 67);
            ButtonResetMontant.Name = "ButtonResetMontant";
            ButtonResetMontant.Size = new Size(86, 29);
            ButtonResetMontant.TabIndex = 1;
            ButtonResetMontant.Text = "0.01";
            ButtonResetMontant.UseVisualStyleBackColor = true;
            // 
            // NumericUpDownMontant
            // 
            NumericUpDownMontant.DecimalPlaces = 2;
            NumericUpDownMontant.Font = new Font("Segoe UI", 10F);
            NumericUpDownMontant.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            NumericUpDownMontant.Location = new Point(23, 29);
            NumericUpDownMontant.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            NumericUpDownMontant.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            NumericUpDownMontant.Name = "NumericUpDownMontant";
            NumericUpDownMontant.ReadOnly = true;
            NumericUpDownMontant.Size = new Size(86, 25);
            NumericUpDownMontant.TabIndex = 0;
            NumericUpDownMontant.TextAlign = HorizontalAlignment.Center;
            NumericUpDownMontant.Value = new decimal(new int[] { 1, 0, 0, 131072 });
            // 
            // TextBoxLog
            // 
            TextBoxLog.Anchor = AnchorStyles.Bottom;
            TextBoxLog.Font = new Font("Segoe UI", 10F);
            TextBoxLog.Location = new Point(12, 283);
            TextBoxLog.Multiline = true;
            TextBoxLog.Name = "TextBoxLog";
            TextBoxLog.ReadOnly = true;
            TextBoxLog.Size = new Size(681, 155);
            TextBoxLog.TabIndex = 2;
            // 
            // ButtonDeposer
            // 
            ButtonDeposer.Font = new Font("Segoe UI", 10F);
            ButtonDeposer.Location = new Point(12, 231);
            ButtonDeposer.Name = "ButtonDeposer";
            ButtonDeposer.Size = new Size(86, 29);
            ButtonDeposer.TabIndex = 3;
            ButtonDeposer.Text = "Déposer";
            ButtonDeposer.UseVisualStyleBackColor = true;
            // 
            // ButtonRetirer
            // 
            ButtonRetirer.Font = new Font("Segoe UI", 10F);
            ButtonRetirer.Location = new Point(210, 231);
            ButtonRetirer.Name = "ButtonRetirer";
            ButtonRetirer.Size = new Size(86, 29);
            ButtonRetirer.TabIndex = 4;
            ButtonRetirer.Text = "Retirer";
            ButtonRetirer.UseVisualStyleBackColor = true;
            // 
            // ButtonVider
            // 
            ButtonVider.Font = new Font("Segoe UI", 10F);
            ButtonVider.Location = new Point(408, 231);
            ButtonVider.Name = "ButtonVider";
            ButtonVider.Size = new Size(86, 29);
            ButtonVider.TabIndex = 5;
            ButtonVider.Text = "Vider";
            ButtonVider.UseVisualStyleBackColor = true;
            // 
            // ButtonResetCompte
            // 
            ButtonResetCompte.Font = new Font("Segoe UI", 10F);
            ButtonResetCompte.Location = new Point(606, 231);
            ButtonResetCompte.Name = "ButtonResetCompte";
            ButtonResetCompte.Size = new Size(86, 29);
            ButtonResetCompte.TabIndex = 6;
            ButtonResetCompte.Text = "Reset";
            ButtonResetCompte.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(705, 450);
            Controls.Add(ButtonResetCompte);
            Controls.Add(ButtonVider);
            Controls.Add(ButtonRetirer);
            Controls.Add(ButtonDeposer);
            Controls.Add(TextBoxLog);
            Controls.Add(GroupBoxTransaction);
            Controls.Add(GroupBoxData);
            Name = "Form1";
            Text = "Simulateur de Compte --- ";
            GroupBoxData.ResumeLayout(false);
            GroupBoxData.PerformLayout();
            GroupBoxTransaction.ResumeLayout(false);
            GroupBoxTransaction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownMontant).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox GroupBoxData;
        private GroupBox GroupBoxTransaction;
        private Label LabelDetenteur;
        private Label LabelNumero;
        private Label LabelSolde;
        private TextBox TextBoxSolde;
        private TextBox TextBoxDetenteur;
        private TextBox TextBoxNumero;
        private NumericUpDown NumericUpDownMontant;
        private RadioButton RadioButton4;
        private RadioButton RadioButton3;
        private RadioButton RadioButton2;
        private RadioButton RadioButton1;
        private Button ButtonRandom;
        private Button ButtonResetMontant;
        private CheckBox CheckBoxGele;
        private TextBox TextBoxLog;
        private Button ButtonDeposer;
        private Button ButtonRetirer;
        private Button ButtonVider;
        private Button ButtonResetCompte;
    }
}
