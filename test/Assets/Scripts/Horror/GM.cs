using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GM : MonoBehaviour
{
    //�\��������摜�I�u�W�F�N�g��Raw�摜�R���|�[�l���g
    public RawImage img;

    //�\��������摜���X�g
    public List<Texture> texture_list = new List<Texture>();

    // Start is called before the first frame update
    void Start()
    {
        img = GameObject.Find("DisplayImage").GetComponent<RawImage>();
        //1�`10�̉摜��ǂݍ���
        read_img(10);
    }

    //���\�[�X����\�����������摜���w�肵���������ǂݍ��ފ֐�
    public void read_img(int n)
    {
        Texture tmp;
        for (int i = 1; i < n + 1; i++)
        {
            tmp = Resources.Load("img/" + i) as Texture;
            texture_list.Add(tmp);
        }
    }

    //�{�^���ŌĂяo�����֐�
    public void ChangeImage()
    {
        //�P�`�\������摜�̐��������_���ŎZ�o
        int random = Random.Range(1, texture_list.Count);

        Debug.Log("�����_���l��" + random);

        img.texture = texture_list[random];
    }
}
