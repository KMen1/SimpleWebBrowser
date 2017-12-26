using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ChromiumWebBrowser chrome;
        int i = 0;


        private void Form1_Load(object sender, EventArgs e)
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            chrome = new ChromiumWebBrowser("https://google.com");
            chrome.Dock = DockStyle.Fill;
            chrome.AddressChanged += Chrome_AddressChanged;
            chrome.TitleChanged += Chrome_TitleChanged;
            chrome.Visible = true;
            //chrome.Load = Web_DocumentCompleted;
            tabControl1.TabPages.Add("New Tab");
            tabControl1.SelectTab(i);
            tabControl1.SelectedTab.Controls.Add(chrome);
            i += 1;
            ((ChromiumWebBrowser)tabControl1.SelectedTab.Controls[0]).Load("https://google.com");
        }

        private void Chrome_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            Invoke(new MethodInvoker(() => {
                tabControl1.SelectedTab.Text = e.Title;
            }));
        }

        private void Chrome_AddressChanged(object sender, AddressChangedEventArgs e)
        {

            Invoke(new MethodInvoker(() => {
                textBox1.Text = e.Address;
                toolStripComboBox1.Items.Add(e.Address);
            }));
        }

        private void Web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl1.SelectedTab.Text = ((ChromiumWebBrowser)tabControl1.SelectedTab.Controls[0]).Text;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((ChromiumWebBrowser)tabControl1.SelectedTab.Controls[0]).Load(textBox1.Text);
            //textBox1.Text = ("");
            //button1.Enabled = false;
            //textBox1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (((ChromiumWebBrowser)tabControl1.SelectedTab.Controls[0]).CanGoBack)
            {
                ((ChromiumWebBrowser)tabControl1.SelectedTab.Controls[0]).Back();
                //button4.Enabled = false;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (((ChromiumWebBrowser)tabControl1.SelectedTab.Controls[0]).CanGoForward)
            {
                ((ChromiumWebBrowser)tabControl1.SelectedTab.Controls[0]).Forward();
                //button5.Enabled = false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            chrome = new ChromiumWebBrowser("");
            chrome.Dock = DockStyle.Fill;
            chrome.Visible = true;
            //chrome.DocumentCompleted += Web_DocumentCompleted;
            tabControl1.TabPages.Add("New Tab");
            tabControl1.SelectTab(i);
            tabControl1.SelectedTab.Controls.Add(chrome);
            i += 1;
            ((ChromiumWebBrowser)tabControl1.SelectedTab.Controls[0]).Load(textBox3.Text);
            //button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count - 1 > 0)
            {
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
                tabControl1.SelectTab(tabControl1.TabPages.Count - 1);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ((ChromiumWebBrowser)tabControl1.SelectedTab.Controls[0]).Refresh();
            //button6.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ((ChromiumWebBrowser)tabControl1.SelectedTab.Controls[0]).Load("https://google.com");
            //button7.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ((ChromiumWebBrowser)tabControl1.SelectedTab.Controls[0]).Load("https://google.com/search?q=" + textBox2.Text);
            //button8.Enabled = false;
            //textBox2.Enabled = false;
            if (!toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
            {
                toolStripComboBox1.Items.Add("Google: " + textBox2.Text);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ((ChromiumWebBrowser)tabControl1.SelectedTab.Controls[0]).Load("https://youtube.com");
            //button9.Enabled = false;
            if (!toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
            {
                toolStripComboBox1.Items.Add("Shortcut: YouTube");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ((ChromiumWebBrowser)tabControl1.SelectedTab.Controls[0]).Load("https://facebook.com");
            //button10.Enabled = false;
            if (!toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
            {
                toolStripComboBox1.Items.Add("Shortcut: Facebook");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ((ChromiumWebBrowser)tabControl1.SelectedTab.Controls[0]).Load("https://reddit.com");
            //button11.Enabled = false;
            if (!toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
            {
                toolStripComboBox1.Items.Add("Shortcut: Reddit");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ((ChromiumWebBrowser)tabControl1.SelectedTab.Controls[0]).Load("https://gmail.com");
            //button12.Enabled = false;
            if (!toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
            {
                toolStripComboBox1.Items.Add("Shortcut: Gmail");
            }
        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cef.Shutdown();
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
            {
                ((ChromiumWebBrowser)tabControl1.SelectedTab.Controls[0]).Load(textBox1.Text);
                //textBox1.Enabled = false;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
            {
                ((ChromiumWebBrowser)tabControl1.SelectedTab.Controls[0]).Load("https://google.com/search?q=" + textBox2.Text);
                //textBox2.Enabled = false;
                if (!toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
                {
                    toolStripComboBox1.Items.Add("Google: " + textBox2.Text);
                }
            }
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Text = ("");
        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.Text = (""); 
        }

        private void beállításokToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
