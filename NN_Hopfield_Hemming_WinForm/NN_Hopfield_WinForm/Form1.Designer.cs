namespace NN_Hopfield_WinForm
{
    partial class ViewForm
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
            this.PredButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelListAvailableLetters = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxHemming = new System.Windows.Forms.CheckBox();
            this.checkBoxHopfield = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // PredButton
            // 
            this.PredButton.Location = new System.Drawing.Point(478, 204);
            this.PredButton.Name = "PredButton";
            this.PredButton.Size = new System.Drawing.Size(84, 39);
            this.PredButton.TabIndex = 0;
            this.PredButton.Text = "Распознать символ";
            this.PredButton.UseVisualStyleBackColor = true;
            this.PredButton.Click += new System.EventHandler(this.PredButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Использовать:";
            // 
            // labelListAvailableLetters
            // 
            this.labelListAvailableLetters.AutoSize = true;
            this.labelListAvailableLetters.Location = new System.Drawing.Point(12, 263);
            this.labelListAvailableLetters.Name = "labelListAvailableLetters";
            this.labelListAvailableLetters.Size = new System.Drawing.Size(0, 13);
            this.labelListAvailableLetters.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Р",
            "О",
            "Т",
            "Д"});
            this.comboBox1.Location = new System.Drawing.Point(12, 279);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(166, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Буквы, доступные для распознования";
            // 
            // checkBoxHemming
            // 
            this.checkBoxHemming.AutoSize = true;
            this.checkBoxHemming.Location = new System.Drawing.Point(15, 226);
            this.checkBoxHemming.Name = "checkBoxHemming";
            this.checkBoxHemming.Size = new System.Drawing.Size(72, 17);
            this.checkBoxHemming.TabIndex = 7;
            this.checkBoxHemming.Text = "Хемминг";
            this.checkBoxHemming.UseVisualStyleBackColor = true;
            this.checkBoxHemming.CheckedChanged += new System.EventHandler(this.CheckBoxHemming_CheckedChanged);
            // 
            // checkBoxHopfield
            // 
            this.checkBoxHopfield.AutoSize = true;
            this.checkBoxHopfield.Location = new System.Drawing.Point(106, 226);
            this.checkBoxHopfield.Name = "checkBoxHopfield";
            this.checkBoxHopfield.Size = new System.Drawing.Size(71, 17);
            this.checkBoxHopfield.TabIndex = 8;
            this.checkBoxHopfield.Text = "Хопфилд";
            this.checkBoxHopfield.UseVisualStyleBackColor = true;
            this.checkBoxHopfield.CheckedChanged += new System.EventHandler(this.CheckBoxHopfield_CheckedChanged);
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 511);
            this.Controls.Add(this.checkBoxHopfield);
            this.Controls.Add(this.checkBoxHemming);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelListAvailableLetters);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PredButton);
            this.Name = "ViewForm";
            this.Text = "ViewForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PredButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelListAvailableLetters;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxHemming;
        private System.Windows.Forms.CheckBox checkBoxHopfield;
    }
}

