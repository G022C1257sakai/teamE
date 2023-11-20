using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

// 11/17 更新

public class Card : MonoBehaviour
{

    //カードのID
    public int Id;

    // 表示するカードの画像
    public Image CardImage;

    //透過処理用
    public CanvasGroup CanGroup;

    //選択されているか判定
    private bool mIsSelected = false;

    public bool IsSelected => this.mIsSelected;

    //カード情報
    private CardData mData;

    // 座標情報
    public RectTransform mRt;



    //カードの設定
    public void Set(CardData data)
    {
        //カード情報を設定
        this.mData = data;

        //IDを設定する
        this.Id = data.Id;

        //表示する画像を設定する
        //初回は全て裏面表示とする
        this.CardImage.sprite = Resources.Load<Sprite>("Image/uracreate");

        //選択判定フラグを初期化する
        this.mIsSelected = false;

        //アルファ値を1に設定
        this.CanGroup.alpha = 1;

        //座標情報を取得しておく
        this.mRt = this.GetComponent<RectTransform>();

    }


    ///<summary>
    ///選択された時の処理
    ///</summary>
    public void OnClick()
    {
        //カードが表面になっていた場合は無効
        if (this.mIsSelected)
        {
            return;
        }

        Debug.Log("OnClick");

        //拡大処理を行う
        this.kakudai(() =>
        {         
            //回転処理を行う
            this.onRotate(() =>
            {
                //選択判定フラグを有効にする
                this.mIsSelected = true;

                //カードを表面にする
                this.CardImage.sprite = this.mData.ImgSprite;

                // Y座標をもとに戻す
                this.onReturnRotate(() =>
                {
                    //拡大を元に戻す
                    this.syusyuku(() =>
                    {
                        //選択したCardIdを保存
                        GameStateController.Instance.SelectedCardIdList.Add(this.mData.Id);
                    });
                });
            });
        });


        /*//Dotweenで回転処理を行う
        this.mRt.DORotate(new Vector3(0f, 90f, 0f), 0.2f)
            //回転が完了したら
            .OnComplete(() =>
            {
                //選択判定フラグを有効にする
                this.mIsSelected = true;

                //カードを表面にする
                this.CardImage.sprite = this.mData.ImgSprite;
                // Y座標をもとに戻す
                this.onReturnRotate();
            });*/

        /*//選択判定フラグを有効にする
        this.mIsSelected = true;

        //カードを表面にする
        this.CardImage.sprite = this.mData.ImgSprite;
        
        //選択したCardIdを保存
        GameStateController.Instance.SelectedCardIdList.Add(this.mData.Id);*/
    }

    ///<summary>
    ///カードを中央に拡大表示する
    /// </summary>
    private void kakudai(Action onComp)
    {

        //カードを中央に移動させる
        Vector3 hozon = this.transform.position;
        this.mRt.DOMove(new Vector3(0, 0, 0), 1);

        //カードを拡大させる
        this.mRt.DOScale(new Vector3(2,2,2),1)

            //拡大が終了したら
            .OnComplete(() =>
            {
                if (onComp != null)
                {
                    onComp();
                }
            });
    }

    ///<summary>
    ///カードを元に戻す
    /// </summary>
    private void syusyuku(Action onComp)
    {


        //カードを収縮させる
        this.mRt.DOScale(new Vector3(1, 1, 1), 1)
        //カードを元の位置に移動させる
        //this.mRt.DOMove(hozon , 1)

            //移動が終了したら
            .OnComplete(() =>
            {
                if (onComp != null)
                {
                    onComp();
                }
            });
    }



    ///<summary>
    ///カードの回転軸をもとに戻す
    /// </summary>
    private void onRotate(Action onComp)
    {
        //９０度回転する
        this.mRt.DORotate(new Vector3(0f, 90f, 0f), 0.2f)
            //回転が終了したら
            .OnComplete(() =>
            {
                if (onComp != null)
                {
                    onComp();
                }
            });
    }


    ///<summary>
    ///カードの回転軸をもとに戻す
    /// </summary>
    private void onReturnRotate(Action onComp)
    {
        this.mRt.DORotate(new Vector3(0f, 0f, 0f), 0.2f)
            //回転が終わったら
            .OnComplete(() =>
            {
                if (onComp != null)
                {
                    onComp();
                }
                //選択したCardIdを保存しよう
                //GameStateController.Instance.SelectedCardIdList.Add(this.mData.Id);
            });
    }



    /// <summary>
    /// カードを背面表記にする
    /// </summary>
    public void SetHide()
    {
        //９０度回転する
        this.onRotate(() =>
        {
            //判定フラグを初期化する
            this.mIsSelected = false;

            //カードを背面表示にする
            this.CardImage.sprite = Resources.Load<Sprite>("Image/uracreate");

            this.onReturnRotate(() =>
            {
                Debug.Log("onhide");
            });
        });

        /*// 判定フラグを初期化する
        this.mIsSelected = false;

        //カードを背面表示にする
        this.CardImage.sprite = Resources.Load<Sprite>("Image/uracreate");*/
    }

    /// <summary>
    /// カードを非表示にする
    /// </summary>
    public void SetInvisible()
    {
        //選択済み設定にする
        this.mIsSelected = true;

        //アルファ値を0に設定（非表示）
        this.CanGroup.alpha = 0;
    }

}


///<summary>
///カードの情報クラス
///</summary>
public class CardData {
    //カードのID //setしたデータを抽出する
    public int Id { get; private set; }
    //画像
    public Sprite ImgSprite { get; private set; }

    public CardData(int _id, Sprite _sprite) {
        this.Id = _id;
        this.ImgSprite = _sprite;
    }
}
