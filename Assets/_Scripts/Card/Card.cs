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
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI damageText;

    public void Initialize(CardInfo cardInfo)
    {
        nameText.text = cardInfo.Name;
        descriptionText.text = cardInfo.Description;

        manaText.text = cardInfo.Mana.ToString();
        lifeText.text = cardInfo.Life.ToString();
        damageText.text = cardInfo.Damage.ToString();

        avatar.Initialize();
    }
}
