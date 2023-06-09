//NPCEvent.cs 会話用のイベントクラスの定義
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[Serializable]

[CreateAssetMenu(fileName = "TarkEntity", menuName = "CreatTarkEntity")]

public class NPCEvent : ScriptableObject
{
    public int test;
    public Sprite My;
    public Sprite Enemy;
    public List<EventActionData> actionList;

}

[Serializable]
public class EventActionData
{
    public EventActionType actionType; //トークか選択肢か
    
    //トーク
    public int Who;
    public int speech;
    [TextArea]
    public string talkText;
    [TextArea]
    public string RubytalkText;
    public bool Shakeflag;

    //選択肢
    public string Choices1Name;
    [TextArea]
    public string Choices1;
    public string Choices2Name;
    [TextArea]
    public string Choices2;
    public string Choices3Name;
    [TextArea]
    public string Choices3;
}
public enum EventActionType
{
    Talk,
    Choices
}