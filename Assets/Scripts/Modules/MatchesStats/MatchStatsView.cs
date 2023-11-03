using Data.Matching;
using TMPro;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

[RequireComponent(typeof(Button))]
public class MatchStatsView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _matchType;
    [SerializeField]
    private Image _icon;
    public async void FillView(MatchData matchData)
    {
        _matchType.text = matchData.MatchType.ToString().ToUpper();
        AsyncOperationHandle<Sprite> handle = Addressables.LoadAssetAsync<Sprite>(matchData.Icon);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            _icon.sprite = handle.Result;
        }
        else
        {
            Debug.LogError("Failed to load sprite: " + matchData.Icon);
        }

        Addressables.Release(handle);
    }
}
