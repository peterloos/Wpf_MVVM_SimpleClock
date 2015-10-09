using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_MVVM_01_SimpleClock
{
    public class ClockViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ClockModel model;

        private String currentTime;
        private String currentDate;

        public ClockViewModel()
        {
            this.model = new ClockModel();

            this.currentDate = String.Format("{0:00}.{1:00}.{2:0000}",
                this.model.LastDate.Day,
                this.model.LastDate.Month,
                this.model.LastDate.Year);

            this.currentTime = String.Format("{0:00}:{1:00}:{2:00}",
                this.model.LastTime.Hours,
                this.model.LastTime.Minutes,
                this.model.LastTime.Seconds);

            this.model.DateChanged += this.Model_DateChanged;
            this.model.TimeChanged += this.Model_TimeChanged;

            this.model.Start();
        }

        public String CurrentTime
        {
            set
            {
                this.currentTime = value;

                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs("CurrentTime"));
            }

            get
            {
                return this.currentTime;
            }
        }

        public String CurrentDate
        {
            set
            {
                this.currentDate = value;

                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs("CurrentDate"));
            }

            get
            {
                return this.currentDate;
            }
        }

        private void Model_TimeChanged(TimeSpan time)
        {
            this.CurrentTime = String.Format("{0:00}:{1:00}:{2:00}",
                time.Hours, time.Minutes, time.Seconds);
        }

        private void Model_DateChanged(DateTime date)
        {
            this.CurrentDate = String.Format("{0:00}.{1:00}.{2:0000}",
                date.Day, date.Month, date.Year);
        }
    }
}
