using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

// 1/11更新

public class GameSceneManager : MonoBehaviour
{
    //一致したカードリストID
    private List<int> mContainCardIdList = new List<int>();

    //カード生成マネージャクラス
    public CardCreateManager CardCreate;

    void Start()
    {
        //一致したカードIDリストを初期化
        this.mContainCardIdList.Clear();

        //カードリストを生成する
        this.CardCreate.CreateCard();
    }

    void Update()
    {
        //選択したカードが2枚以上になったら
        if (GameStateController.Instance.SelectedCardIdList.Count >= 2)
        {
            //最初に選択したCardIDを取得する
            int selectedId = GameStateController.Instance.SelectedCardIdList[0];
            Debug.Log($"Contains! {selectedId}");

            //２枚目のカードと一緒だったら
            if (selectedId == GameStateController.Instance.SelectedCardIdList[1])
            {
                Debug.Log($"Contains!{selectedId}");
                //一致したカードIDを保存する
                this.mContainCardIdList.Add(selectedId);
            }
            //カードの表示切替を行う
            this.CardCreate.HideCardList(this.mContainCardIdList);

            //選択したカードリストを初期化する
            GameStateController.Instance.SelectedCardIdList.Clear();
        }
    }
    //更新用
}
