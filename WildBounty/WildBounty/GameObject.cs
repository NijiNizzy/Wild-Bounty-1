﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*
 * Authors: Alex Pierce, Dezmon Gilbert, Niko Bazos
 * Purpose: game object class
 * Date: 3/2/2016
 */
namespace WildBounty
{
    public class GameObject
    {
        // attributes
        private Texture2D image;
        private Rectangle rect;
        private int health; 

        // properties
        public Texture2D Image
        {
            get { return image; }
            set { image = value; }
        }

        public Rectangle Rect
        {
            get { return rect; }
            set { rect = value; }
        }

        // Not sure if needed
        /*
        public int xRec
        {
            set { rect.X = value; }
            get { return rect.X; }
        }

        public int yRec
        {
            set { rect.Y = value; }
            get { return rect.Y; }
        }
        **/

        // All gameobjects will have a health including obstacles
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        // parameterized constructor to set Rectangles attribute
        public GameObject(Texture2D img, int x, int y, int wth, int hght)
        {
            image = img;
            rect = new Rectangle(x, y, wth, hght);
        }
    }
}
