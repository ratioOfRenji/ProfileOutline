using Data.Matching;
using Modules.Profile.View.Matches;
using UnityEngine;
using Zenject;

namespace Modules.Profile.View
{
	public class ProfileView : MonoBehaviour
	{
		[Inject]
		private MatchesStatsView m_matchesStatsView;

        public void Initialize(MatchData[] matches, int maxMatchesParameters)
        {
            m_matchesStatsView.Initialize(maxMatchesParameters, matches);
        }
    }
}