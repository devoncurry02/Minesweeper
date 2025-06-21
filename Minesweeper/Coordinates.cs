using System.CodeDom.Compiler;
using System.Globalization;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

class Coordinates
{
    public int X = 5;
    public int Y = 5;
    public int mine_count = 5;

    public int TranslateLetter(char Letter)
    {
        switch (Letter)
        {
            case 'A': return 1;
            case 'B': return 2;
            case 'C': return 3;
            case 'D': return 4;
            case 'E': return 5;
            case 'F': return 6;
            case 'G': return 7;
            case 'H': return 8;
            case 'I': return 9;
            case 'J': return 10;
            case 'K': return 11;
            case 'L': return 12;
            case 'M': return 13;
            case 'N': return 14;
            case 'O': return 15;
            case 'P': return 16;
            case 'Q': return 17;
            case 'R': return 18;
            case 'S': return 19;
            case 'T': return 20;
            case 'U': return 21;
            case 'V': return 22;
            case 'W': return 23;
            case 'X': return 24;
            case 'Y': return 25;
            case 'Z': return 26;
            default: return 0;
        }
    }

    public bool IsValid(string coords)
    {
        if (TranslateLetter(coords[0]) > X)
        {
            return false;
        }
        if (coords[1] - '0' > Y || coords[1] - '0' < 1)
        {
            return false;
        }
        return true;
    }

    public string GenerateGrid(int x_range, int y_range, int mine_count)
    {
        List<char> mines = Initialize(x_range, y_range, mine_count);
        string grid = Populate(mines, x_range);
        string masked_grid = grid;


        return masked_grid;
    }
    
    public List<char> Initialize(int x_range, int y_range, int mine_count)
        {
            List<char> minelist = new List<char>(new string('X', mine_count) + new string('0', (x_range * y_range) - mine_count));
            Random random = new Random();
            var mines = minelist.OrderBy(digit => random.Next()).ToList();
            return Number(mines, x_range);
        }

    public List<char> Number(List<char> mines, int x_range)
    {
        int digit_tracker = 0;
        int total_mines = mines.Count;
        foreach (char digit in mines.ToList())
        {
            int mine_count = 0;
            if (digit == '0')
            {
                if (digit_tracker - x_range - 1 >= 0          && digit_tracker % x_range != 0           && mines[digit_tracker - 1 - x_range] == 'X') { mine_count += 1; };
                if (digit_tracker - x_range >= 0                                                        && mines[digit_tracker - x_range] == 'X')     { mine_count += 1; };
                if (digit_tracker - x_range + 1 >= 0          && digit_tracker % x_range != x_range - 1 && mines[digit_tracker + 1 - x_range] == 'X') { mine_count += 1; };
                if (digit_tracker % x_range != 0                                                        && mines[digit_tracker - 1] == 'X')           { mine_count += 1; };
                if (digit_tracker % x_range != x_range - 1    && digit_tracker + 1 < total_mines        && mines[digit_tracker + 1] == 'X')           { mine_count += 1; };
                if (digit_tracker + x_range - 1 < total_mines && digit_tracker % x_range != 0           && mines[digit_tracker - 1 + x_range] == 'X') { mine_count += 1; };
                if (digit_tracker + x_range < total_mines                                               && mines[digit_tracker + x_range] == 'X')     { mine_count += 1; };
                if (digit_tracker + x_range + 1 < total_mines && digit_tracker % x_range != x_range - 1 && mines[digit_tracker + 1 + x_range] == 'X') { mine_count += 1; };
                if (mine_count == 0)
                {
                    mines[digit_tracker] = '_';
                }
                else
                {
                    mines[digit_tracker] = mine_count.ToString()[0];
                }
            }
            digit_tracker += 1;
        }
        return mines;
    }

    public string Populate(List<char> mines, int x_range)
    {
        string grid = "";
        int digit_tracker = 0;
        foreach (char mine in mines)
        {
            if (digit_tracker % x_range == 0)
            {
                grid += "\n";
            }
            if (mine == 'X')
            {
                grid += $"[X]";
            }
            else
            {
                grid += $"[{mine}]";
            }
            digit_tracker += 1;
        }
        return grid;
    }
}