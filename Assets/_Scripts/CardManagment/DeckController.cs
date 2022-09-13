using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    [SerializeField] private Deck deck;
    private List<CardInfo> avaiableDeck = new List<CardInfo>();

    private bool isDeckInitialized;

    private void Awake()
    {
       Initialize();
    }

    private void Initialize()
    {
        CardInfo[] cardsArray = new CardInfo[deck.Cards.Count];
        deck.Cards.CopyTo(cardsArray);
        avaiableDeck = cardsArray.ToList();

        isDeckInitialized = true;
    }

    public CardInfo GetRandomCardInfo()
    {
        if (isDeckInitialized == false)
        {
            Initialize();
        }

        if (avaiableDeck.Count == 0)
        {
            return new CardInfo();
        }

        int randomIndex = Random.Range(0, avaiableDeck.Count);
        CardInfo randomCardInfo = avaiableDeck[randomIndex];
        avaiableDeck.RemoveAt(randomIndex);

        return randomCardInfo;
    }
}
