// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:


        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(200, 200); // window size should match grid paper "resolution"
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        float blindsRelativePos = 0; // increments toward 20 then resets to 0 if any higher
        float girlPosX = 100;
        float girlPosY = 100;
        public void Update()
        {
            Window.ClearBackground(Color.Cyan);
            Draw.LineSize = 0;



            // create 11*2 "blinds" that appear to move
            Draw.FillColor = new Color(0, 89, 255); // darker blue
            for (int i = 0; i<11; i++) // draw background blinds going left
            { 
                // lower layer
                Draw.Triangle(i*20-blindsRelativePos, 180, 20+i*20-blindsRelativePos, 180, 10+i*20-blindsRelativePos, 170);
                // upper layer
                Draw.Triangle(i*20-blindsRelativePos, 20, 20+i*20-blindsRelativePos, 20, 10+i*20-blindsRelativePos, 30);
            }
            // create 11*2 more blinds on top of the first
            Draw.FillColor = new Color(0, 175, 255); // lighter blue
            for (int i = -1; i < 10; i++) // draw background blinds going right. starts at -1 as blinds come from the left
            {
                // lower layer
                Draw.Triangle(i*20+blindsRelativePos, 180, 20+i*20+blindsRelativePos, 180, 10+i*20+blindsRelativePos, 170);
                // upper layer
                Draw.Triangle(i*20+blindsRelativePos, 20, 20+i*20+blindsRelativePos, 20, 10+i*20+blindsRelativePos, 30);
            }
            Draw.Rectangle(0, 0, 200, 20); // draw edge of upper blind
            Draw.Rectangle(0, 180, 200, 20); // draw edge of lower blind



            // draw girl at prev position, or randomize a new position if mouse is on her
            float mX = Input.GetMouseX();
            float mY = Input.GetMouseY();
            while (mX > (girlPosX-15) && mX < (girlPosX + 15) && mY > (girlPosY - 40) && mY < (girlPosY + 30))
            {
                girlPosX = Random.Float(50, 150); // random x that keeps the girl wholly on screen
                girlPosY = Random.Float(75, 125); // random y that keeps the girl within the bounds of the blinds
            }
            DrawGirl(girlPosX, girlPosY);



            // increment the position of the blinds, looping cleanly
            blindsRelativePos += 0.35f;
            blindsRelativePos %= 20;
        }

        /// <summary>
        ///     used to draw the pixel girl from the defined centre
        /// </summary>
        public void DrawGirl(float x, float y)
        {
            // draw most hair and sweater
            Draw.FillColor = new Color(0, 175, 255); // lighter blue
            Draw.Rectangle(x - 15, y - 40, 30, 65);
            Draw.Rectangle(x - 25, y - 40, 50, 10); // lower edge of buns
            Draw.Rectangle(x - 20, y - 45, 10, 45); // left bun and bang
            Draw.Rectangle(x + 10, y - 45, 10, 45); // right bun and bang
            Draw.Rectangle(x - 25, y - 20, 50, 10); // outer edge of bangs

            // draw face and sweater stripe
            Draw.FillColor = Color.White;
            Draw.Rectangle(x - 15, y - 30, 30, 25); // face
            Draw.Rectangle(x, y, 5, 15); // upper sweater stripe
            Draw.Rectangle(x + 5, y + 15, 5, 10); // lower sweater stripe

            // draw sweater outline, legs and eyes
            Draw.FillColor = Color.Black;
            Draw.Rectangle(x - 10, y - 5, 20, 5); // sweater outline
            Draw.Rectangle(x - 15, y - 10, 5, 25);
            Draw.Rectangle(x + 10, y - 10, 5, 25);
            Draw.Rectangle(x - 20, y + 15, 5, 15);
            Draw.Rectangle(x + 15, y + 15, 5, 15);
            Draw.Rectangle(x - 15, y + 25, 30, 5);
            Draw.Rectangle(x - 10, y + 30, 5, 10); // legs
            Draw.Rectangle(x - 15, y + 40, 10, 5);
            Draw.Rectangle(x + 5, y + 30, 5, 10);
            Draw.Rectangle(x + 5, y + 40, 10, 5);
            Draw.Rectangle(x - 10, y - 25, 5, 10); // eyes
            Draw.Rectangle(x + 5, y - 25, 5, 10);

            // complete hair
            Draw.FillColor = new Color(0, 175, 255); // lighter blue
            Draw.Rectangle(x - 15, y - 30, 5, 5);
            Draw.Rectangle(x - 5, y - 30, 10, 5);
            Draw.Rectangle(x + 10, y - 30, 5, 5);
        }
    }

}
