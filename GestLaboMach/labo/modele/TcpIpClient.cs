<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Net.Sockets;
using System.Net;
using System.Threading;

using System.Xml;
using System.IO;

namespace GestLaboMach.labo.modele
{

    public struct Issue
    {
        public string symbol;
        public string bid;
        public string offer;
        public string volume;
    }

    class TcpIpClient
    {
        
        private Encoding ASCII = Encoding.ASCII;
        private Thread t;
        private Socket s;

        private Hashtable socketHolder = new Hashtable();
        private Hashtable threadHolder = new Hashtable();

       
        static AutoResetEvent JobDone = new AutoResetEvent(false);
        MethodInvoker miv;

        public forms.ResultatForm rslform;     
        private labo.modele.Machine mach;

        public long connectId = 1;

        private string msg_recu="";

        //		Char endOfMsg = '\n';// 13 is return

        public void seConecter(int _id_machine)
        {
            this.mach = new labo.modele.Machine(_id_machine);

            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                    ProtocolType.Tcp);
            connectId = connectId + 1;
            socketHolder.Add(connectId, s);

            IPAddress hostadd = IPAddress.Parse(this.mach.ipAdresse);
                int port = this.mach.portNumber;
                IPEndPoint EPhost = new IPEndPoint(hostadd, port);

                try
                {
                    s.Connect(EPhost);

                    if (s.Connected)
                    {
                        Byte[] bBuf;
                        string buf;
                        buf = String.Format("{0}:{1}", this.mach.userName, this.mach.passWord);
                        bBuf = ASCII.GetBytes(buf);
                        s.Send(bBuf, 0, bBuf.Length, 0);
                        t = new Thread(new ThreadStart(StartRecieve));
                    
                    connectId = connectId + 1;
                    threadHolder.Add(connectId, t);
                    t.Start();
                      this.rslform.txt_infos.Text = "Ready to recieve data";
                      this.rslform.btn_Seconnecter.Enabled = false;
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.ToString());
                }
            
        }
        private void StartRecieve()
        {
            miv = new MethodInvoker(this.UpdateListView);
            int cnt = 0;
            string tmp = "";
            Byte[] firstb = new Byte[1];
            while (true)
            {
                try
                {
                    Byte[] receive = new Byte[100000];
                    int ret = s.Receive(receive, receive.Length, 0);
                    if (ret > 0)
                    {

                        /*
                        switch (receive[0])
                        {
                            case 11: //check start message
                                cnt = 0;
                                break;
                            case 10: // check end message
                                cnt = 0;                               
                                HandleText(tmp);
                                tmp = null;
                                break;
                            default:
                                if (cnt == 0)
                                    firstb[0] = receive[0];
                                tmp += System.Text.Encoding.ASCII.GetString(receive);
                                cnt++;
                                break;
                        }
                        */

                        tmp = System.Text.Encoding.ASCII.GetString(receive);

                    }
                    else
                    {       

                        // tmp = "";
                        // HandleText(tmp);
                        //MessageBox.Show(tmp);
                    }

                    HandleText(tmp);

                }
                catch (Exception e)
                {
                    if (!s.Connected)
                    {
                        try
                        {
                            this.rslform.btn_Seconnecter.Enabled = true;
                        }
                        catch (Exception exx)
                        {
                        }
                            break;
                    }
                }
            }
            t.Abort();
        }
                   
      
        private void UpdateListView()
        {
            /*
            int ind = -1;
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                if (this.listView1.Items[i].Text == isu.symbol.ToString())
                    ind = i;
                if (ind > -1)
                {
                    break;
                }
            }
            if (ind == -1)
            {
                ListViewItem newItem = new ListViewItem(isu.symbol.ToString());
                newItem.SubItems.Add(isu.bid);
                newItem.SubItems.Add(isu.offer);
                newItem.SubItems.Add(isu.volume);

                this.listView1.Items.Add(newItem);
                int i = this.listView1.Items.IndexOf(newItem);
                setRowColor(i, System.Drawing.Color.FromArgb(255, 255, 175));
                setColColorHL(i, 0, System.Drawing.Color.FromArgb(128, 0, 0));
                setColColorHL(i, 1, System.Drawing.Color.FromArgb(128, 0, 0));
                this.listView1.Update();
                Thread.Sleep(300);
                setColColor(i, 0, System.Drawing.Color.FromArgb(255, 255, 175));
                setColColor(i, 1, System.Drawing.Color.FromArgb(255, 255, 175));
            }
            else
            {
                this.listView1.Items[ind].Text = isu.symbol.ToString();
                this.listView1.Items[ind].SubItems[1].Text = (isu.bid);
                this.listView1.Items[ind].SubItems[2].Text = (isu.offer);
                this.listView1.Items[ind].SubItems[3].Text = (isu.volume);
                setColColorHL(ind, 0, System.Drawing.Color.FromArgb(128, 0, 0));
                setColColorHL(ind, 1, System.Drawing.Color.FromArgb(128, 0, 0));
                this.listView1.Update();
                Thread.Sleep(300);
                setColColor(ind, 0, System.Drawing.Color.FromArgb(255, 255, 175));
                setColColor(ind, 1, System.Drawing.Color.FromArgb(255, 255, 175));
            }
            */

            this.rslform.init_dataGridViewListDossiers();
            this.rslform.txt_infos.Text = this.msg_recu ;
            Thread.Sleep(100);
            JobDone.Set();
        }


