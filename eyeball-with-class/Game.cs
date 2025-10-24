// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D;

public class Game
{
    Eyeball[] eyeballs = [
        new Eyeball(new Vector2(100, 200)),
        new Eyeball(new Vector2(300, 200)),
        new Eyeball(new Vector2(200, 100)),
        ];

    public void Setup()
    {
        Window.SetTitle("Eyeball with Class");
        Window.SetSize(400, 400);
    }

    public void Update()
    {
        Window.ClearBackground(Color.OffWhite);
        for (int i = 0; i < eyeballs.Length; i++)
        {
            Eyeball eyeball = eyeballs[i];
            eyeball.DrawEyeball();
        }
    }
}
