using System;
using System.Numerics;

namespace MohawkGame2D;

public class Eyeball
{
    public Color irisColor = new Color(128, 64, 0);
    public Vector2 position = new Vector2(200, 200);
    public float corneaR = 50;
    public float irisR = 30;
    public float pupilR = 15;
    private bool isEyeOpen = true;

    Color[] eyeColors = [
        new Color(128,  64,   0), // brown
        new Color( 64, 128,  64), // green
        new Color( 64, 100, 160), // blue
        ];

    public Eyeball() { }

    public Eyeball(Vector2 position)
    {
        this.position = position;
        this.irisColor = eyeColors[Random.Integer(eyeColors.Length)];
    }

    public Eyeball(float size)
    {
        this.position = Random.Vector2(Window.Size);
        this.irisColor = eyeColors[Random.Integer(eyeColors.Length)];
        corneaR = size;
        irisR = size * 0.7f;
        pupilR = size * 0.35f;
    }

    public bool IsEyeClicked()
    {
        // Was eye closed this frame?
        bool value = false;

        // Only run if we are clicking the mouse button
        if (Input.IsMouseButtonPressed(MouseInput.Left))
        {
            // Compute distance between centre of eye and mouse
            Vector2 mousePosition = Input.GetMousePosition();
            Vector2 fromEyeToMouse = mousePosition - position;
            float distanceEyeToMouse = fromEyeToMouse.Length();
            // Check if mouse is on top of eye (inside circle)
            if (distanceEyeToMouse <= corneaR)
            {
                // Value will be true on first call, then false on all future calls
                value = isEyeOpen;
                isEyeOpen = false;
            }
        }

        return value;
    }

    public void DrawEyeball()
    {
        // General draw config
        Draw.LineColor = Color.Black;
        Draw.LineSize = 1;

        // Draw Cornea
        Draw.FillColor = Color.White;
        Draw.Circle(position, corneaR);

        if (isEyeOpen)
        {
            // Math out vector from eye to mouse
            Vector2 mousePosition = Input.GetMousePosition();
            Vector2 fromEyeToMouse = mousePosition - position;
            float distanceToMouse = fromEyeToMouse.Length();
            Vector2 directionToMouse = Vector2.Normalize(fromEyeToMouse);

            // Calculate where iris an pupil will go
            Vector2 irisPosition;
            if (distanceToMouse < corneaR - irisR)
            {
                // mouse is on top of eye, draw at mouse position
                irisPosition = mousePosition;
            }
            else
            {
                // mouse is outside of eye, draw eye towards mouse
                irisPosition = position + directionToMouse * (corneaR - irisR);
            }

            // Draw Iris
            Draw.FillColor = irisColor;
            Draw.Circle(irisPosition, irisR);

            // Draw Pupil
            Draw.FillColor = Color.Black;
            Draw.Circle(irisPosition, pupilR);
        }
        else // if eye is closed
        {
            Vector2 offset = new Vector2(corneaR, 0);
            Draw.Line(position - offset, position + offset);
        }
    }

}

