using SFML.Graphics;
using SFML.System;

namespace GameFinal.Entities;

public class Snake
{
    private List<SnakeSegment> snakeBody;
    private int blockSize;
    private Direction direction;
    private int speed;
    private int lives;
    private int score;
    private bool hasLost;
    private RectangleShape bodyRect;
    private Vector2i snakeStartPos;
    
    public Snake(int blockSize, Vector2u windowSize)
    {
        this.snakeBody = new List<SnakeSegment>();
        this.blockSize = blockSize;
        this.bodyRect = new RectangleShape(new Vector2f(blockSize - 1f, blockSize - 1f));
        
        this.snakeBody.Clear();
        Random random = new Random();
        int maxX = (int)((windowSize.X / this.blockSize) - 2);
        int maxY = (int)((windowSize.Y / this.blockSize) - 2);
        this.snakeStartPos = new Vector2i((int)(random.Next() % maxX), (int)(random.Next() % maxY + 1));
        
        this.snakeBody.Add(new SnakeSegment(0,snakeStartPos.X, 3));
        this.snakeBody.Add(new SnakeSegment(1,snakeStartPos.X, 2));
        this.snakeBody.Add(new SnakeSegment(2,snakeStartPos.X, 1));
        
        this.SetDirection(Direction.None);
        this.speed = 5;
        this.lives = 3;
        this.score = 0;
        this.hasLost = false;
    }
    
    public void SetDirection(Direction dir)
    {
        this.direction = dir;
    }

    public Direction getDirection()
    {
        return this.direction;
    }

    public int GetSpeed()
    {
        return this.speed;
    }

    public Vector2i GetPosition()
    {
        return (snakeBody.Count > 0 ? this.snakeBody[0].position : new Vector2i(1, 1));
    }
    
    public void SetPosition(Vector2i newPos)
    {
        this.snakeBody[0].position = newPos;
    }

    public int GetLives()
    {
        return this.lives;
    }

    public int GetScore()
    {
        return this.score;
    }

    public List<SnakeSegment> GetSnakeBody()
    {
        return this.snakeBody;
    }

    public void IncreaseScore()
    {
        this.score += 10 * this.speed;
    }

    public void IncreaseSpeed()
    {
        this.speed ++;
    }

    public bool HasLost()
    {
        return this.hasLost;
    }

    public void Lose()
    {
        this.hasLost = true;
        Console.WriteLine("Game Over!");
    }

    public void ToggleLost()
    {
        this.hasLost = !this.hasLost;
    }

    public void Extend()
    {
        if (this.snakeBody.Count == 0) return;
        SnakeSegment tail_head = this.snakeBody[this.snakeBody.Count - 1];

        if (this.snakeBody.Count > 1)
        {
            SnakeSegment tail_bone = this.snakeBody[this.snakeBody.Count - 2];

            if (tail_head.position.X == tail_bone.position.X)
            {
                if (tail_head.position.Y > tail_bone.position.Y)
                {
                    this.snakeBody.Add(new SnakeSegment(this.snakeBody.Count, tail_head.position.X, tail_head.position.Y + 1));
                }
                else
                {
                    this.snakeBody.Add(new SnakeSegment(this.snakeBody.Count, tail_head.position.X, tail_head.position.Y - 1));
                }
            }
            else if (tail_head.position.Y == tail_bone.position.Y)
            {
                if (tail_head.position.X > tail_bone.position.X)
                {
                    this.snakeBody.Add(new SnakeSegment(this.snakeBody.Count,tail_head.position.X + 1, tail_head.position.Y));
                }
                else
                {
                    this.snakeBody.Add(new SnakeSegment(this.snakeBody.Count,tail_head.position.X - 1, tail_head.position.Y));
                }
            }
        }
        else
        {
            if (this.direction == Direction.Up)
            {
                this.snakeBody.Add(new SnakeSegment(this.snakeBody.Count, tail_head.position.X, tail_head.position.Y + 1));
            }
            else if (this.direction == Direction.Down)
            {
                this.snakeBody.Add(new SnakeSegment(this.snakeBody.Count, tail_head.position.X, tail_head.position.Y - 1));
            }
            else if (this.direction == Direction.Left)
            {
                this.snakeBody.Add(new SnakeSegment(this.snakeBody.Count,tail_head.position.X + 1, tail_head.position.Y));
            }
            else if (this.direction == Direction.Right)
            {
                this.snakeBody.Add(new SnakeSegment(this.snakeBody.Count,tail_head.position.X - 1, tail_head.position.Y));
            }
        }
    }

