using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FieldLayout))]
public class Field : MonoSingleton<Field>
{
    private FieldLayout layout;

    private List<Card> cards = new List<Card>();

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        layout = GetComponent<FieldLayout>();
    }

    public void AssignParentToCard(Card card)
    {
        cards.Add(card);
        card.transform.SetParent(transform);

        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].Movement.CardsCountChanged(layout, i, cards.Count);
        }
    }
}
