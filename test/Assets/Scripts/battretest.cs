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

    [Header("プレイヤーステータス")]
    [SerializeField] public Image PLimage;
    [SerializeField] private int HP_view;
    [SerializeField] public GameObject PL_HP;
    [SerializeField] private int PLHandNumber;
    [SerializeField] CardController cardPrefab;
    [SerializeField] Transform playerHand;


    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {

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
    }
    //カード生成時
    void CreateCard(int cardID, Transform place)
    {
        CardController card = Instantiate(cardPrefab, place);
        card.Init(cardID);
    }

}
