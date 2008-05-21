using System;

namespace MvcApplication
{
    public class Logger
    {
        public virtual void Log(int ProductId)
        {
            throw new Exception("eeeks!");
        }
    }
}