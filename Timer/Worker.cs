using System;
using System.Timers;

namespace WorkTimer
{
    public class Worker : IDisposable
    {
        private Timer _timer;

        private readonly Random _random;

        public INotifier Notifier { get; private set; }

        public bool IsRunning { get; private set; }

        public Worker()
        {
            _random = new Random();
        }

        public Worker(INotifier notifier) : this()
        {
            Notifier = notifier;
        }

        public int WorkingMinute { get; private set; }

        public void Start()
        {
            _timer = new Timer();
            TakeRest();
            IsRunning = true;
        }

        public void TakeRest()
        {
            _timer.Dispose();
            _timer = new Timer();
            Notifier.Notify("Toi dang nghi ngoi");
            var nextWorkDuration = 3;
            _timer.Interval = nextWorkDuration * 1000;
            _timer.Elapsed -= (s, e) => TakeRest();
            _timer.Elapsed += DoWork;
            _timer.Start();
        }

        public void DoWork(object source, ElapsedEventArgs e)
        {
            _timer.Dispose();
            _timer = new Timer();
            var nextWorkDuration = _random.Next(1, 10);
            Notifier.Notify(string.Format("Toi dang lam task thoi gian {0} s", nextWorkDuration));
            _timer.Interval = nextWorkDuration * 1000;
            _timer.Elapsed += (s, evt) => TakeRest();
            _timer.Elapsed -= DoWork;
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
            _timer.Dispose();
            IsRunning = false;
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
