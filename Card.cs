using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

// 11/17 �X�V

public class Card : MonoBehaviour
{

    //�J�[�h��ID
    public int Id;

    // �\������J�[�h�̉摜
    public Image CardImage;

    //���ߏ����p
    public CanvasGroup CanGroup;

    //�I������Ă��邩����
    private bool mIsSelected = false;

    public bool IsSelected => this.mIsSelected;

    //�J�[�h���
    private CardData mData;

    // ���W���
    public RectTransform mRt;



    //�J�[�h�̐ݒ�
    public void Set(CardData data)
    {
        //�J�[�h����ݒ�
        this.mData = data;

        //ID��ݒ肷��
        this.Id = data.Id;

        //�\������摜��ݒ肷��
        //����͑S�ė��ʕ\���Ƃ���
        this.CardImage.sprite = Resources.Load<Sprite>("Image/uracreate");

        //�I�𔻒�t���O������������
        this.mIsSelected = false;

        //�A���t�@�l��1�ɐݒ�
        this.CanGroup.alpha = 1;

        //���W�����擾���Ă���
        this.mRt = this.GetComponent<RectTransform>();

    }


    ///<summary>
    ///�I�����ꂽ���̏���
    ///</summary>
    public void OnClick()
    {
        //�J�[�h���\�ʂɂȂ��Ă����ꍇ�͖���
        if (this.mIsSelected)
        {
            return;
        }

        Debug.Log("OnClick");

        //�g�又�����s��
        this.kakudai(() =>
        {         
            //��]�������s��
            this.onRotate(() =>
            {
                //�I�𔻒�t���O��L���ɂ���
                this.mIsSelected = true;

                //�J�[�h��\�ʂɂ���
                this.CardImage.sprite = this.mData.ImgSprite;

                // Y���W�����Ƃɖ߂�
                this.onReturnRotate(() =>
                {
                    //�g������ɖ߂�
                    this.syusyuku(() =>
                    {
                        //�I������CardId��ۑ�
                        GameStateController.Instance.SelectedCardIdList.Add(this.mData.Id);
                    });
                });
            });
        });


        /*//Dotween�ŉ�]�������s��
        this.mRt.DORotate(new Vector3(0f, 90f, 0f), 0.2f)
            //��]������������
            .OnComplete(() =>
            {
                //�I�𔻒�t���O��L���ɂ���
                this.mIsSelected = true;

                //�J�[�h��\�ʂɂ���
                this.CardImage.sprite = this.mData.ImgSprite;
                // Y���W�����Ƃɖ߂�
                this.onReturnRotate();
            });*/

        /*//�I�𔻒�t���O��L���ɂ���
        this.mIsSelected = true;

        //�J�[�h��\�ʂɂ���
        this.CardImage.sprite = this.mData.ImgSprite;
        
        //�I������CardId��ۑ�
        GameStateController.Instance.SelectedCardIdList.Add(this.mData.Id);*/
    }

    ///<summary>
    ///�J�[�h�𒆉��Ɋg��\������
    /// </summary>
    private void kakudai(Action onComp)
    {

        //�J�[�h�𒆉��Ɉړ�������
        Vector3 hozon = this.transform.position;
        this.mRt.DOMove(new Vector3(0, 0, 0), 1);

        //�J�[�h���g�傳����
        this.mRt.DOScale(new Vector3(2,2,2),1)

            //�g�傪�I��������
            .OnComplete(() =>
            {
                if (onComp != null)
                {
                    onComp();
                }
            });
    }

    ///<summary>
    ///�J�[�h�����ɖ߂�
    /// </summary>
    private void syusyuku(Action onComp)
    {


        //�J�[�h�����k������
        this.mRt.DOScale(new Vector3(1, 1, 1), 1)
        //�J�[�h�����̈ʒu�Ɉړ�������
        //this.mRt.DOMove(hozon , 1)

            //�ړ����I��������
            .OnComplete(() =>
            {
                if (onComp != null)
                {
                    onComp();
                }
            });
    }



    ///<summary>
    ///�J�[�h�̉�]�������Ƃɖ߂�
    /// </summary>
    private void onRotate(Action onComp)
    {
        //�X�O�x��]����
        this.mRt.DORotate(new Vector3(0f, 90f, 0f), 0.2f)
            //��]���I��������
            .OnComplete(() =>
            {
                if (onComp != null)
                {
                    onComp();
                }
            });
    }


    ///<summary>
    ///�J�[�h�̉�]�������Ƃɖ߂�
    /// </summary>
    private void onReturnRotate(Action onComp)
    {
        this.mRt.DORotate(new Vector3(0f, 0f, 0f), 0.2f)
            //��]���I�������
            .OnComplete(() =>
            {
                if (onComp != null)
                {
                    onComp();
                }
                //�I������CardId��ۑ����悤
                //GameStateController.Instance.SelectedCardIdList.Add(this.mData.Id);
            });
    }



    /// <summary>
    /// �J�[�h��w�ʕ\�L�ɂ���
    /// </summary>
    public void SetHide()
    {
        //�X�O�x��]����
        this.onRotate(() =>
        {
            //����t���O������������
            this.mIsSelected = false;

            //�J�[�h��w�ʕ\���ɂ���
            this.CardImage.sprite = Resources.Load<Sprite>("Image/uracreate");

            this.onReturnRotate(() =>
            {
                Debug.Log("onhide");
            });
        });

        /*// ����t���O������������
        this.mIsSelected = false;

        //�J�[�h��w�ʕ\���ɂ���
        this.CardImage.sprite = Resources.Load<Sprite>("Image/uracreate");*/
    }

    /// <summary>
    /// �J�[�h���\���ɂ���
    /// </summary>
    public void SetInvisible()
    {
        //�I���ςݐݒ�ɂ���
        this.mIsSelected = true;

        //�A���t�@�l��0�ɐݒ�i��\���j
        this.CanGroup.alpha = 0;
    }

}


///<summary>
///�J�[�h�̏��N���X
///</summary>
public class CardData {
    //�J�[�h��ID //set�����f�[�^�𒊏o����
    public int Id { get; private set; }
    //�摜
    public Sprite ImgSprite { get; private set; }

    public CardData(int _id, Sprite _sprite) {
        this.Id = _id;
        this.ImgSprite = _sprite;
    }
}
