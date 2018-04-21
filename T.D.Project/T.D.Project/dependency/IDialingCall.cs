using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.D.Project.dependency
{
   public interface IDialingCall
    {
        void call(string number);
    }
    public interface IShareApp
    {
        void share();
    }
}
