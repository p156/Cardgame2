using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardEntity", menuName = "Create CardEntity")]

public class CardEntity : ScriptableObject
{
    public enum Type
    {
        Attack,  // �U��
        Action,  // �s��
        Heel,    // ��
        Record,  // �W�Q
        Poison,  // ��
        Jamming, // �W�Q
        Special, // ����
    };

    public string cardname;
    public int cardID;
    public Type Job;
    public int cost;
    public int jobPT;
    public Sprite icon;
    [TextArea(3, 5)] public string flavor;
}