using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MatchesAchievmentsMediator : MonoBehaviour
{

    [SerializeField]
    private MatchesStatsView _matchesStatsView;

    [SerializeField]
    private AchievmentView _achievmentView;

    [SerializeField]
    private Button[] _showAchievmentsPanelButton;

    [SerializeField]
    private Button[] _showMatchesPanelButton;

    [SerializeField]
    private Image[] _showAchievmentsPanelButtonImages;
    [SerializeField]
    private Image[] _showMatchesPanelButtonImages;
    private void Start()
    {

        for (int i = 0; i < _showMatchesPanelButton.Length; i++)
        {
            _showMatchesPanelButton[i].onClick.AddListener(ShowMAtchesPanel);
        }
        for (int i = 0; i < _showAchievmentsPanelButton.Length; i++)
        {
            _showAchievmentsPanelButton[i].onClick.AddListener(ShowAchievmentPanel);
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _showMatchesPanelButton.Length; i++)
        {
            _showMatchesPanelButton[i].onClick.RemoveListener(ShowMAtchesPanel);
        }
        for (int i = 0; i < _showMatchesPanelButton.Length; i++)
        {
            _showAchievmentsPanelButton[i].onClick.RemoveListener(ShowAchievmentPanel);
        }

    }
    private void ShowMAtchesPanel()
    {
        _achievmentView.SetVisibility(false);
        _matchesStatsView.SetVisibility(true);
        foreach(Image img in _showMatchesPanelButtonImages)
        {
            img.enabled = true;
        }
        foreach (Image img in _showAchievmentsPanelButtonImages)
        {
            img.enabled = false;
        }
    }

    private void ShowAchievmentPanel()
    {
        _achievmentView.SetVisibility(true);
        _matchesStatsView.SetVisibility(false);
        foreach (Image img in _showMatchesPanelButtonImages)
        {
            img.enabled = false;
        }
        foreach (Image img in _showAchievmentsPanelButtonImages)
        {
            img.enabled = true;
        }
    }
}
