using UnityEngine;

namespace Core.Ui.Helpers.AdaptiveLayout
{
    // LayoutGroup не умеют мен€ть spacing, padding, cellSize при изменении разрешени€, мы их научим :)
    public class AdaptiveLayoutUtils
    {
        // ѕример: (1920 / 1080) / (2560 / 1080) = 0.75 -> это множитель параметров LayoutGroup
        public static float RatioDifferenceComparedToReference()
        {
            const float referenceRatio = 1920f / 1080f;
            var currentRatio = (float)Screen.width / Screen.height;
            var ratioMul = currentRatio / referenceRatio;
            return ratioMul;
        }

        public static RectOffset CopyRectOffset(RectOffset rectOffset)
        {
            return new RectOffset(rectOffset.left, rectOffset.right, rectOffset.top, rectOffset.bottom);
        }

        public static void CopyToRectOffsetWithMultiplier(RectOffset from, RectOffset to, float mul)
        {
            to.left = (int)(from.left * mul);
            to.right = (int)(from.right * mul);
            to.top = (int)(from.top * mul);
            to.bottom = (int)(from.bottom * mul);
        }
    }
}