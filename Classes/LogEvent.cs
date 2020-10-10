using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarcheTextEditor.Classes
{
    public class LogEvent
    {
        public string Text { get; set; }
        public DateTime Time { get; set; }

        public LogEvent(string text)
        {
            Text = text;
            Time = DateTime.Now;
        }
    }
}
