namespace ProgettoPOIS.View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame));
            this.picture1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSkill3 = new System.Windows.Forms.Button();
            this.labelPlayer = new System.Windows.Forms.Label();
            this.buttonSkill4 = new System.Windows.Forms.Button();
            this.buttonSkill1 = new System.Windows.Forms.Button();
            this.ButtonChangePokemon = new System.Windows.Forms.Button();
            this.buttonSkill2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.hp1 = new System.Windows.Forms.Label();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.labelExp1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelName1 = new System.Windows.Forms.Label();
            this.labelLevel1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.hp2 = new System.Windows.Forms.Label();
            this.progressBar4 = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.labelExp2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelName2 = new System.Windows.Forms.Label();
            this.labelLevel2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.picture2 = new System.Windows.Forms.PictureBox();
            this.labelMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).BeginInit();
            this.SuspendLayout();
            // 
            // picture1
            // 
            this.picture1.BackColor = System.Drawing.Color.Transparent;
            this.picture1.Location = new System.Drawing.Point(25, 226);
            this.picture1.Name = "picture1";
            this.picture1.Size = new System.Drawing.Size(80, 80);
            this.picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture1.TabIndex = 0;
            this.picture1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonSkill3);
            this.panel1.Controls.Add(this.labelPlayer);
            this.panel1.Controls.Add(this.buttonSkill4);
            this.panel1.Controls.Add(this.buttonSkill1);
            this.panel1.Controls.Add(this.ButtonChangePokemon);
            this.panel1.Controls.Add(this.buttonSkill2);
            this.panel1.Location = new System.Drawing.Point(12, 315);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 132);
            this.panel1.TabIndex = 4;
            // 
            // buttonSkill3
            // 
            this.buttonSkill3.Location = new System.Drawing.Point(259, 17);
            this.buttonSkill3.Name = "buttonSkill3";
            this.buttonSkill3.Size = new System.Drawing.Size(108, 38);
            this.buttonSkill3.TabIndex = 4;
            this.buttonSkill3.Text = "Skill 3";
            this.buttonSkill3.UseVisualStyleBackColor = true;
            this.buttonSkill3.Click += new System.EventHandler(this.ButtonSkill3_Click);
            // 
            // labelPlayer
            // 
            this.labelPlayer.AutoSize = true;
            this.labelPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer.Location = new System.Drawing.Point(13, 23);
            this.labelPlayer.Name = "labelPlayer";
            this.labelPlayer.Size = new System.Drawing.Size(101, 29);
            this.labelPlayer.TabIndex = 10;
            this.labelPlayer.Text = "Player1";
            // 
            // buttonSkill4
            // 
            this.buttonSkill4.Location = new System.Drawing.Point(259, 73);
            this.buttonSkill4.Name = "buttonSkill4";
            this.buttonSkill4.Size = new System.Drawing.Size(108, 38);
            this.buttonSkill4.TabIndex = 3;
            this.buttonSkill4.Text = "Skill 4";
            this.buttonSkill4.UseVisualStyleBackColor = true;
            this.buttonSkill4.Click += new System.EventHandler(this.ButtonSkill4_Click);
            // 
            // buttonSkill1
            // 
            this.buttonSkill1.Location = new System.Drawing.Point(131, 17);
            this.buttonSkill1.Name = "buttonSkill1";
            this.buttonSkill1.Size = new System.Drawing.Size(108, 38);
            this.buttonSkill1.TabIndex = 2;
            this.buttonSkill1.Text = "Skill 1";
            this.buttonSkill1.UseVisualStyleBackColor = true;
            this.buttonSkill1.Click += new System.EventHandler(this.ButtonSkill1_Click);
            // 
            // ButtonChangePokemon
            // 
            this.ButtonChangePokemon.Location = new System.Drawing.Point(7, 73);
            this.ButtonChangePokemon.Name = "ButtonChangePokemon";
            this.ButtonChangePokemon.Size = new System.Drawing.Size(104, 38);
            this.ButtonChangePokemon.TabIndex = 5;
            this.ButtonChangePokemon.Text = "Change pokemon";
            this.ButtonChangePokemon.UseVisualStyleBackColor = true;
            this.ButtonChangePokemon.Click += new System.EventHandler(this.ButtonChangePokemon_Click);
            // 
            // buttonSkill2
            // 
            this.buttonSkill2.Location = new System.Drawing.Point(131, 73);
            this.buttonSkill2.Name = "buttonSkill2";
            this.buttonSkill2.Size = new System.Drawing.Size(108, 38);
            this.buttonSkill2.TabIndex = 1;
            this.buttonSkill2.Text = "Skill 2";
            this.buttonSkill2.UseVisualStyleBackColor = true;
            this.buttonSkill2.Click += new System.EventHandler(this.ButtonSkill2_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.hp1);
            this.panel3.Controls.Add(this.progressBar3);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.labelExp1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.labelName1);
            this.panel3.Controls.Add(this.labelLevel1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Location = new System.Drawing.Point(142, 216);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(254, 87);
            this.panel3.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "HP";
            // 
            // hp1
            // 
            this.hp1.AutoSize = true;
            this.hp1.Location = new System.Drawing.Point(224, 58);
            this.hp1.Name = "hp1";
            this.hp1.Size = new System.Drawing.Size(25, 13);
            this.hp1.TabIndex = 12;
            this.hp1.Text = "100";
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(31, 57);
            this.progressBar3.MarqueeAnimationSpeed = 0;
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(187, 17);
            this.progressBar3.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar3.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "/100";
            // 
            // labelExp1
            // 
            this.labelExp1.AutoSize = true;
            this.labelExp1.Location = new System.Drawing.Point(89, 34);
            this.labelExp1.Name = "labelExp1";
            this.labelExp1.Size = new System.Drawing.Size(25, 13);
            this.labelExp1.TabIndex = 5;
            this.labelExp1.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Exp";
            // 
            // labelName1
            // 
            this.labelName1.AutoSize = true;
            this.labelName1.Location = new System.Drawing.Point(8, 11);
            this.labelName1.Name = "labelName1";
            this.labelName1.Size = new System.Drawing.Size(38, 13);
            this.labelName1.TabIndex = 3;
            this.labelName1.Text = "Name ";
            // 
            // labelLevel1
            // 
            this.labelLevel1.AutoSize = true;
            this.labelLevel1.Location = new System.Drawing.Point(38, 34);
            this.labelLevel1.Name = "labelLevel1";
            this.labelLevel1.Size = new System.Drawing.Size(13, 13);
            this.labelLevel1.TabIndex = 2;
            this.labelLevel1.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Level";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(31, 57);
            this.progressBar1.MarqueeAnimationSpeed = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(187, 17);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.hp2);
            this.panel2.Controls.Add(this.progressBar4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.labelExp2);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.labelName2);
            this.panel2.Controls.Add(this.labelLevel2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.progressBar2);
            this.panel2.Location = new System.Drawing.Point(27, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(254, 87);
            this.panel2.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "HP";
            // 
            // hp2
            // 
            this.hp2.AutoSize = true;
            this.hp2.Location = new System.Drawing.Point(225, 59);
            this.hp2.Name = "hp2";
            this.hp2.Size = new System.Drawing.Size(25, 13);
            this.hp2.TabIndex = 11;
            this.hp2.Text = "100";
            // 
            // progressBar4
            // 
            this.progressBar4.Location = new System.Drawing.Point(33, 57);
            this.progressBar4.MarqueeAnimationSpeed = 0;
            this.progressBar4.Name = "progressBar4";
            this.progressBar4.Size = new System.Drawing.Size(187, 17);
            this.progressBar4.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar4.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(113, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "/100";
            // 
            // labelExp2
            // 
            this.labelExp2.AutoSize = true;
            this.labelExp2.Location = new System.Drawing.Point(92, 33);
            this.labelExp2.Name = "labelExp2";
            this.labelExp2.Size = new System.Drawing.Size(25, 13);
            this.labelExp2.TabIndex = 8;
            this.labelExp2.Text = "100";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Exp";
            // 
            // labelName2
            // 
            this.labelName2.AutoSize = true;
            this.labelName2.Location = new System.Drawing.Point(8, 12);
            this.labelName2.Name = "labelName2";
            this.labelName2.Size = new System.Drawing.Size(35, 13);
            this.labelName2.TabIndex = 3;
            this.labelName2.Text = "Name";
            // 
            // labelLevel2
            // 
            this.labelLevel2.AutoSize = true;
            this.labelLevel2.Location = new System.Drawing.Point(40, 33);
            this.labelLevel2.Name = "labelLevel2";
            this.labelLevel2.Size = new System.Drawing.Size(13, 13);
            this.labelLevel2.TabIndex = 2;
            this.labelLevel2.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Level";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(33, 57);
            this.progressBar2.MarqueeAnimationSpeed = 0;
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(187, 17);
            this.progressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar2.TabIndex = 0;
            // 
            // picture2
            // 
            this.picture2.BackColor = System.Drawing.Color.Transparent;
            this.picture2.Location = new System.Drawing.Point(313, 54);
            this.picture2.Name = "picture2";
            this.picture2.Size = new System.Drawing.Size(80, 80);
            this.picture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture2.TabIndex = 8;
            this.picture2.TabStop = false;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.BackColor = System.Drawing.Color.Transparent;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(27, 157);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(112, 29);
            this.labelMessage.TabIndex = 11;
            this.labelMessage.Text = "message";
            // 
            // FormGame
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(416, 456);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.picture2);
            this.Controls.Add(this.picture1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGame";
            this.Text = "Pokemon battle";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGame_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.PictureBox picture1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSkill3;
        private System.Windows.Forms.Button buttonSkill4;
        private System.Windows.Forms.Button buttonSkill1;
        private System.Windows.Forms.Button buttonSkill2;
        private System.Windows.Forms.Button ButtonChangePokemon;
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
        private System.Windows.Forms.Label labelPlayer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelExp1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelExp2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.ProgressBar progressBar4;
        private System.Windows.Forms.Label hp2;
        private System.Windows.Forms.Label hp1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelMessage;
    }
}

