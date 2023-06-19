using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class battreManager : MonoBehaviour
{
    [SerializeField] private PLstatus.level Level_veiw;

    [Header("デッキ")]
    [SerializeField] private List<int> Dack_veiw;
    [SerializeField] private List<int> Trash_veiw;

    [Header("プレイヤーステータス")]
    [SerializeField] public Image PLimage;
    [SerializeField] private int HP_view;
    [SerializeField] public GameObject PL_HP;
    [SerializeField] private GameObject PL_hand;
    [SerializeField] private int PLHandNumber;
    [SerializeField] CardController cardPrefab;
    [SerializeField] Transform playerHand;

    [Header("エネミー&バトルステータス")]
    [SerializeField] private GameObject enemy_HP;
    [SerializeField] public Image Enemyimage;
    [SerializeField] private GameObject TurnEnd;
    [SerializeField] private GameObject ManaCostPanel;

    [Header("バトルステータス")]
    private bool turnflag;    //ターン開始フラグ


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (turnflag == false)
        {
            StartGame();
        }
        if (int.Parse(enemy_HP.GetComponentInChildren<TextMeshProUGUI>().text) <= 0)
        {
            //ゲーム終了処理
        }
        if (int.Parse(PL_HP.GetComponentInChildren<TextMeshProUGUI>().text) <= 0)
        {
            //ゲームオーバー
        }
    }
    
    //ターン開始時
    void StartGame()　
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
    
    //ターンエンド処理
    public void EndGame()
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

    //敵の攻撃
    public void EnemyAtack()
    {

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

    //カード生成時
    void CreateCard(int cardID, Transform place)
    {
        CardController card = Instantiate(cardPrefab, place);
        card.Init(cardID);
    }

}
