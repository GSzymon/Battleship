using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using ServerData;

namespace Client
{

    public partial class Client
    {
        public static Socket socket;
        public static IPAddress ipAdress;
        public static string ID;
        public static string login;
        public static Thread thread;
        public static bool isConnected = false;

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Login.Text)) //login validation
            {
                AppendMsgBoard("Wrong ID \r\n");
            }
            else if (!IPAddress.TryParse(serverIP.Text, out ipAdress)) //ip validation
            {
                AppendMsgBoard("Wrong IP address\r\n");
            }
            else //connection to server
            {
                Login.ReadOnly = true;
                Login.Enabled = false;
                serverIP.ReadOnly = true;
                serverIP.Enabled = false;
                ConnectBtn.Visible = false;
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipEndPoint = new IPEndPoint(ipAdress, 4242);

                try
                {
                    socket.Connect(ipEndPoint);
                    login = Login.Text;

                    isConnected = true;
                    ConnectBtn.Enabled = false;
                    SendBtn.Enabled = true;

                    thread = new Thread(Data_IN);
                    thread.Start();
                }
                catch (SocketException ex)
                {
                    AppendMsgBoard("Error during connecting to server\r\n");
                }
            }
        }

        private void Data_IN()
        {
            byte[] buffer;
            int readBytes;
            AppendMsgBoard("Waiting for incomming data\r\n");
            while (true)
            {
                try
                {
                    buffer = new byte[socket.SendBufferSize];
                    readBytes = socket.Receive(buffer);
                    
                    if (readBytes > 0)
                    {
                        DataManager(new Packet(buffer));
                    }
                }
                catch (SocketException ex)
                {
                    AppendMsgBoard("Error during receiving data\r\n");
                }

            }
        }

        private void DataManager(Packet p)
        {
            switch (p.packetType)
            {
                case PacketType.Registration:
                    ID = p.data[0];
                    who = p.senderWho;
                    Packet packet = new Packet(PacketType.Chat, ID);
                    packet.data.Add(login);
                    packet.data.Add("Connected");
                    socket.Send(packet.ToBytes());
                    SetLabelVisibility();
                    break;


                case PacketType.Chat:
                case PacketType.CloseConnection:
                    if (p.data.Count == 2)
                    {
                        AppendMsgBoard(p.data[0] + ": " + p.data[1] + "\r\n");
                    }
                    else
                    {
                        foreach (string str in p.data)
                        {
                            AppendMsgBoard(str + "\r\n");
                        }
                    }
                    if (p.packetBool == true )
                    {
                        if (who == 'A')
                        {
                           myTurn = true;
                            SetLabelRdy("Twój ruch");
                        }
                        else if (who == 'B')
                        {
                            SetLabelRdy("Ruch przeciwnika");
                        }
                    }
                    break;
                case PacketType.Battleship_shot:
                    Shoot(p);
                    break;
                case PacketType.Game_over:
                    GameOver(p);
                    break;
            }
        }

        private void GameOver(Packet p)
        {
            myTurn = false;
            AppendMsgBoard(p.data[0]+"\r\n");
            SetLabelVisibility2();
        }

        private void SetLabelVisibility2()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(SetLabelVisibility2), new object[] { });
                return;
            }
            labelRdy.Visible = false;
        }
        private void Shoot(Packet p)
        {
            bool h = false;
            if (p.data.Count==2 && p.senderWho == who)  //trafia
            {
                myTurn = true;
            }
            else if (p.data.Count==2 && p.senderWho != who)  //trafia
            {
                myTurn = false;
            }
            else if (p.senderWho == who)                //nie trafia
            {
                myTurn = false;
            }
            else if (p.senderWho != who)                // nie trafia
            {
                myTurn = true;
            }
            foreach (Label label in labels)
            {
                if (label.Text == p.data[0])
                {
                    if (p.data.Count == 2)
                    {
                        label.BackColor = Color.Black;
                    }
                    else
                    {
                        label.BackColor = Color.White;
                    }
                }
            }
            try
            {
                AppendMsgBoard(p.data[1] + "\r\n");
            }
            catch (Exception e)
            {
                //
            }
            
            if (myTurn == true)
            {
                SetLabelRdy("Twój ruch");
            }
            else if (myTurn == false)
            {
                SetLabelRdy("Ruch przeciwnika");
            }
        }

        private void SetLabelRdy(string str)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(SetLabelRdy), new object[] { str });
                return;
            }
            else
            {
                labelRdy.Text = str;
            }
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {   
            string msg = Msg.Text;
            Msg.Text = string.Empty;

            Packet p = new Packet(PacketType.Chat, ID);
            p.data.Add(login);
            p.data.Add(msg);
            SendToServer(p);
        }

        private void SendToServer(Packet p)
        {
            try
            {
                socket.Send(p.ToBytes());
            }
            catch (Exception ex)
            {
                AppendMsgBoard("Couldn't send this msg\r\n");
                AppendMsgBoard(ex.ToString()+"\r\n");
                Msg.Text = "";
            }
        }

        private void AppendMsgBoard(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendMsgBoard), new object[] { value });
                return;
            }
            MsgBoard.Text += value;
        }

        private void SetLabelVisibility()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(SetLabelVisibility), new object[] { });
                return;
            }
            else
            {
                if (who == 'A')
                {
                    labelWho.Text = "Gracz A: " + login;
                    foreach (Label label in labels)
                    {
                        if (label.Text[0] == 'A')
                        {
                            label.Click += new EventHandler(label_Click);
                        }
                    }
                }
                else if (who == 'B')
                {
                    labelWho.Text = "Gracz B: " + login;
                    foreach (Label label in labels)
                    {
                        //AppendMsgBoard(label.Text[0].ToString());
                        if (label.Text[0] == 'B')
                        {
                            label.Click += new EventHandler(label_Click);
                        }
                    }
                }
                labelRdy.Visible = true;
                foreach (Label label in labels)
                {
                    if (label.Text[0] == who)
                    {
                        label.BackColor = Color.LawnGreen;
                    }
                }
            }
        }
    }
}