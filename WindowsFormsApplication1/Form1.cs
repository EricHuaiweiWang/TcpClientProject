using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Socket socketClient;
        CancellationTokenSource cts;
        //设置枚举类型，方便支持多种不同形式数据
        public enum MessageType
        {
            ASCII,
            UTF8,
            Hex,
            File,
            JSON
        }
        public Form1()
        {
            InitializeComponent();
        }

        private string CurrentTime
        {
            get { return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); }
        }

        private void AddLog(int index, string info)
        {
            if (!this.lst_Rcv.InvokeRequired)
            {
                ListViewItem lst = new ListViewItem(" " + CurrentTime, index);

                lst.SubItems.Add(info);

                lst_Rcv.Items.Insert(lst_Rcv.Items.Count, lst);
            }
            else
            {
                Invoke(new Action(() =>
                {
                    ListViewItem lst = new ListViewItem(" " + CurrentTime, index);

                    lst.SubItems.Add(info);

                    lst_Rcv.Items.Insert(lst_Rcv.Items.Count, lst);
                }));
            }

        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            AddLog(0, "与服务器连接中");
            //1、创建套接字
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //2、设置套接字地址结构，说明客户端与之通信的服务器的IP地址和端口号。
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(this.txt_IP.Text.Trim()), int.Parse(this.txt_Port.Text.Trim()));

            //3、调用connect()函数来建立与服务器的连接
            try
            {
                socketClient.Connect(ipe);
            }
            catch (Exception ex)
            {
                AddLog(1, "连接服务器失败：" + ex.Message);
                return;
            }

            //创建一个接收的线程
            cts = new CancellationTokenSource();
            Task.Run(new Action(() =>
            {
                CheckReceiveMsg();
            }), cts.Token);
            AddLog(0, "成功连接至服务器");
            this.btn_Connect.Enabled = false;
            this.btn_DisConn.Enabled = false;
        }

        private void btn_DisConn_Click(object sender, EventArgs e)
        {
            cts?.Cancel();
            socketClient?.Close();
            this.btn_Connect.Enabled = true;
            this.btn_DisConn.Enabled = true;
            AddLog(0, "与服务器连接断开");
        }

        //数据接收处理及解析
        private void CheckReceiveMsg()
        {
            while (!cts.IsCancellationRequested)
            {
                //创建一个缓冲区
                byte[] buffer = new byte[1024 * 1024 * 10];
                int length = -1;

                //第四步：调用读写函数发送或者接收数据
                try
                {
                    length = socketClient.Receive(buffer);
                }
                catch (Exception)
                {
                    break;
                }
                if (length > 0)
                {
                    string msg = string.Empty;
                    MessageType type = MessageType.ASCII;
                    try
                    {
                        type = (MessageType)buffer[0];
                    }
                    catch
                    {
                        AddLog(1, "服务器：接收数据类型不正确");
                    }
                    switch (type)
                    {
                        case MessageType.ASCII:
                            msg = Encoding.ASCII.GetString(buffer, 1, length - 1);
                            AddLog(0, "服务器" + msg);
                            break;
                        case MessageType.UTF8:
                            msg = Encoding.UTF8.GetString(buffer, 1, length - 1);
                            AddLog(0, "服务器" + msg);
                            break;
                        case MessageType.Hex:
                            msg = GetHexStringFromByteArray(buffer, 1, length - 1);
                            AddLog(0, "服务器" + msg);
                            break;
                        case MessageType.File:
                            Invoke(new Action(() =>
                            {
                                SaveFileDialog sfd = new SaveFileDialog();
                                sfd.Filter = @"txt files(*.txt)|*.txt|xls files(*.xls)|*.xls|xlsx files
                                (*.xlsx)|*.xlsx|All files(*.*)|*.*";
                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    string fileSavePath = sfd.FileName;
                                    using (FileStream fs = new FileStream(fileSavePath, FileMode.Create))
                                    {
                                        fs.Write(buffer, 1, length - 1);
                                    }
                                    AddLog(0, "文件成功保存至" + msg);
                                }
                            }));

                            break;
                        case MessageType.JSON:
                            Invoke(new Action(() =>
                            {
                                string res = Encoding.Default.GetString(buffer, 1, length);
                                List<Student> StuList = JsonHelper.FromJSON<List<Student>>(res);

                            }));
                            AddLog(0, "接收JSON数据" + msg);
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        private string GetHexStringFromByteArray(byte[] buffer, int v1, int v2)
        {
            return BitConverter.ToString(buffer).Replace("-", "").ToLower();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_IP.Text = "127.0.0.1";
            txt_Port.Text = "8001";
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btn_SendASCII_Click(object sender, EventArgs e)
        {
            AddLog(0,"发送内容："+this.txt_Send.Text.Trim());
            byte[] send = Encoding.ASCII.GetBytes(this.txt_Send.Text.Trim());
            //创建最终发送的数组
            byte[] sendMsg = new byte[send.Length+1];

            //整体拷贝数组
            Array.Copy(send,0,sendMsg,1,send.Length);

            //给首字节赋值
            sendMsg[0] = (byte)MessageType.ASCII;
            socketClient?.Send(sendMsg);
        }

        private void btn_SendFile_Click(object sender, EventArgs e)
        {
            if (this.txt_File.Text.Length == 0)
            {
                AddLog(1,"请先选择你要发送的文件路径");
                return;
            }
            else
            {
                //发送两次
                using (FileStream fs=new FileStream(this.txt_File.Text,FileMode.Open))
                {
                    //第一次发送文件名称

                    //获取文件名称
                    string filename = Path.GetFileName(this.txt_File.Text);
                    //获取后缀名
                    string fileExtension = Path.GetExtension(this.txt_File.Text);

                    string strMsg = "发送文件："+filename+"."+ fileExtension;
                    byte[] send1 = Encoding.UTF8.GetBytes(strMsg);
                    byte[] send1Msg = new byte[send1.Length + 1];
                    Array.Copy(send1,0,send1Msg,1,send1.Length);
                    send1Msg[0] = (byte)MessageType.UTF8;
                    socketClient?.Send(send1Msg);

                    //第二次发送文件内容

                    byte[] send2 = new byte[1024 * 1024 * 10];

                    //有效长度
                    int length = fs.Read(send2,0,send2.Length);

                    byte[] send2Msg = new byte[length + 1];

                    Array.Copy(send2,0,send2Msg,1,length);
                    send2Msg[0] = (byte)MessageType.File;
                    socketClient?.Send(send2Msg);
                    AddLog(0, strMsg);
                }
            }
        }

        private void btn_SelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            //设置默认的路径
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.txt_File.Text = ofd.FileName;
                AddLog(0, "选择文件：" + this.txt_File.Text);
            }
        }

        private void btn_SendJSON_Click(object sender, EventArgs e)
        {
            //创建集合
            List<Student> stuList = new List<Student>()
            {
                new Student() { StudentID=10001,StudentName="小明",ClassName="软件一班"},
                new Student() { StudentID=10002,StudentName="小红",ClassName="软件二班"},
                new Student() { StudentID=10003,StudentName="小花",ClassName="软件三班"}
            };

            string str = JsonHelper.ToJSON(stuList);
            byte[] send = Encoding.Default.GetBytes(str);
            byte[] sendMsg = new byte[send.Length + 1];
            Array.Copy(send,0,sendMsg,1,send.Length);
            sendMsg[0] = (byte)MessageType.JSON;
            socketClient?.Send(sendMsg);
        }

        private void btn_SendUTF8_Click(object sender, EventArgs e)
        {

        }

        private void btn_SendHex_Click(object sender, EventArgs e)
        {

        }
    }
}
