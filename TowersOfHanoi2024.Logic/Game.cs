namespace TowersOfHanoi2024.Logic
{
    public class Game
    {
        public Tower[] Towers { get; }
        public bool IsRunning => !Towers[2].IsComplete;

        public Game()
        {
            Towers = new Tower[]
            {
                new Tower(6, 4, 2),
                new Tower(),
                new Tower(),
            };
        }

        public void Move(int fromTowerNo, int toTowerNo)
        {
            var fromIndex = fromTowerNo - 1;
            var toIndex = toTowerNo - 1;
            var fromTower = Towers[fromIndex];
            var toTower = Towers[toIndex];
            var disk = fromTower.GetTopDisk();
            var didAdd = toTower.AddDisk(disk);
            if (didAdd)
            {
                fromTower.RemoveDisk();
            }
        }
    }
}
