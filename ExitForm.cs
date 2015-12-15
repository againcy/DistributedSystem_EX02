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
    public partial class ExitForm : Form
    {
        private ParkingSpace slot;
        public List<EntryForm> entries;
        public ExitForm(ParkingSpace s)
        {
            InitializeComponent();
            slot = s;
            entries = new List<EntryForm>();
        }

        public void AddEntry(EntryForm entry)
        {
            entries.Add(entry);
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            slot.CarOut();
            foreach(var entry in entries)
            {
                ProcMessage msg = new ProcMessage();
                msg.src = 0;
                msg.time = DateTime.Now;
                msg.type = ProcMessage.msgRequest;
                entry.ReceiveMsg(msg);
            }
        }
    }
}
