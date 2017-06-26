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
    public partial class F0601 : Form
    {
        VertexBuffer vertexBuffer1 = null;
        Texture texture = null;
        private Device device;
        private bool pause;
        public F0601 ()
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
            SetupMatrix();
        }
        public void OnCreateDevice(object sender, EventArgs e)
        {
            Device dev = sender as Device;
            vertexBuffer1 = new VertexBuffer(typeof(CustomVertex.PositionTextured), 6, dev, 0, CustomVertex.PositionTextured.Format, Pool.Default);
            vertexBuffer1.Created += onCreateVertexBuffer;
            this.onCreateVertexBuffer(vertexBuffer1, null);
            texture = TextureLoader.FromFile(dev, ".\\Resources\\p1.jpg");
        }
        private void onCreateVertexBuffer(object sender ,EventArgs e)
        {
            CustomVertex.PositionTextured[] verts = (CustomVertex.PositionTextured[])vertexBuffer1.Lock(0, 0);
            verts[0].Position = new Microsoft.DirectX.Vector3(-2, -2, 2);
            verts[0].Tu = 0;
            verts[0].Tv = 1f;
            verts[1].Position = new Microsoft.DirectX.Vector3(-2, 2, 2);
            verts[1].Tu = 0;
            verts[1].Tv = 0;
            verts[2].Position = new Microsoft.DirectX.Vector3(2, 2, 2);
            verts[2].Tu = 1;
            verts[2].Tv = 0;
            verts[3].Position = new Microsoft.DirectX.Vector3(-2, -2, 2);
            verts[3].Tu = 0;
            verts[3].Tv = 1;
            verts[4].Position = new Microsoft.DirectX.Vector3(2, 2, 2);
            verts[4].Tu = 1;
            verts[4].Tv = 0;
            verts[5].Position = new Microsoft.DirectX.Vector3(2, -2, 2);
            verts[5].Tu = 1;
            verts[5].Tv = 1;
            vertexBuffer1.Unlock();
        }
        private void SetupMatrix()
        {
            device.Transform.World = Matrix.RotationY(0);
            device.Transform.View = Matrix.LookAtLH(new Vector3(0, 0, -4), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
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
            device.BeginScene();
            device.SetTexture(0, texture);
            device.SetStreamSource(0, vertexBuffer1, 0);
            device.VertexFormat = CustomVertex.PositionTextured.Format;
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);

            device.EndScene();
            device.Present();
        }
    }
}
