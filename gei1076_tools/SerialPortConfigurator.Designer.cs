namespace gei1076_tools
{
    partial class SerialPortConfigurator
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblState = new System.Windows.Forms.Label();
            this.lblEtat = new System.Windows.Forms.Label();
            this.chkSerialPortSync = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSerialPortList = new System.Windows.Forms.ComboBox();
            this.btnSerialPortClose = new System.Windows.Forms.Button();
            this.btnSerialPortOpen = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSerialPortSpeed = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblState
            // 
            this.lblState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblState.AutoSize = true;
            this.lblState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblState.Location = new System.Drawing.Point(373, 60);
            this.lblState.MinimumSize = new System.Drawing.Size(30, 2);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(30, 15);
            this.lblState.TabIndex = 15;
            // 
            // lblEtat
            // 
            this.lblEtat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEtat.AutoSize = true;
            this.lblEtat.Location = new System.Drawing.Point(327, 60);
            this.lblEtat.Name = "lblEtat";
            this.lblEtat.Size = new System.Drawing.Size(32, 13);
            this.lblEtat.TabIndex = 14;
            this.lblEtat.Text = "État :";
            // 
            // chkSerialPortSync
            // 
            this.chkSerialPortSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSerialPortSync.AutoSize = true;
            this.chkSerialPortSync.Checked = true;
            this.chkSerialPortSync.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSerialPortSync.Location = new System.Drawing.Point(316, 84);
            this.chkSerialPortSync.Name = "chkSerialPortSync";
            this.chkSerialPortSync.Size = new System.Drawing.Size(87, 17);
            this.chkSerialPortSync.TabIndex = 13;
            this.chkSerialPortSync.Text = "Synchroniser";
            this.chkSerialPortSync.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ports reconnus";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Configuration du port série";
            // 
            // cboSerialPortList
            // 
            this.cboSerialPortList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSerialPortList.FormattingEnabled = true;
            this.cboSerialPortList.Location = new System.Drawing.Point(114, 32);
            this.cboSerialPortList.Name = "cboSerialPortList";
            this.cboSerialPortList.Size = new System.Drawing.Size(121, 21);
            this.cboSerialPortList.TabIndex = 10;
            this.cboSerialPortList.SelectedIndexChanged += new System.EventHandler(this.cboSerialPortList_SelectedIndexChanged);
            // 
            // btnSerialPortClose
            // 
            this.btnSerialPortClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialPortClose.Location = new System.Drawing.Point(328, 31);
            this.btnSerialPortClose.Name = "btnSerialPortClose";
            this.btnSerialPortClose.Size = new System.Drawing.Size(75, 23);
            this.btnSerialPortClose.TabIndex = 9;
            this.btnSerialPortClose.Text = "Fermer";
            this.btnSerialPortClose.UseVisualStyleBackColor = true;
            this.btnSerialPortClose.Click += new System.EventHandler(this.btnSerialPortClose_Click);
            // 
            // btnSerialPortOpen
            // 
            this.btnSerialPortOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialPortOpen.Location = new System.Drawing.Point(247, 31);
            this.btnSerialPortOpen.Name = "btnSerialPortOpen";
            this.btnSerialPortOpen.Size = new System.Drawing.Size(75, 23);
            this.btnSerialPortOpen.TabIndex = 8;
            this.btnSerialPortOpen.Text = "Ouvrir";
            this.btnSerialPortOpen.UseVisualStyleBackColor = true;
            this.btnSerialPortOpen.Click += new System.EventHandler(this.btnSerialPortOpen_Click);
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.Location = new System.Drawing.Point(247, 55);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 8;
            this.btnTest.Text = "Tester";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Vitesse";
            // 
            // cboSerialPortSpeed
            // 
            this.cboSerialPortSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSerialPortSpeed.FormattingEnabled = true;
            this.cboSerialPortSpeed.Items.AddRange(new object[] {
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "56000",
            "57600",
            "115200"});
            this.cboSerialPortSpeed.Location = new System.Drawing.Point(114, 57);
            this.cboSerialPortSpeed.Name = "cboSerialPortSpeed";
            this.cboSerialPortSpeed.Size = new System.Drawing.Size(121, 21);
            this.cboSerialPortSpeed.TabIndex = 16;
            this.cboSerialPortSpeed.Text = "9600";
            // 
            // SerialPortConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboSerialPortSpeed);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblEtat);
            this.Controls.Add(this.chkSerialPortSync);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSerialPortList);
            this.Controls.Add(this.btnSerialPortClose);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnSerialPortOpen);
            this.Name = "SerialPortConfigurator";
            this.Size = new System.Drawing.Size(422, 114);
            this.Load += new System.EventHandler(this.SerialPortConfigurator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblEtat;
        private System.Windows.Forms.CheckBox chkSerialPortSync;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSerialPortList;
        private System.Windows.Forms.Button btnSerialPortClose;
        private System.Windows.Forms.Button btnSerialPortOpen;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboSerialPortSpeed;
    }
}
