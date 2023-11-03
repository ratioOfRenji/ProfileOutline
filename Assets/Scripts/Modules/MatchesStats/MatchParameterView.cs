using Data.Matching;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MatchParameterView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _header;
    [SerializeField]
    private TMP_Text _subHeader;
    [SerializeField]
    private TMP_Text _score;
    public void FillView(MatchParameter matchParameter)
    {
        _header.text = matchParameter.Header.ToUpper();
        _subHeader.text = matchParameter.SubHeader.ToUpper();
        _score.text = matchParameter.Score.ToString()+" PT.".ToUpper();

    }
}
