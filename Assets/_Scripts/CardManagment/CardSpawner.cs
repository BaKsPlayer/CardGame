using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private DeckController deckController;
    [SerializeField] private Hand hand;
    [SerializeField] private Card cardPrefab;

    private void Awake()
    {
        int startCardsCount = Random.Range(4, 7);
        for (int i = 0; i < startCardsCount; i++)
        {
            CardInfo randomCardInfo = deckController.GetRandomCardInfo();

            var newCard = Instantiate(cardPrefab, transform);
            newCard.Initialize(randomCardInfo);
        }

        hand.Initialize();
    }
}
