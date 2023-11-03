using Data.Matching;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class MatchesStatsView : MonoBehaviour
{

    [SerializeField]
    private GameObject _content;

    [SerializeField]
    private MatchStatsView[] _recentMatches;

    [SerializeField]
    private GameObject _matchParameterPrefab;

    [SerializeField]
    private Transform _contentTransform;

    
    private List<Button> _lastMatchesButtons = new List<Button>();

    private List<MatchParameterView> _matchParameters = new List<MatchParameterView>();


    private void OnDestroy()
    {
        foreach(Button b in _lastMatchesButtons)
        {
            b.onClick.RemoveAllListeners();
        }
    }
    public void SetVisibility(bool _b)
    {
        _content.SetActive(_b);
    }

    public void Initialize(int maxMatchesParameters, MatchData[] matches)
    {
        for (int i = 0; i < maxMatchesParameters; i++)
        {
            var newParameter = Instantiate(_matchParameterPrefab, _contentTransform);
            _matchParameters.Add(newParameter.GetComponent<MatchParameterView>());
            newParameter.SetActive(false);
        }

        ShowLastMatches(matches);
    }
    public void ShowLastMatches(MatchData[] matches)
    {
        _lastMatchesButtons.Clear();

        for (int i = 0; i < _recentMatches.Length; i++)
        {
            _recentMatches[i].FillView(matches[i]);
            Button b = _recentMatches[i].GetComponent<Button>();
            int index = i;
            b.onClick.AddListener(() => { ShowMatchParameters(matches[index]); });
            _lastMatchesButtons.Add(_recentMatches[i].GetComponent<Button>());
        }
        ShowMatchParameters(matches[0]);
    }

    public void ShowMatchParameters(MatchData match)
    {
        int parametersCount = match.Parameters.Length;
        for (int i = 0; i < _matchParameters.Count; i++)
        {
            if (i < parametersCount)
            {
                _matchParameters[i].gameObject.SetActive(true);
                _matchParameters[i].FillView(match.Parameters[i]);
            }
            else
            {
                _matchParameters[i].gameObject.SetActive(false);
            }
        }
    }
}
