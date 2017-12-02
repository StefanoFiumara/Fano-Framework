using System;
using System.Windows.Input;

namespace FanoMvvm.Utility
{
    public class MouseOverride : IDisposable
    {
        public MouseOverride(Cursor cursor)
        {
            Mouse.OverrideCursor = cursor;
        }
        public void Dispose()
        {
            Mouse.OverrideCursor = null;
        }
    }
}