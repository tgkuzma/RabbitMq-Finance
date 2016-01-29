using System;
using Data.Interfaces;

namespace Data
{
    public class RepositoryEvents : IRepositoryEvents
    {
        public event EventHandler<ChangesSavedEventArgs> ChangesSaved;

        public void OnChangesSaved(ChangesSavedEventArgs args)
        {
            ChangesSaved(this, args);
        }

    }
}