﻿using Data.Matching;
using UnityEngine;

namespace Modules.Profile.View
{
	public class ProfileView : MonoBehaviour
	{
		[SerializeField]
		private MatchesStatsView _matchesStatsView;

        public void Initialize(MatchData[] matches, int maxMatchesParameters)
        {
            _matchesStatsView.Initialize(maxMatchesParameters, matches);
        }
    }
}