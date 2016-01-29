using System;

namespace Data.Interfaces
{
    public interface IRepositoryEvents
    {
        event EventHandler<ChangesSavedEventArgs> ChangesSaved;
        void OnChangesSaved(ChangesSavedEventArgs args);
    }
}