        // methode à executer suite à reception messsage##########################################
        void HandleText(string str)
        {
            /*
            isu.symbol = Mid(str, 0, 4).TrimEnd(' ');
            isu.bid = Mid(str, 4, 5).TrimEnd(' ');
            isu.offer = Mid(str, 9, 5).TrimEnd(' ');
            isu.volume = Mid(str, 16, str.Length - 16).TrimEnd(' ');
            */

            this.msg_recu = str;

            this.rslform.BeginInvoke(miv);
            Thread.Sleep(300);
            JobDone.WaitOne();
        }

        public void envoyerMsgAuServeur(string str)
        {


            try
            {
                Byte[] bBuf;
                string buf;
                buf = String.Format("{0}", str);
                bBuf = ASCII.GetBytes(buf);
                s.Send(bBuf, 0, bBuf.Length, 0);

                MessageBox.Show("Message envoyé au serveur  : " + str + "" );
            }
            catch (Exception xxx)
            {
                MessageBox.Show(xxx.Message);
            }
            /*
            if (s!=null && s.Connected)
            {
                
            } */
        }

        public void seDeconnecter()
        {
           
            try
            {
                foreach (Socket s in socketHolder.Values)
                {
                    if (s.Connected)
                    {
                        s.Close();

                    }
                }

            }
            catch (Exception)
            {

            }

            try
            {
                foreach (Thread t in threadHolder.Values)
                {
                    if (t.IsAlive)
                    {
                        t.Abort();
                    }
                }

            }
            catch (Exception)
            {

            }
            
        }


    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Net.Sockets;
using System.Net;
using System.Threading;

using System.Xml;
using System.IO;

namespace GestLaboMach.labo.modele
{

    public struct Issue
    {
        public string symbol;
        public string bid;
        public string offer;
        public string volume;
    }

    class TcpIpClient
    {
        
        private Encoding ASCII = Encoding.ASCII;
        private Thread t;
        private Socket s;
        Issue isu = new Issue();
        static AutoResetEvent JobDone = new AutoResetEvent(false);
        MethodInvoker miv;

        public forms.ResultatForm rslform;     
        private labo.modele.Machine mach;

        private string msg_recu="";

        //		Char endOfMsg = '\n';// 13 is return

        public void seConecter(int _id_machine)
        {
            this.mach = new labo.modele.Machine(_id_machine);

            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                    ProtocolType.Tcp);

                IPAddress hostadd = IPAddress.Parse(this.mach.ipAdresse);
                int port = this.mach.portNumber;
                IPEndPoint EPhost = new IPEndPoint(hostadd, port);

