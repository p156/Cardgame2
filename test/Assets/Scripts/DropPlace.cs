using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DropPlace : MonoBehaviour, IDropHandler
{
    [SerializeField] TextMeshProUGUI LeaderText;
    [SerializeField] int LeaderHP = 10;
    [SerializeField] ParticleSystem healeffect;

    public void Start()
    {
        LeaderText.text = Convert.ToString(LeaderHP);
        healeffect.Stop();
    }

    public void OnDrop(PointerEventData eventData) // �h���b�v���ꂽ���ɍs������
    {
        CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>(); // �h���b�O���Ă�����񂩂�CardMovement���擾
        if (card != null) // �����J�[�h������΁A
        {
            CardView cardView = card.GetComponent<CardView>();
            switch(cardView.ID)
            {
                case 1: //�e
                    LeaderHP = LeaderHP - cardView.jobPT;
                    LeaderText.text = Convert.ToString(LeaderHP);
                    //iTween.ShakePosition(gameObject, iTween.Hash("x", 0.5f, "y", 0.5f, "time", 0.5f));
                    break;
                case 2: //�񕜖�
                    LeaderHP = LeaderHP + cardView.jobPT;
                    LeaderText.text = Convert.ToString(LeaderHP);
                    healeffect.Play(true);
                    Invoke("healdff", 1.0f);
                    break;
            }

            //card.cardParent = this.transform; // �J�[�h�̐e�v�f�������i�A�^�b�`����Ă�I�u�W�F�N�g�j�ɂ���
        }
    }
    private void healdff()
    {
        healeffect.Stop();
    }
}
