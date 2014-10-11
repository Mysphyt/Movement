using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movement
{
    static class GraphicsManager
    {
        // Create the Dictionary
        static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();


        public static void AddTexture(string myKey /* "default" */, Texture2D myTexture /* Key-Value pair */)
        {
            textures[myKey] = myTexture;
        }
        public static Texture2D GetTexture(string myKey)
        {
            // If the Dictionary contains the key
            if (DoesContainTexture(myKey))
                // Return the texture
                return textures[myKey];

            else
                // Return the default 'error' texture
                return textures["Derek"];
        }
        public static Boolean DoesContainTexture(string myKey)
        {
            return textures.ContainsKey(myKey);
        }
    }
}