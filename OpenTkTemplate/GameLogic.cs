using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;

namespace OpenTkTemplate
{
    public class GameLogic
    {
        internal GameContext gc;
        internal void Logic(KeyboardState input)
        {
            //foreach (Sprite item in gc.sprites)
            //{
            //    if (input.IsAnyKeyDown)
            //    {

            //        item.pos.X += ((float)gc.r.Next(0, 100)) / 1000000.0f;
            //        item.pos.Y += ((float)gc.r.Next(0, 100)) / 1000000.0f;
            //        item.pos.Z += ((float)gc.r.Next(0, 100)) / 1000000.0f;
            //    }
            //}

            if (input.IsKeyDown(Keys.Up))
            {
                //gc.camera.Position = new Vector3(0, 0, 0);
                //gc.camera.Yaw += 0.001f;
                //gc.camera.Pitch += 0.001f;
                //gc.player[0].pos.Y += 0.001f;

                gc.player[0].pos += gc.playerFace * 0.001f;
                //gc.camera.Front = gc.camera.Front + new Vector3(0.0001f, 0, 0);
            }
            else if (input.IsKeyDown(Keys.Down))
            {
                //gc.camera.Yaw -= 0.001f;
                //gc.player[0].pos.Y -= 0.001f;
                //gc.camera.Pitch -= 0.001f;
                //gc.rot += 0.001f * gc.frametime;


                gc.player[0].pos -= gc.playerFace* 0.001f;

            }
            if (input.IsKeyDown(Keys.Right))
            {
                //gc.camera.Position = new Vector3(0, 0, 0);
                //gc.camera.Yaw += 0.001f;
                //gc.camera.Pitch += 0.001f;
                //gc.player[0].pos.X += 0.001f;
                // gc.player[0].rotZ += 0.001f;
                gc.rot += 1.0f * gc.frametime;
                gc.player[0].rotZ = gc.rot;

                gc.playerFace = Vector3.Transform(Vector3.UnitY, Quaternion.FromEulerAngles(0, 0, gc.rot));
                gc.playerFace.Normalize();
                //gc.camera.Front = gc.camera.Front + new Vector3(0.0001f, 0, 0);
            }
            else if (input.IsKeyDown(Keys.Left))
            {
                //gc.camera.Yaw -= 0.001f;
                gc.playerFace = Vector3.Transform(Vector3.UnitY, Quaternion.FromEulerAngles(0, 0, gc.rot));
                gc.playerFace.Normalize();
                //gc.player[0].pos.X -= 0.001f;
                //gc.player[0].rotZ -= 1;
                gc.rot -= 1.0f * gc.frametime;
                gc.player[0].rotZ = gc.rot;
                //gc.camera.Pitch -= 0.001f;

            }
        }

        internal void Load()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int i2 = 0; i2 < 10; i2++)
                {
                    gc.sprites.Add(new Sprite()
                    {
                        texture = gc.renderer.textureManager.GetTexture("floor"),
                        pos = new Vector3(i2, i, 0)
                    });
                }
            }
            gc.player.Add(new Sprite()
            {
                texture = gc.renderer.textureManager.GetTexture("wall"),
                pos = new Vector3(0, 0, 0)
            });
        }
    }
}
