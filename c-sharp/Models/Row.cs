namespace Models;

public class Row()
{ 
    public List<Cell> Cells { get; init; }

    public string GetCellValues()
    {
        var stringResult = "";

        foreach(var c in Cells)
        {
            if (c.IsMine)
                stringResult += '*';
            else
                stringResult += c.Value;
        }

        return stringResult;
    }
}