using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class CardCreateManager : MonoBehaviour
{
    //��������Card�I�u�W�F�N�g
    public Card CardPrefad;

    //�u�J�[�h�v�𐶐�����e�I�u�W�F�N�g
    public RectTransform CardCreateParent;

    //���������J�[�h�I�u�W�F�N�g��ۑ�����
    public List<Card> CardList = new List<Card> ();

    //�J�[�h�̏��̏��ʂ������_���ɕύX�������X�g
    private List<CardData> mRandomCardDataList = new List<CardData> ();

    //GrodLayoutGroup
    public GridLayoutGroup GridLayout;

    //�J�[�h�z��̃C���f�b�N�X
    private int mIndex;

    //�J�[�h�𐶐�����Ƃ��̍����C���f�b�N�X
    private int mHelgthIdx;
    //�J�[�h�𐶐�����Ƃ��̕��C���f�b�N�X
    private int mWidthIdx;

    //�J�[�h�̐����A�j���[�V�����̃A�j���[�V��������
    private readonly float DEAL_CARD_TIME = 1f;



    /// <summary>
    ///�J�[�h�𐶐�����
    /// </summary>
    public void CreateCard()
    {
        //�J�[�h��񃊃X�g
        List<CardData> cardDataList = new List<CardData>();

        //�\������J�[�h�摜���̃��X�g
        List<Sprite> imgList = new List<Sprite>();

        //Resources/Image�t�H���_���ɂ���摜���擾����
        imgList.Add(Resources.Load<Sprite>("Image/1gatu_huda"));
        imgList.Add(Resources.Load<Sprite>("Image/1gatu_turu"));
        imgList.Add(Resources.Load<Sprite>("Image/2gatu_huda"));
        imgList.Add(Resources.Load<Sprite>("Image/2gatu_tori"));

        //for���񂷉񐔂��擾����
        int loopCnt = imgList.Count;

        for (int i = 0; i < loopCnt; i++)
        {
            //�J�[�h���𐶐�����
            CardData cardata = new CardData(i, imgList[i]);
            cardDataList.Add(cardata);
        }

        this.mIndex = 0;
        this.mHelgthIdx = 0;
        this.mWidthIdx = 0;

        //���������J�[�h���X�g2���̃��X�g�𐶐�����
        List<CardData> SumCardDataList = new List<CardData>();
        //SumCardDataList.AddRange(cardDataList);
        SumCardDataList.AddRange(cardDataList);

        //�����_�����X�g�̏�����
        this.mRandomCardDataList.Clear();

        //���X�g�̒��g�������_���ɍĔz�u����
        /*List<CardData> randomCardDataList = SumCardDataList.OrderBy(a => Guid.NewGuid()).ToList();*/
        this.mRandomCardDataList = SumCardDataList.OrderBy(a => Guid.NewGuid()).ToList();
        this.mRandomCardDataList.AddRange(SumCardDataList.OrderBy(a => Guid.NewGuid()).ToList());

        //GridLayout�𖳌�
        this.GridLayout.enabled = false;

        //�J�[�h��z��A�j���[�V��������
        this.mSetDealCardAnime();

        Debug.Log("a");


        //�J�[�h�I�u�W�F�N�g�𐶐�����
        /*foreach (var _cardData in randomCardDataList)
        {
            //Instantiate��Card�I�u�W�F�N�g�𐶐�
            Card card = Instantiate<Card>(this.CardPrefad, this.CardCreateParent);

            //�f�[�^��ݒ肷��
            card.Set(_cardData);

            //���������J�[�h�I�u�W�F�N�g��ۑ�����
            this.CardList.Add(card);
        }*/
    }



    /// <summary>
    ///�擾���Ă��Ȃ��J�[�h��w�ʂɂ���
    /// </summary>
    public void HideCardList(List<int> containCardIdList)
    {
        foreach (var _card in this.CardList)
        {
            //���łɊl�������J�[�hID�̏ꍇ�A��\���ɂ���
            if (containCardIdList.Contains(_card.Id))
            {
                //�J�[�h���\���ɂ���
                _card.SetInvisible();
            }
            //�J�[�h���\�� && �l�����Ă��Ȃ��J�[�h�͗��ʕ\���ɂ���
            else�@if(_card.IsSelected)
            {
                //�J�[�h�𗠖ʕ\���ɂ���
                _card.SetHide();

            }
        }
    }


    ///<summary>
    ///�J�[�h��z��A�j���[�V��������
    /// </summary>
    private void mSetDealCardAnime()
    {
        var _cardData = this.mRandomCardDataList[this.mIndex];

        //Instantiate��Card�I�u�W�F�N�g�𐶐�
        Card card = Instantiate<Card>(this.CardPrefad, this.CardCreateParent);
        
        //�f�[�^��ݒ肷��
        card.Set(_cardData);
        //�J�[�h�̏����l��ݒ�(��ʊO�ɂ���)
        card.mRt.anchoredPosition = new Vector2(1900, 0f);
        //�T�C�Y��GridLayout��CellSize�ɐݒ�
        card.mRt.sizeDelta = this.GridLayout.cellSize;

        //�J�[�h�̈ړ����ݒ�
        float posX = (this.GridLayout.cellSize.x * this.mWidthIdx) + (this.GridLayout.spacing.x * (this.mWidthIdx + 1)); //�����ʒu�Ƃ���335�ɂȂ�悤�C������
        float posY = ((this.GridLayout.cellSize.y * this.mHelgthIdx) + (this.GridLayout.spacing.y * this.mHelgthIdx)) * -1f;�@//�����ʒu�Ƃ���0�ɂȂ�悤����

        //DOAnchorPos�ŃA�j���[�V�������s��
        card.mRt.DOAnchorPos(new Vector2(posX, posY), this.DEAL_CARD_TIME)
            //�A�j���[�V�������I��������
            .OnComplete(() =>
            {
                //���������J�[�h�I�u�W�F�N�g��ۑ�����
                this.CardList.Add(card);

                //��������J�[�h�f�[�^���X�g�̃C���f�b�N�X���X�V
                this.mIndex++;
                this.mWidthIdx++;

                //�����C���f�b�N�X�����X�g�̍ő�l���}������
                if (this.mIndex >= this.mRandomCardDataList.Count) 
                {
                    //GridLayout��L���ɂ��A�����������I������
                    this.GridLayout.enabled = true;
                }
                else
                {
                    //GridLayout�̐܂�Ԃ��n�_�ɗ�����
                    if(this.mIndex % this.GridLayout.constraintCount == 0)
                    {
                        //�����̐��������X�V
                        this.mHelgthIdx++;
                        this.mWidthIdx = 0;
                    }
                    //�A�j���[�V�����������ċA��������
                    this.mSetDealCardAnime();
                }
            });
    }
}
