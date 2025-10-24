// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    public class Game
    {
        Eyeball eyeball = new Eyeball();

        public void Setup()
        {
            Window.SetTitle("Eyeball with Class");
            Window.SetSize(400, 400);
        }

        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);
            eyeball.DrawEyeball();
        }
    }

}
