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
    public partial class F0507 : Form
    {
        VertexBuffer vertexBuffer = null;
        Material mtrl;
        float Angle = 0, ViewZ = -6f;
        private Device device;
        private bool pause;
        public F0507()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
            this.KeyPreview = true;
            this.KeyDown += F0501_KeyDown;
        }

        private void F0501_KeyDown(object sender, KeyEventArgs e)
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
            dev.RenderState.CullMode = Cull.None;
            dev.RenderState.Lighting = true;
            SetupLights();
        }
        public void OnCreateDevice(object sender, EventArgs e)
        {
            Device dev = sender as Device;
            vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionNormal), 3, dev, Usage.WriteOnly, CustomVertex.PositionNormal.Format, Pool.Default);
            vertexBuffer.Created += onCreateVertexBuffer;
            this.onCreateVertexBuffer(dev, null);
            mtrl = new Material();
            mtrl.Diffuse = Color.Yellow;
            mtrl.Ambient = Color.Red;
        }
        private void onCreateVertexBuffer(object sender, EventArgs e)
        {
            CustomVertex.PositionNormal[] verts = (CustomVertex.PositionNormal[])vertexBuffer.Lock(0, 0);
            verts[0].Position = new Microsoft.DirectX.Vector3(-2, -2, 0);
            verts[0].Normal = new Microsoft.DirectX.Vector3(0, 0, -1);
            verts[1].Position = new Microsoft.DirectX.Vector3(0, 2, 0);
            verts[1].Normal = new Microsoft.DirectX.Vector3(0, 0, -1);
            verts[2].Position = new Microsoft.DirectX.Vector3(2, -2, 0);
            verts[2].Normal = new Microsoft.DirectX.Vector3(0, 0, -1);
            vertexBuffer.Unlock();
        }
        private void SetupMatrix()
        {
            device.Transform.World = Matrix.RotationY(Angle);
            device.Transform.View = Matrix.LookAtLH(new Vector3(0, 3, ViewZ), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4, 1, 1, 100);
        }
        private void SetupLights()
        {
            device.Material = mtrl;
            device.Lights[0].Type = LightType.Spot;
            device.Lights[0].Diffuse = Color.White;
            device.Lights[0].Range = 20f;
            device.Lights[0].Position = new Vector3(0, 0, -4);
            device.Lights[0].Direction = new Vector3(0, 0, 4);//光源照射方向
            device.Lights[0].InnerConeAngle = 0.5f;
            device.Lights[0].OuterConeAngle = 1f;
            device.Lights[0].Falloff = 0.1f;
            device.Lights[0].Attenuation0 = 1f;
            device.Lights[0].Enabled = true;
            device.Lights[0].Update();
           
            device.RenderState.Ambient = Color.FromArgb(0x808080);//环境光
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
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, 1);
            device.EndScene();
            device.Present();
        }
    }
}
