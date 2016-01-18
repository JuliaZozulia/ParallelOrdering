namespace Уровневый_принцип
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
            this.dg_enter = new System.Windows.Forms.DataGridView();
            this.LoadFromFile = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dg_Smax = new System.Windows.Forms.DataGridView();
            this.dg_Smin = new System.Windows.Forms.DataGridView();
            this.dg_h = new System.Windows.Forms.DataGridView();
            this.Enter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_enter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Smax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Smin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_h)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg_enter
            // 
            this.dg_enter.BackgroundColor = System.Drawing.Color.Snow;
            this.dg_enter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_enter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_enter.Location = new System.Drawing.Point(18, 17);
            this.dg_enter.Name = "dg_enter";
            this.dg_enter.Size = new System.Drawing.Size(380, 346);
            this.dg_enter.TabIndex = 0;
            this.dg_enter.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dg_enter_RowsAdded);
            this.dg_enter.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dg_enter_RowsRemoved);
            // 
            // LoadFromFile
            // 
            this.LoadFromFile.Location = new System.Drawing.Point(6, 42);
            this.LoadFromFile.Name = "LoadFromFile";
            this.LoadFromFile.Size = new System.Drawing.Size(136, 46);
            this.LoadFromFile.TabIndex = 1;
            this.LoadFromFile.Text = "Зчитати граф з файлу";
            this.LoadFromFile.UseVisualStyleBackColor = true;
            this.LoadFromFile.Click += new System.EventHandler(this.LoadFromFile_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(416, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 454);
            this.panel1.TabIndex = 2;
            // 
            // dg_Smax
            // 
            this.dg_Smax.BackgroundColor = System.Drawing.Color.Snow;
            this.dg_Smax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_Smax.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Smax.Location = new System.Drawing.Point(303, 83);
            this.dg_Smax.Name = "dg_Smax";
            this.dg_Smax.Size = new System.Drawing.Size(249, 212);
            this.dg_Smax.TabIndex = 3;
            // 
            // dg_Smin
            // 
            this.dg_Smin.BackgroundColor = System.Drawing.Color.Snow;
            this.dg_Smin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_Smin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Smin.Location = new System.Drawing.Point(15, 77);
            this.dg_Smin.Name = "dg_Smin";
            this.dg_Smin.Size = new System.Drawing.Size(249, 218);
            this.dg_Smin.TabIndex = 4;
            // 
            // dg_h
            // 
            this.dg_h.BackgroundColor = System.Drawing.Color.Snow;
            this.dg_h.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_h.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_h.Location = new System.Drawing.Point(55, 179);
            this.dg_h.Name = "dg_h";
            this.dg_h.Size = new System.Drawing.Size(48, 23);
            this.dg_h.TabIndex = 5;
            this.dg_h.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dg_h_RowsAdded);
            // 
            // Enter
            // 
            this.Enter.Location = new System.Drawing.Point(6, 25);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(136, 74);
            this.Enter.TabIndex = 6;
            this.Enter.Text = "Модифікований рівневий принцип";
            this.Enter.UseVisualStyleBackColor = true;
            this.Enter.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Задайте h:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.dg_h);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LoadFromFile);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 777);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вхідні данні:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.Enter);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.ForeColor = System.Drawing.Color.SaddleBrown;
            this.groupBox4.Location = new System.Drawing.Point(6, 220);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(146, 239);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Знайти:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 164);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(136, 67);
            this.button3.TabIndex = 13;
            this.button3.Text = "Перевірка доцільності переривань";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 53);
            this.button2.TabIndex = 12;
            this.button2.Text = "Метод декомпозиції";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 50);
            this.button1.TabIndex = 11;
            this.button1.Text = "Зчитати граф з таблиці";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "h[i]=";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(62, 483);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(83, 23);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "h = const";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Visible = false;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(62, 512);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(67, 23);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "h різні";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Visible = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.dg_enter);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.groupBox2.Location = new System.Drawing.Point(176, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(805, 477);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Заданий граф обмежень:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.dg_Smin);
            this.groupBox3.Controls.Add(this.dg_Smax);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.ForeColor = System.Drawing.Color.SaddleBrown;
            this.groupBox3.Location = new System.Drawing.Point(176, 495);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(801, 305);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Знайдені впорядкування:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 19);
            this.label4.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 19);
            this.label3.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(984, 801);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Рівневий принцип";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_enter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Smax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Smin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_h)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_enter;
        private System.Windows.Forms.Button LoadFromFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dg_Smax;
        private System.Windows.Forms.DataGridView dg_Smin;
        private System.Windows.Forms.DataGridView dg_h;
        private System.Windows.Forms.Button Enter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

