using Modules.Profile.View.Achievments;
using Modules.Profile.View.Matches;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Ui.Helpers
{
    public class MatchesAchievmentsMediator : MonoBehaviour
    {

        [Inject]
        private MatchesStatsView m_matchesStatsView;

        [Inject]
        private AchievmentView m_achievmentView;

        [SerializeField]
        private Button[] m_showAchievmentsPanelButton;

        [SerializeField]
        private Button[] m_showMatchesPanelButton;

        [SerializeField]
        private Image[] m_showAchievmentsPanelButtonImages;
        [SerializeField]
        private Image[] m_showMatchesPanelButtonImages;
        private void Start()
        {

            for (int i = 0; i < m_showMatchesPanelButton.Length; i++)
            {
                m_showMatchesPanelButton[i].onClick.AddListener(ShowMAtchesPanel);
            }
            for (int i = 0; i < m_showAchievmentsPanelButton.Length; i++)
            {
                m_showAchievmentsPanelButton[i].onClick.AddListener(ShowAchievmentPanel);
            }
        }

        private void OnDestroy()
        {
            for (int i = 0; i < m_showMatchesPanelButton.Length; i++)
            {
                m_showMatchesPanelButton[i].onClick.RemoveListener(ShowMAtchesPanel);
            }
            for (int i = 0; i < m_showMatchesPanelButton.Length; i++)
            {
                m_showAchievmentsPanelButton[i].onClick.RemoveListener(ShowAchievmentPanel);
            }

        }
        private void ShowMAtchesPanel()
        {
            m_achievmentView.SetVisibility(false);
            m_matchesStatsView.SetVisibility(true);
            foreach (Image img in m_showMatchesPanelButtonImages)
            {
                img.enabled = true;
            }
            foreach (Image img in m_showAchievmentsPanelButtonImages)
            {
                img.enabled = false;
            }
        }

        private void ShowAchievmentPanel()
        {
            m_achievmentView.SetVisibility(true);
            m_matchesStatsView.SetVisibility(false);
            foreach (Image img in m_showMatchesPanelButtonImages)
            {
                img.enabled = false;
            }
            foreach (Image img in m_showAchievmentsPanelButtonImages)
            {
                img.enabled = true;
            }
        }
    }
}