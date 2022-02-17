namespace Lab7
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbP1 = new System.Windows.Forms.TextBox();
            this.tbP2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCoded = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.bChoose1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bChoose3 = new System.Windows.Forms.Button();
            this.bChoose2 = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.bCorrect = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbP1
            // 
            this.tbP1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbP1.Location = new System.Drawing.Point(383, 75);
            this.tbP1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbP1.Name = "tbP1";
            this.tbP1.Size = new System.Drawing.Size(325, 22);
            this.tbP1.TabIndex = 0;
            this.tbP1.Text = "1011";
            // 
            // tbP2
            // 
            this.tbP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbP2.Location = new System.Drawing.Point(383, 31);
            this.tbP2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbP2.Name = "tbP2";
            this.tbP2.ReadOnly = true;
            this.tbP2.Size = new System.Drawing.Size(325, 22);
            this.tbP2.TabIndex = 0;
            this.tbP2.Text = "1011";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(379, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Информационный код:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(379, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Порождающий полином:";
            // 
            // bStart
            // 
            this.bStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bStart.Location = new System.Drawing.Point(464, 111);
            this.bStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(135, 28);
            this.bStart.TabIndex = 3;
            this.bStart.Text = "Закодировать";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(383, 146);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Закодированная последовательность";
            // 
            // tbCoded
            // 
            this.tbCoded.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCoded.Location = new System.Drawing.Point(383, 166);
            this.tbCoded.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbCoded.Name = "tbCoded";
            this.tbCoded.Size = new System.Drawing.Size(329, 22);
            this.tbCoded.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(387, 198);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "Раскодировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbResult
            // 
            this.tbResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbResult.Location = new System.Drawing.Point(383, 234);
            this.tbResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(329, 22);
            this.tbResult.TabIndex = 7;
            // 
            // bChoose1
            // 
            this.bChoose1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bChoose1.Location = new System.Drawing.Point(8, 89);
            this.bChoose1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bChoose1.Name = "bChoose1";
            this.bChoose1.Size = new System.Drawing.Size(309, 28);
            this.bChoose1.TabIndex = 8;
            this.bChoose1.Text = "n=7, k=4, t=1";
            this.bChoose1.UseVisualStyleBackColor = true;
            this.bChoose1.Click += new System.EventHandler(this.bChoose1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.bChoose3);
            this.groupBox1.Controls.Add(this.bChoose2);
            this.groupBox1.Controls.Add(this.bChoose1);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(325, 198);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбрать готовый порождающий полином";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(8, 23);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(309, 57);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "n - длина кодового слова\r\nk - количество информационных бит\r\nt - количество испра" +
    "вляемых ошибок";
            // 
            // bChoose3
            // 
            this.bChoose3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bChoose3.Location = new System.Drawing.Point(8, 160);
            this.bChoose3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bChoose3.Name = "bChoose3";
            this.bChoose3.Size = new System.Drawing.Size(309, 28);
            this.bChoose3.TabIndex = 8;
            this.bChoose3.Text = "n=15, k=5, t=3";
            this.bChoose3.UseVisualStyleBackColor = true;
            this.bChoose3.Click += new System.EventHandler(this.bChoose3_Click);
            // 
            // bChoose2
            // 
            this.bChoose2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bChoose2.Location = new System.Drawing.Point(8, 124);
            this.bChoose2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bChoose2.Name = "bChoose2";
            this.bChoose2.Size = new System.Drawing.Size(309, 28);
            this.bChoose2.TabIndex = 8;
            this.bChoose2.Text = "n=15, k=7, t=2";
            this.bChoose2.UseVisualStyleBackColor = true;
            this.bChoose2.Click += new System.EventHandler(this.bChoose2_Click);
            // 
            // tbLog
            // 
            this.tbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLog.Location = new System.Drawing.Point(16, 286);
            this.tbLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(695, 173);
            this.tbLog.TabIndex = 10;
            // 
            // bCorrect
            // 
            this.bCorrect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCorrect.Location = new System.Drawing.Point(551, 198);
            this.bCorrect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bCorrect.Name = "bCorrect";
            this.bCorrect.Size = new System.Drawing.Size(157, 28);
            this.bCorrect.TabIndex = 11;
            this.bCorrect.Text = "Исправить";
            this.bCorrect.UseVisualStyleBackColor = true;
            this.bCorrect.Click += new System.EventHandler(this.bCorrect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(732, 474);
            this.Controls.Add(this.bCorrect);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbCoded);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbP2);
            this.Controls.Add(this.tbP1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "БЧХ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbP1;
        private System.Windows.Forms.TextBox tbP2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCoded;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Button bChoose1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bChoose3;
        private System.Windows.Forms.Button bChoose2;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bCorrect;
    }
}

