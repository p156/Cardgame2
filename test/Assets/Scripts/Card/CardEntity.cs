using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardEntity", menuName = "Create CardEntity")]

public class CardEntity : ScriptableObject
{
    public enum 属性
    {
        ー,
        抑止,
        秘匿,
        解析,
    };

    public enum 種類
    {
        行動,  // 攻撃
        スキル,  // 行動
    };

    public string cardname;
    public int cardID;
    public int cost;
    public 属性 Class;
    public 種類 type;
    public int jobPT;
    public Sprite icon;
    [TextArea(3, 5)] public string flavor;
}