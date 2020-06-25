using System.Collections.Generic;

namespace FoldreView.Models
{
    public class PageView
    {
        public string Name { get; set; }
        public IList<FoldersView> Folders { get; set; }
    }

    public class FoldersView
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
