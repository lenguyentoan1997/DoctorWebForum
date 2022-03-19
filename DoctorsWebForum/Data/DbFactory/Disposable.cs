using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorsWebForum.Data.DbFactory
{
    public class Disposable : IDisposable
    {
        private bool _isDisposed = false;

        ~Disposable()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                DisposeCore();
            }
            _isDisposed = true;
        }

        protected virtual void DisposeCore() { }
    }
}