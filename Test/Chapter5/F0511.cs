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
    public partial class F0511 : Form
    {
        VertexBuffer vertexBuffer = null;
        Material mtrl;
        private Device device;
        private bool pause;
        public F0511()
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
            Device device = sender as Device;
            device.RenderState.CullMode = Cull.None;
            device.RenderState.Lighting = true;
            device.RenderState.ZBufferEnable = true;
            SetupLights();
        }
        public void OnCreateDevice(object sender, EventArgs e)
        {
            Device dev = sender as Device;
            vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionNormal), 6, dev, Usage.WriteOnly, CustomVertex.PositionNormal.Format, Pool.Default);
            vertexBuffer.Created += onCreateVertexBuffer;
            this.onCreateVertexBuffer(vertexBuffer, null);
            mtrl = new Material();
            mtrl.Diffuse = Color.Yellow;
            mtrl.Ambient = Color.Red;
        }
        private void onCreateVertexBuffer(object sender, EventArgs e)
        {
            CustomVertex.PositionNormal[] verts = (CustomVertex.PositionNormal[])vertexBuffer.Lock(0, 0);
            verts[0].Position = new Microsoft.DirectX.Vector3(-2, -2, -2);
            verts[0].Normal = new Microsoft.DirectX.Vector3(0, 1, 0);
            verts[1].Position = new Microsoft.DirectX.Vector3(-2, -2, 2);
            verts[1].Normal = new Microsoft.DirectX.Vector3(0, 1, 0);
            verts[2].Position = new Microsoft.DirectX.Vector3(2, -2, 2);
            verts[2].Normal = new Microsoft.DirectX.Vector3(0, 1, 0);
            verts[3].Position = new Microsoft.DirectX.Vector3(-2, -2, -2);
            verts[3].Normal = new Microsoft.DirectX.Vector3(0, 1, 0);
            verts[4].Position = new Microsoft.DirectX.Vector3(2, -2, 2);
            verts[4].Normal = new Microsoft.DirectX.Vector3(0, 1, 0);
            verts[5].Position = new Microsoft.DirectX.Vector3(2, -2, -2);
            verts[5].Normal = new Microsoft.DirectX.Vector3(0, 1, 0);

            vertexBuffer.Unlock();
        }
        private void SetupMatrix()
        {
            device.Transform.World = Matrix.RotationY(0);
            device.Transform.View = Matrix.LookAtLH(new Vector3(0, 30, -5), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4, 1, 1, 100);

        }
        private void SetupLights()
        {
            device.Material = mtrl;
            device.Lights[0].Type = LightType.Point;
            device.Lights[0].Diffuse = Color.White;
            device.Lights[0].Range = 20f;
            device.Lights[0].Position = new Vector3(0, -4, 4);
            device.Lights[0].Attenuation0 = 0.2f;
            device.Lights[0].Update();
            device.Lights[0].Enabled = true;
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
            SetupMatrix();
            device.BeginScene();
            device.SetStreamSource(0, vertexBuffer, 0);
            device.VertexFormat = CustomVertex.PositionNormal.Format;
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);
            device.EndScene();
            device.Present();
        }
    }
}
