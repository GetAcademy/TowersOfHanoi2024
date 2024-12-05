using TowersOfHanoi2024.ConsoleUI;
using TowersOfHanoi2024.Logic;

var game = new Game();
while (game.IsRunning)
{
    Console.Clear();
    GameConsole.WriteGame(game, 2, 10, 20, 8);
    Console.SetCursorPosition(1, 15);
    var fromTowerNo = GameConsole.Ask("Hvilket tårn vil du flytte fra? ");
    var toTowerNo = GameConsole.Ask("Hvilket tårn vil du flytte til? ");
    game.Move(fromTowerNo, toTowerNo);
}
Console.Clear();
GameConsole.WriteGame(game, 2, 10, 20, 8);
Console.SetCursorPosition(1, 15);
Console.WriteLine("Løst!");


//var list = new List<string>();
//list.Add("a");
//list.Add("b");
//list.Add("c");
//list.Remove();


//var stack = new Stack<int>();
//stack.Push(1);
//stack.Push(2);
//var number = stack.Pop();
//stack.Peek();