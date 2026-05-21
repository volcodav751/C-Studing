namespace PractiseWork6;

public class Counter
{
    private readonly object locker = new object();

    private int value;
    private bool isPaused;
    private bool isRunning = true;
    private ConsoleColor currentColor = ConsoleColor.White;

    public int Value
    {
        get
        {
            lock (locker)
            {
                return value;
            }
        }
    }

    public bool IsPaused
    {
        get
        {
            lock (locker)
            {
                return isPaused;
            }
        }
    }

    public bool IsRunning
    {
        get
        {
            lock (locker)
            {
                return isRunning;
            }
        }
    }

    public ConsoleColor CurrentColor
    {
        get
        {
            lock (locker)
            {
                return currentColor;
            }
        }
    }

    public void Increase()
    {
        lock (locker)
        {
            value++;
        }
    }

    public void Reset()
    {
        lock (locker)
        {
            value = 0;
        }
    }

    public void TogglePause()
    {
        lock (locker)
        {
            isPaused = !isPaused;
        }
    }

    public void ChangeColor()
    {
        lock (locker)
        {
            if (currentColor == ConsoleColor.White)
                currentColor = ConsoleColor.Green;
            else if (currentColor == ConsoleColor.Green)
                currentColor = ConsoleColor.Yellow;
            else if (currentColor == ConsoleColor.Yellow)
                currentColor = ConsoleColor.Cyan;
            else
                currentColor = ConsoleColor.White;
        }
    }

    public void Stop()
    {
        lock (locker)
        {
            isRunning = false;
        }
    }
}