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
    public partial class F0404 : Form
    {
        VertexBuffer vertexBuffer = null;
        float Angle = 0, ViewZ = -6;
        private Device device;
        private bool pause;
        public F0404()
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
            dev.RenderState.CullMode = Cull.CounterClockwise;
            dev.RenderState.Lighting = false;

        }
        public void OnCreateDevice(object sender, EventArgs e)
        {
            Device dev = (Device)sender;
            vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionColored), 6, dev, 0, CustomVertex.PositionColored.Format, Pool.Default);
            vertexBuffer.Created += this.onCreateVertexBuffer;
            this.onCreateVertexBuffer(vertexBuffer, null);
        }
        private void onCreateVertexBuffer(object sender, EventArgs e)
        {
            CustomVertex.PositionColored[] verts = (CustomVertex.PositionColored[])vertexBuffer.Lock(0, 0);
            verts[0].Position = new Microsoft.DirectX.Vector3(-1, -1, 0);
            verts[0].Color = Color.Aqua.ToArgb();
            verts[1].Position = new Microsoft.DirectX.Vector3(1, 1, 0);
            verts[1].Color = Color.Brown.ToArgb();
            verts[2].Position = new Microsoft.DirectX.Vector3(1, -1, 0);
            verts[2].Color = Color.LightPink.ToArgb();
            verts[3].Position = new Microsoft.DirectX.Vector3(-1, -1, 0);
            verts[3].Color = Color.Aqua.ToArgb();
            verts[4].Position = new Microsoft.DirectX.Vector3(-1, 1, 0);
            verts[4].Color = Color.Red.ToArgb();
            verts[5].Position = new Microsoft.DirectX.Vector3(1, 1, 0);
            verts[5].Color = Color.Brown.ToArgb();
            vertexBuffer.Unlock();
        }
        private void SetupMatrices()
        {
            device.Transform.World = Matrix.RotationY(Angle);
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
            this.KeyPreview = true;
            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Blue, 1, 0);
            SetupMatrices();
            device.BeginScene();
            //Todo: Input your code here!
            device.SetStreamSource(0, vertexBuffer, 0);
            device.VertexFormat = (CustomVertex.PositionColored.Format);
            device.Transform.World = Matrix.Translation(0, 0, -1)*Matrix.RotationY(Angle);
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);

            device.Transform.World = Matrix.RotationY((float)Math.PI) * Matrix.Translation(0, 0, 1) * Matrix.RotationY(Angle);
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);

            device.Transform.World = Matrix.RotationY(-(float)Math.PI / 2) * Matrix.Translation(1, 0, 0) * Matrix.RotationY(Angle);
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);

            device.Transform.World = Matrix.RotationY((float)Math.PI / 2) * Matrix.Translation(-1, 0, 0) * Matrix.RotationY(Angle);
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);

            device.Transform.World = Matrix.RotationX((float)Math.PI / 2) * Matrix.Translation(0, 1, 0) * Matrix.RotationY(Angle);
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);

            device.Transform.World = Matrix.RotationX(-(float)Math.PI / 2) * Matrix.Translation(0, -1, 0) * Matrix.RotationY(Angle);
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);

            device.EndScene();
            device.Present();
        }
    }
}
