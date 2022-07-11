using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace OpenTkTemplate.GLBase.Shaders
{
    public class MainDefaultShader : Shader
    {
        public MainDefaultShader(string vertPath, string fragPath) : base(vertPath, fragPath)
        {
        }
        public void Load()
        {
            Use();

            int vertexLocation = GetAttribLocation("aPosition");
            GL.EnableVertexAttribArray(vertexLocation);
            GL.VertexAttribPointer(vertexLocation, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);

            int texCoordLocation = GetAttribLocation("aTexCoord");
            GL.EnableVertexAttribArray(texCoordLocation);
            GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));



            SetInt("texture0", 0);
        }

        internal void SetCamera(Camera camera)
        {
            SetMatrix4("view", camera.GetViewMatrix());
            SetMatrix4("projection", camera.GetProjectionMatrix());
        }

        internal void SetCameraOrto(Camera camera, Vector3 pos)
        {
            Matrix4.CreateOrthographic(10 * camera.AspectRatio, 10, 0.01f, 100f, out Matrix4 id);

            Matrix4 view = Matrix4.LookAt(new Vector3(pos.X, pos.Y, 5), pos, Vector3.UnitY);

            SetMatrix4("view", view);
            SetMatrix4("projection", id);
        }
        internal void SetCameraOrto(Camera camera, Vector3 pos, float rotZ)
        {
            Matrix4.CreateOrthographic(10 * camera.AspectRatio, 10, 0.01f, 100f, out Matrix4 id);

            Vector3 up = Vector3.UnitY;
            up = Vector3.Transform(up, Quaternion.FromEulerAngles(0, 0, rotZ));
            

            Matrix4 view = Matrix4.LookAt(new Vector3(pos.X, pos.Y, 5), pos, up);

            SetMatrix4("view", view);
            SetMatrix4("projection", id);
        }
        internal void SetCameraOrto(Camera camera, Vector3 pos, Vector3 up)
        {
            Matrix4.CreateOrthographic(10 * camera.AspectRatio, 10, 0.01f, 100f, out Matrix4 id);



            Matrix4 view = Matrix4.LookAt(new Vector3(pos.X, pos.Y, 5), pos, up);

            SetMatrix4("view", view);
            SetMatrix4("projection", id);
        }
        internal void SetModelM(Matrix4 tran)
        {
            SetMatrix4("model", tran);
        }
    }
}

