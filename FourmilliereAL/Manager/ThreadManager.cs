
using System.Diagnostics;
using System.Threading;

namespace FourmilliereAL
{
    public class ThreadManager
    {
        public Thread GrilleThread { get; set; }
        public Stopwatch StopWatch { get; set; }

        public ThreadManager()
        {
            StopWatch = new Stopwatch();
        }

        public void StartGrilleExecution()
        {
            StopWatch.Start();
            GrilleThread = new Thread(App.fourmilliereVM.Avance);
            GrilleThread.Start();
        }

        public void StopGrilleExecution()
        {
            App.fourmilliereVM.Stop();
            if (StopWatch.IsRunning) {
                StopWatch.Stop();
            }
        }

    }
}
