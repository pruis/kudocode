using System;
using System.Collections.Generic;

namespace KudoCode.LogicLayer.Plugin.Redis.Infrastructure
{
    public class DelegateContext : IDelegateContext
    {
        public DelegateContext()
        {
            Keys = new List<string>();
        }
        public List<string> Keys { get; set; }
    }
}