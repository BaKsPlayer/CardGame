using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IBeginDragHandler,IEndDragHandler,IDragHandler
{
    private Vector2 positionOffsetOnDrag;
    private Vector2 startPosition;
    private Vector3 startRotation;

    private Card card;

    private bool isCardOnField;

    public void Initialize(Card card)
    {
        this.card = card;
    }

    private void SetPositionAndRotation(Vector3 position, Vector3 rotation, float duration = 1f, Action callback = null)
    {
        transform.DOKill();
        transform.DOLocalMove(position, duration).OnComplete(() => callback?.Invoke());
        transform.DOLocalRotate(rotation, duration);
    }

    public void CardsCountChanged(Layout layout,int siblingIndex, int totalSiblingsCount)
    {
        Vector3 position = layout.CalculatePosition(siblingIndex, totalSiblingsCount);
        Vector3 rotation = layout.CalculateRotation(siblingIndex, totalSiblingsCount);

        SetPositionAndRotation(position, rotation);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isCardOnField)
        {
            return;
        }

        card.SetActiveGlow(true);

        transform.DOKill();

        startPosition = transform.localPosition;
        startRotation = transform.localEulerAngles;

        positionOffsetOnDrag = new Vector2(transform.position.x, transform.position.y) - eventData.position;

        transform.DOLocalRotate(Vector3.zero, 0.4f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isCardOnField)
        {
            return;
        }

        transform.position = eventData.position + positionOffsetOnDrag;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isCardOnField)
        {
            return;
        }

        card.SetActiveGlow(false);

        if ((transform.localPosition.y - startPosition.y) <= 200)
        {
            SetPositionAndRotation(startPosition, startRotation);
        }
        else
        {
            isCardOnField = true;
            Field.Instance.AssignParentToCard(card);
            Card.OnCardRemovedFromHand.Invoke(card);
        }
    }
}
