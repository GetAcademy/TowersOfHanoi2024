namespace TowersOfHanoi2024.Logic
{
    public class Disk
    {
        public int Size { get; }

        public Disk(int size)
        {
            Size = size;
        }

        public bool IsGreaterThan(Disk disk)
        {
            return Size > disk.Size;
        }
    }
}
