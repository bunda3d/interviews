namespace UnitTests;

using Application;

public class BowlingGameTests
{
    [Fact]
    public void CanInstantiateGame()
    {
        //Arrange & Act
        BowlingGame game = new BowlingGame();

        Assert.NotNull(game);
    }

    [Fact]
    public void GameHasScore()
    {
        BowlingGame game = new BowlingGame();

        Assert.Equal(0, game.Score);
    }

    // [Fact]
    // public void GameHasFrames()
    // {
    //     BowlingGame game = new BowlingGame();

    //     Assert.NotNull(game.Frames);
    //     Assert.Equal(10, game.Frames.Count);
    // }

    [Fact]
    public void CanReadInput()
    {
        BowlingGame game = new BowlingGame();

        int firstThrowValue = 7;
        game.MakeFrame(firstThrowValue, 0);

        Assert.Equal(firstThrowValue, game.Frames[0].FirstThrow);
    }

    [Fact]
    public void CanSetSecondThrow()
    {
        BowlingGame game = new BowlingGame();

        int firstThrowValue = 1;
        int secondThrowValue = 8;

        game.MakeFrame(firstThrowValue, secondThrowValue);

        Assert.Equal(secondThrowValue, game.Frames[0].SecondThrow);
    }

    [Fact]
    public void CloseFrameWhenStrike()
    {
        BowlingGame game = new BowlingGame();

        int firstThrowValue = 10;
        int? secondThrowValue = null;

        game.MakeFrame(firstThrowValue, secondThrowValue);

        Assert.Equal(firstThrowValue, game.Frames[0].FirstThrow);
        Assert.Null(game.Frames[0].SecondThrow);
    }

    [Fact]
    public void CanGetScore()
    {
        BowlingGame game = new BowlingGame();

        int firstThrowValue = 10;
        int? secondThrowValue = null;

        game.MakeFrame(firstThrowValue, secondThrowValue);

        Assert.Equal(10, game.Score);
    }

    [Fact]
    public void CanMakeIncrementScore()
    {
        BowlingGame game = new BowlingGame();

        int firstThrowValue = 5;
        int secondThrowValue = 3;

        game.MakeFrame(firstThrowValue, secondThrowValue);
        game.MakeFrame(firstThrowValue, secondThrowValue);

        Assert.Equal(16, game.Score);
    }

    [Fact]
    public void CanHandleSpare()
    {
        BowlingGame game = new BowlingGame();

        int firstThrowValue = 5;
        int secondThrowValue = 5;

        int firstThrowSecondFrame = 7;
        int secondThrowSecondFrame = 2;

        game.MakeFrame(firstThrowValue, secondThrowValue);
        game.MakeFrame(firstThrowSecondFrame, secondThrowSecondFrame);

        int expectedScore = 26; // Double 7 from first throw after spare

        Assert.Equal(expectedScore, game.Score);
    }

    [Fact]
    public void CanHandleStrikes()
    {
        BowlingGame game = new BowlingGame();

        int firstThrowValue = 10;
        int? secondThrowValue = null;

        int firstThrowSecondFrame = 7;
        int? secondThrowSecondFrame = 2;

        game.MakeFrame(firstThrowValue, secondThrowValue);
        game.MakeFrame(firstThrowSecondFrame, secondThrowSecondFrame);

        int expectedScore = 28;

        Assert.Equal(expectedScore, game.Score);
    }

    [Fact]
    public void CanHaveThirdThrowOnFinalFrame()
    {
        Frame frame = new Frame();

        Assert.Null(frame.ThirdThrow);
    }

    [Fact]
    public void CanGiveValueToThirdThrowOnStrike()
    {
        BowlingGame game = new BowlingGame();

        int firstThrow = 8;
        int secondThrow = 1;

        for (int i = 0; i < 9; i++)
        {
            game.MakeFrame(firstThrow, secondThrow);
        }

        int strikeValue = 10;
        int? secondThrowTenthFrame = 5;
        int? thirdThrowTenthFrame = 4;

        game.MakeFrame(strikeValue, secondThrowTenthFrame, thirdThrowTenthFrame);

        Assert.Equal(109, game.Score);
    }

}
