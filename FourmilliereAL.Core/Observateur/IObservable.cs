namespace FourmilliereAL.Core
{
    interface IObservable
    {
        void Attach(Fourmi observer);

        void Detach(Fourmi observer);

        void Notify();
    }
}
