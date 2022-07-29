using SFML.Graphics;
using SFML.System;

namespace GameFinal.Entities;

public class World
{
    private Vector2u windowSize;
    private Vector2i item;
    private int blockSize;

    private CircleShape appleShape;
    private RectangleShape[] bounds;
    
    public World(Vector2u windSize, int blockSize)
    {
        this.bounds = new RectangleShape[4];
        this.blockSize = blockSize;
        this.windowSize = windSize;
        this.RespawnApple();

        this.appleShape = new CircleShape(this.blockSize / 2f);
        this.appleShape.FillColor = Color.Red;
        this.appleShape.Position = new Vector2f(item.X * blockSize, item.Y * blockSize);

        for (int i = 0; i < 4; ++i)
        {
            this.bounds[i] = new RectangleShape();
            this.bounds[i].FillColor = new Color(150, 0, 0);
            if ((i + 1) % 2 != 0)
            {
                this.bounds[i].Size = new Vector2f(this.windowSize.X, this.blockSize);
            }
            else
            {
                this.bounds[i].Size = new Vector2f(this.blockSize, this.windowSize.Y);
            }

            if (i < 2)
            {
                this.bounds[i].Position = new Vector2f(0, 0);
            }
            else
            {
                this.bounds[i].Origin = this.bounds[i].Size;
                this.bounds[i].Position = (Vector2f) this.windowSize;
            }
        }
        
    }

    public int GetBlocksSize()
    {
        return this.blockSize;
    }

    public void RespawnApple()
    {
        int maxX = (int)((this.windowSize.X / this.blockSize) - 2);
        int maxY = (int)((this.windowSize.Y / this.blockSize) - 2);

        Random random = new Random();
        this.appleShape = new CircleShape(this.blockSize / 2f);
        this.appleShape.FillColor = Color.Red;
        this.item = new Vector2i(random.Next() % maxX + 1, random.Next() % maxY + 1);
        this.appleShape.Position = new Vector2f(item.X * blockSize, item.Y * blockSize);
    }

    public void Update(ref Snake player)
    {
        if (player.GetPosition() == item)
        {
            player.Extend();
            player.Extend();
            player.Extend();
            player.IncreaseScore();
            player.IncreaseSpeed();
            Console.WriteLine($"Lives: {player.GetLives()} Score: {player.GetScore()} Speed: {player.GetSpeed()}  Length: {player.GetSnakeBody().Count}");
            this.RespawnApple();
        }

        int gridSizeX = (int)(this.windowSize.X / this.blockSize);
        int gridSizeY = (int)(this.windowSize.Y / this.blockSize);

        if (player.GetPosition().X <= 0)
        {
            player.SetPosition(new Vector2i(gridSizeX - 2, player.GetPosition().Y));
        }
        else if (player.GetPosition().X >= gridSizeX - 1)
        {
            player.SetPosition(new Vector2i(1, player.GetPosition().Y));
        }
        else if (player.GetPosition().Y <= 0)
        {
            player.SetPosition(new Vector2i( player.GetPosition().X, gridSizeY - 2));
        }
        else if (player.GetPosition().Y >= gridSizeY - 1)
        {
            player.SetPosition(new Vector2i(player.GetPosition().X, 1));
        }
    }

    public Vector2u GetWindowSize()
    {
        return this.windowSize;
    }
    public void Render(RenderWindow window)
    {
        for (int i = 0; i < 4; ++ i)
        {
            window.Draw(this.bounds[i]);
        }
        window.Draw(this.appleShape);
    }

    ~World()
    {
        
    }
}