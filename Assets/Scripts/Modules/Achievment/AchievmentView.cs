using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievmentView : MonoBehaviour
{
    [SerializeField]
    private GameObject _content;

    public void SetVisibility(bool _b)
    {
        _content.SetActive(_b);
    }

}
