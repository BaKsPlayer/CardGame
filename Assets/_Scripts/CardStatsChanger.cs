using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public enum StatsType
{
    Mana,
    HP,
    Damage
}

public class CardStatsChanger : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderValueText;

    private int currentCardIndex;
    private StatsType statsTypeToChange;
    private List<Card> cards = new List<Card>();

    public void Initialize()
    {
        cards = new List<Card>();

        foreach (Transform child in transform)
        {
            cards.Add(child.GetComponent<Card>());
        }
    }

    public void ChangeCardStats()
    {
        cards[currentCardIndex].HighlightStats(statsTypeToChange, false);

        currentCardIndex = 0;
        statsTypeToChange = (StatsType)Random.Range(0, Enum.GetValues(typeof(StatsType)).Length);

        cards[currentCardIndex].HighlightStats(statsTypeToChange, true);
    }

    public void ApplyChanges()
    {
        cards[currentCardIndex].ChangeStats(statsTypeToChange, (int)slider.value);
    }

    public void GoToNextCard()
    {
        cards[currentCardIndex].HighlightStats(statsTypeToChange, false) ;

        currentCardIndex++;
        if (currentCardIndex >= transform.childCount)
        {
            currentCardIndex = 0;
        }

        cards[currentCardIndex].HighlightStats(statsTypeToChange, true);
    }

    public void SliderValueChanged()
    {
        sliderValueText.text = slider.value.ToString();
    }
}