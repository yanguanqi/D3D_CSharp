using Microsoft.DirectX;
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
    public partial class F0408 : Form
    {
        private VertexBuffer vertexBuffer = null;
        private Device device;
        private bool pause;
        public F0408()
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
                device.DeviceReset += OnResetDevice;
                this.OnCreateDevice(device, null);
                this.OnResetDevice(device, null);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public void OnResetDevice(object sender, EventArgs e)
        {
            Device dev = sender as Device;
            dev.RenderState.CullMode = Cull.None;
            dev.RenderState.Lighting = false;
        }
        private void SetupMatrix()
        {
            device.Transform.World = Matrix.RotationAxis(new Vector3((float)Math.Cos(Environment.TickCount / 250), 1, (float)Math.Sin(Environment.TickCount / 250)), Environment.TickCount / 3000);
            device.Transform.View = Matrix.LookAtLH(new Vector3(0, 3, -5), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4, 1, 1, 100);
        }
        public void OnCreateDevice(object sender, EventArgs e)
        {
            Device dev = (Device)sender;
            vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionColored), 100, dev, Usage.WriteOnly, CustomVertex.PositionColored.Format, Pool.Default);
            vertexBuffer.Created += OnCreateVertexBuffer;

        }
        private void OnCreateVertexBuffer(object sender, EventArgs e)
        {
            CustomVertex.PositionColored[] verts = (CustomVertex.PositionColored[])vertexBuffer.Lock(0, 0);
            for (int i = 0; i < 50; i++)
            {
                float theta = (float)(2 * Math.PI * i) / 49;
                verts[2 * i].Position = new Microsoft.DirectX.Vector3((float)Math.Sin(theta), -1, (float)Math.Cos(theta));
                verts[2 * i].Color = Color.LightPink.ToArgb();
                verts[2 * i + 1].Position = new Microsoft.DirectX.Vector3((float)Math.Sin(theta), 1, (float)Math.Cos(theta));
                verts[2 * i + 1].Color = Color.LightPink.ToArgb();
            }
            vertexBuffer.Unlock();
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
            //Todo:Insert your code here!
            SetupMatrix();
            device.SetStreamSource(0, vertexBuffer, 0);
            device.VertexFormat = CustomVertex.PositionColored.Format;
            device.DrawPrimitives(PrimitiveType.TriangleStrip, 0, (4 * 25) - 2);
            device.EndScene();
            device.Present();
        }
    }
}
