internal class Program
{
    private static void Copy1()
    {
        string src = @"D:\file0.txt";
        string dest = @"D:\file.txt";
        File.Copy(src, dest, true);
        Console.WriteLine("1");
    }
    private static void Copy2()
    {
        string src = @"D:\file01.txt";
        string dest = @"D:\file1.txt";
        File.Copy(src, dest, true);
        Console.WriteLine("2");
    }
    private async static void CopyAsync()
    {
        await Task.Run(() => Copy2());
    }
    internal class Timer
    {
        public DateTime dt1;
        public DateTime dt2;
        public Timer() /// конструктор создаёт таймер вызывать так: Timer timer = new Timer();
        {

        }
        public void Start() /// запускает таймер вызывать так: timer.Start();
        {
            dt1 = DateTime.Now;
        }
        public void Stop() /// останавливает таймер и выводит сколько времени прошло с начала запуска вызывать так: Timer.Stop();
        {
            dt2 = DateTime.Now;
            TimeSpan ts = dt2 - dt1;
            Console.WriteLine("Времени прошло " + ts.TotalMilliseconds + " миллисекунда"); /// время отоброжается в миллисекундах
        }
    }
    private static void Main(string[] args)
    {
        Timer timer = new Timer();
        timer.Start();
        Thread copy1 = new(Copy1);
        copy1.Start();
        CopyAsync();
        Console.WriteLine();
        timer.Stop();
    }
}