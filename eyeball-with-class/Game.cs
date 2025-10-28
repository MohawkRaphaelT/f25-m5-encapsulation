using System;
using System.Numerics;

namespace MohawkGame2D;
public class Game
{
    int numberOfEyesClicked;
    float gameTimeWon;
    Eyeball[] eyeballs = [];

    public void Setup()
    {
        // Game window setup
        Window.SetTitle("Eyeball with Class");
        Window.SetSize(400, 400);

        // Game reset / initial state
        numberOfEyesClicked = 0;
        gameTimeWon = 0;
        Time.SecondsElapsed = 0; // reset timer
        eyeballs = [
            new Eyeball(new Vector2(100, 200)),
            new Eyeball(new Vector2(300, 200)),
            new Eyeball(new Vector2(200, 100)),
            ];
    }

    public void Update()
    {
        bool isGameWon = numberOfEyesClicked == eyeballs.Length;
        if (isGameWon)
        {
            GameWinScreen();
        }
        else
        {
            GameClickOnEyes();
        }
    }

    void GameClickOnEyes()
    {
        Window.ClearBackground(Color.OffWhite);
        for (int i = 0; i < eyeballs.Length; i++)
        {
            Eyeball eyeball = eyeballs[i];
            bool isClicked = eyeball.IsEyeClicked();
            eyeball.DrawEyeball();

            // Check if eye is clicked
            if (isClicked)
            {
                numberOfEyesClicked += 1;
                gameTimeWon = Time.SecondsElapsed;
            }
        }
        // Draw current time to screen
        string text = $"{Time.SecondsElapsed:0.000}";
        Text.Color = Color.Black;
        Text.Draw(text, 10, 10);
    }

    void GameWinScreen()
    {
        Window.ClearBackground(Color.Yellow);
        Text.Color = Color.Black;
        string text = $"Winner!\nTime: {gameTimeWon:0.000}";
        float y = Window.Height / 2 - Text.Size;
        Text.Draw(text, 10, y);

        if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
        {
            // Reset game variables
            Setup();
        }
    }
}
