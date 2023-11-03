using UnityEngine;

namespace Modules.Profile.View.Achievments
{
    public class AchievmentView : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_content;

        public void SetVisibility(bool _b)
        {
            m_content.SetActive(_b);
        }

    }
}