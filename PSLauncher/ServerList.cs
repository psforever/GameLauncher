using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PSLauncher.Properties;
using System.Collections.Specialized;
using System.Diagnostics;

namespace PSLauncher
{
    public partial class ServerList : Form
    {
        struct ServerEntry
        {
            public string name;
            public string hostname;
            public int port;
        }

        List<ServerEntry> entries = new List<ServerEntry>();

        public ServerList()
        {
            InitializeComponent();

            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            StringCollection serverList = Settings.Default.ServerList;

            foreach(String entry in serverList)
            {
                String [] tokens = entry.Split(',');

                if(tokens.Length != 3)
                {
                    Debug.WriteLine("Failed to load server entry " + entry);
                    continue;
                }

                ServerEntry newEntry = new ServerEntry();
                newEntry.name = tokens[0];
                newEntry.hostname = tokens[1];
                newEntry.port = int.Parse(tokens[2]);

                addEntry(newEntry);
            }
        }

        private void textInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox control = sender as TextBox;

            // disallow commas as they are used for tokenizing
            if(e.KeyChar == ',')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void portInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            Debug.WriteLine("Char: " + e.KeyChar.ToString());

            if(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b')
            {
                if(portInput.Text.Length >= 5 && e.KeyChar != '\b')
                    e.Handled = true;
                else
                    e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (hostnameInput.Text.Length == 0 || serverNameInput.Text.Length == 0
               || portInput.Text.Length == 0)
                return;

            // validate server entry fields
            ServerEntry entry = new ServerEntry();
            entry.name = serverNameInput.Text;
            entry.hostname = hostnameInput.Text;
            entry.port = Convert.ToInt32(portInput.Text);

            // add the entry to the top of the list
            addEntry(entry, 0);
        }

        private void addEntry(ServerEntry entry, int position=-1)
        {
            if (position == -1)
                position = entries.Count;

            entries.Insert(position, entry);
            serverDisplay.Items.Insert(position, entry.name + " - " + entry.hostname + ":" + entry.port);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            StringCollection serverList = new StringCollection();

            foreach (ServerEntry entry in entries)
            {
                string[] tokens = new string[3];
                tokens[0] = entry.name;
                tokens[1] = entry.hostname;
                tokens[2] = Convert.ToString(entry.port);

                serverList.Add(string.Join(",", tokens));
            }

            Settings.Default.ServerList = serverList;

            this.DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void moveUp_Click(object sender, EventArgs e)
        {
            int selected = serverDisplay.SelectedIndex;

            Debug.WriteLine("Move " + selected + " ^");

            if (selected == -1 || selected == 0)
                return;

            entries.Insert(selected - 1, entries[selected]);
            serverDisplay.Items.Insert(selected - 1, serverDisplay.Items[selected]);

            entries.RemoveAt(selected+1);
            serverDisplay.Items.RemoveAt(selected+1);

            serverDisplay.SelectedIndex = selected - 1;
        }

        private void moveDown_Click(object sender, EventArgs e)
        {
            int selected = serverDisplay.SelectedIndex;

            Debug.WriteLine("Move " + selected + " v");

            if (selected == -1 || (selected+1) == entries.Count)
                return;

            entries.Insert(selected + 2, entries[selected]);
            serverDisplay.Items.Insert(selected + 2, serverDisplay.Items[selected]);

            entries.RemoveAt(selected);
            serverDisplay.Items.RemoveAt(selected);

            serverDisplay.SelectedIndex = selected + 1;
        }

        private void deleteItem_Click(object sender, EventArgs e)
        {
            int selected = serverDisplay.SelectedIndex;

            entries.RemoveAt(selected);
            serverDisplay.Items.RemoveAt(selected);

            if(entries.Count > 0)
            {
                if(selected >= entries.Count)
                {
                    serverDisplay.SelectedIndex = selected-1;
                }
                else
                {
                    serverDisplay.SelectedIndex = selected;
                }
            }
        }

        private void serverDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            moveDown.Enabled = moveUp.Enabled = deleteItem.Enabled = serverDisplay.SelectedIndex != -1;
        }
    }
}
