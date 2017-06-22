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
    public partial class F0305 : Form
    {
        private bool pause = false;
        private Device mDevice;
        CustomVertex.TransformedColored[] verts = null, verts1 = null;
        VertexBuffer vertexBuffer = null;
        public F0305()
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
            vertexBuffer = new VertexBuffer(typeof(CustomVertex.TransformedColored), 18, dev, 0, CustomVertex.TransformedColored.Format, Pool.Default);
            vertexBuffer.Created += onCreateVertexBuffer;

            this.onCreateVertexBuffer(vertexBuffer, null);
        }
        private void onCreateVertexBuffer(object sender, EventArgs e)
        {
              CustomVertex.TransformedColored[] verts = (CustomVertex.TransformedColored[])vertexBuffer.Lock(0, 0);
            verts[0].Position = new Microsoft.DirectX.Vector4(100, 50, 0.5f, 1);
            verts[0].Color = Color.Aqua.ToArgb();

            verts[1].Position = new Microsoft.DirectX.Vector4(200, 50, 0.5f, 1);
            verts[1].Color = Color.Red.ToArgb();

            verts[2].Position = new Microsoft.DirectX.Vector4(50, 100, 0.5f, 1);
            verts[2].Color = Color.Red.ToArgb();

            verts[3].Position = new Microsoft.DirectX.Vector4(50, 100, 0.5f, 1);
            verts[3].Color = Color.Brown.ToArgb();

            verts[4].Position = new Microsoft.DirectX.Vector4(200, 50, 0.5f, 1);
            verts[4].Color = Color.Red.ToArgb();

            verts[5].Position = new Microsoft.DirectX.Vector4(150, 100, 0.5f, 1);
            verts[5].Color = Color.Red.ToArgb();

            verts[6].Position = new Microsoft.DirectX.Vector4(50, 100, 0.5f, 1);
            verts[6].Color = Color.Green.ToArgb();

            verts[7].Position = new Microsoft.DirectX.Vector4(150, 100, 0.5f, 1);
            verts[7].Color = Color.Purple.ToArgb();

            verts[8].Position = new Microsoft.DirectX.Vector4(50, 200, 0.5f, 1);
            verts[8].Color = Color.Green.ToArgb();

            verts[9].Position = new Microsoft.DirectX.Vector4(50, 200, 0.5f, 1);
            verts[9].Color = Color.Green.ToArgb();

            verts[10].Position = new Microsoft.DirectX.Vector4(150, 100, 0.5f, 1);
            verts[10].Color = Color.Black.ToArgb();

            verts[11].Position = new Microsoft.DirectX.Vector4(150, 200, 0.5f, 1);
            verts[11].Color = Color.Green.ToArgb();

            verts[12].Position = new Microsoft.DirectX.Vector4(150, 100, 0.5f, 1);
            verts[12].Color = Color.Yellow.ToArgb();

            verts[13].Position = new Microsoft.DirectX.Vector4(200, 50, 0.5f, 1);
            verts[13].Color = Color.White.ToArgb();

            verts[14].Position = new Microsoft.DirectX.Vector4(150, 200, 0.5f, 1);
            verts[14].Color = Color.Yellow.ToArgb();

            verts[15].Position = new Microsoft.DirectX.Vector4(150, 200, 0.5f, 1);
            verts[15].Color = Color.Gray.ToArgb();

            verts[16].Position = new Microsoft.DirectX.Vector4(200, 50, 0.5f, 1);
            verts[16].Color = Color.Yellow.ToArgb();

            verts[17].Position = new Microsoft.DirectX.Vector4(200, 150, 0.5f, 1);
            verts[17].Color = Color.Gold.ToArgb();

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
            mDevice.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.LightBlue, 1, 0);
            mDevice.BeginScene();
            //Todo: Input your code
            mDevice.SetStreamSource(0, vertexBuffer, 0);
            mDevice.VertexFormat = CustomVertex.TransformedColored.Format;
            mDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 6);
            mDevice.EndScene();
            mDevice.Present();

        }
    }
}
