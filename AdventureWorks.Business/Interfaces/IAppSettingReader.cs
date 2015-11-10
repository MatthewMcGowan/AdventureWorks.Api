using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Interfaces
{
    public interface IAppSettingReader
    {
        string GetAppSetting(string key);
    }
}
