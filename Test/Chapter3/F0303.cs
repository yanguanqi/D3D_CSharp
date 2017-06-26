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
    public partial class F0303 : Form
    {
        private bool pause = false;
        private Device mDevice;
        CustomVertex.TransformedColored[] verts = null, verts1 = null;
        public F0303()
        {
            InitializeComponent();
            this.Paint += F0303_Paint;
            this.Resize += F0303_Resize;
        }

        private void F0303_Resize(object sender, EventArgs e)
        {
            pause = this.WindowState == FormWindowState.Minimized || !this.Visible;
        }

        private void F0303_Paint(object sender, PaintEventArgs e)
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
        private void OnCreateDevice(object sender,EventArgs e)
        {
            verts = new CustomVertex.TransformedColored[6];
            verts[0].Position = new Microsoft.DirectX.Vector4(10, 10, 0.5f, 1);
            verts[0].Color = Color.Aqua.ToArgb();
            verts[1].Position = new Microsoft.DirectX.Vector4(210, 10, 0.5f, 1);
            verts[1].Color = Color.Brown.ToArgb();
            verts[2].Position = new Microsoft.DirectX.Vector4(110, 60, 0.5f, 1);
            verts[2].Color = Color.LightPink.ToArgb();
            verts[3].Position = new Microsoft.DirectX.Vector4(210, 210, 0.5f, 1);
            verts[4].Color = Color.Red.ToArgb();
            verts[4].Position = new Microsoft.DirectX.Vector4(110, 160, 0.5f, 1);
            verts[4].Color = Color.Aqua.ToArgb();
            verts[5].Position = new Microsoft.DirectX.Vector4(10, 210, 0.5f, 1);
            verts[5].Color = Color.LightPink.ToArgb();
        }
        private void OnResetDevice(object sender,EventArgs e)
        {

        }
        private void MDevice_DeviceReset(object sender, EventArgs e)
        {
            
        }
        public void Render()
        {
            if(mDevice==null)
            {
                return;
            }
            if (pause)
                return;
            mDevice.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Blue, 1, 0);
            mDevice.RenderState.CullMode = Cull.None;
            mDevice.BeginScene();
            //Todo: Input your code
            mDevice.VertexFormat = CustomVertex.TransformedColored.Format;
            Modify(1, 1);
            mDevice.DrawUserPrimitives(PrimitiveType.TriangleFan, 5, verts1);
            Modify(250, 0);
            mDevice.DrawUserPrimitives(PrimitiveType.TriangleStrip, 4, verts1);
            Modify(500, 0);
            mDevice.DrawUserPrimitives(PrimitiveType.TriangleList, 2, verts1);
            Modify(0, 250);
            mDevice.DrawUserPrimitives(PrimitiveType.LineList, 3, verts1);
            Modify(250, 250);
            mDevice.DrawUserPrimitives(PrimitiveType.LineStrip, 5, verts1);
            Modify(500, 250);
            mDevice.DrawUserPrimitives(PrimitiveType.PointList, 6, verts1);
            mDevice.EndScene();
            mDevice.Present();

        }
        void Modify(float x1, float y1)
        {
            verts1 = (CustomVertex.TransformedColored[])verts.Clone();
            for (int i = 0; i < 6; i++)
            {
                verts1[i].X += x1;
                verts1[i].Y += y1;
            }
        }
    }
}
