class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Minesweeper! Type a coordinate to select a cell, but watch out for mines! Each number says how many mines are next to it. Good luck!");
        while (true)
        {

            Console.Write("Enter a coordinate: ");
            string coordinate = Console.ReadLine();
            Console.WriteLine(coordinate);
        }
    }
}