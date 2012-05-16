using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PivoTurtle
{
    public partial class IssuesForm : Form
    {
        private readonly IEnumerable<TicketItem> _tickets;
        private readonly List<TicketItem> _ticketsAffected = new List<TicketItem>();

        public IssuesForm(IEnumerable<TicketItem> tickets)
        {
            InitializeComponent();
            _tickets = tickets;
        }

        public IEnumerable<TicketItem> TicketsFixed
        {
            get { return _ticketsAffected; }
        }

        private void IssuesForm_Load(object sender, EventArgs e)
        {
            foreach (TicketItem ticketItem in _tickets)
            {
                ListViewItem item = new ListViewItem();
                item.Text = "";
                item.SubItems.Add(ticketItem.Number.ToString());
                item.SubItems.Add(ticketItem.Summary);
                item.Tag = ticketItem;

                listView1.Items.Add(item);
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                TicketItem ticketItem = item.Tag as TicketItem;
                if (ticketItem != null && item.Checked)
                {
                    _ticketsAffected.Add(ticketItem);
                }
            }
        }
    }
}
