using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardView : MonoBehaviour
{
    public int ID;
    public CardEntity.属性 Class;
    public CardEntity.種類 Job;
    public int jobPT;
    public int cost;
    [SerializeField] Image iconImage;
    public string flavor;

    public void Show(CardModel cardModel) // cardModelのデータ取得と反映
    {
        ID = cardModel.ID;
        Class = cardModel.Class;
        Job = cardModel.Job;
        cost = cardModel.cost;
        jobPT = cardModel.jobPT;
        iconImage.sprite = cardModel.icon;
        flavor = cardModel.flavor;
    }
}