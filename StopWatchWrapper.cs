using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Solum
{
    class StopWatchWrapper
    {
        TimeSpan _offsetTimeSpan;
        Stopwatch _stopwatch;

        public StopWatchWrapper(TimeSpan offsetElapsedTimeSpan)
        {

            _offsetTimeSpan = offsetElapsedTimeSpan;

            _stopwatch = new Stopwatch();

        }


        public void Start()
        {

            _stopwatch.Start();

        }


        public void Stop()
        {

            _stopwatch.Stop();

        }


        public TimeSpan ElapsedTimeSpan
        {


            get
            {


                if (_offsetTimeSpan == null)


                    return _stopwatch.Elapsed;


                return _stopwatch.Elapsed + _offsetTimeSpan;

            }


            set
            {

                _offsetTimeSpan =

                value;

            }

        }

    }

}