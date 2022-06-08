using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinApp
{
    public class EntryPageFlyoutMenuItem
    {
        public EntryPageFlyoutMenuItem()
        {
            TargetType = typeof(EntryPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}