namespace BelieveOrNotBelieve
{
    partial class FormMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnAboutProgram = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(98, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "Игра верю не верю";
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPlay.Location = new System.Drawing.Point(129, 122);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(229, 61);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.Text = "Играть";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // btnAboutProgram
            // 
            this.btnAboutProgram.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnAboutProgram.Location = new System.Drawing.Point(129, 211);
            this.btnAboutProgram.Name = "btnAboutProgram";
            this.btnAboutProgram.Size = new System.Drawing.Size(229, 61);
            this.btnAboutProgram.TabIndex = 3;
            this.btnAboutProgram.Text = "О программе";
            this.btnAboutProgram.UseVisualStyleBackColor = true;
            this.btnAboutProgram.Click += new System.EventHandler(this.BtnAboutProgram_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSettings.Location = new System.Drawing.Point(129, 298);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(229, 61);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "Настройки";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnExit.Location = new System.Drawing.Point(129, 384);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(229, 61);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 515);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnAboutProgram);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.label1);
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Believe or not believe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnAboutProgram;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnExit;
    }
}