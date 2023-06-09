using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intermediate : MonoBehaviour
{
    public int HP_Intermediate;
    public PLstatus.level Level_Intermediate;
    public NPCEvent First_Intermediate;　//会話内容ー最初
    public NPCEvent End_Intermediate;    //会話内容ー最後
    public List<int> Dack_Intermediate;

    //private void Start()
    //{
    //    HP_Intermediate = PLstatus.HP;
    //    Level_Intermediate = PLstatus.Level;
    //    First_Intermediate = PLstatus.First;
    //    End_Intermediate = PLstatus.End;
    //    Dack_Intermediate = PLstatus.Dack;
    //}
}
