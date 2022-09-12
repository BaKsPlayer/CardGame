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
    [SerializeField] private Hand hand;

    private int currentCardIndex;
    private StatsType statsTypeToChange;

    public void HighlightToChangeCardStats()
    {
        hand.Cards[currentCardIndex].HighlightStats(statsTypeToChange, false);

        currentCardIndex = 0;
        statsTypeToChange = (StatsType)Random.Range(0, Enum.GetValues(typeof(StatsType)).Length);

        hand.Cards[currentCardIndex].HighlightStats(statsTypeToChange, true);
    }

    public void ApplyChanges()
    {
        hand.Cards[currentCardIndex].ChangeStats(statsTypeToChange, (int)slider.value);
    }

    public void GoToNextCard()
    {
        hand.Cards[currentCardIndex].HighlightStats(statsTypeToChange, false) ;

        currentCardIndex++;
        if (currentCardIndex >= transform.childCount)
        {
            currentCardIndex = 0;
        }

        hand.Cards[currentCardIndex].HighlightStats(statsTypeToChange, true);
    }

    public void SliderValueChanged()
    {
        sliderValueText.text = slider.value.ToString();
    }
}