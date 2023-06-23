using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardView : MonoBehaviour
{
    public int ID;
    public CardEntity.Type Job;
    public int jobPT;
    public int cost;
    [SerializeField] Image iconImage;
    [SerializeField] TextMeshProUGUI cardname;
    public string flavor;

    public void Show(CardModel cardModel) // cardModel�̃f�[�^�擾�Ɣ��f
    {
        cardname.text = cardModel.name;
        ID = cardModel.ID;
        Job = cardModel.Job;
        cost = cardModel.cost;
        jobPT = cardModel.jobPT;
        iconImage.sprite = cardModel.icon;
        flavor = cardModel.flavor;
    }
}