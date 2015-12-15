using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistributedSystem_EX02
{

    public partial class EntryForm : Form
    {
        private int index;
        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
            }
        }

        

        private List<EntryForm> entries;//保存其它入口
        private Dictionary<int,ProcMessage> requestList;//消息数组
        private List<int> replyList;//回复消息数组
        private int waitingCar;//当前等待入库的车数目
        
        private ParkingSpace slot;
        
        /// <summary>
        /// 构造函数,建立一个进程(出口或入口)
        /// </summary>
        /// <param name="id">进程id</param>
        /// <param name="t">0入口 1出口</param>
        public EntryForm(int id, int t, ParkingSpace p)
        {
            InitializeComponent();
            entries = new List<EntryForm>();
            index = id;
            label_id.Text ="入口 " + id.ToString();
            slot = p;
            requestList = new Dictionary<int, ProcMessage>();
            replyList = new List<int>();
            waitingCar = 0;
            timer1.Start();
        }
        /// <summary>
        /// 告知当前入口进程一个新加入的入口
        /// </summary>
        /// <param name="entry">入口</param>
        public void AddEntry(EntryForm entry)
        {
            entries.Add(entry);
        }

        private void ChangeState(string str)
        {
            label_state.Text = DateTime.Now.ToLongTimeString() + " " + str;
        }

        public void ChangeParkState(string str)
        {
            label_parkState.Text = str;
        }

        /// <summary>
        /// 当前入口获得进入临界区的许可
        /// </summary>
        private void DoEvent()
        {
            if (slot.CheckSlot()==true)
            {
                //有空位
                if (slot.CarIn()==false)
                {
                    ChangeState("出错!");
                }
                SendMsg(ProcMessage.msgRelease);
                ChangeState("成功入库");
                waitingCar--;
                if (waitingCar>0)
                {
                    SendMsg(ProcMessage.msgRequest);
                }
            }
            else
            {
                ChangeState("车辆等待中");
            }
        }

        public void ReceiveMsg(ProcMessage msg)
        {
            if (msg.src == 0)
            {
                //出口消息
                if (requestList.ContainsKey(index)==true)
                {
                    //当前出口有挂起的请求
                    DateTime tmp = requestList[index].time;
                    bool isFirst = true;
                    foreach(var m in requestList.Values)
                    {
                        if (m.time < tmp) isFirst = false;
                    }
                    if (isFirst == true)
                    {
                        DoEvent();
                    } 
                }
                return;
            }
            if (msg.type == ProcMessage.msgRequest)
            {
                //Request
                requestList.Add(msg.src, msg);
                if (requestList.Count == 1) SendMsg(ProcMessage.msgReply, msg.src);//如果当前请求是队列中唯一的请求，则回复reply
            }
            else if (msg.type == ProcMessage.msgReply)
            {
                //记录回复消息
                if (replyList.Contains(msg.src) == false) replyList.Add(msg.src);
                if (replyList.Count == entries.Count+1)
                {
                    DoEvent();//得到所有进程的回复消息，开始执行
                    replyList.Clear();
                }
            }
            else if (msg.type == ProcMessage.msgRelease)
            {
                requestList.Remove(msg.src);
                if (requestList.Count == 1) SendMsg(ProcMessage.msgReply, msg.src);//如果当前请求是队列中唯一的请求，则回复reply
            }
        }

        private void SendMsg(int msg, int dest = 0)
        {
            DateTime curTime = DateTime.Now;
            ProcMessage newMsg = new ProcMessage();
            newMsg.type = msg;
            newMsg.src = index;
            newMsg.time = curTime;
            //if (newMsg.type == ProcMessage.msgRequest) requestList.Add(index, newMsg);
            if (dest == 0)
            {
                //广播消息
                foreach (var entry in entries)
                {
                    entry.ReceiveMsg(newMsg);
                }
                this.ReceiveMsg(newMsg);
            }
            else
            {
                foreach (var entry in entries)
                {
                    if (entry.Index == dest) entry.ReceiveMsg(newMsg);
                }
                if (this.index == dest) this.ReceiveMsg(newMsg);
            }
        }

        private void button_enter_Click(object sender, EventArgs e)
        {
            waitingCar++;
            ChangeState("车辆等待中");
            if (waitingCar == 1)
            {
                SendMsg(ProcMessage.msgRequest);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_curTime.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
