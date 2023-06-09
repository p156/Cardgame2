using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    public NPCEvent texts;//Unity��œ��͂���string�̔z��
    int textNumber;//���Ԗڂ�texts[]��\�������邩
    string displayText;//�\��������string
    int textCharNumber;//�������ڂ�displayText�ɒǉ����邩
    int displayTextSpeed; //�S�̂̃t���[�����[�g�𗎂Ƃ��ϐ�
    bool click;//�N���b�N����
    bool textStop; //�e�L�X�g�\�����n�߂邩
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
                    if (textCharNumber != texts.actionList[textNumber].talkText.Length)//����text[textNumber]�̕�����̕������Ō�̕�������Ȃ����
                    {
                        displayText = displayText + texts.actionList[textNumber].talkText[textCharNumber];//displayText�ɕ�����ǉ����Ă���
                        textCharNumber = textCharNumber + 1;//���̕����ɂ���
                        if (textCharNumber == texts.actionList[textNumber].talkText.Length)
                        {
                            displayText = texts.actionList[textNumber].RubytalkText;
                        }
                    }
                    else//����text[textNumber]�̕�����̕������Ō�̕�����������
                    {
                        if (textNumber != texts.actionList.Count - 1)//����texts[]���Ō�̃Z���t����Ȃ��Ƃ���
                        {
                            if (click == true)//�N���b�N���ꂽ����
                            {
                                displayText = "";//�\�������镶���������
                                textCharNumber = 0;//�����̔ԍ����ŏ��ɂ���
                                textNumber = textNumber + 1;//���̃Z���t�ɂ���
                            }
                        }
                        else //����texts[]���Ō�̃Z���t�ɂȂ�����
                        {
                            if (click == true) //�N���b�N���ꂽ����
                            {
                                displayText = ""; //�\�������镶���������
                                textCharNumber = 0; //�����̔ԍ����ŏ��ɂ���
                                textStop = true; //�Z���t�\�����~�߂�
                            }
                        }
                    }
                }
                else if(texts.actionList[textNumber].actionType == EventActionType.Choices)
                {

                }

                this.GetComponent<RubyTextMeshProUGUI>().UnditedText = displayText;//��ʏ��displayText��\��
                click = false;//�N���b�N���ꂽ���������
            }
            if (Input.GetMouseButton(0))//�}�E�X���N���b�N������
            {
                click = true; //�N���b�N���ꂽ����ɂ���
            }
        }
    }
}