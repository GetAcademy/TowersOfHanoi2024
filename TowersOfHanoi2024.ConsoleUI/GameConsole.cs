using TowersOfHanoi2024.Logic;

namespace TowersOfHanoi2024.ConsoleUI
{
    internal class GameConsole
    {
        public static void WriteTower(Tower tower, int startRow, int col, int height)
        {
            var disks = tower.GetDisks();
            var row = startRow + height;
            WriteDisk(12, row, col, 'O');
            foreach (var disk in disks.Reverse())
            {
                row--;
                WriteDisk(disk, row, col);
            }
        }

        public static void WriteDisk(Disk disk, int row, int col, char character = '=')
        {
            WriteDisk(disk.Size, row, col, character);
        }

        public static void WriteDisk(int size, int row, int col, char character = '=')
        {
            var x = col - size / 2;
            System.Console.SetCursorPosition(x, row);
            System.Console.Write(new string(character, size));
        }

        public static void WriteGame(
            Game game, int row, int col, 
            int towerWidth, int towerHeight)
        {
            var currentCol = col;
            foreach (var tower in game.Towers)
            {
                WriteTower(tower, row, currentCol, towerHeight);
                currentCol += towerWidth;
            }
        }

        public static int Ask(string question)
        {
            System.Console.Write(question);
            var answer = System.Console.ReadLine();
            return Convert.ToInt32(answer);
        }
    }
}
