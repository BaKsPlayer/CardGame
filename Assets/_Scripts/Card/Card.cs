using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CardMovement))]
public class Card : MonoBehaviour
{
    [SerializeField] private CardAvatar avatar;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    [SerializeField] private TextMeshProUGUI manaText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI damageText;

    [SerializeField] private Color defaultTextColor;
    [SerializeField] private Color highlightedTextColor;

    private CardInfo cardInfo;
    private Hand hand;
    private CardMovement movement;

    public CardMovement Movement => movement;

    public void Initialize(CardInfo cardInfo, Hand hand)
    {
        this.cardInfo = cardInfo;
        this.hand = hand;

        movement = GetComponent<CardMovement>();

        nameText.text = cardInfo.Name;
        descriptionText.text = cardInfo.Description;

        manaText.text = cardInfo.Mana.ToString();
        hpText.text = cardInfo.HP.ToString();
        damageText.text = cardInfo.Damage.ToString();

        avatar.Initialize();
    }

    public void ChangeStats(StatsType statsType, int value)
    {
        switch (statsType)
        {
            case StatsType.Mana:
                StartCoroutine(StatsFiller.FillStats(manaText, cardInfo.Mana, value));
                cardInfo.Mana = value;
                break;
            case StatsType.Damage:
                StartCoroutine(StatsFiller.FillStats(damageText, cardInfo.Damage, value));
                cardInfo.Damage = value;
                break;
            case StatsType.HP:
                if (value <= 0)
                {
                    hand.RemoveCard(this);
                    Destroy(gameObject);
                    return;
                }

                StartCoroutine(StatsFiller.FillStats(hpText, cardInfo.HP, value));
                cardInfo.HP = value;
                break;
        }
    }

    public void HighlightStats(StatsType statsType, bool value)
    {
        var colorToSet = value ? highlightedTextColor : defaultTextColor;

        switch (statsType)
        {
            case StatsType.Mana:
                manaText.color = colorToSet;
                break;
            case StatsType.Damage:
                damageText.color = colorToSet;
                break;
            case StatsType.HP:
                hpText.color = colorToSet;
                break;
        }
    }
}
