using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TalkDisplay : MonoBehaviour
{
    public NPCEvent texts;//Unity上で入力するstringの配列
    int textNumber;//何番目のtexts[]を表示させるか
    string displayText;//表示させるstring
    int textCharNumber;//何文字目をdisplayTextに追加するか
    int displayTextSpeed; //全体のフレームレートを落とす変数
    bool click;//クリック判定
    public bool textStop; //テキスト表示を始めるか

    bool onemove = true;
    
    bool buttonflag;

    [SerializeField] GameObject[] talkdisplay;
    [SerializeField] Sprite[] PCImage;
    [SerializeField] Sprite[] EnemyImage;
    [SerializeField] Sprite[] PCSelectImage;
    void Start()
    {

    }
    void Update()
    {
        if (textStop == false) //テキストを表示させるif文
        {
            displayTextSpeed++;
            if (displayTextSpeed % 10 == 0)//５回に一回プログラムを実行するif文
            {
                if (texts.actionList[textNumber].actionType == EventActionType.Talk)
                {
                    
                    if (textCharNumber != texts.actionList[textNumber].talkText.Length)//もし配列の文字列の文字が最後の文字じゃなければ
                    {
                        displayText = displayText + texts.actionList[textNumber].talkText[textCharNumber];//displayTextに文字を追加していく
                        textCharNumber = textCharNumber + 1;//次の文字にする

                    }
                    else//配列の中の文字列の文字が最後の文字だったら
                    {
                        if (textNumber != texts.actionList.Count - 1)//もし配列の中が最後のセリフじゃないときは
                        {
                            if (click == true)//クリックされた判定
                            {
                                displayText = "";//表示させる文字列を消す
                                textCharNumber = 0;//文字の番号を最初にする
                                textNumber = textNumber + 1;//次のセリフにする
                            }
                        }
                        else //もし配列の中が最後のセリフになったら
                        {
                            if (click == true) //クリックされた判定
                            {
                                displayText = ""; //表示させる文字列も消す
                                textCharNumber = 0; //文字の番号を最初にする
                                textStop = true; //セリフ表示を止める
                            }
                        }
                    }

                    if (textNumber % talkdisplay.Length == 0) //吹き出しが全部trueになったら全部消す
                    {
                        for (int i = 0; i < talkdisplay.Length; i++)
                        {
                            talkdisplay[i].SetActive(false);
                        }
                    }
                }
                //選択肢編
                else if (texts.actionList[textNumber].actionType == EventActionType.Choices)
                {

                }

                if(onemove == true) //一回だけ動かす　固定数値のみ
                {
                    if (texts.actionList[textNumber].Who == 0)
                    {
                        talkdisplay[textNumber % talkdisplay.Length].transform.localScale = new Vector3(-1, 1, 1);
                        talkdisplay[textNumber % talkdisplay.Length].transform.GetChild(0).localScale = new Vector3(-1, 1, 1);
                    }
                    if (texts.actionList[textNumber].Who == 1)
                    {
                        talkdisplay[textNumber % talkdisplay.Length].transform.localScale = new Vector3(1, 1, 1);
                        talkdisplay[textNumber % talkdisplay.Length].transform.GetChild(0).localScale = new Vector3(1, 1, 1);
                    }
                    onemove = false;
                }

                Imgalpha(textNumber);
                talkdisplay[textNumber % talkdisplay.Length].SetActive(true);
                talkdisplay[textNumber % talkdisplay.Length].GetComponentInChildren<RubyTextMeshProUGUI>().UnditedText = displayText;//画面上にdisplayTextを表示
                click = false;//クリックされた判定を解除
            }
            if (Input.GetMouseButtonDown(0))//マウスをクリックしたら
            {
                onemove = true;
                click = true; //クリックされた判定にする
            }
        }
        else
        {
            for (int i = 0; i < talkdisplay.Length; i++)
            {
                talkdisplay[i].SetActive(false);
                textNumber = 0;
                textStop = false;
                GameObject.Find("GameManager").GetComponent<GameManager>().talkendflag = true;
            }
        }
    }
    private void Imgalpha(int number)//色の濃さ
    {
        if (texts.actionList[number].actionType == EventActionType.Talk)
        {
            if (texts.actionList[number].Who == 0)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().PLimage.GetComponent<Image>().color = Color.gray;
                GameObject.Find("GameManager").GetComponent<GameManager>().Enemyimage.GetComponent<Image>().color = Color.white;

            }
            else if (texts.actionList[number].Who == 1)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().PLimage.GetComponent<Image>().color = Color.white;
                GameObject.Find("GameManager").GetComponent<GameManager>().Enemyimage.GetComponent<Image>().color = Color.gray;
            }
        }
        else if (texts.actionList[number].actionType == EventActionType.Choices)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().PLimage.GetComponent<Image>().color = Color.white;
            GameObject.Find("GameManager").GetComponent<GameManager>().Enemyimage.GetComponent<Image>().color = Color.gray;
        }
    }
}