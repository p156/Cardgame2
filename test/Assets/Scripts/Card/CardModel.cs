using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardModel
{
    public string name;
    public int ID;
    public int cardID;
    public CardEntity.属性 Class;
    public CardEntity.種類 Job;
    public int cost;
    public int jobPT;
    public Sprite icon;
    public string flavor;

    public CardModel(int cardID)
    {
        CardEntity cardEntity = Resources.Load<CardEntity>("CardEntityList/Card " + cardID);

        ID = cardID;
        name = cardEntity.cardname;
        Class = cardEntity.Class;
        Job = cardEntity.type;
        cost = cardEntity.cost;
        jobPT = cardEntity.jobPT;
        icon = cardEntity.icon;
        flavor = cardEntity.flavor;
    }
}