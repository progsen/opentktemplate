using OpenTK.Graphics.OpenGL4;

namespace OpenTkTemplate.GLBase
{
    public class Plane
    {
        private readonly float[] _vertices =
         {
            // Position Texture coordinates
             0.5f,  0.5f, 0.0f,1.0f, 1.0f, // top right,x,y,z,u,v
             0.5f, -0.5f, 0.0f,1.0f, 0.0f, // bottom right,x,y,z,u,v
            -0.5f, -0.5f, 0.0f,0.0f, 0.0f, // bottom left,x,y,z,u,v
            -0.5f,  0.5f, 0.0f,0.0f, 1.0f  // top left,x,y,z,u,v
        };
        private readonly float[] uv =
        {
            // Position Texture coordinates
            1.0f, 1.0f, // top right,x,y,z,u,v
            1.0f, 0.0f, // bottom right,x,y,z,u,v
            0.0f, 0.0f, // bottom left,x,y,z,u,v
            0.0f, 1.0f  // top left,x,y,z,u,v
        };
        private readonly uint[] _indices =
        {
            0, 1, 3,
            1, 2, 3
        };

        private int elementBufferObject;

        private int vertexBufferObject;

        private int vertexArrayObject;

        public void Load()
        {


            vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(vertexArrayObject);

            vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

            SetUv(uv);
            GL.BindVertexArray(vertexArrayObject);
            elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);
        }

        internal void SetUv(float[] uv)
        {
            if (uv.Length != this.uv.Length)
            {
                throw new System.Exception("uv length wrong");
            }
            for (int i = 0, uvi = 0; i < _vertices.Length; i += 5, uvi += 2)
            {
                _vertices[i + 3] = uv[uvi];
                _vertices[i + 4] = uv[uvi + 1];
            }

            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);
        }

        internal void Bind()
        {
            GL.BindVertexArray(vertexArrayObject);
        }

        internal void Renderer()
        {
            GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
        }
    }
}

