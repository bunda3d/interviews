using Models;

namespace Application.Services;

public interface IMinesweeper
{
    Grid Initialize(int width, int height, int mineCount);
    Grid Initialize(string grid);
    string RevealCells(Grid grid);
    // void ToggleFlag(int x, int y);
    // bool IsGameOver { get; }
    // bool IsWin { get; }
}