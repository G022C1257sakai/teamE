using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1/11�X�V

public class StartView : MonoBehaviour
{
    //���ߏ����p
    public CanvasGroup CanGroup;

    /// <summary>
    /// ���̏�Ԃɖ߂�
    /// </summary>
    public void reset()
    {
        //�A���t�@�l��0�ɐݒ�i��\���j
        this.CanGroup.alpha = 0;
    }

    /// <summary>
    /// �A�N�e�B�u��Ԃɂ���
    /// </summary>
    public void Active()
    {
        //�A���t�@�l��1�ɐݒ�i�\���j
        this.CanGroup.alpha = 1;
    }

}
