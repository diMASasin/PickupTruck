using DG.Tweening;
using ItemComponents;
using UnityEngine;

public class BaggagePoint : MonoBehaviour
{
    public bool IsOcuppied { get; private set; }

    public void Put(Item item)
    {
        item.transform.parent = null;
        IsOcuppied = true;
        item.SetUseGravity(false);

        item.transform.DOMove(transform.position, 0.2f).OnComplete(item.FreezeAll);
        item.transform.DORotate(Vector3.zero, 0.2f);
    }
}