using System;
using System.Collections.Generic;

namespace EconRentCar.Core
{
    public class EntityActionResult
    {
        public int ErrorCode { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Messages { get; set; }
        public int Id { get; set; }
    }
}