    public Direction GetPhysicalDirection()
    {
        if (this.snakeBody.Count <= 1)
        {
            return Direction.None;
        }

        SnakeSegment head = this.snakeBody[0];
        SnakeSegment neck = this.snakeBody[1];

        if (head.position.X == neck.position.X)
        {
            return (head.position.Y > neck.position.Y ? Direction.Down : Direction.Up);
        }
        else if (head.position.Y == neck.position.Y)
        {
            return (head.position.X > neck.position.X ? Direction.Right : Direction.Left);
        }

        return Direction.None;
    }
    
    public void Reset()
    {
        this.snakeBody.Clear();
        this.snakeBody.Add(new SnakeSegment(0,snakeStartPos.X + 1, 3));
        this.snakeBody.Add(new SnakeSegment(1,snakeStartPos.X + 1, 2));
        this.snakeBody.Add(new SnakeSegment(2,snakeStartPos.X + 1, 1));
        this.SetDirection(Direction.None);
        this.speed = 5;
        this.score = 0;
        -- this.lives;
    }

    public void Move()
    {
        for (int i = this.snakeBody.Count - 1; i > 0; --i)
        {
            this.snakeBody[i].position = this.snakeBody[i - 1].position;
        }
        if (this.direction == Direction.Left)
        {
            -- this.snakeBody[0].position.X;
        }
        else if (this.direction == Direction.Right)
        {
            ++ this.snakeBody[0].position.X;
        }
        else if (this.direction == Direction.Up)
        {
            -- this.snakeBody[0].position.Y;
        }
        else if (this.direction == Direction.Down)
        {
            ++ this.snakeBody[0].position.Y;
        }
    }

    public void Tick()
    {
        if (this.snakeBody.Count == 0) return;
        if (this.direction == Direction.None) return;
        this.Move();
        this.CheckCollision();
    }

    public void Cut(int segments, int cutIndex)
    {
        this.snakeBody.RemoveAll(segment => segment.index >= cutIndex);
        --this.lives;
        this.speed = Math.Clamp(this.speed / 2, 5, int.MaxValue) ;
        Console.WriteLine("You lost a life!");
        Console.WriteLine($"Lives: {this.GetLives()} Score: {this.GetScore()} Speed: {this.GetSpeed()} Length: {this.snakeBody.Count}");
        if (this.lives == 0)
        {
            this.Lose();
            return;
        }
    }

    public void Render(RenderWindow window)
    {
        if (this.snakeBody.Count == 0) return;

        SnakeSegment head = this.snakeBody[0];
        this.bodyRect.FillColor = Color.Yellow;
        this.bodyRect.Position = new Vector2f(head.position.X * this.blockSize, head.position.Y * blockSize);
        window.Draw(this.bodyRect);
        
        this.bodyRect.FillColor = Color.Green;
        for (int i = 1; i < snakeBody.Count; ++i)
        {
            SnakeSegment segment = this.snakeBody[i];
            this.bodyRect.Position = new Vector2f(segment.position.X * this.blockSize, segment.position.Y * blockSize);
            window.Draw(this.bodyRect);
        }
    }

    private void CheckCollision()
    {
        if (this.snakeBody.Count < 5) return;
        SnakeSegment head = this.snakeBody[0];
        for (int i = 1; i < this.snakeBody.Count; ++i)
        {
            SnakeSegment segment = this.snakeBody[i];
            if (segment.position == head.position)
            {
                int segments = this.snakeBody.Count - segment.index;
                this.Cut(segments, segment.index - 1);
                break;
            }
        }

    }

}