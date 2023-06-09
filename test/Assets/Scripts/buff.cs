using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buff : MonoBehaviour
{
    [SerializeField] buffdetail buffnow;
    [SerializeField] Image image;
    
    private void OnValidate()
    {
        switch ((int)buffnow)
        {
            case 0:
                image.sprite = Resources.Load<Sprite>("buff/buff " + (int)buffnow);
                break;
            case 1:
                image.sprite = Resources.Load<Sprite>("buff/buff " + (int)buffnow);
                break;
            case 2:
                image.sprite = Resources.Load<Sprite>("buff/buff " + (int)buffnow);
                break;
        }
    }
    public enum buffdetail
    {
        non,
        longevity,
        test,
        test2,

    }


}
