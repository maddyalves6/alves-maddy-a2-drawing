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
        int blindsRelativePos = 0; // increments toward 20 then resets to 0 if any higher
        int [] girlPos = {100, 100}; // where [0] is X and [1] is Y
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);
            Draw.LineSize = 0;

            // create 11*4 "blinds" that appear to move
            Draw.FillColor = new Color(0, 89, 255); // darker blue
            for (int i = 0; i<11; i++) // draw background blinds going left
            { 
                // lower layer
                Draw.Triangle(i*20-blindsRelativePos, 180, 20+i*20-blindsRelativePos, 180, 10+i*20-blindsRelativePos, 170);
                // upper layer
                Draw.Triangle(i*20-blindsRelativePos, 20, 20+i*20-blindsRelativePos, 20, 10+i*20-blindsRelativePos, 30);
            }
        }
    }

}
