using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Wpf_MVVM_01_SimpleClock
{
    public delegate void DateChangedEventHandler(DateTime date);
    public delegate void TimeChangedEventHandler(TimeSpan time);

    class ClockModel
    {
        public event DateChangedEventHandler DateChanged;
        public event TimeChangedEventHandler TimeChanged;

        private DispatcherTimer dispatcherTimer;
        private DateTime lastTime;

        public ClockModel()
        {
            this.DateChanged = null;
            this.TimeChanged = null;

            this.lastTime = DateTime.Now;

            this.dispatcherTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            this.dispatcherTimer.Tick += this.TimerTick;
        }

        public DateTime LastDate
        {
            get
            {
                return this.lastTime.Date;
            }
        }

        public TimeSpan LastTime
        {
            get
            {
                return this.lastTime.TimeOfDay;
            }
        }

        public void Start()
        {
            this.dispatcherTimer.Start();
        }

        public void Stop()
        {
            this.dispatcherTimer.Stop();
        }

        private void TimerTick(Object sender, EventArgs e)
        {
            DateTime last = this.lastTime;
            this.lastTime = DateTime.Now;

            if (this.lastTime.Date != last.Date)
                if (this.DateChanged != null)
                    this.DateChanged.Invoke(this.lastTime.Date);

            if (this.lastTime.TimeOfDay != last.TimeOfDay)
                if (this.TimeChanged != null)
                    this.TimeChanged.Invoke(this.lastTime.TimeOfDay);
        }
    }
}
