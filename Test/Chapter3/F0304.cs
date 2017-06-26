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
        VertexBuffer vertexBuffer = null;
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
            Device dev = (Device)sender;
            vertexBuffer = new VertexBuffer(typeof(CustomVertex.TransformedColored), 3, dev, 0, CustomVertex.TransformedColored.Format, Pool.Default);
            vertexBuffer.Created += onCreateVertexBuffer;
           
            this.onCreateVertexBuffer(vertexBuffer, null);
        }
        private void onCreateVertexBuffer(object sender,EventArgs e)
        {
            CustomVertex.TransformedColored[] verts = (CustomVertex.TransformedColored[])vertexBuffer.Lock(0, 0);
            verts[0].X = 150;
            verts[0].Y = 50;
            verts[0].Z = 0.5f;
            verts[0].Rhw = 1;
            verts[0].Color = Color.Aqua.ToArgb();

            verts[1].X = 250;
            verts[1].Y = 250;
            verts[1].Z = 0.5f;
            verts[1].Rhw = 1;
            verts[1].Color = Color.Brown.ToArgb();

            verts[2].X = 50;
            verts[2].Y = 250;
            verts[2].Z = 0.5f;
            verts[2].Rhw = 1;
            verts[2].Color = Color.LightPink.ToArgb();
            vertexBuffer.Unlock();
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
            mDevice.SetStreamSource(0, vertexBuffer, 0);
            mDevice.VertexFormat = CustomVertex.TransformedColored.Format;
            mDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 1);
            mDevice.EndScene();
            mDevice.Present();

        }
    }
}
