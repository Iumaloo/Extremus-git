using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IslandShaker : MonoBehaviour
{
    [SerializeField]
    private float upStrenght = 1;
    [SerializeField]
    private float duration = 1;
    [SerializeField]
    AnimationCurve upcurve;
    [SerializeField]
    AnimationCurve Downcurve;
    // Start is called before the first frame update
    private void Start()
    {
        Sequence sequence= DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.position + Vector3.up * upStrenght, duration).SetEase(upcurve));
        sequence.Append(transform.DOMove(transform.position, 1).SetEase(Downcurve));
        sequence.SetLoops(-1);

        //var tweener=transform.DOShakePosition(10,new Vector3(0,3f),1,0,false,false);
        //tweener.SetLoops(-1,LoopType.Yoyo);
    }
}
