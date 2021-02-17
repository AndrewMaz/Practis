using System;

namespace NullObject.Coding.Exercise
{
    public interface ILog
    {
        // maximum # of elements in the log
        int RecordLimit { get; }

        // number of elements already in the log
        int RecordCount { get; set; }

        // expected to increment RecordCount
        void LogInfo(string message);
    }

    public class Account
    {
        private ILog log;

        public Account(ILog log)
        {
            this.log = log;
        }

        public void SomeOperation()
        {
            int c = log.RecordCount;
            log.LogInfo("Performing an operation");
            if (c + 1 != log.RecordCount)
                throw new Exception();
            if (log.RecordCount >= log.RecordLimit)
                throw new Exception();
        }
    }

    public class NullLog : ILog
    {
        int count;
        public int RecordLimit => RecordCount + 1;
        public int RecordCount { get { return count; } set { count = RecordCount; } }
        public void LogInfo(string message) { count++; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var nullObj = new NullLog();
            var ac = new Account(nullObj);

            ac.SomeOperation();

        }
    }
}
