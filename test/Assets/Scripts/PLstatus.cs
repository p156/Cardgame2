using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLstatus : MonoBehaviour
{
    public static int HP;
    public static level Level;
    public static NPCEvent First;　//会話内容ー最初
    public static NPCEvent End;    //会話内容ー最後
    public static List<int> Dack;

    [SerializeField] private int HP_state;
    [SerializeField] private level Level_state;
    [SerializeField] private NPCEvent First_state;　//会話内容ー最初
    [SerializeField] private NPCEvent End_state;    //会話内容ー最後
    [SerializeField] private List<int> Dack_state;

    private void Start()
    {
        HP = HP_state;
        Level = Level_state;
        First = First_state;
        End = End_state;
        Dack = Dack_state;
    }

    public enum level //ステージ
    {
        tutorial,
        floor1,
        floor2,
        floor3,
        floor4,
        floor5,
    }
}
