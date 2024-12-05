namespace TowersOfHanoi2024.Logic
{
    public class Tower
    {
        public bool IsComplete => _disks.Count == 3;

        private readonly Stack<Disk> _disks;

        public Tower(params int[] diskSizes)
        {
            _disks = new Stack<Disk>();
            foreach (var diskSize in diskSizes)
            {
                var disk = new Disk(diskSize);
                _disks.Push(disk);
            }
        }

        public Disk[] GetDisks()
        {
            return _disks.ToArray();
        }

        public Disk GetTopDisk()
        {
            return _disks.Peek();
        }

        public Disk RemoveDisk()
        {
            return _disks.Pop();
        }

        public bool AddDisk(Disk disk)
        {
            if (_disks.Count > 0)
            {
                var topDisk = _disks.Peek();
                if (disk.IsGreaterThan(topDisk)) return false;
            }
            _disks.Push(disk);
            return true;
        }
    }
}
