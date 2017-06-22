using Microsoft.DirectX.Direct3D;
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
    public partial class F0304 : Form
    {
        private bool pause = false;
        private Device mDevice;
        CustomVertex.TransformedColored[] verts = null, verts1 = null;
        public F0304()
        {
            InitializeComponent();
            this.Paint += F0304_Paint;
            this.Resize += F0304_Resize;
        }

        private void F0304_Resize(object sender, EventArgs e)
        {
            pause = this.WindowState == FormWindowState.Minimized || !this.Visible;
        }

        private void F0304_Paint(object sender, PaintEventArgs e)
        {
            this.Render();
        }

        public bool InitializeGraphics()
        {
            try
            {
                PresentParameters pp = new PresentParameters();
                pp.Windowed = true;
                pp.SwapEffect = SwapEffect.Discard;
                pp.EnableAutoDepthStencil = true;
                pp.AutoDepthStencilFormat = DepthFormat.D16;
                this.mDevice = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, pp);
                this.mDevice.DeviceReset += MDevice_DeviceReset;
                this.OnCreateDevice(mDevice, null);
                this.OnResetDevice(mDevice, null);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        private void OnCreateDevice(object sender, EventArgs e)
        {

        }
        private void OnResetDevice(object sender, EventArgs e)
        {

        }
        private void MDevice_DeviceReset(object sender, EventArgs e)
        {

        }
        public void Render()
        {
            if (mDevice == null)
            {
                return;
            }
            if (pause)
                return;
            mDevice.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Blue, 1, 0);
            mDevice.BeginScene();
            //Todo: Input your code

            mDevice.EndScene();
            mDevice.Present();

        }
    }
}
