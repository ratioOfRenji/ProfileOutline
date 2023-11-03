using Data.Matching;
using TMPro;
using UnityEngine;

namespace Modules.Profile.View.Matches
{
    public class MatchParameterView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text m_header;
        [SerializeField]
        private TMP_Text m_subHeader;
        [SerializeField]
        private TMP_Text m_score;
        public void FillView(MatchParameter matchParameter)
        {
            m_header.text = matchParameter.Header.ToUpper();
            m_subHeader.text = matchParameter.SubHeader.ToUpper();
            m_score.text = matchParameter.Score.ToString() + " PT.".ToUpper();

        }
    }
}