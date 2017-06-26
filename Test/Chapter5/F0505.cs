using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;

namespace Test
{
    public partial class F0505 : Form
    {
        VertexBuffer vertexBuffer = null;
        Material mtrl;
        float Angle = 0, ViewZ = -6f;
        private Device device;
        private bool pause;
        public F0505()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
            this.KeyPreview = true;
            this.KeyDown += F0502_KeyDown;
        }

        private void F0502_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    Angle += 0.1f;
                    break;
                case Keys.W:
                    ViewZ -= 0.1f;
                    break;
                case Keys.S:
                    ViewZ += 0.1f;
                    break;
                case Keys.D:
                    Angle -= 0.1f;
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
            Device dev = sender as Device;
            dev.RenderState.CullMode = Cull.CounterClockwise;
            dev.RenderState.ZBufferEnable = true;
            dev.RenderState.Lighting = true;
            SetupLights();
        }
        public void OnCreateDevice(object sender, EventArgs e)
        {
            Device dev = sender as Device;
            vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionNormal), 6, dev, Usage.WriteOnly, CustomVertex.PositionNormal.Format, Pool.Default);
            vertexBuffer.Created += onCreateVertexBuffer;
            this.onCreateVertexBuffer(dev, null);
            mtrl = new Material();
            mtrl.Diffuse = Color.Yellow;
            mtrl.Ambient = Color.Red;

        }
        private void onCreateVertexBuffer(object sender, EventArgs e)
        {
            CustomVertex.PositionNormal[] verts = (CustomVertex.PositionNormal[])vertexBuffer.Lock(0, 0);
            verts[0].Position = new Microsoft.DirectX.Vector3(-1, -1, 0);
            verts[0].Normal = new Microsoft.DirectX.Vector3(0, 0, -1);
            verts[1].Position = new Microsoft.DirectX.Vector3(1, 1, 0);
            verts[1].Normal = new Microsoft.DirectX.Vector3(0, 0, -1);
            verts[2].Position = new Microsoft.DirectX.Vector3(1, -1, 0);
            verts[2].Normal = new Microsoft.DirectX.Vector3(0, 0, -1);
            verts[3].Position = new Microsoft.DirectX.Vector3(-1, -1, 0);
            verts[3].Normal = new Microsoft.DirectX.Vector3(0, 0, -1);
            verts[4].Position = new Microsoft.DirectX.Vector3(-1, 1, 0);
            verts[4].Normal = new Microsoft.DirectX.Vector3(0, 0, -1);
            verts[5].Position = new Microsoft.DirectX.Vector3(1, 1, 0);
            verts[5].Normal = new Microsoft.DirectX.Vector3(0, 0, -1);
            vertexBuffer.Unlock();
        }
        private void SetupMatrix()
        {
            device.Transform.World = Matrix.RotationY(0);
            Vector3 v1 = new Vector3(0, 0, 5);
            v1.TransformCoordinate(Matrix.RotationYawPitchRoll(Angle, ViewZ, 0));

            device.Transform.View = Matrix.LookAtLH(v1, new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4, 1, 1, 100);
        }
        private void SetupLights()
        {
            device.Material = mtrl;
            device.Lights[0].Type = LightType.Point;
            device.Lights[0].Diffuse = Color.White;
            device.Lights[0].Range = 20f;
            device.Lights[0].Position = new Vector3(0, 0, 0);
            device.Lights[0].Attenuation1 = 0.2f;
            device.Lights[0].Enabled = true;
            device.Lights[0].Update();
            device.RenderState.Ambient = Color.FromArgb(0x808080);
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
            SetupMatrix();
            device.SetStreamSource(0, vertexBuffer, 0);
            device.VertexFormat = CustomVertex.PositionNormal.Format;

            device.Transform.World = Matrix.Translation(0, 0, -1);
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);

            device.Transform.World = Matrix.RotationY((float)Math.PI) * Matrix.Translation(0, 0, 1);
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);

            device.Transform.World = Matrix.RotationY(-(float)Math.PI / 2) * Matrix.Translation(1, 0, 0);
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);

            device.Transform.World = Matrix.RotationY((float)Math.PI / 2) * Matrix.Translation(-1, 0, 0);
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);

            device.Transform.World = Matrix.RotationX((float)Math.PI / 2) * Matrix.Translation(0, 1, 0);
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);

            device.Transform.World = Matrix.RotationX(-(float)Math.PI / 2) * Matrix.Translation(0, -1, 0);
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);


            device.EndScene();
            device.Present();
        }
    }
}
