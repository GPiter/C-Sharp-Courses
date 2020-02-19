namespace BelieveOrNotBelieve
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tbTextQuestion = new System.Windows.Forms.TextBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnAddQuestion = new System.Windows.Forms.Button();
            this.btnDeleteQuestion = new System.Windows.Forms.Button();
            this.btnSaveQuestion = new System.Windows.Forms.Button();
            this.nudNumbQuestion = new System.Windows.Forms.NumericUpDown();
            this.cbTruth = new System.Windows.Forms.CheckBox();
            this.lblCountQuestion = new System.Windows.Forms.Label();
            this.tsmiMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAboutProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumbQuestion)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMenu,
            this.tsmiAboutProgram});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(588, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tbTextQuestion
            // 
            this.tbTextQuestion.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbTextQuestion.Location = new System.Drawing.Point(0, 24);
            this.tbTextQuestion.Multiline = true;
            this.tbTextQuestion.Name = "tbTextQuestion";
            this.tbTextQuestion.Size = new System.Drawing.Size(588, 343);
            this.tbTextQuestion.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblCountQuestion);
            this.panelBottom.Controls.Add(this.cbTruth);
            this.panelBottom.Controls.Add(this.nudNumbQuestion);
            this.panelBottom.Controls.Add(this.btnSaveQuestion);
            this.panelBottom.Controls.Add(this.btnDeleteQuestion);
            this.panelBottom.Controls.Add(this.btnAddQuestion);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 366);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(588, 84);
            this.panelBottom.TabIndex = 2;
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.Location = new System.Drawing.Point(19, 33);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(75, 23);
            this.btnAddQuestion.TabIndex = 0;
            this.btnAddQuestion.Text = "Добавить";
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            this.btnAddQuestion.Click += new System.EventHandler(this.BtnAddQuestion_Click);
            // 
            // btnDeleteQuestion
            // 
            this.btnDeleteQuestion.Location = new System.Drawing.Point(134, 33);
            this.btnDeleteQuestion.Name = "btnDeleteQuestion";
            this.btnDeleteQuestion.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteQuestion.TabIndex = 1;
            this.btnDeleteQuestion.Text = "Удалить";
            this.btnDeleteQuestion.UseVisualStyleBackColor = true;
            this.btnDeleteQuestion.Click += new System.EventHandler(this.BtnDeleteQuestion_Click);
            // 
            // btnSaveQuestion
            // 
            this.btnSaveQuestion.Location = new System.Drawing.Point(246, 33);
            this.btnSaveQuestion.Name = "btnSaveQuestion";
            this.btnSaveQuestion.Size = new System.Drawing.Size(75, 23);
            this.btnSaveQuestion.TabIndex = 2;
            this.btnSaveQuestion.Text = "Сохранить";
            this.btnSaveQuestion.UseVisualStyleBackColor = true;
            this.btnSaveQuestion.Click += new System.EventHandler(this.BtnSaveQuestion_Click);
            // 
            // nudNumbQuestion
            // 
            this.nudNumbQuestion.Location = new System.Drawing.Point(361, 36);
            this.nudNumbQuestion.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudNumbQuestion.Name = "nudNumbQuestion";
            this.nudNumbQuestion.Size = new System.Drawing.Size(101, 20);
            this.nudNumbQuestion.TabIndex = 3;
            this.nudNumbQuestion.ValueChanged += new System.EventHandler(this.NudNumbQuestion_ValueChanged);
            // 
            // cbTruth
            // 
            this.cbTruth.AutoSize = true;
            this.cbTruth.Location = new System.Drawing.Point(492, 36);
            this.cbTruth.Name = "cbTruth";
            this.cbTruth.Size = new System.Drawing.Size(64, 17);
            this.cbTruth.TabIndex = 4;
            this.cbTruth.Text = "Правда";
            this.cbTruth.UseVisualStyleBackColor = true;
            // 
            // lblCountQuestion
            // 
            this.lblCountQuestion.AutoSize = true;
            this.lblCountQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCountQuestion.Location = new System.Drawing.Point(347, 12);
            this.lblCountQuestion.Name = "lblCountQuestion";
            this.lblCountQuestion.Size = new System.Drawing.Size(128, 15);
            this.lblCountQuestion.TabIndex = 5;
            this.lblCountQuestion.Text = "Всего вопросов: 0";
            // 
            // tsmiMenu
            // 
            this.tsmiMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNew,
            this.tsmiSave,
            this.tsmiLoad,
            this.toolStripMenuItem1,
            this.tsmiExit});
            this.tsmiMenu.Name = "tsmiMenu";
            this.tsmiMenu.Size = new System.Drawing.Size(53, 20);
            this.tsmiMenu.Text = "Меню";
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(180, 22);
            this.tsmiSave.Text = "Сохранить";
            this.tsmiSave.Click += new System.EventHandler(this.TsmiSave_Click);
            // 
            // tsmiLoad
            // 
            this.tsmiLoad.Name = "tsmiLoad";
            this.tsmiLoad.Size = new System.Drawing.Size(180, 22);
            this.tsmiLoad.Text = "Загрузить";
            this.tsmiLoad.Click += new System.EventHandler(this.TsmiLoad_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(180, 22);
            this.tsmiExit.Text = "Выход";
            this.tsmiExit.Click += new System.EventHandler(this.TsmiExit_Click);
            // 
            // tsmiNew
            // 
            this.tsmiNew.Name = "tsmiNew";
            this.tsmiNew.Size = new System.Drawing.Size(180, 22);
            this.tsmiNew.Text = "Новый";
            this.tsmiNew.Click += new System.EventHandler(this.TsmiNew_Click);
            // 
            // tsmiAboutProgram
            // 
            this.tsmiAboutProgram.Name = "tsmiAboutProgram";
            this.tsmiAboutProgram.Size = new System.Drawing.Size(94, 20);
            this.tsmiAboutProgram.Text = "О программе";
            this.tsmiAboutProgram.Click += new System.EventHandler(this.TsmiAboutProgram_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 450);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.tbTextQuestion);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Believe or not believe";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumbQuestion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox tbTextQuestion;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.CheckBox cbTruth;
        private System.Windows.Forms.NumericUpDown nudNumbQuestion;
        private System.Windows.Forms.Button btnSaveQuestion;
        private System.Windows.Forms.Button btnDeleteQuestion;
        private System.Windows.Forms.Button btnAddQuestion;
        private System.Windows.Forms.Label lblCountQuestion;
        private System.Windows.Forms.ToolStripMenuItem tsmiMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoad;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiAboutProgram;
    }
}

