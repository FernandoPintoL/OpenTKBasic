using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace OpenTKBasic
{
    public class Game : GameWindow
    {
        private int vertexBufferHandle;
        public Game() : base(GameWindowSettings.Default, NativeWindowSettings.Default) {
            //this.CenterWindow(new Vector2i(800, 768));
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            //GL.Viewport(0, 0, e.Width, e.Height);
            GL.Viewport(0, 0, Size.X, Size.Y);
            base.OnResize(e);
        }
        float[] vertices = new float[]
            {
                0.0f, 0.5f, 0f,
                0.5f, -0.5f, 0f,
                -0.5f, -0.5f, 0f,
            };
        int vao;
        int vbo;
        protected override void OnLoad()
        {
            GL.ClearColor(new Color4(0.3f, 0.4f, 0.5f, 1f));
            vao = GL.GenVertexArray();
            GL.BindVertexArray(vao);
            GL.GenBuffer();
            vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(
                BufferTarget.ArrayBuffer,
                vertices.Length * sizeof(float),
                vertices.ToArray(),
                BufferUsageHint.StaticDraw);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, true, 0, 0);
            /*
            float[] vertices = new float[]
            {
                0.0f, 0.5f, 0f,
                0.5f, -0.5f, 0f,
                -0.5f, -0.5f, 0f,
            };
            this.vertexBufferHandle = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, this.vertexBufferHandle);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            String vertexShaderCode = "";*/
            base.OnLoad();
        }

        protected override void OnUnload()
        {
            base.OnUnload();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.BindVertexArray(vao);
            GL.DrawArrays(BeginMode.Triangles, 0, vertices.Length);
            this.Context.SwapBuffers();
            base.OnRenderFrame(args);
        }

    }
}