                try
                {
                    s.Connect(EPhost);

                    if (s.Connected)
                    {
                        Byte[] bBuf;
                        string buf;
                        buf = String.Format("{0}:{1}", this.mach.userName, this.mach.passWord);
                        bBuf = ASCII.GetBytes(buf);
                        s.Send(bBuf, 0, bBuf.Length, 0);
                        t = new Thread(new ThreadStart(StartRecieve));
                        t.Start();
                      this.rslform.txt_infos.Text = "Ready to recieve data";
                      this.rslform.btn_Seconnecter.Enabled = false;
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.ToString());
                }
            
        }
        private void StartRecieve()
        {
            miv = new MethodInvoker(this.UpdateListView);
            int cnt = 0;
            string tmp = null;
            Byte[] firstb = new Byte[1];
            while (true)
            {
                try
                {
                    Byte[] receive = new Byte[1];
                    int ret = s.Receive(receive, 1, 0);
                    if (ret > 0)
                    {
                        switch (receive[0])
                        {
                            case 11: //check start message
                                cnt = 0;
                                break;
                            case 10: // check end message
                                cnt = 0;                               
                                HandleText(tmp);
                                tmp = null;
                                break;
                            default:
                                if (cnt == 0)
                                    firstb[0] = receive[0];
                                tmp += System.Text.Encoding.ASCII.GetString(receive);
                                cnt++;
                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    if (!s.Connected)
                    {
                      this.rslform.btn_Seconnecter.Enabled = true;
                        break;
                    }
                }
            }
            t.Abort();
        }
                   
      
        private void UpdateListView()
        {

            /*
            int ind = -1;
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                if (this.listView1.Items[i].Text == isu.symbol.ToString())
                    ind = i;
                if (ind > -1)
                {
                    break;
                }
            }
            if (ind == -1)
            {
                ListViewItem newItem = new ListViewItem(isu.symbol.ToString());
                newItem.SubItems.Add(isu.bid);
                newItem.SubItems.Add(isu.offer);
                newItem.SubItems.Add(isu.volume);

                this.listView1.Items.Add(newItem);
                int i = this.listView1.Items.IndexOf(newItem);
                setRowColor(i, System.Drawing.Color.FromArgb(255, 255, 175));
                setColColorHL(i, 0, System.Drawing.Color.FromArgb(128, 0, 0));
                setColColorHL(i, 1, System.Drawing.Color.FromArgb(128, 0, 0));
                this.listView1.Update();
                Thread.Sleep(300);
                setColColor(i, 0, System.Drawing.Color.FromArgb(255, 255, 175));
                setColColor(i, 1, System.Drawing.Color.FromArgb(255, 255, 175));
            }
            else
            {
                this.listView1.Items[ind].Text = isu.symbol.ToString();
                this.listView1.Items[ind].SubItems[1].Text = (isu.bid);
                this.listView1.Items[ind].SubItems[2].Text = (isu.offer);
                this.listView1.Items[ind].SubItems[3].Text = (isu.volume);
                setColColorHL(ind, 0, System.Drawing.Color.FromArgb(128, 0, 0));
                setColColorHL(ind, 1, System.Drawing.Color.FromArgb(128, 0, 0));
                this.listView1.Update();
                Thread.Sleep(300);
                setColColor(ind, 0, System.Drawing.Color.FromArgb(255, 255, 175));
                setColColor(ind, 1, System.Drawing.Color.FromArgb(255, 255, 175));
            }
            */

            this.rslform.init_dataGridViewListDossiers();
            this.rslform.txt_infos.Text = "Ready to recieve data .... " 
                + " |||| " + this.msg_recu ;
            Thread.Sleep(100);

            JobDone.Set();
        }


        // methode à executer suite à reception messsage##########################################
        void HandleText(string str)
        {
            /*
            isu.symbol = Mid(str, 0, 4).TrimEnd(' ');
            isu.bid = Mid(str, 4, 5).TrimEnd(' ');
            isu.offer = Mid(str, 9, 5).TrimEnd(' ');
            isu.volume = Mid(str, 16, str.Length - 16).TrimEnd(' ');
            */

            this.msg_recu = str;

            this.rslform.BeginInvoke(miv);
            Thread.Sleep(300);
            JobDone.WaitOne();
        }


    }
}
>>>>>>> cc2682dbd3ef8945a5b90c1c69165e9682417efb
