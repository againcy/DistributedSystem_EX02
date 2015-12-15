using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistributedSystem_EX02
{
    public partial class MainForm : Form
    {
        private int entryCount;
        private List<EntryForm> entries;
        private List<ExitForm> exits;
        private ParkingSpace slot;

        public MainForm()
        {
            InitializeComponent();
            entryCount = 1;
            entries = new List<EntryForm>();
            exits = new List<ExitForm>();
            slot = new ParkingSpace(4, Refresh);
            AddExit(1);
        }
        public void Refresh(int cur,int total)
        {
            string str = "剩余车位: " + cur.ToString() + "/" + total.ToString();
            foreach(var entry in entries)
            {
                entry.ChangeParkState(str);
            }
        }

        private void AddExit(int n)
        {
            for (int i = 0; i < n; i++)
            {
                ExitForm newExit = new ExitForm(slot);
                exits.Add(newExit);
                newExit.Show();
            }
        }

        private void button_addEntry_Click(object sender, EventArgs e)
        {
            EntryForm newEntry = new EntryForm(entryCount, 0, slot);
            int timeStamp = 0;
            if (entries.Count>0)
            {
                timeStamp++;
                foreach (var entry in entries) newEntry.AddEntry(entry);
                foreach (var entry in entries) entry.AddEntry(newEntry);
            }
            
            entries.Add(newEntry);
            foreach (var exit in exits) exit.AddEntry(newEntry);
            
            entryCount++;
            newEntry.Show();
        }
    }
}
