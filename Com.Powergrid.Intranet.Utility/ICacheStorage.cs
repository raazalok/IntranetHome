using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Powergrid.Intranet.Utility
{
    public interface ICacheStorage
    {
        void Remove(String key);
        void Store(String key, Object data);
        T Retrieve<T>(String key);
    }
}
