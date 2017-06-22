using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class DemoCenter : Form
    {
        public DemoCenter()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void bt_ex_3_2_Click(object sender, EventArgs e)
        {
            using (F0302 f = new F0302())
            {
                f.TopMost = false;
                f.TopLevel = false;
                this.panel1.Controls.Add(f);
                f.Show();
                f.InitializeGraphics();
                while (f.Created)
                {
                    f.Render();
                    Application.DoEvents();
                }
                
            }
        }

        private void bt_ex_3_3_Click(object sender, EventArgs e)
        {
            using (F0303 f = new F0303())
            {
                f.TopMost = false;
                f.TopLevel = false;
                this.panel1.Controls.Add(f);
                f.Show();
                f.InitializeGraphics();
                while (f.Created)
                {
                    f.Render();
                    Application.DoEvents();
                }

            }
        }

        private void bt_ex_3_4_Click(object sender, EventArgs e)
        {
            using (F0304 f = new F0304())
            {
                f.TopMost = false;
                f.TopLevel = false;
                this.panel1.Controls.Add(f);
                f.Show();
               
                f.InitializeGraphics();
                while (f.Created)
                {
                    f.Render();
                    Application.DoEvents();
                }

            }
        }
    }
}
