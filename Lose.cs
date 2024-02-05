using UnityEngine;
using DG.Tweening;

public class Lose: MonoBehaviour
{
    public RectTransform objectToMove;
    public float duration = 1.0f;
    public float startY = 200f; // 上端のY座標
    public float endY = -200f; // 下端のY座標

    void Start()
    {
        // 初期位置を設定
        objectToMove.anchoredPosition = new Vector2(objectToMove.anchoredPosition.x, startY);

        // DOTweenを使って上から下への移動を設定
        objectToMove.DOAnchorPosY(endY, duration)
            .SetEase(Ease.OutBounce); // out bounceのイージングを設定
    }

}