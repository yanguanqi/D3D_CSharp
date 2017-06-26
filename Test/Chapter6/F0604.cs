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

namespace Test.Chapter6
{
    public partial class F0604 : Form
    {
        VertexBuffer vertexBuffer = null;
        Material mtrl;
        Texture texture = null;
        float Angle = 0, ViewZ = -6f;
        private Device device;
        private bool pause;
        public F0604()
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
        public void OnCreateDevice(object sender, EventArgs e)
        {
            Device dev = sender as Device;
            vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionNormalTextured), 6, dev, 0, CustomVertex.PositionNormalTextured.Format, Pool.Default);
            vertexBuffer.Created += onCreateVertexBuffer;
            this.onCreateVertexBuffer(vertexBuffer, null);
            mtrl = new Material();
            mtrl.Diffuse = Color.Yellow;
            mtrl.Ambient = Color.Red;
            texture = TextureLoader.FromFile(dev, ".\\Resources\\p1.jpg");
        }
        private void onCreateVertexBuffer(object sender,EventArgs e)
        {
            CustomVertex.PositionNormalTextured[] verts = (CustomVertex.PositionNormalTextured[])vertexBuffer.Lock(0, 0);
            verts[0].Position = new Microsoft.DirectX.Vector3(-1, -1, 0);
            verts[0].Normal = new Microsoft.DirectX.Vector3(0, 0, -1);
            verts[0].Tu = 0f;
            verts[0].Tv = 1f;

            verts[1].Position = new Microsoft.DirectX.Vector3(-1, 1, 0);
            verts[1].Normal = new Microsoft.DirectX.Vector3(0, 0, -1);
            verts[1].Tu = 0f;
            verts[1].Tv = 0f;

            verts[2].Position = new Microsoft.DirectX.Vector3(1, 1, 0);
            verts[2].Normal = new Microsoft.DirectX.Vector3(0, 0, -1);
            verts[2].Tu = 1f;
            verts[2].Tv = 0f;

            verts[3].Position = new Microsoft.DirectX.Vector3(-1, -1, 0);
            verts[3].Normal = new Microsoft.DirectX.Vector3(0, 0, -1);
            verts[3].Tu = 0f;
            verts[3].Tv = 1f;
        
            verts[4].Position = new Microsoft.DirectX.Vector3(1, 1, 0);
            verts[4].Normal = new Microsoft.DirectX.Vector3(0, 0, -1);
            verts[4].Tu = 1f;
            verts[4].Tv = 0f;

            verts[5].Position = new Microsoft.DirectX.Vector3(1, -1, 0);
            verts[5].Normal = new Microsoft.DirectX.Vector3(0, 0, -1);
            verts[5].Tu = 1f;
            verts[5].Tv = 1f;

            vertexBuffer.Unlock();
        }
        private void SetupMatrix()
        {
            device.Transform.World = Matrix.RotationY(0);
            Vector3 v1 = new Vector3(0, 0, -5);
            v1.TransformCoordinate(Matrix.RotationYawPitchRoll(Angle, ViewZ, 0));
            device.Transform.View = Matrix.LookAtLH(v1, new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4, 1, 1,100);
        }
        private void SetupLights()
        {

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
