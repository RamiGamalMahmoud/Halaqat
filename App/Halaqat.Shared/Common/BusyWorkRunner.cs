using System;

namespace Halaqat.Shared.Common
{
    public class BusyWorkRunner
    {
        public static IDisposable CreateBusyWork(DoBusyWork doBusyWork) => new BusyWork(doBusyWork);

        protected class BusyWork : IDisposable
        {
            private readonly DoBusyWork _doBusyWork;

            public BusyWork(DoBusyWork doBusyWork)
            {
                _doBusyWork = doBusyWork;
                SetBusy(true);
            }

            public void Dispose() => SetBusy(false);

            private void SetBusy(bool isBusy)
            {
                _doBusyWork.IsBusy = isBusy;
            }
        }
    }
}
