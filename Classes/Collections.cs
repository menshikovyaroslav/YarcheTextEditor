using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using YarcheTextEditor.Models;

namespace YarcheTextEditor.Classes
{
    public static class Collections
    {
        public static EventHandler<EventArgs> TextCollectionChangedHandler;
        public static ObservableCollection<StringElement> TextCollection { get; set; }

        static Collections()
        {
            TextCollection = new ObservableCollection<StringElement>();
        }



        public static void TextCollectionChanged()
        {
            var eventArgs = new EventArgs();
            TextCollectionChangedHandler?.Invoke(null, eventArgs);
        }
    }
}
