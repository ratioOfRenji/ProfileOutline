using Data.Matching;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MatchStatsView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _matchType;
    [SerializeField]
    private Image _icon;
    public void FillView(MatchData matchData)
    {
        _matchType.text = matchData.MatchType.ToString().ToUpper();
    }
}
