using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool talkendflag;       //会話終了フラグ
    [SerializeField] Intermediate Status;
    [SerializeField] private state Now;
    [SerializeField] private PLstatus.level Level_veiw;


    [Header("ステージ詳細")]
    [Space(10)]

    [Header("キャラステータス")]
    [SerializeField] public Image PLimage;
    [SerializeField] public Image Enemyimage;

    [Header("ストーリーのUI")]
    [SerializeField] private GameObject talk;

    void Start()
    {
        //非表示 & 初期化
    }

    private void Update()
    {

        if (Now == state.starttalk)//最初のトーク
        {
           
        }
        if (Now == state.battle)//バトル
        {
            
        }
 
    }
    //トーク前にUIを消すもの
    void TalkMordchange()
    {

    }

    //バトル前にUIを消すもの
    void battleMordchange()
    {
        
    }





    public enum state //状態
    {
        starttalk,
        battle,
        endtalk,
    }

}
