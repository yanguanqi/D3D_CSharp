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
    public partial class F0403 : Form
    {
        VertexBuffer vertexBuffer = null;
        float Angle = 0, ViewZ = -6;
        private Device device;
        private bool pause;
        public F0403()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
            this.KeyDown += F0402_KeyDown;
            this.Focus();
        }

        private void F0402_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    Angle += 0.1f;
                    break;
                case Keys.D:
                    Angle -= 0.1f;
                    break;
                case Keys.W:
                    ViewZ += 0.1f;
                    break;
                case Keys.S:
                    ViewZ -= 0.1f;
                    break;
                default:
                    break;
            }
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
            Device dev = (Device)sender;
            dev.RenderState.CullMode = Cull.None;
            dev.RenderState.Lighting = false;

        }
        public void OnCreateDevice(object sender, EventArgs e)
        {
            Device dev = (Device)sender;
            vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionColored), 3, dev, 0, CustomVertex.PositionColored.Format, Pool.Default);
            vertexBuffer.Created += this.onCreateVertexBuffer;
            this.onCreateVertexBuffer(vertexBuffer, null);
        }
        private void onCreateVertexBuffer(object sender, EventArgs e)
        {
            CustomVertex.PositionColored[] verts = (CustomVertex.PositionColored[])vertexBuffer.Lock(0, 0);
            verts[0].Position = new Microsoft.DirectX.Vector3(-1, -1, 0);
            verts[0].Color = Color.Aqua.ToArgb();
            verts[1].Position = new Microsoft.DirectX.Vector3(1, -1, 0);
            verts[1].Color = Color.Brown.ToArgb();
            verts[2].Position = new Microsoft.DirectX.Vector3(0, 1, 0);
            verts[2].Color = Color.LightPink.ToArgb();
            vertexBuffer.Unlock();
        }
        private void SetupMatrices()
        {
            int iTime = Environment.TickCount % 1000;
            Angle = iTime * (2 * (float)Math.PI / 1000);
            device.Transform.World = Matrix.Translation(1, 0, 0) *Matrix.RotationY(Angle)  ;
            device.Transform.View = Matrix.LookAtLH(new Vector3(0, 3, ViewZ), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4, 1, 1, 100);
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
            SetupMatrices();
            device.BeginScene();
            //Todo: Input your code here!
            device.SetStreamSource(0, vertexBuffer, 0);
            device.VertexFormat = (CustomVertex.PositionColored.Format);
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, 1);
            device.EndScene();
            device.Present();
        }
    }
}
