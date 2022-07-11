using OpenTK.Mathematics;
using OpenTkTemplate.GLBase;
using System;
using System.Collections.Generic;

namespace OpenTkTemplate
{
    public class GameContext
    {
        internal Random r = new Random();
        internal Camera camera;
        internal GameRenderer renderer = new GameRenderer();
        internal GameLogic logic = new GameLogic();
        internal List<Sprite> sprites = new List<Sprite>();
        internal List<Sprite> player = new List<Sprite>();
        internal float rot;
        internal float frametime;
        internal Vector3 playerFace = Vector3.UnitY;

        public GameContext()
        {
            logic.gc = this;
            renderer.gc = this;
        }
    }
}
