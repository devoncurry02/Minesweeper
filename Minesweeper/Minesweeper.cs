class Program
{
    static void Main()
    {
        Coordinates coordinates = new Coordinates();
        Console.WriteLine("Welcome to Minesweeper! Type a coordinate to select a cell, but watch out for mines!\nEach number says how many mines are next to it. Good luck! (Coordinate example: A4, D1, B3)");
        while (true)
        {
            Console.WriteLine(coordinates.GenerateGrid(coordinates.X, coordinates.Y, coordinates.mine_count));

            Console.Write("Enter a coordinate: ");
            string coords = Console.ReadLine().ToUpper();

            if (coordinates.IsValid(coords))
            {
                Console.WriteLine("Valid coordinate.");
            }
            else
            {
                Console.WriteLine("The coordinates you entered are not valid. Please try again.");
            }
        }
    }
}