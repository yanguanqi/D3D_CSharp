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

        private void bt_ex_3_5_Click(object sender, EventArgs e)
        {
            using (F0305 f = new F0305())
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

        private void bt_ex_4_1_Click(object sender, EventArgs e)
        {
            using (F0401 f = new F0401())
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

        private void bt_ex_4_2_Click(object sender, EventArgs e)
        {
            using (F0402 f = new F0402())
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

        private void bt_ex_4_3_Click(object sender, EventArgs e)
        {
            using (F0403 f = new F0403())
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

        private void bt_ex_4_4_Click(object sender, EventArgs e)
        {
            using (F0404 f = new F0404())
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

        private void bt_ex_4_5_Click(object sender, EventArgs e)
        {
            using (F0405 f = new F0405())
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

        private void bt_ex_4_6_Click(object sender, EventArgs e)
        {
            using (F0406 f = new F0406())
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

        private void bt_ex_4_7_Click(object sender, EventArgs e)
        {
            using (F0407 f = new F0407())
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
