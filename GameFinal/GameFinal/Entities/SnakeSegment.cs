using SFML.System;

namespace GameFinal.Entities;

public class SnakeSegment
{
    public Vector2i position;
    public int index;
        
    public SnakeSegment(int index, int x, int y)
    {
        this.index = index;
        this.position.X = x;
        this.position.Y = y;
    }
}