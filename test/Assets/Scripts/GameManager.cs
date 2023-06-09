using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool talkendflag;       //��b�I���t���O
    private bool turnflag;    //�^�[���J�n�t���O
    [SerializeField] Intermediate Status;
    [SerializeField] private state Now;

    [Header("�X�e�[�W�ڍ�")]
    [Space(10)]

    [Header("�f�b�L")]
    [SerializeField] private List<int> Dack_veiw;
    [SerializeField] private List<int> Trash_veiw;

    [Header("�L�����X�e�[�^�X")]
    [SerializeField] public Image PLimage;
    [SerializeField] private int HP_view;
    [SerializeField] private PLstatus.level Level_veiw;
    [SerializeField] public GameObject PL_HP;
    [SerializeField] private GameObject PL_hand;
    [SerializeField] private int PLHandNumber;


    [Header("�G�l�~�[&�o�g���X�e�[�^�X")]
    [SerializeField] public Image Enemyimage;
    [SerializeField] private GameObject enemy_HP;
    [SerializeField] private GameObject TurnEnd;
    [SerializeField] private GameObject ManaCostPanel;

    [Header("���C���Q�[���̃J�[�h�n")]
    [SerializeField] CardController cardPrefab;
    [SerializeField] Transform playerHand;

    [Header("�X�g�[���[��UI")]
    [SerializeField] private GameObject talk;

    void Start()
    {
        //��\�� & ������
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

        if (Now == state.starttalk)//�ŏ��̃g�[�N
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
        if (Now == state.battle)//�o�g��
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
                //�Q�[���I������
            }
            if (int.Parse(PL_HP.GetComponentInChildren<TextMeshProUGUI>().text) <= 0) 
            {
                //�Q�[���I�[�o�[
            }
        }
        if (Now == state.endtalk)//�Ō�̃g�[�N
        {
            talk.GetComponent<TalkDisplay>().texts = Status.End_Intermediate;
            talk.SetActive(true);
            if (talkendflag == true)
            {
                //�V�[���ړ�
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

    void StartGame()�@//�^�[���J�n��
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

    public void EndGame()//�^�[���G���h����
    {
        int i = 0;
        while (i < PLHandNumber)
        {
            GameObject card = playerHand.GetChild(i).gameObject;
            Trash_veiw.Add(card.GetComponent<CardView>().ID);
            Destroy(card);
            i++;
        }

        EnemyAtack(); //�G�̍U��
        StartGame();//�h���[
    }

    public void EnemyAtack()
    {

    }

    void CreateCard(int cardID, Transform place)�@//�J�[�h������
    {
        CardController card = Instantiate(cardPrefab, place);
        card.Init(cardID);
    }

    void Shuffle() // �f�b�L���V���b�t������
    {
        // ���� n �̏����l�̓f�b�L�̖���
        int n = Dack_veiw.Count;

        // n��1��菬�����Ȃ�܂ŌJ��Ԃ�
        while (n > 1)
        {
            n--;

            // k�� 0 �` n+1 �̊Ԃ̃����_���Ȓl
            int k = UnityEngine.Random.Range(0, n + 1);

            // k�Ԗڂ̃J�[�h��temp�ɑ��
            int temp = Dack_veiw[k];
            Dack_veiw[k] = Dack_veiw[n];
            Dack_veiw[n] = temp;
        }
    }

    public enum state //���
    {
        starttalk,
        battle,
        endtalk,
    }

}
