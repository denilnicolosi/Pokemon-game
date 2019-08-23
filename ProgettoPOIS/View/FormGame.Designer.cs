namespace ProgettoPOIS
{
    partial class FormGame
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.picture1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSkill3 = new System.Windows.Forms.Button();
            this.buttonSkill4 = new System.Windows.Forms.Button();
            this.buttonSkill1 = new System.Windows.Forms.Button();
            this.buttonSkill2 = new System.Windows.Forms.Button();
            this.ButtonChangePokémon = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelName1 = new System.Windows.Forms.Label();
            this.labelLevel1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelName2 = new System.Windows.Forms.Label();
            this.labelLevel2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.picture2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).BeginInit();
            this.SuspendLayout();
            // 
            // picture1
            // 
            this.picture1.Location = new System.Drawing.Point(24, 212);
            this.picture1.Name = "picture1";
            this.picture1.Size = new System.Drawing.Size(98, 87);
            this.picture1.TabIndex = 0;
            this.picture1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSkill3);
            this.panel1.Controls.Add(this.buttonSkill4);
            this.panel1.Controls.Add(this.buttonSkill1);
            this.panel1.Controls.Add(this.buttonSkill2);
            this.panel1.Location = new System.Drawing.Point(107, 315);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 132);
            this.panel1.TabIndex = 4;
            // 
            // buttonSkill3
            // 
            this.buttonSkill3.Location = new System.Drawing.Point(157, 17);
            this.buttonSkill3.Name = "buttonSkill3";
            this.buttonSkill3.Size = new System.Drawing.Size(108, 38);
            this.buttonSkill3.TabIndex = 4;
            this.buttonSkill3.Text = "Skill 3";
            this.buttonSkill3.UseVisualStyleBackColor = true;
            // 
            // buttonSkill4
            // 
            this.buttonSkill4.Location = new System.Drawing.Point(157, 73);
            this.buttonSkill4.Name = "buttonSkill4";
            this.buttonSkill4.Size = new System.Drawing.Size(108, 38);
            this.buttonSkill4.TabIndex = 3;
            this.buttonSkill4.Text = "Skill 4";
            this.buttonSkill4.UseVisualStyleBackColor = true;
            // 
            // buttonSkill1
            // 
            this.buttonSkill1.Location = new System.Drawing.Point(21, 17);
            this.buttonSkill1.Name = "buttonSkill1";
            this.buttonSkill1.Size = new System.Drawing.Size(108, 38);
            this.buttonSkill1.TabIndex = 2;
            this.buttonSkill1.Text = "Skill 1";
            this.buttonSkill1.UseVisualStyleBackColor = true;
            this.buttonSkill1.Click += new System.EventHandler(this.ButtonSkill1_Click);
            // 
            // buttonSkill2
            // 
            this.buttonSkill2.Location = new System.Drawing.Point(21, 73);
            this.buttonSkill2.Name = "buttonSkill2";
            this.buttonSkill2.Size = new System.Drawing.Size(108, 38);
            this.buttonSkill2.TabIndex = 1;
            this.buttonSkill2.Text = "Skill 2";
            this.buttonSkill2.UseVisualStyleBackColor = true;
            // 
            // ButtonChangePokémon
            // 
            this.ButtonChangePokémon.Location = new System.Drawing.Point(24, 361);
            this.ButtonChangePokémon.Name = "ButtonChangePokémon";
            this.ButtonChangePokémon.Size = new System.Drawing.Size(77, 38);
            this.ButtonChangePokémon.TabIndex = 5;
            this.ButtonChangePokémon.Text = "Change pokemon";
            this.ButtonChangePokémon.UseVisualStyleBackColor = true;
            this.ButtonChangePokémon.Click += new System.EventHandler(this.ButtonChangePokémon_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelName1);
            this.panel3.Controls.Add(this.labelLevel1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Location = new System.Drawing.Point(192, 212);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 87);
            this.panel3.TabIndex = 7;
            // 
            // labelName1
            // 
            this.labelName1.AutoSize = true;
            this.labelName1.Location = new System.Drawing.Point(17, 12);
            this.labelName1.Name = "labelName1";
            this.labelName1.Size = new System.Drawing.Size(35, 13);
            this.labelName1.TabIndex = 3;
            this.labelName1.Text = "label2";
            // 
            // labelLevel1
            // 
            this.labelLevel1.AutoSize = true;
            this.labelLevel1.Location = new System.Drawing.Point(49, 33);
            this.labelLevel1.Name = "labelLevel1";
            this.labelLevel1.Size = new System.Drawing.Size(13, 13);
            this.labelLevel1.TabIndex = 2;
            this.labelLevel1.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Level";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(17, 57);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(165, 17);
            this.progressBar1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelName2);
            this.panel2.Controls.Add(this.labelLevel2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.progressBar2);
            this.panel2.Location = new System.Drawing.Point(24, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 87);
            this.panel2.TabIndex = 9;
            // 
            // labelName2
            // 
            this.labelName2.AutoSize = true;
            this.labelName2.Location = new System.Drawing.Point(17, 12);
            this.labelName2.Name = "labelName2";
            this.labelName2.Size = new System.Drawing.Size(35, 13);
            this.labelName2.TabIndex = 3;
            this.labelName2.Text = "label2";
            // 
            // labelLevel2
            // 
            this.labelLevel2.AutoSize = true;
            this.labelLevel2.Location = new System.Drawing.Point(49, 33);
            this.labelLevel2.Name = "labelLevel2";
            this.labelLevel2.Size = new System.Drawing.Size(13, 13);
            this.labelLevel2.TabIndex = 2;
            this.labelLevel2.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Level";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(17, 57);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(165, 17);
            this.progressBar2.TabIndex = 0;
            // 
            // picture2
            // 
            this.picture2.Location = new System.Drawing.Point(294, 24);
            this.picture2.Name = "picture2";
            this.picture2.Size = new System.Drawing.Size(98, 87);
            this.picture2.TabIndex = 8;
            this.picture2.TabStop = false;
            // 
            // FormGame
            // 
            this.ClientSize = new System.Drawing.Size(416, 465);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.picture2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.ButtonChangePokémon);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picture1);
            this.Name = "FormGame";
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.PictureBox picture1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSkill3;
        private System.Windows.Forms.Button buttonSkill4;
        private System.Windows.Forms.Button buttonSkill1;
        private System.Windows.Forms.Button buttonSkill2;
        private System.Windows.Forms.Button ButtonChangePokémon;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLevel1;
        private System.Windows.Forms.Label labelName1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelName2;
        private System.Windows.Forms.Label labelLevel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.PictureBox picture2;
    }
}

