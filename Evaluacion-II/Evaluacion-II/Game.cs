namespace Evaluacion_II;

public class Game
{
    public bool IsRunning = true;
    private int counter;

    private void Start()
    {
        
    }

    private void Update()
    {
       
    }

    private void Finish()
    {
        
    }
    public void Play()
    {
        Start();
        while (IsRunning)
        {
            Update();
        }
        Finish();
    }

}