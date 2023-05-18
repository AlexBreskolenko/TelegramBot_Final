using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory_TelegramBot.Services
{
    public interface IFileHandler
    {
        string Process(string code, string param);
    }
}
