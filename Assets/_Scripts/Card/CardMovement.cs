using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CardMovement : MonoBehaviour
{
    [SerializeField] private Vector3 rotationOffset = new Vector3(0, 0, -10);
    [SerializeField] private Vector2 positionOffset = new Vector2(100, -14);

    private Vector3 CalculatePosition(int siblingIndex, int totalSiblingsCount)
    {
        var index = siblingIndex - (totalSiblingsCount - 1) / 2f;
        var absIndex = Mathf.Abs(index);

        return new Vector2(positionOffset.x * index, positionOffset.y * Mathf.Pow(2, absIndex));
    }

    private Vector3 CalculateRotation(int siblingIndex, int totalSiblingsCount)
    {
        return rotationOffset * (siblingIndex - (totalSiblingsCount - 1) / 2f);
    }

    private void SetPositionAndRotation(Vector3 position, Vector3 rotation)
    {
        transform.DOKill();
        transform.DOLocalMove(position, 1);
        transform.DOLocalRotate(rotation, 1);
    }

    public void CardsCountChanged(int siblingIndex, int totalSiblingsCount)
    {
        Vector3 position = CalculatePosition(siblingIndex, totalSiblingsCount);
        Vector3 rotation = CalculateRotation(siblingIndex, totalSiblingsCount);

        SetPositionAndRotation(position, rotation);
    }
}
