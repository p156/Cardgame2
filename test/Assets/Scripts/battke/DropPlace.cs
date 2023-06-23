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

    public void Start()
    {
        LeaderText.text = Convert.ToString(LeaderHP);
    }

    public void OnDrop(PointerEventData eventData) // ドロップされた時に行う処理
    {
        CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>(); // ドラッグしてきた情報からCardMovementを取得
        if (card != null) // もしカードがあれば、
        {
            CardView cardView = card.GetComponent<CardView>();
            switch(cardView.ID)
            {
                case 1://鎮圧射撃
                case 2:
                case 3:
                    LeaderHP = LeaderHP - cardView.jobPT;
                    LeaderText.text = Convert.ToString(LeaderHP);
                    break;
                case 4://情報操作
                case 5:
                case 6:
                    LeaderHP = LeaderHP - cardView.jobPT;
                    LeaderText.text = Convert.ToString(LeaderHP);
                    break;
                case 7://原因究明
                case 8:
                case 9:
                    LeaderHP = LeaderHP - cardView.jobPT;
                    LeaderText.text = Convert.ToString(LeaderHP);
                    break;

                case 10: //応急薬
                case 11:
                case 12:
                    LeaderHP = LeaderHP + cardView.jobPT;
                    LeaderText.text = Convert.ToString(LeaderHP);
                    break;

                case 13: //警戒
                case 14:
                case 15:
                   //防護点の導入
                    break;
                
                case 16: //抗生薬品
                case 17:
                case 18:
                   //デバフを消す
                    break;
                
                case 19: //計画
                case 20:
                case 21:
                   //山札系、効果はdiscordを見る
                    break;

                case 22: //探索
                case 23:
                case 24:
                   //手札　ドロー
                    break;






                default://エラー回避
                    Debug.Log(cardView.ID);
                    break;
            }

            //card.cardParent = this.transform; // カードの親要素を自分（アタッチされてるオブジェクト）にする
        }
    }
}
