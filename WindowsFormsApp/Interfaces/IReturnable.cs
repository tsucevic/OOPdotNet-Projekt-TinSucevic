using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp.Interfaces
{
    interface IReturnable<T>
    {
        public T ReturnValue();
    }
}
