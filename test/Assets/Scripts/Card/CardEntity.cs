using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardEntity", menuName = "Create CardEntity")]

public class CardEntity : ScriptableObject
{
    public enum Type
    {
        Attack,  // UŒ‚
        Action,  // s“®
        Heel,    // ‰ñ•œ
        Record,  // –WŠQ
        Poison,  // “Å
        Jamming, // –WŠQ
        Special, // “Áê
    };

    public string cardname;
    public int cardID;
    public Type Job;
    public int cost;
    public int jobPT;
    public Sprite icon;
    [TextArea(3, 5)] public string flavor;
}