﻿using System.Collections.Generic;

namespace VendingMachine.DataService.Common
{
    public class DataServiceExceptionData
    {
        public List<object> Extensions;
        public Dictionary<string, List<string>> Messages { get; set; }
        public Dictionary<int, Dictionary<string, List<string>>> IndexMessages { get; set; }
        public string GeneralMessage { get; set; }
    }
}
