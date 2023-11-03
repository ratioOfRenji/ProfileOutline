using Data.Matching;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Modules.Profile.View.Matches
{
    [RequireComponent(typeof(Button))]
    public class MatchStatsView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text m_matchType;
        [SerializeField]
        private Image m_icon;

        public async UniTask FillView(MatchData matchData)
        {
            m_matchType.text = matchData.MatchType.ToString().ToUpper();

            AsyncOperationHandle<Sprite> handle = Addressables.LoadAssetAsync<Sprite>(matchData.Icon);
            await handle.ToUniTask();

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                m_icon.sprite = handle.Result;
            }
            else
            {
                Debug.LogError("Failed to load sprite: " + matchData.Icon);
            }

            Addressables.Release(handle);
        }
    }
}