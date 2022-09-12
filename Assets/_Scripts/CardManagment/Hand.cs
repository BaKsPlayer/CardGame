using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    private List<Card> cards = new List<Card>();
    public List<Card> Cards => cards;

    public void Initialize()
    {
        cards = new List<Card>();

        foreach (Transform child in transform)
        {
            cards.Add(child.GetComponent<Card>());
        }

        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].Movement.CardsCountChanged(i, cards.Count);
        }
    }

    public void RemoveCard(Card cardToRemove)
    {
        cards.Remove(cardToRemove);
        Destroy(cardToRemove.gameObject);

        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].Movement.CardsCountChanged(i, cards.Count);
        }
    }
}
