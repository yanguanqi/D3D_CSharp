using Microsoft.DirectX.Direct3D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace Test
{
    public partial class F0302 : Form
    {
        CustomVertex.TransformedColored[] verts;
        private Device device;
        private bool pause;
        public F0302()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.Render();
        }

       
        public bool InitializeGraphics()
        {
            try
            {
                PresentParameters presentParams = new PresentParameters();
                presentParams.Windowed = true;
                presentParams.SwapEffect = SwapEffect.Discard;
                presentParams.EnableAutoDepthStencil = true;
                presentParams.AutoDepthStencilFormat = DepthFormat.D16;
                device = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, presentParams);
                device.DeviceReset += Device_DeviceReset;
                this.OnCreateDevice(device, null);
                this.OnResetDevice(device, null);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        private void Device_DeviceReset(object sender, EventArgs e)
        {
            
        }
        public void OnResetDevice(object sender,EventArgs e)
        {

        }
        public void OnCreateDevice(object sender,EventArgs e)
        {
            verts = new CustomVertex.TransformedColored[3];
            verts[0].Position = new Microsoft.DirectX.Vector4(150, 50, 0.5f, 1);
            verts[0].Color = Color.Aqua.ToArgb();
            verts[1].Position = new Microsoft.DirectX.Vector4(250, 250, 0.5f, 1);
            verts[1].Color = Color.Brown.ToArgb();
            verts[2].Position = new Microsoft.DirectX.Vector4(50, 250, 0.5f, 1);
            verts[2].Color = Color.LightPink.ToArgb();
        }
        public void Render()
        {
            if (device == null)
            {
                return;
            }
            if (pause)
            {
                return;
            }
            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Blue, 1, 0);
            device.BeginScene();
            device.VertexFormat = (VertexFormats)CustomVertex.TransformedColored.Format;
            device.DrawUserPrimitives(PrimitiveType.TriangleList, 1, verts);
            device.EndScene();
            device.Present();
        }
    }
}
