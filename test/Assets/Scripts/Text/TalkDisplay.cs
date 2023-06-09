using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TalkDisplay : MonoBehaviour
{
    public NPCEvent texts;//Unity��œ��͂���string�̔z��
    int textNumber;//���Ԗڂ�texts[]��\�������邩
    string displayText;//�\��������string
    int textCharNumber;//�������ڂ�displayText�ɒǉ����邩
    int displayTextSpeed; //�S�̂̃t���[�����[�g�𗎂Ƃ��ϐ�
    bool click;//�N���b�N����
    public bool textStop; //�e�L�X�g�\�����n�߂邩

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
        if (textStop == false) //�e�L�X�g��\��������if��
        {
            displayTextSpeed++;
            if (displayTextSpeed % 10 == 0)//�T��Ɉ��v���O���������s����if��
            {
                if (texts.actionList[textNumber].actionType == EventActionType.Talk)
                {
                    
                    if (textCharNumber != texts.actionList[textNumber].talkText.Length)//�����z��̕�����̕������Ō�̕�������Ȃ����
                    {
                        displayText = displayText + texts.actionList[textNumber].talkText[textCharNumber];//displayText�ɕ�����ǉ����Ă���
                        textCharNumber = textCharNumber + 1;//���̕����ɂ���

                    }
                    else//�z��̒��̕�����̕������Ō�̕�����������
                    {
                        if (textNumber != texts.actionList.Count - 1)//�����z��̒����Ō�̃Z���t����Ȃ��Ƃ���
                        {
                            if (click == true)//�N���b�N���ꂽ����
                            {
                                displayText = "";//�\�������镶���������
                                textCharNumber = 0;//�����̔ԍ����ŏ��ɂ���
                                textNumber = textNumber + 1;//���̃Z���t�ɂ���
                            }
                        }
                        else //�����z��̒����Ō�̃Z���t�ɂȂ�����
                        {
                            if (click == true) //�N���b�N���ꂽ����
                            {
                                displayText = ""; //�\�������镶���������
                                textCharNumber = 0; //�����̔ԍ����ŏ��ɂ���
                                textStop = true; //�Z���t�\�����~�߂�
                            }
                        }
                    }

                    if (textNumber % talkdisplay.Length == 0) //�����o�����S��true�ɂȂ�����S������
                    {
                        for (int i = 0; i < talkdisplay.Length; i++)
                        {
                            talkdisplay[i].SetActive(false);
                        }
                    }
                }
                //�I������
                else if (texts.actionList[textNumber].actionType == EventActionType.Choices)
                {

                }

                if(onemove == true) //��񂾂��������@�Œ萔�l�̂�
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
                talkdisplay[textNumber % talkdisplay.Length].GetComponentInChildren<RubyTextMeshProUGUI>().UnditedText = displayText;//��ʏ��displayText��\��
                click = false;//�N���b�N���ꂽ���������
            }
            if (Input.GetMouseButtonDown(0))//�}�E�X���N���b�N������
            {
                onemove = true;
                click = true; //�N���b�N���ꂽ����ɂ���
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
    private void Imgalpha(int number)//�F�̔Z��
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