using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;
using TowersOfHanoi2024.Logic;

namespace TowersOfHanoi2024.WpfUI
{
    internal class GamePanel
    {
        private Game _game;
        private StackPanel[] _towerPanels;
        public StackPanel Panel { get; }

        public GamePanel(Game game)
        {
            _game = game;
            _towerPanels = new StackPanel[game.Towers.Length];
            Panel = CreateHorizontalPanel();
            for (var index = 0; index < game.Towers.Length; index++)
            {
                var towerPanel = CreateVerticalPanel();
                _towerPanels[index] = towerPanel;
                var toIndexA = (index + 1) % 3;
                var toIndexB = (index + 2) % 3;
                AddButton(index + 1, toIndexA + 1, towerPanel);
                AddButton(index + 1, toIndexB + 1, towerPanel);
                Panel.Children.Add(towerPanel);
            }
            UpdateTowers();
        }

        public void UpdateTowers()
        {
            for (var index = 0; index < _game.Towers.Length; index++)
            {
                var tower = _game.Towers[index];
                var towerPanel = _towerPanels[index];
                for (var towerIndex = towerPanel.Children.Count - 1; towerIndex >= 0; towerIndex--)
                {
                    var child = towerPanel.Children[towerIndex];
                    if (child is Rectangle)
                    {
                        towerPanel.Children.Remove(child);
                    }
                }

                foreach (var disk in tower.GetDisks())
                {
                    AddRectangle(disk.Size, Brushes.Blue, towerPanel);
                }
                AddRectangle(10, Brushes.Red, towerPanel);
            }
        }

        private static void AddRectangle(int size, SolidColorBrush color, StackPanel towerPanel)
        {
            var rectangle = new Rectangle
            {
                Width = 20 * size,
                Height = 20,
                Fill = color,
                Margin = new Thickness(5)
            };
            towerPanel.Children.Insert(towerPanel.Children.Count-2, rectangle);
        }

        private void AddButton(int from, int to, StackPanel panel)
        {
            var button = new Button { Content = $"=> {to}" };
            panel.Children.Add(button);
            button.Click += CreateClickMethod(from, to);
        }
        private RoutedEventHandler CreateClickMethod(int from, int to)
        {
            return (object sender, RoutedEventArgs e) =>
            {
                _game.Move(from, to);
                UpdateTowers();
            };
        }

        private static StackPanel CreateVerticalPanel()
        {
            return new StackPanel
            {
                Orientation = Orientation.Vertical,
                VerticalAlignment = VerticalAlignment.Bottom
            };
        }

        private static StackPanel CreateHorizontalPanel()
        {
            return new StackPanel
            {
                Orientation = Orientation.Horizontal
            };
        }
    }
}
