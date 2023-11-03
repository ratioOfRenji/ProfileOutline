using Modules.Profile.Controller;
using Modules.Profile.Model;
using Modules.Profile.View;
using Modules.Profile.View.Matches;
using Modules.Profile.View.Achievments;
using UnityEngine;
using Zenject;

namespace Modules.Profile
{
    public class ProfileModule : MonoInstaller
    {
        [SerializeField]
        private ProfileView m_profileView;
        [SerializeField]
        private MatchesStatsView m_matchesStatsView;
        [SerializeField]
        private AchievmentView m_achievmentView;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ProfileController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ProfileModel>().AsSingle().NonLazy();
            Container.BindInstance(m_profileView).AsSingle().NonLazy();
            Container.BindInstance(m_matchesStatsView).AsSingle().NonLazy();
            Container.BindInstance(m_achievmentView).AsSingle().NonLazy();
        }
    }
}
