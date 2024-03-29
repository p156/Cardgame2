using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    public NPCEvent texts;//Unity上で入力するstringの配列
    int textNumber;//何番目のtexts[]を表示させるか
    string displayText;//表示させるstring
    int textCharNumber;//何文字目をdisplayTextに追加するか
    int displayTextSpeed; //全体のフレームレートを落とす変数
    bool click;//クリック判定
    bool textStop; //テキスト表示を始めるか
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
                    if (textCharNumber != texts.actionList[textNumber].talkText.Length)//もしtext[textNumber]の文字列の文字が最後の文字じゃなければ
                    {
                        displayText = displayText + texts.actionList[textNumber].talkText[textCharNumber];//displayTextに文字を追加していく
                        textCharNumber = textCharNumber + 1;//次の文字にする
                        if (textCharNumber == texts.actionList[textNumber].talkText.Length)
                        {
                            displayText = texts.actionList[textNumber].RubytalkText;
                        }
                    }
                    else//もしtext[textNumber]の文字列の文字が最後の文字だったら
                    {
                        if (textNumber != texts.actionList.Count - 1)//もしtexts[]が最後のセリフじゃないときは
                        {
                            if (click == true)//クリックされた判定
                            {
                                displayText = "";//表示させる文字列を消す
                                textCharNumber = 0;//文字の番号を最初にする
                                textNumber = textNumber + 1;//次のセリフにする
                            }
                        }
                        else //もしtexts[]が最後のセリフになったら
                        {
                            if (click == true) //クリックされた判定
                            {
                                displayText = ""; //表示させる文字列も消す
                                textCharNumber = 0; //文字の番号を最初にする
                                textStop = true; //セリフ表示を止める
                            }
                        }
                    }
                }
                else if(texts.actionList[textNumber].actionType == EventActionType.Choices)
                {

                }

                this.GetComponent<RubyTextMeshProUGUI>().UnditedText = displayText;//画面上にdisplayTextを表示
                click = false;//クリックされた判定を解除
            }
            if (Input.GetMouseButton(0))//マウスをクリックしたら
            {
                click = true; //クリックされた判定にする
            }
        }
    }
}