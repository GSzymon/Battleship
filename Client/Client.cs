using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerData;

namespace Client
{
    
    public partial class Client : Form
    {
        private volatile int amountShips = 5;
        private char who;
        private bool myTurn=false;
        public ArrayList fields = new ArrayList();
        public ArrayList labels = new ArrayList();
        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Point location1 = new Point(40, 90);
            Point location2 = new Point(375, 90);
            InitializeBoard(location1, 'A');
            InitializeBoard(location2, 'B');
            ConnectBtn.Click+=new EventHandler(ConnectBtn_Click);
            SendBtn.Click+=new EventHandler(SendBtn_Click);
        }


        public void InitializeBoard(Point location1, char id1)
        {
            
            Point loc1 = location1;
            
            Size size = new Size(30, 30);

            loc1.Y -= 31;
            for (int i = 1; i < 10; i++)
            {
                Label labell = new Label();
                labell.AutoSize = false;
                labell.TextAlign = ContentAlignment.MiddleCenter;
                labell.Location = loc1;
                labell.Size = size;
                labell.MaximumSize = size;
                labell.Margin.All.Equals(1);
                labell.Text = i.ToString();
                this.Controls.Add(labell);
                loc1.X += 31;
            }

            loc1.X = location1.X - 31;
            loc1.Y = location1.Y;


            for (int i = 1; i < 10; i++)
            {
                Label labell = new Label();
                labell.AutoSize = false;
                labell.TextAlign = ContentAlignment.MiddleCenter;
                labell.Location = loc1;
                labell.Size = size;
                labell.MaximumSize = size;
                labell.Margin.All.Equals(1);
                labell.Text = toLetter(i).ToString();
                this.Controls.Add(labell);
                loc1.Y += 31;
            }

            loc1.X = location1.X;
            loc1.Y = location1.Y;

            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    Label label = new Label();
                    label.AutoSize = false;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Text = id1.ToString() + "_" + j.ToString() + toLetter(i);
                    label.BackColor = Color.MediumPurple;
                    label.ForeColor = Color.MediumPurple;
                    label.Font = new Font("Arial", 1, FontStyle.Regular);
                    label.Margin.All.Equals(1);
                    label.MaximumSize = size;
                    label.Size = size;
                    label.Location = loc1;
                    //label.Click += new EventHandler(label_Click);
                    //fields.Add(new Field(label.Text));
                    labels.Add(label);
                    this.Controls.Add(label);
                    loc1.X += 31;
                }
                loc1.Y += 31;
                loc1.X = location1.X;
            }
        }
        public char toLetter(int x)
        {
            if (x==0) return '?';
            if (x == 1) return 'a';
            if (x == 2) return 'b';
            if (x == 3) return 'c';
            if (x == 4) return 'd';
            if (x == 5) return 'e';
            if (x == 6) return 'f';
            if (x == 7) return 'g';
            if (x == 8) return 'h';
            if (x == 9) return 'i';
            else return '?';
        }

        public void label_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label.BackColor != Color.DarkGreen)
            {
                if (amountShips > 0)
                {
                    label.BackColor = Color.DarkGreen;
                    amountShips--;
                    if (amountShips == 0)
                    {
                        btnRdy.Enabled = true;
                        btnRdy.Visible = true;
                    }
                }
                else
                {
                    foreach (Label labell in labels)
                    {
                        if (who == labell.Text[0])
                        {
                            labell.Click -= new EventHandler(label_Click);
                        }
                    }
                }
            }
        }

        public void label_Click2(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label.BackColor == Color.MediumPurple && myTurn==true)
            {
                /*foreach (Label labell in labels)
                {
                    if (who != labell.Text[0])
                    {
                        labell.Click -= new EventHandler(label_Click2);
                    }
                }*/
                myTurn = false;
                Packet p = new Packet(PacketType.Battleship_shot, ID, who);
                p.data.Add(label.Text);
                SendToServer(p);
            }
        }

        private void MsgBoard_TextChanged(object sender, EventArgs e)
        {
            MsgBoard.SelectionStart = MsgBoard.Text.Length;
            MsgBoard.ScrollToCaret();
        }

        private void btnRdy_Click(object sender, EventArgs e)
        {
            btnRdy.Enabled = false;
            btnRdy.Visible = false;
            labelRdy.Text = "Czekaj...";
            Packet p = new Packet(PacketType.Battleship_set, ID, who);
            foreach (Label label in labels)
            {
                if (label.BackColor == Color.DarkGreen)
                {
                    p.data.Add(label.Text);
                }
                if (label.Text[0] != who)
                {
                    label.Click += new EventHandler(label_Click2);
                }
            }
            SendToServer(p);
        }
    }
}
