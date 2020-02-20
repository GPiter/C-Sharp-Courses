namespace BelieveOrNotBelieve
{
    partial class FormGame
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
            this.btnTrue = new System.Windows.Forms.Button();
            this.btnFalse = new System.Windows.Forms.Button();
            this.tbQuestion = new System.Windows.Forms.TextBox();
            this.lblNumbQuestion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTrue
            // 
            this.btnTrue.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTrue.Location = new System.Drawing.Point(86, 291);
            this.btnTrue.Name = "btnTrue";
            this.btnTrue.Size = new System.Drawing.Size(229, 61);
            this.btnTrue.TabIndex = 3;
            this.btnTrue.Text = "Правда";
            this.btnTrue.UseVisualStyleBackColor = true;
            this.btnTrue.Click += new System.EventHandler(this.BtnTrue_Click);
            // 
            // btnFalse
            // 
            this.btnFalse.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFalse.Location = new System.Drawing.Point(434, 291);
            this.btnFalse.Name = "btnFalse";
            this.btnFalse.Size = new System.Drawing.Size(229, 61);
            this.btnFalse.TabIndex = 4;
            this.btnFalse.Text = "Ложь";
            this.btnFalse.UseVisualStyleBackColor = true;
            this.btnFalse.Click += new System.EventHandler(this.BtnFalse_Click);
            // 
            // tbQuestion
            // 
            this.tbQuestion.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Bold);
            this.tbQuestion.Location = new System.Drawing.Point(100, 88);
            this.tbQuestion.Multiline = true;
            this.tbQuestion.Name = "tbQuestion";
            this.tbQuestion.ReadOnly = true;
            this.tbQuestion.Size = new System.Drawing.Size(563, 136);
            this.tbQuestion.TabIndex = 5;
            this.tbQuestion.Text = "Текст вопроса";
            // 
            // lblNumbQuestion
            // 
            this.lblNumbQuestion.AutoSize = true;
            this.lblNumbQuestion.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumbQuestion.Location = new System.Drawing.Point(289, 31);
            this.lblNumbQuestion.Name = "lblNumbQuestion";
            this.lblNumbQuestion.Size = new System.Drawing.Size(166, 33);
            this.lblNumbQuestion.TabIndex = 6;
            this.lblNumbQuestion.Text = "Номер вопроса";
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 450);
            this.Controls.Add(this.lblNumbQuestion);
            this.Controls.Add(this.tbQuestion);
            this.Controls.Add(this.btnFalse);
            this.Controls.Add(this.btnTrue);
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Believe or not believe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnTrue;
        private System.Windows.Forms.Button btnFalse;
        private System.Windows.Forms.TextBox tbQuestion;
        private System.Windows.Forms.Label lblNumbQuestion;
    }
}