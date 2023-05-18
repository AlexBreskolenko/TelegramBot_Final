using SkillFactory_TelegramBot.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory_TelegramBot.Services
{
    class TextFileHandler : IFileHandler
    {
        public string Process(string code, string param)
        {
            string result = string.Empty;
            switch (code)
            {
                case "cw": return $"В вашем сообщении {param.Length} символов.";      // кол-во символов
                case "cn": return $"Сумма чисел {GetSumOfNumbers(param)}";
                default: break;
            }
            return result;
        }
        protected int GetSumOfNumbers(string str)
        {
            var numbers = str.Split(' ');
            int result = 0;
            foreach(var number in numbers)
            {
                result += int.Parse(number);
            }
            return result;
        }
    }
}
