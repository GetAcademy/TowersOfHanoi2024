using System.Windows;
using TowersOfHanoi2024.Logic;

namespace TowersOfHanoi2024.WpfUI
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var game = new Game();

            var app = new Application();
            var window = new Window();
            var gamePanel = new GamePanel(game);
            window.Content = gamePanel.Panel;
            app.Run(window);
        }
    }
}
