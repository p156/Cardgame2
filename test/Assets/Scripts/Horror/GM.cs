using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GM : MonoBehaviour
{
    //表示させる画像オブジェクトのRaw画像コンポーネント
    public RawImage img;

    //表示させる画像リスト
    public List<Texture> texture_list = new List<Texture>();

    // Start is called before the first frame update
    void Start()
    {
        img = GameObject.Find("DisplayImage").GetComponent<RawImage>();
        //1～10の画像を読み込む
        read_img(10);
    }

    //リソースから表示させたい画像を指定した個数だけ読み込む関数
    public void read_img(int n)
    {
        Texture tmp;
        for (int i = 1; i < n + 1; i++)
        {
            tmp = Resources.Load("img/" + i) as Texture;
            texture_list.Add(tmp);
        }
    }

    //ボタンで呼び出される関数
    public void ChangeImage()
    {
        //１～表示する画像の数をランダムで算出
        int random = Random.Range(1, texture_list.Count);

        Debug.Log("ランダム値は" + random);

        img.texture = texture_list[random];
    }
}
