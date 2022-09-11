using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    public void Initialize(CardInfo cardInfo)
    {
        this.cardInfo = cardInfo;

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
                cardInfo.Mana = value;
                manaText.text = value.ToString();
                break;
            case StatsType.Damage:
                cardInfo.Damage = value;
                damageText.text = value.ToString();
                break;
            case StatsType.HP:
                cardInfo.HP = value;
                hpText.text = value.ToString();
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
