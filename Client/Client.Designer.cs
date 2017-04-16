namespace Client
{
    partial class Client
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
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.serverIP = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.TextBox();
            this.MsgBoard = new System.Windows.Forms.TextBox();
            this.Msg = new System.Windows.Forms.TextBox();
            this.SendBtn = new System.Windows.Forms.Button();
            this.labelWho = new System.Windows.Forms.Label();
            this.labelRdy = new System.Windows.Forms.Label();
            this.btnRdy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(145, 35);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectBtn.TabIndex = 0;
            this.ConnectBtn.Text = "Połącz";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            // 
            // serverIP
            // 
            this.serverIP.BackColor = System.Drawing.SystemColors.Info;
            this.serverIP.Location = new System.Drawing.Point(12, 38);
            this.serverIP.Name = "serverIP";
            this.serverIP.Size = new System.Drawing.Size(127, 20);
            this.serverIP.TabIndex = 1;
            this.serverIP.Text = "192.168.1.102";
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.SystemColors.Info;
            this.Login.Location = new System.Drawing.Point(12, 12);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(127, 20);
            this.Login.TabIndex = 2;
            this.Login.Text = "MyID";
            // 
            // MsgBoard
            // 
            this.MsgBoard.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.MsgBoard.Location = new System.Drawing.Point(12, 400);
            this.MsgBoard.Multiline = true;
            this.MsgBoard.Name = "MsgBoard";
            this.MsgBoard.ReadOnly = true;
            this.MsgBoard.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MsgBoard.Size = new System.Drawing.Size(641, 73);
            this.MsgBoard.TabIndex = 5;
            this.MsgBoard.WordWrap = false;
            this.MsgBoard.TextChanged += new System.EventHandler(this.MsgBoard_TextChanged);
            // 
            // Msg
            // 
            this.Msg.BackColor = System.Drawing.SystemColors.Info;
            this.Msg.Location = new System.Drawing.Point(12, 480);
            this.Msg.Name = "Msg";
            this.Msg.Size = new System.Drawing.Size(559, 20);
            this.Msg.TabIndex = 6;
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(577, 479);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(75, 23);
            this.SendBtn.TabIndex = 7;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            // 
            // labelWho
            // 
            this.labelWho.AutoSize = true;
            this.labelWho.Location = new System.Drawing.Point(145, 15);
            this.labelWho.MaximumSize = new System.Drawing.Size(200, 0);
            this.labelWho.Name = "labelWho";
            this.labelWho.Size = new System.Drawing.Size(0, 13);
            this.labelWho.TabIndex = 11;
            // 
            // labelRdy
            // 
            this.labelRdy.AutoSize = true;
            this.labelRdy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelRdy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelRdy.Location = new System.Drawing.Point(295, 12);
            this.labelRdy.Name = "labelRdy";
            this.labelRdy.Size = new System.Drawing.Size(177, 24);
            this.labelRdy.TabIndex = 12;
            this.labelRdy.Text = "Ustaw swoje statki";
            this.labelRdy.Visible = false;
            // 
            // btnRdy
            // 
            this.btnRdy.Enabled = false;
            this.btnRdy.Location = new System.Drawing.Point(496, 13);
            this.btnRdy.Name = "btnRdy";
            this.btnRdy.Size = new System.Drawing.Size(75, 23);
            this.btnRdy.TabIndex = 13;
            this.btnRdy.Text = "Gotowe";
            this.btnRdy.UseVisualStyleBackColor = true;
            this.btnRdy.Visible = false;
            this.btnRdy.Click += new System.EventHandler(this.btnRdy_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(666, 512);
            this.Controls.Add(this.btnRdy);
            this.Controls.Add(this.labelRdy);
            this.Controls.Add(this.labelWho);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.Msg);
            this.Controls.Add(this.MsgBoard);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.serverIP);
            this.Controls.Add(this.ConnectBtn);
            this.Name = "Client";
            this.Text = "Battleship";
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.TextBox serverIP;
        private System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.TextBox MsgBoard;
        private System.Windows.Forms.TextBox Msg;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.Label labelWho;
        private System.Windows.Forms.Label labelRdy;
        private System.Windows.Forms.Button btnRdy;
    }
}

