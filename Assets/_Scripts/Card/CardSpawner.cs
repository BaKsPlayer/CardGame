using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private DeckController deckController;
    [SerializeField] private CardStatsChanger cardStatsChanger;
    [SerializeField] private Card cardPrefab;

    private void Awake()
    {
        int startCardsCount = Random.Range(4, 7);
        for (int i = 0; i < startCardsCount; i++)
        {
            var newCard = Instantiate(cardPrefab, transform);
            newCard.GetComponent<RectTransform>().localPosition = new Vector2((100 * i) , newCard.GetComponent<RectTransform>().position.y);
            newCard.Initialize(deckController.GetRandomCardInfo());
        }

        cardStatsChanger.Initialize();
    }
}
