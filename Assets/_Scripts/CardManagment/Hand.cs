using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HandLayout))]
public class Hand : MonoBehaviour
{
    private HandLayout layout;

    private List<Card> cards = new List<Card>();
    public List<Card> Cards => cards;

    public void Initialize()
    {
        layout = GetComponent<HandLayout>();
        Card.OnCardRemovedFromHand += RemoveCard;

        cards = new List<Card>();

        foreach (Transform child in transform)
        {
            cards.Add(child.GetComponent<Card>());
        }

        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].Movement.CardsCountChanged(layout,i, cards.Count);
        }
    }

    private void OnDestroy()
    {
        Card.OnCardRemovedFromHand -= RemoveCard;
    }

    public void RemoveCard(Card cardToRemove)
    {
        cards.Remove(cardToRemove);

        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].Movement.CardsCountChanged(layout, i, cards.Count);
        }
    }
}
