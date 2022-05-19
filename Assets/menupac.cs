using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class menupac : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 firsttarget;
    public Vector2 secondtarget;
    private SpriteRenderer sr;
    public Ease ease;
    void Start()
    {
        Vector2 targetPos = transform.position + new Vector3(1, -2);
        DOTween.Sequence().Append(
        transform.DOMove(firsttarget, 17f)).Append(
        transform.DOMove(secondtarget, -2f)).Append(
        sr.DOColor(Color.black, 2f));

        transform.DOScale(new Vector3(0.5f, 0.5f, 1), 6f).OnComplete(MoveRightDown);
    }
    void MoveRightDown()
    {
        Vector2 target = transform.position + new Vector3(1, -2);
        transform.DOMove(target, 2f).OnComplete(MoveLeftDown);
    }

    void MoveLeftDown()
    {
        Vector2 target = transform.position + new Vector3(-1, -2);
        transform.DOMove(target, 2f).OnComplete(MoveRightDown).SetEase(ease);
    }

    
}
