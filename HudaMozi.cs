using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1/11�X�V

public class HudaMozi : MonoBehaviour
{
    //���ߏ����p
    public CanvasGroup CanGroup;


    /// <summary>
    /// ��\���ɂ���
    /// </summary>
    public void SetInvisible()
    {
        //�A���t�@�l��0�ɐݒ�i��\���j
        this.CanGroup.alpha = 0;
    }

    /// <summary>
    /// ���̏�Ԃɖ߂�
    /// </summary>
    public void reset()
    {
        //�A���t�@�l��1�ɐݒ�i�\���j
        this.CanGroup.alpha = 1;
    }

}