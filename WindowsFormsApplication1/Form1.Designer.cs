namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lst_Rcv = new System.Windows.Forms.ListView();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.btn_DisConn = new System.Windows.Forms.Button();
            this.btn_SendASCII = new System.Windows.Forms.Button();
            this.btn_SendUTF8 = new System.Windows.Forms.Button();
            this.btn_SendHex = new System.Windows.Forms.Button();
            this.btn_SendFile = new System.Windows.Forms.Button();
            this.btn_SendJSON = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_SelectFile = new System.Windows.Forms.Button();
            this.txt_File = new System.Windows.Forms.TextBox();
            this.txt_Send = new System.Windows.Forms.TextBox();
            this.ch1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lst_Rcv
            // 
            this.lst_Rcv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch1,
            this.ch2});
            this.lst_Rcv.FullRowSelect = true;
            this.lst_Rcv.GridLines = true;
            this.lst_Rcv.LabelEdit = true;
            this.lst_Rcv.Location = new System.Drawing.Point(12, 56);
            this.lst_Rcv.Name = "lst_Rcv";
            this.lst_Rcv.Size = new System.Drawing.Size(495, 290);
            this.lst_Rcv.TabIndex = 0;
            this.lst_Rcv.UseCompatibleStateImageBehavior = false;
            this.lst_Rcv.View = System.Windows.Forms.View.Details;
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(634, 62);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(141, 25);
            this.txt_IP.TabIndex = 1;
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(634, 113);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(141, 25);
            this.txt_Port.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(634, 167);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(141, 25);
            this.textBox3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(529, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "服务器IP：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(529, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "服务器端口：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(529, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "用户名称：";
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(532, 240);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(107, 40);
            this.btn_Connect.TabIndex = 7;
            this.btn_Connect.Text = "连接服务器";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_DisConn
            // 
            this.btn_DisConn.Location = new System.Drawing.Point(677, 240);
            this.btn_DisConn.Name = "btn_DisConn";
            this.btn_DisConn.Size = new System.Drawing.Size(107, 40);
            this.btn_DisConn.TabIndex = 8;
            this.btn_DisConn.Text = "断开服务器";
            this.btn_DisConn.UseVisualStyleBackColor = true;
            this.btn_DisConn.Click += new System.EventHandler(this.btn_DisConn_Click);
            // 
            // btn_SendASCII
            // 
            this.btn_SendASCII.Location = new System.Drawing.Point(532, 306);
            this.btn_SendASCII.Name = "btn_SendASCII";
            this.btn_SendASCII.Size = new System.Drawing.Size(107, 40);
            this.btn_SendASCII.TabIndex = 9;
            this.btn_SendASCII.Text = "发送ASCII";
            this.btn_SendASCII.UseVisualStyleBackColor = true;
            this.btn_SendASCII.Click += new System.EventHandler(this.btn_SendASCII_Click);
            // 
            // btn_SendUTF8
            // 
            this.btn_SendUTF8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_SendUTF8.Enabled = false;
            this.btn_SendUTF8.Location = new System.Drawing.Point(677, 306);
            this.btn_SendUTF8.Name = "btn_SendUTF8";
            this.btn_SendUTF8.Size = new System.Drawing.Size(107, 40);
            this.btn_SendUTF8.TabIndex = 10;
            this.btn_SendUTF8.Text = "发送UTF8";
            this.btn_SendUTF8.UseVisualStyleBackColor = false;
            this.btn_SendUTF8.Click += new System.EventHandler(this.btn_SendUTF8_Click);
            // 
            // btn_SendHex
            // 
            this.btn_SendHex.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_SendHex.Enabled = false;
            this.btn_SendHex.Location = new System.Drawing.Point(532, 383);
            this.btn_SendHex.Name = "btn_SendHex";
            this.btn_SendHex.Size = new System.Drawing.Size(107, 40);
            this.btn_SendHex.TabIndex = 11;
            this.btn_SendHex.Text = "发送Hex";
            this.btn_SendHex.UseVisualStyleBackColor = false;
            this.btn_SendHex.Click += new System.EventHandler(this.btn_SendHex_Click);
            // 
            // btn_SendFile
            // 
            this.btn_SendFile.Location = new System.Drawing.Point(677, 383);
            this.btn_SendFile.Name = "btn_SendFile";
            this.btn_SendFile.Size = new System.Drawing.Size(107, 40);
            this.btn_SendFile.TabIndex = 12;
            this.btn_SendFile.Text = "发送文件";
            this.btn_SendFile.UseVisualStyleBackColor = true;
            this.btn_SendFile.Click += new System.EventHandler(this.btn_SendFile_Click);
            // 
            // btn_SendJSON
            // 
            this.btn_SendJSON.Location = new System.Drawing.Point(532, 458);
            this.btn_SendJSON.Name = "btn_SendJSON";
            this.btn_SendJSON.Size = new System.Drawing.Size(107, 40);
            this.btn_SendJSON.TabIndex = 13;
            this.btn_SendJSON.Text = "发送JSON";
            this.btn_SendJSON.UseVisualStyleBackColor = true;
            this.btn_SendJSON.Click += new System.EventHandler(this.btn_SendJSON_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_SelectFile
            // 
            this.btn_SelectFile.Location = new System.Drawing.Point(400, 530);
            this.btn_SelectFile.Name = "btn_SelectFile";
            this.btn_SelectFile.Size = new System.Drawing.Size(107, 40);
            this.btn_SelectFile.TabIndex = 15;
            this.btn_SelectFile.Text = "选择文件";
            this.btn_SelectFile.UseVisualStyleBackColor = true;
            this.btn_SelectFile.Click += new System.EventHandler(this.btn_SelectFile_Click);
            // 
            // txt_File
            // 
            this.txt_File.Location = new System.Drawing.Point(12, 540);
            this.txt_File.Name = "txt_File";
            this.txt_File.Size = new System.Drawing.Size(381, 25);
            this.txt_File.TabIndex = 16;
            // 
            // txt_Send
            // 
            this.txt_Send.Location = new System.Drawing.Point(13, 368);
            this.txt_Send.Multiline = true;
            this.txt_Send.Name = "txt_Send";
            this.txt_Send.Size = new System.Drawing.Size(494, 130);
            this.txt_Send.TabIndex = 17;
            // 
            // ch1
            // 
            this.ch1.Text = "时间";
            this.ch1.Width = 220;
            // 
            // ch2
            // 
            this.ch2.Text = "内容";
            this.ch2.Width = 270;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 622);
            this.Controls.Add(this.txt_Send);
            this.Controls.Add(this.txt_File);
            this.Controls.Add(this.btn_SelectFile);
            this.Controls.Add(this.btn_SendJSON);
            this.Controls.Add(this.btn_SendFile);
            this.Controls.Add(this.btn_SendHex);
            this.Controls.Add(this.btn_SendUTF8);
            this.Controls.Add(this.btn_SendASCII);
            this.Controls.Add(this.btn_DisConn);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.txt_IP);
            this.Controls.Add(this.lst_Rcv);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lst_Rcv;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button btn_DisConn;
        private System.Windows.Forms.Button btn_SendASCII;
        private System.Windows.Forms.Button btn_SendUTF8;
        private System.Windows.Forms.Button btn_SendHex;
        private System.Windows.Forms.Button btn_SendFile;
        private System.Windows.Forms.Button btn_SendJSON;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_SelectFile;
        private System.Windows.Forms.TextBox txt_File;
        private System.Windows.Forms.TextBox txt_Send;
        private System.Windows.Forms.ColumnHeader ch1;
        private System.Windows.Forms.ColumnHeader ch2;
    }
}

