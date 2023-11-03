using Data.Matching;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private List<MatchParameterView> _matchParameters = new List<MatchParameterView>();
    public void SetVisibility(bool _b)
    {
        _content.SetActive(_b);
    }

    public void ShowLastMatches(MatchData[] matches)
    {
        for (int i = 0; i < _recentMatches.Length; i++)
        {
            _recentMatches[i].FillView(matches[i]);
        }

        int parametersCount = matches[0].Parameters.Length;
        if (_matchParameters.Count >0)
        {
            foreach (MatchParameterView parameter in _matchParameters)
            {
                Destroy(parameter.gameObject);
            }
        }
        
        _matchParameters.Clear();

        for (int i = 0; i < parametersCount; i++)
        {

            var newParameter = Instantiate(_matchParameterPrefab, _contentTransform);
            _matchParameters.Add(newParameter.GetComponent<MatchParameterView>());

            _matchParameters[i].gameObject.SetActive(true);
            _matchParameters[i].FillView(matches[0].Parameters[i]);
        }

        for (int i = 0; i < _matchParameters.Count; i++)
        {
            if(i>= parametersCount)
            {
                _matchParameters[i].gameObject.SetActive(false);
            }
        }
    }
}
