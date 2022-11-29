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
            this.ListAI = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PredButton
            // 
            this.PredButton.Location = new System.Drawing.Point(184, 204);
            this.PredButton.Name = "PredButton";
            this.PredButton.Size = new System.Drawing.Size(84, 39);
            this.PredButton.TabIndex = 0;
            this.PredButton.Text = "Распознать символ";
            this.PredButton.UseVisualStyleBackColor = true;
            this.PredButton.Click += new System.EventHandler(this.PredButton_Click);
            // 
            // ListAI
            // 
            this.ListAI.FormattingEnabled = true;
            this.ListAI.Items.AddRange(new object[] {
            "Нейронная сеть Хемминга",
            "Нейронная сеть Хопфилда"});
            this.ListAI.Location = new System.Drawing.Point(12, 222);
            this.ListAI.Name = "ListAI";
            this.ListAI.Size = new System.Drawing.Size(166, 21);
            this.ListAI.TabIndex = 1;
            this.ListAI.SelectedIndexChanged += new System.EventHandler(this.ListAI_SelectedIndexChanged);
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
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListAI);
            this.Controls.Add(this.PredButton);
            this.Name = "ViewForm";
            this.Text = "ViewForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PredButton;
        private System.Windows.Forms.ComboBox ListAI;
        private System.Windows.Forms.Label label1;
    }
}

