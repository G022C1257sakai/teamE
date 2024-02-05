using UnityEngine;
using DG.Tweening;

public class Lose: MonoBehaviour
{
    public RectTransform objectToMove;
    public float duration = 1.0f;
    public float startY = 200f; // ��[��Y���W
    public float endY = -200f; // ���[��Y���W

    void Start()
    {
        // �����ʒu��ݒ�
        objectToMove.anchoredPosition = new Vector2(objectToMove.anchoredPosition.x, startY);

        // DOTween���g���ďォ�牺�ւ̈ړ���ݒ�
        objectToMove.DOAnchorPosY(endY, duration)
            .SetEase(Ease.OutBounce); // out bounce�̃C�[�W���O��ݒ�
    }

}