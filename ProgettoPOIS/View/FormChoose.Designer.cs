namespace ProgettoPOIS.View
{
    partial class FormChoose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChoose));
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelPlayer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelSkill2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelSkill1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelDefence = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.picture = new System.Windows.Forms.PictureBox();
            this.labelAttack = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelAttribute = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBox
            // 
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point(12, 110);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(281, 334);
            this.checkedListBox.TabIndex = 0;
            this.checkedListBox.SelectedIndexChanged += new System.EventHandler(this.CheckedListBox_SelectedIndexChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(230, 450);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(142, 30);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Next\r\n";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.Button1_Click);
            // 
            // labelPlayer
            // 
            this.labelPlayer.AutoSize = true;
            this.labelPlayer.Font = new System.Drawing.Font("Snap ITC", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer.Location = new System.Drawing.Point(229, 9);
            this.labelPlayer.Name = "labelPlayer";
            this.labelPlayer.Size = new System.Drawing.Size(151, 37);
            this.labelPlayer.TabIndex = 3;
            this.labelPlayer.Text = "Player 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Snap ITC", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(170, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(308, 37);
            this.label3.TabIndex = 5;
            this.label3.Text = "Choose 3 pokemon";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelSkill2);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.labelSkill1);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.labelDefence);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.picture);
            this.panel1.Controls.Add(this.labelAttack);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.labelAttribute);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(299, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 334);
            this.panel1.TabIndex = 6;
            // 
            // labelSkill2
            // 
            this.labelSkill2.AutoSize = true;
            this.labelSkill2.Location = new System.Drawing.Point(197, 292);
            this.labelSkill2.Name = "labelSkill2";
            this.labelSkill2.Size = new System.Drawing.Size(30, 13);
            this.labelSkill2.TabIndex = 13;
            this.labelSkill2.Text = "skill2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(61, 292);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Skill 2";
            // 
            // labelSkill1
            // 
            this.labelSkill1.AutoSize = true;
            this.labelSkill1.Location = new System.Drawing.Point(197, 264);
            this.labelSkill1.Name = "labelSkill1";
            this.labelSkill1.Size = new System.Drawing.Size(30, 13);
            this.labelSkill1.TabIndex = 11;
            this.labelSkill1.Text = "skill1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(61, 264);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Skill 1";
            // 
            // labelDefence
            // 
            this.labelDefence.AutoSize = true;
            this.labelDefence.Location = new System.Drawing.Point(197, 237);
            this.labelDefence.Name = "labelDefence";
            this.labelDefence.Size = new System.Drawing.Size(46, 13);
            this.labelDefence.TabIndex = 9;
            this.labelDefence.Text = "defence";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(61, 237);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Defence";
            // 
            // picture
            // 
            this.picture.Location = new System.Drawing.Point(119, 42);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(80, 80);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture.TabIndex = 7;
            this.picture.TabStop = false;
            // 
            // labelAttack
            // 
            this.labelAttack.AutoSize = true;
            this.labelAttack.Location = new System.Drawing.Point(197, 211);
            this.labelAttack.Name = "labelAttack";
            this.labelAttack.Size = new System.Drawing.Size(37, 13);
            this.labelAttack.TabIndex = 6;
            this.labelAttack.Text = "attack";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(61, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Attack";
            // 
            // labelAttribute
            // 
            this.labelAttribute.AutoSize = true;
            this.labelAttribute.Location = new System.Drawing.Point(197, 183);
            this.labelAttribute.Name = "labelAttribute";
            this.labelAttribute.Size = new System.Drawing.Size(45, 13);
            this.labelAttribute.TabIndex = 4;
            this.labelAttribute.Text = "attribute";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(61, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Attribute";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(197, 156);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(33, 13);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // FormChoose
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(610, 486);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelPlayer);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.checkedListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormChoose";
            this.Text = "Choose pokemon";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormChoose_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelPlayer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Label labelAttack;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelAttribute;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSkill2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelSkill1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelDefence;
        private System.Windows.Forms.Label label13;
    }
}

