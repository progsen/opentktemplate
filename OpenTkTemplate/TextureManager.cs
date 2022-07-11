using OpenTK.Graphics.OpenGL4;
using OpenTkTemplate.GLBase;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace OpenTkTemplate
{
    public class TextureManager
    {
        readonly Dictionary<string, GlTextureImage> map = new Dictionary<string, GlTextureImage>();
        readonly Dictionary<string, SpriteTexture> uvmap = new Dictionary<string, SpriteTexture>();


        GlTextureImage current;

        public void AddSpriteSheetTexture(string textureFile, string sprite, int[] pixelRect)
        {

            FileInfo file = new FileInfo(textureFile);
            GlTextureImage texture;
            if (map.TryGetValue(file.Name, out texture) == false)
            {
                texture = GlTextureImage.LoadFromFile(file.FullName);
                map.Add(file.Name, texture);
            }

            float x = (pixelRect[0] / (float)texture.width);
            float y = (pixelRect[1] / (float)texture.height);
            float x2 =  ((pixelRect[0] + pixelRect[2]) / (float)texture.width);
            float y2 =  ((pixelRect[1] + pixelRect[3]) / (float)texture.height);

            //0.5f,  0.5f, 0.0f,1.0f, 1.0f, // top right,x,y,z,u,v
            /*   0.5f, -0.5f, 0.0f,1.0f, 0.0f, // bottom right,x,y,z*/
            /*  -0.5f, -0.5f, 0.0f,0.0f, 0.0f, // bottom left,x,y,z,*/
            //-0.5f,  0.5f, 0.0f,0.0f, 1.0f  // top left,x,y,z,u,v

            Debug.WriteLine(x + " " + y + " " + x2 + " " + y2);
            uvmap.Add(sprite, new SpriteTexture()
            {
                name = sprite,
                textureImage = texture,
                uv = new float[] {
                    x2,                    y, // top right,
                    x2,                    y2, // bottom right,
                    x,                    y2, // bottom left,
                    x,                    y  // top left,
                }
            });
        }
        public void AddTexture(string textureFile)
        {
            FileInfo file = new FileInfo(textureFile);
            GlTextureImage texture = GlTextureImage.LoadFromFile(file.FullName);
            //texture.Use(TextureUnit.Texture0);
            map.Add(file.Name, texture);

            uvmap.Add(file.Name, new SpriteTexture()
            {
                name = textureFile,
                textureImage = texture,
                uv = new float[] {
                    1.0f,                    1.0f, // top right,
                    1.0f,                    0.0f, // bottom right,
                    0.0f,                    0.0f, // bottom left,
                    0.0f,                    1.0f  // top left,
                }
            });
        }

        internal SpriteTexture GetTexture(string v)
        {
            return uvmap[v];
        }

        internal void Use(GlTextureImage texture)
        {
            if (texture != current)
            {
                current = texture;
                texture.Use(TextureUnit.Texture0);
            }
        }
    }
}
