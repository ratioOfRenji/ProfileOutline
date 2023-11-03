using System;
using Data;
using Modules.Profile.Model;
using Modules.Profile.View;
using Zenject;

namespace Modules.Profile.Controller
{
    public class ProfileController : IInitializable, IDisposable
    {
        private readonly ProfileModel m_model;
        private readonly ProfileView m_view;

        public ProfileController(ProfileModel model, ProfileView view)
        {
            m_model = model;
            m_view = view;
        }

        public void Initialize()
        {
            AccountData data = m_model.GetAccount();
            m_view.Initialize(data.Matches, m_model.MaxMatchParameters);
        }

        //не вижу что здесь нужно что-то диспозить, из неуправляемых ресурсов есть только handle у адрессеблов, его я освобождаю в том же методе где вызываю
        public void Dispose()
        {
           
        }
    }
}
