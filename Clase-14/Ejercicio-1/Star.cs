using System;

public class Star
{
    public static int miNumerito = 42;
	private int posX;
	private int posY;
    
    // Constructor
	public Star(int posX, int posY)
    {
        this.posX = posX;
        this.posY = posY;
    }

    public int GetPosX()
    {
        return this.posX;
    }
    public int GetPosY()
    {
        return this.posY;
    }

}
