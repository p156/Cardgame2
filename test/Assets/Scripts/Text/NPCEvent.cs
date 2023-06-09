//NPCEvent.cs ��b�p�̃C�x���g�N���X�̒�`
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
    public EventActionType actionType; //�g�[�N���I������
    
    //�g�[�N
    public int Who;
    public int speech;
    [TextArea]
    public string talkText;
    [TextArea]
    public string RubytalkText;
    public bool Shakeflag;

    //�I����
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