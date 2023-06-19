using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardModel
{
    public string name;
    public int ID;
    public int cardID;
    public CardEntity.Type Job;
    public int cost;
    public int jobPT;
    public Sprite icon;
    public string flavor;

    public CardModel(int cardID)
    {
        CardEntity cardEntity = Resources.Load<CardEntity>("CardEntityList/Card " + cardID);

        ID = cardID;
        name = cardEntity.cardname;
        Job = cardEntity.Job;
        cost = cardEntity.cost;
        jobPT = cardEntity.jobPT;
        icon = cardEntity.icon;
        flavor = cardEntity.flavor;
    }
}