namespace Application;

public class BowlingGame
{
    public int Score { get; set; } = 0;
    public List<Frame> Frames = new List<Frame>();
    public BowlingGame()
    {

    }

    public void MakeFrame(int firstThrowValue, int? secondThrowValue, int? thirdThrowValue = null)
    {
        Frame frame = new Frame();

        frame.FirstThrow = firstThrowValue;
        frame.SecondThrow = secondThrowValue;

        Score += firstThrowValue + (secondThrowValue ?? 0);

        if (IsLastFrame())
        {
            Score += firstThrowValue + (secondThrowValue ?? 0) + (thirdThrowValue ?? 0);
        }

        if (LastFrameIsSpare())
        {
            Score += firstThrowValue;
        }

        else if (LastFrameIsStrike())
        {
            Score += firstThrowValue;
            Score += secondThrowValue ?? 0;
        }

        Frames.Add(frame);
    }

    private bool LastFrameIsSpare()
    {
        Frame? frameToCheck = Frames.Where(f => f != null).LastOrDefault();

        if (frameToCheck == null)
        {
            return false;
        }

        if (frameToCheck.FirstThrow + frameToCheck.SecondThrow == 10
            && frameToCheck.FirstThrow != 10)
        {
            return true;
        }

        return false;
    }

    private bool LastFrameIsStrike()
    {
        Frame? frameToCheck = Frames.Where(f => f != null).LastOrDefault();

        if (frameToCheck == null)
        {
            return false;
        }

        if (frameToCheck.FirstThrow == 10)
        {
            return true;
        }

        return false;
    }

    private bool IsLastFrame()
    {
        int frameCount = Frames.Where(f => f != null).Count();

        return frameCount == 9;
    }


}
