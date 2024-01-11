using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

// 1/11�X�V

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

    //�����\�����Ă���J�[�h�̔���
    private bool dIsSelected = false;

    //�J�[�h���
    private CardData mData;

    // ���W���
    public RectTransform mRt;

    //�ړ��O�̍��W�ۑ��ϐ�
    private Vector3 sevepos;











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

        //�����\���t���O������������
        this.dIsSelected = true;

        //�A���t�@�l��1�ɐݒ�
        this.CanGroup.alpha = 1;

        //���W�����擾���Ă���
        this.mRt = this.GetComponent<RectTransform>();
    }

    //�R�[���`���J�n
    public void OnClick()
    {
        StartCoroutine(CardMove());
        Debug.Log("OnClick");
    }


    ///<summary>
    ///�I�����ꂽ���̏���
    ///</summary>
    public IEnumerator CardMove()
    {


        //�J�[�h���\�ʂɂȂ��Ă����ꍇ�͖���
        if (this.mIsSelected)
        {
            yield break;
        }




        //�������W�̎擾
        sevepos = transform.localPosition;


        //�����Ɋg��\������
        this.center(() =>
        {
            //�����\���t���O��L���ɂ���
            this.dIsSelected = false;

        });

        //�N���b�N�ҋ@
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        //�J�[�h���\�ʂɂȂ��Ă����ꍇ�͖���
        if (this.dIsSelected && this.mIsSelected)
        {
            yield break;
        }

        //��]�������s��
        this.onRotate(() => {

            //�I�𔻒�t���O��L���ɂ���
            this.mIsSelected = true;

            //�J�[�h��\�ʂɂ���
            this.CardImage.sprite = this.mData.ImgSprite;


            // Y���W�����Ƃɖ߂�
            this.onReturnRotate(() => {

                //�I������CardId��ۑ�
                GameStateController.Instance.SelectedCardIdList.Add(this.mData.Id);
            });


        });

        //���̈ʒu�ɖ߂�
        this.former(() =>
        {
            //�����\���t���O��L���ɂ���
            this.dIsSelected = true;
        });
    }



    /*///<summary>
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

        //�������W�̎擾
        sevepos = transform.localPosition;


        //�����Ɋg��\������
        this.center(() =>
        {
            //�����\���t���O��L���ɂ���
            this.dIsSelected = false;

        });


    }

    public void OnSecondClick()
    {

        //�J�[�h���\�ʂɂȂ��Ă����ꍇ�͖���
        if (this.dIsSelected && this.mIsSelected)
        {
            return;
        }

        //��]�������s��
        this.onRotate(() => {

            //�I�𔻒�t���O��L���ɂ���
            this.mIsSelected = true;

            //�J�[�h��\�ʂɂ���
            this.CardImage.sprite = this.mData.ImgSprite;


            // Y���W�����Ƃɖ߂�
            this.onReturnRotate(() => {

                //�I������CardId��ۑ�
                GameStateController.Instance.SelectedCardIdList.Add(this.mData.Id);
            });


        });

        //���̈ʒu�ɖ߂�
        this.former(() =>
        {
            //�����\���t���O��L���ɂ���
            this.dIsSelected = true;
        });

    }*/








    ///<summary>
    ///�J�[�h�𒆉��Ɋg��\������
    /// </summary>
    private void center(Action onComp)
    {

        var sequence = DOTween.Sequence();
        sequence.Append(

        //�J�[�h���g�傳����
        this.mRt.DOScale(new Vector3(2f, 2f, 2f), 1f)

        );

        //  Join()�Œǉ�����
        sequence.Join(

        //�J�[�h�𒆉��Ɉړ�������
        this.mRt.DOLocalMove(new Vector3(0f, 0f), 1f)

            )

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
    private void former(Action onComp)
    {
        var sequence = DOTween.Sequence();
        sequence.Append(


        //�J�[�h�����k������
        this.mRt.DOScale(new Vector3(1f, 1f, 1f), 1f)

        );

        //  Join()�Œǉ�����
        sequence.Join(

        //�J�[�h�����Ƃ̈ʒu�ɖ߂�
        this.mRt.DOLocalMove(sevepos, 1f)

        )

            //�ړ����I��������
            .OnComplete(() =>
            {
                if (onComp != null)
                {
                    Debug.Log("OnComp");
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
public class CardData
{
    //�J�[�h��ID //set�����f�[�^�𒊏o����
    public int Id { get; private set; }
    //�摜
    public Sprite ImgSprite { get; private set; }

    public CardData(int _id, Sprite _sprite)
    {
        this.Id = _id;
        this.ImgSprite = _sprite;
    }
}
