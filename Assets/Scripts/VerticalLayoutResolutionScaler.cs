using UnityEngine;
using UnityEngine.UI;

namespace Core.Ui.Helpers.AdaptiveLayout
{
    [RequireComponent(typeof(VerticalLayoutGroup))]
    public class VerticalLayoutResolutionScaler : MonoBehaviour
    {
        [SerializeField]
        private VerticalLayoutGroup _verticalLayout;

        private Vector2 _referenceCellSize;
        private float _referenceSpacing;
        private RectOffset _referencePadding;

        private void OnValidate()
        {
            if (_verticalLayout == null)
                _verticalLayout = GetComponent<VerticalLayoutGroup>();
        }

        private void Awake()
        {
            if (_verticalLayout == null)
                _verticalLayout = GetComponent<VerticalLayoutGroup>();

            _referenceSpacing = _verticalLayout.spacing;
            _referencePadding = AdaptiveLayoutUtils.CopyRectOffset(_verticalLayout.padding);
        }

        private void OnEnable()
        {
            AdjustLayoutGroupForResolution();
        }

#if UNITY_EDITOR
        private void Update()
        {
            AdjustLayoutGroupForResolution();
        }
#endif

        private void AdjustLayoutGroupForResolution()
        {
            var diff = AdaptiveLayoutUtils.RatioDifferenceComparedToReference();
            _verticalLayout.spacing = _referenceSpacing * diff;
            AdaptiveLayoutUtils.CopyToRectOffsetWithMultiplier(_referencePadding, _verticalLayout.padding, diff);
            _verticalLayout.padding = _verticalLayout.padding;
        }
    }
}