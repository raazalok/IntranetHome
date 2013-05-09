using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Powergrid.Intranet.Utility
{
    public class NullObjectCache : ICacheStorage
    {
        public void Remove(string key)
        {
            //Do Nothing
        }

        public void Store(string key, object data)
        {
            //Do Nothing
        }

        public T Retrieve<T>(string key)
        {
            return default(T);
        }
    }
}
