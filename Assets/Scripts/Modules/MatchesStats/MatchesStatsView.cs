using Data.Matching;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Profile.View.Matches
{
    public class MatchesStatsView : MonoBehaviour
    {

        [SerializeField]
        private GameObject m_content;

        [SerializeField]
        private MatchStatsView[] m_recentMatches;

        [SerializeField]
        private GameObject m_matchParameterPrefab;

        [SerializeField]
        private Transform m_contentTransform;


        private List<Button> m_lastMatchesButtons = new List<Button>();

        private List<MatchParameterView> m_matchParameters = new List<MatchParameterView>();


        private void OnDestroy()
        {
            foreach (Button b in m_lastMatchesButtons)
            {
                b.onClick.RemoveAllListeners();
            }
        }
        public void SetVisibility(bool _b)
        {
            m_content.SetActive(_b);
        }

        public void Initialize(int maxMatchesParameters, MatchData[] matches)
        {
            for (int i = 0; i < maxMatchesParameters; i++)
            {
                var newParameter = Instantiate(m_matchParameterPrefab, m_contentTransform);
                m_matchParameters.Add(newParameter.GetComponent<MatchParameterView>());
                newParameter.SetActive(false);
            }

            ShowLastMatches(matches);
        }
        private void ShowLastMatches(MatchData[] matches)
        {

            ShowRecentMatches(matches);
            ShowMatchParameters(matches[0]);
        }

        private void ShowRecentMatches(MatchData[] matches)
        {
            m_lastMatchesButtons.Clear();

            for (int i = 0; i < m_recentMatches.Length; i++)
            {
                m_recentMatches[i].FillView(matches[i]);
                Button b = m_recentMatches[i].GetComponent<Button>();
                int index = i;
                b.onClick.AddListener(() => { ShowMatchParameters(matches[index]); });
                m_lastMatchesButtons.Add(m_recentMatches[i].GetComponent<Button>());
            }
        }
        private void ShowMatchParameters(MatchData match)
        {
            int parametersCount = match.Parameters.Length;
            for (int i = 0; i < m_matchParameters.Count; i++)
            {
                if (i < parametersCount)
                {
                    m_matchParameters[i].gameObject.SetActive(true);
                    m_matchParameters[i].FillView(match.Parameters[i]);
                }
                else
                {
                    m_matchParameters[i].gameObject.SetActive(false);
                }
            }
        }
    }
}