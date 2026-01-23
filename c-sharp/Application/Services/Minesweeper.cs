using Models;

namespace Application.Services;

public class Minesweeper : IMinesweeper
{
    public Grid Initialize(int width, int height, int mineCount)
    {
        var grid = new Grid() { Rows = new() };

        for (var i = 0; i < height; i++)
        {
            var gridRowCells = new List<Cell>();

            for (var j = 0; j < width; j++)
            {
                gridRowCells.Add(new() { IsMine = false, IsGuessed = false });
            }

            grid.Rows.Add(new Row(){Cells = gridRowCells});
        }


        return grid;
    }

    public Grid Initialize(string gridString)
    {
        var grid = new Grid() { Rows = new() };

        var rows = gridString.Split(Environment.NewLine);

        foreach (var row in rows)
        {
            var gridRowCells = new List<Cell>();

            foreach (var c in row)
            {
                var cell = new Cell()
                {
                    IsGuessed = false,
                    IsMine = (c) switch
                    {
                        '*' => true,
                        '.' => false,
                        _ => false
                    }
                };

                gridRowCells.Add(cell);
            }

            grid.Rows.Add(new Row(){Cells = gridRowCells});
        }

        return grid;
    }

    public string RevealCells(Grid grid)
    {
        return string.Empty;
    }
}