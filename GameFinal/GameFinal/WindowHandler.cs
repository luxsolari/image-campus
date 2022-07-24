using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GameFinal;

public class WindowHandler
{
    private RenderWindow window = null!;
    private Vector2u windowSize;
    private string windowTitle;

    private bool isDone;
    private bool isFullScreen;

    public bool IsDone => isDone;
    public bool IsFullscreen => isFullScreen;
    public Vector2u WindowSize => windowSize;

    public WindowHandler()
    {
        this.windowTitle = "Window";
        this.windowSize = new Vector2u(640, 480);
        this.isFullScreen = false;
        this.isDone = false;
        this.Create();
    }

    public WindowHandler(string title, Vector2u size)
    {
        this.windowTitle = title;
        this.windowSize = size;
        this.isFullScreen = false;
        this.isDone = false;
        this.Create();
    }

    private void Create()
    {
        Styles style = (isFullScreen ? Styles.Fullscreen : Styles.Default);
        VideoMode videoMode = new VideoMode(this.windowSize.X, this.windowSize.Y);
        this.window = new RenderWindow(videoMode, this.windowTitle, style);

        this.window.Closed += this.OnWindowClose;
        this.window.Resized += this.OnWindowResize;
    }

    public void StartDraw()
    {
        this.window.Clear(new Color(36, 36, 36));
    }

    public void DispatchEvents()
    {
        this.window.DispatchEvents();
    }
    
    public void Update()
    {
        if (Keyboard.IsKeyPressed(Keyboard.Key.F5))
        {
            this.ToggleFullscreen();
        }
    }

    public void FinishDraw()
    {
        this.window.Display();
    }
    
    public void Draw(Drawable drawable)
    {
        this.window.Draw(drawable);
    }

    ~WindowHandler()
    {
        this.window.Close();
    }

    public void ToggleFullscreen()
    {
        this.isFullScreen = !this.isFullScreen;
        if (this.isFullScreen == true)
        {
            VideoMode videoMode = VideoMode.FullscreenModes[0];
            Console.WriteLine($"Fullscreen mode: {videoMode.Width}x{videoMode.Height}");
            this.windowSize = new Vector2u(videoMode.Width, videoMode.Height);
        }
        else
        {
            this.windowSize = new Vector2u(1280, 720);
        }
        this.window.Close();
        this.Create();
    }    
    private void OnWindowClose(object? sender, EventArgs e)
    {
        this.isDone = true;
        this.window.Close();
    }

    private void OnWindowResize(object? sender, SizeEventArgs e)
    {
        Console.WriteLine("Window has been resized!");
    }
}