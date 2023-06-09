using UnityEngine;
using System.Collections;

public class EffectLayerSetter : MonoBehaviour
{
    //�G�t�F�N�g�p�̃��C���[��
    private string EFFECT_SORTING_LAYER_NAME = "Effect";

    private void Awake()
    {
        SetSortingLayer(transform);
    }

    private void SetSortingLayer(Transform parent)
    {
        //�����_���[������ꍇ�̂݃��C���[��ݒ�
        if (parent.GetComponent<Renderer>())
        {
            parent.GetComponent<Renderer>().sortingLayerName = EFFECT_SORTING_LAYER_NAME;
        }

        //�q������ꍇ�ɂ́A����ɂ������������s��
        foreach (Transform child in parent.transform)
        {
            SetSortingLayer(child);
        }
    }
}