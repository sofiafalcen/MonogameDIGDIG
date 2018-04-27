using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameDIGDIG
{
    static class TextureLibrary
    {
        static Dictionary<string, Texture2D> myTextures;
        static ContentManager Content;

        static public void Init(ContentManager someContent)
        {
            myTextures = new Dictionary<string, Texture2D>();
            Content = someContent;
        }

        static public void LoadTexture(string aTextureName)
        {
            myTextures.Add(aTextureName, Content.Load<Texture2D>(aTextureName));
        }

        static public Texture2D GetTexture(string aTextureName)
        {
            return myTextures[aTextureName];
        }
    }
}
