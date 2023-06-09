using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool talkendflag;       //会話終了フラグ
    private bool turnflag;    //ターン開始フラグ
    [SerializeField] Intermediate Status;
    [SerializeField] private state Now;

    [Header("ステージ詳細")]
    [Space(10)]

    [Header("デッキ")]
    [SerializeField] private List<int> Dack_veiw;
    [SerializeField] private List<int> Trash_veiw;

    [Header("キャラステータス")]
    [SerializeField] public Image PLimage;
    [SerializeField] private int HP_view;
    [SerializeField] private PLstatus.level Level_veiw;
    [SerializeField] public GameObject PL_HP;
    [SerializeField] private GameObject PL_hand;
    [SerializeField] private int PLHandNumber;


    [Header("エネミー&バトルステータス")]
    [SerializeField] public Image Enemyimage;
    [SerializeField] private GameObject enemy_HP;
    [SerializeField] private GameObject TurnEnd;
    [SerializeField] private GameObject ManaCostPanel;

    [Header("メインゲームのカード系")]
    [SerializeField] CardController cardPrefab;
    [SerializeField] Transform playerHand;

    [Header("ストーリーのUI")]
    [SerializeField] private GameObject talk;

    void Start()
    {
        //非表示 & 初期化
        HP_view = Status .HP_Intermediate;
        Level_veiw = Status.Level_Intermediate;
        Dack_veiw = Status.Dack_Intermediate;

        talkendflag = false;
        Now = state.starttalk;
        Shuffle();

        PL_HP.SetActive(false);
        PL_hand.SetActive(false);
        enemy_HP.SetActive(false);
        TurnEnd.SetActive(false);
        ManaCostPanel.SetActive(false);
        talk.SetActive(false);
    }

    private void Update()
    {

        if (Now == state.starttalk)//最初のトーク
        {
            talk.GetComponent<TalkDisplay>().texts = Status.First_Intermediate;
            PLimage.sprite = Status.First_Intermediate.My;
            Enemyimage.sprite = Status.First_Intermediate.Enemy;
            talk.SetActive(true);
            if (talkendflag == true)
            {
                talkendflag = false;
                talk.SetActive(false);
                Now = state.battle;
            }
        }
        if (Now == state.battle)//バトル
        {
            if (turnflag == false)
            {
                battleMordchange();
                StartGame();
            }
            if (int.Parse(enemy_HP.GetComponentInChildren<TextMeshProUGUI>().text) <= 0)
            {
                TalkMordchange();
                Now = state.endtalk;
                //ゲーム終了処理
            }
            if (int.Parse(PL_HP.GetComponentInChildren<TextMeshProUGUI>().text) <= 0) 
            {
                //ゲームオーバー
            }
        }
        if (Now == state.endtalk)//最後のトーク
        {
            talk.GetComponent<TalkDisplay>().texts = Status.End_Intermediate;
            talk.SetActive(true);
            if (talkendflag == true)
            {
                //シーン移動
            }
        }
    }

    void battleMordchange()
    {
        PL_HP.SetActive(true);
        PL_hand.SetActive(true);
        enemy_HP.SetActive(true);
        TurnEnd.SetActive(true);
        ManaCostPanel.SetActive(true);
    }

    void TalkMordchange()
    {
        PL_HP.SetActive(false);
        PL_hand.SetActive(false);
        enemy_HP.SetActive(false);
        TurnEnd.SetActive(false);
        ManaCostPanel.SetActive(false);
    }

    void StartGame()　//ターン開始時
    {
        int i = 0;
        while (i < PLHandNumber)
        {
            CreateCard(Dack_veiw[0], playerHand);
            Dack_veiw.RemoveAt(0);
            i++;
        }

        turnflag = true;
    }

    public void EndGame()//ターンエンド処理
    {
        int i = 0;
        while (i < PLHandNumber)
        {
            GameObject card = playerHand.GetChild(i).gameObject;
            Trash_veiw.Add(card.GetComponent<CardView>().ID);
            Destroy(card);
            i++;
        }

        EnemyAtack(); //敵の攻撃
        StartGame();//ドロー
    }

    public void EnemyAtack()
    {

    }

    void CreateCard(int cardID, Transform place)　//カード生成時
    {
        CardController card = Instantiate(cardPrefab, place);
        card.Init(cardID);
    }

    void Shuffle() // デッキをシャッフルする
    {
        // 整数 n の初期値はデッキの枚数
        int n = Dack_veiw.Count;

        // nが1より小さくなるまで繰り返す
        while (n > 1)
        {
            n--;

            // kは 0 ～ n+1 の間のランダムな値
            int k = UnityEngine.Random.Range(0, n + 1);

            // k番目のカードをtempに代入
            int temp = Dack_veiw[k];
            Dack_veiw[k] = Dack_veiw[n];
            Dack_veiw[n] = temp;
        }
    }

    public enum state //状態
    {
        starttalk,
        battle,
        endtalk,
    }

}
