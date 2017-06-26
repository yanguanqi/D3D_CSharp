using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Test.Chapter6;

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

        private void bt_ex_4_8_Click(object sender, EventArgs e)
        {
            using (F0408 f = new F0408())
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

        private void bt_ex_4_9_Click(object sender, EventArgs e)
        {
            using (F0409 f = new F0409())
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

        private void bt_ex_5_1_Click(object sender, EventArgs e)
        {
            using (F0501 f = new F0501())
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

        private void bt_ex_5_2_Click(object sender, EventArgs e)
        {
            using (F0502 f = new F0502())
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

        private void bt_ex_5_3_Click(object sender, EventArgs e)
        {
            using (F0503 f = new F0503())
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

        private void bt_ex_5_4_Click(object sender, EventArgs e)
        {
            using (F0504 f = new F0504())
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

        private void bt_ex_5_5_Click(object sender, EventArgs e)
        {
            using (F0505 f = new F0505())
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

        private void bt_ex_5_6_Click(object sender, EventArgs e)
        {
            using (F0506 f = new F0506())
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

        private void bt_ex_5_7_Click(object sender, EventArgs e)
        {
            using (F0507 f = new F0507())
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

        private void bt_ex_5_8_Click(object sender, EventArgs e)
        {
            using (F0508 f = new F0508())
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

        private void bt_ex_5_9_Click(object sender, EventArgs e)
        {
            using (F0509 f = new F0509())
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

        private void bt_ex_5_10_Click(object sender, EventArgs e)
        {
            using (F0510 f = new F0510())
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

        private void bt_ex_5_11_Click(object sender, EventArgs e)
        {
            using (F0511 f = new F0511())
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

        private void bt_ex_5_12_Click(object sender, EventArgs e)
        {
            using (F0512 f = new F0512())
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

        private void bt_ex_5_13_Click(object sender, EventArgs e)
        {
            using (F0513 f = new F0513())
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

        private void bt_ex_5_14_Click(object sender, EventArgs e)
        {
            using (F0514 f = new F0514())
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

        private void bt_ex_6_1_Click(object sender, EventArgs e)
        {
            using (F0601 f = new F0601())
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

        private void bt_ex_6_2_Click(object sender, EventArgs e)
        {
            using (F0602 f = new F0602())
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

        private void bt_ex_6_3_Click(object sender, EventArgs e)
        {
            using (F0603 f = new F0603())
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
