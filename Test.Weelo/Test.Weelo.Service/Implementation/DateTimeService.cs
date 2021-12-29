using System;
using Test.Weelo.Service.Contract;

namespace Test.Weelo.Service.Implementation
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}