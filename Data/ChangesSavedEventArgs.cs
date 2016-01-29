using System.Collections.Generic;

namespace Data
{
    public class ChangesSavedEventArgs
    {
        public Dictionary<string, object> Entries { get; set; }
    }
}