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
    public partial class F0409 : Form
    {
        VertexBuffer vertexBuffer = null;
        IndexBuffer indexBuffer = null;
        float Angle = 0, ViewZ = -6;
        private Device device;
        private bool pause;
        public F0409()
        {
            InitializeComponent();
            this.KeyPreview = true;
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
            vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionColored), 8, dev, 0, CustomVertex.PositionColored.Format, Pool.Default);
            indexBuffer = new IndexBuffer(typeof(int), 36, dev, 0, Pool.Default);
            vertexBuffer.Created += this.onCreateVertexBuffer;
            indexBuffer.Created += IndexBuffer_Created;

            this.onCreateVertexBuffer(vertexBuffer, null);
            this.IndexBuffer_Created(indexBuffer, null);
        }

        private void IndexBuffer_Created(object sender, EventArgs e)
        {
            int[] index = { 4, 5, 6, 5, 7, 6, 5, 1, 7, 7, 1, 3, 4, 0, 1, 4, 1, 5, 2, 0, 4, 2, 4, 6, 3, 1, 0, 3, 0, 2, 2, 6, 7, 2, 7, 3 };
            int[] indexV = (int[])indexBuffer.Lock(0, 0);
            for (int i = 0; i < 36; i++)
            {
                indexV[i] = index[i];
            }
            indexBuffer.Unlock();
        }

        private void onCreateVertexBuffer(object sender, EventArgs e)
        {
            CustomVertex.PositionColored[] verts = (CustomVertex.PositionColored[])vertexBuffer.Lock(0, 0);
            verts[0].Position = new Microsoft.DirectX.Vector3(-0.2f, 0.2f, 0.2f);
            verts[0].Color = Color.Aqua.ToArgb();
            verts[1].Position = new Microsoft.DirectX.Vector3(0.2f, 0.2f, 0.2f);
            verts[1].Color = Color.Brown.ToArgb();
            verts[2].Position = new Microsoft.DirectX.Vector3(-0.2f, -0.2f, 0.2f);
            verts[2].Color = Color.LightPink.ToArgb();
            verts[3].Position = new Microsoft.DirectX.Vector3(0.2f, -0.2f, 0.2f);
            verts[3].Color = Color.Red.ToArgb();
            verts[4].Position = new Microsoft.DirectX.Vector3(-0.2f, 0.2f, -0.2f);
            verts[4].Color = Color.Green.ToArgb();
            verts[5].Position = new Microsoft.DirectX.Vector3(0.2f, 0.2f, -0.2f);
            verts[5].Color = Color.Black.ToArgb();
            verts[6].Position = new Microsoft.DirectX.Vector3(-0.2f, -0.2f, -0.2f);
            verts[6].Color = Color.LightPink.ToArgb();
            verts[7].Position = new Microsoft.DirectX.Vector3(0.2f, -0.2f, -0.2f);
            verts[7].Color = Color.Red.ToArgb();
            vertexBuffer.Unlock();
        }
        private void SetupMatrices()
        {
            Vector3 v1 = new Vector3(0, 0, -5);
            v1.TransformCoordinate(Matrix.RotationYawPitchRoll(Angle, ViewZ, 0));
            device.Transform.View = Matrix.LookAtLH(v1, new Vector3(0, 0, 0), new Vector3(0, 1, 0));
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
            device.Indices = indexBuffer;
            int iTime = Environment.TickCount % 10000;
            float Angle = iTime * (2 * (float)Math.PI) / 10000f;
            device.Transform.World = Matrix.RotationY(Angle);
            device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, 8, 0, 12);
            device.Transform.World = Matrix.RotationY(Angle) * Matrix.Translation(2, 0, 0) * Matrix.RotationY(Angle);
            device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, 8, 0, 12);
            device.EndScene();
            device.Present();
        }
    }
}
