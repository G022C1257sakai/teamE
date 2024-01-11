using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1/11更新

public class HudaMozi : MonoBehaviour
{
    //透過処理用
    public CanvasGroup CanGroup;


    /// <summary>
    /// 非表示にする
    /// </summary>
    public void SetInvisible()
    {
        //アルファ値を0に設定（非表示）
        this.CanGroup.alpha = 0;
    }

    /// <summary>
    /// 元の状態に戻す
    /// </summary>
    public void reset()
    {
        //アルファ値を1に設定（表示）
        this.CanGroup.alpha = 1;
    }

}