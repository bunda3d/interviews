using Application.Services;
using FluentAssertions;
using FluentAssertions.Execution;

namespace UnitTests;

public class MinesweeperTests
{
    private Minesweeper _minesweeper = new();
    
    
    [TestCase(4,4)]
    [TestCase(3,5)]
    [TestCase(0,0)]
    public void TestGridSize(int width, int height)
    {
        var grid = _minesweeper.Initialize(width, height, 2);
        grid.Rows.Count.Should().Be(height);
        grid.Rows.All(r => r.Cells.Count == width).Should().BeTrue();
    }
    
    [Test]
    public void TestGrid_FromString()
    {
        var gridString = 
            """
            *...
            ....
            .*..
            ....
            """;

        
        ///
        /// *100
        /// 2210
        /// 1*10
        /// 1110
        /// 
        var grid = _minesweeper.Initialize(gridString);

        grid.Rows.Count.Should().Be(4);
        grid.Rows.All(r => r.Cells.Count == 4).Should().BeTrue();
        grid.Rows.Count(x => x.Cells.Any(y => y.IsMine)).Should().Be(2);

        using (new AssertionScope())
        {
            grid.Rows[0].GetCellValues().Should().Be("*100");
            grid.Rows[1].GetCellValues().Should().Be("2210");
            grid.Rows[2].GetCellValues().Should().Be("1*10");
            grid.Rows[3].GetCellValues().Should().Be("1110");
        }
    }

    [Test]
    public void TestGrid_FromString_3x5()
    {
        var gridString =
            """
            **...
            .....
            .*...
            """;

        var grid = _minesweeper.Initialize(gridString);

        grid.Rows.Count.Should().Be(3);
        grid.Rows.All(r => r.Cells.Count == 5).Should().BeTrue();
        grid.Rows.SelectMany(x=>x.Cells.Where(y=>y.IsMine)).Should().HaveCount(3);

    }
  
}