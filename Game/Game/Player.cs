namespace Game;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

public class Player
{
    // Fields
    private CircleShape graphic;
    private float speed;
    
    // Properties
    public CircleShape Graphic
    {
        get => this.graphic;
        set => this.graphic = value;
    }

    public Player(Vector2f playerPosition, Color fillColor, Color outlineColor, float outlineThickness, float radius, float speed)
    {
        this.Graphic = new CircleShape(radius);
        this.Graphic.FillColor = fillColor;
        this.Graphic.OutlineColor = outlineColor;
        this.Graphic.OutlineThickness = outlineThickness;
        this.Graphic.Position = playerPosition;
        this.speed = speed;
    }

    public void Update(float deltaTime)
    {
        Vector2f input = new Vector2f(0, 0);

        if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            input.X -= 100f;
        if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            input.X += 100f;
        if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            input.Y -= 100f;
        if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            input.Y += 100f;
        
        Vector2f translation = VectorUtils.Normalize(input) * speed * deltaTime ;
        this.graphic.Position += translation;
    }
}