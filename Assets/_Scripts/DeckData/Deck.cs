using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Deck", fileName = "Deck")]
public class Deck : ScriptableObject
{
    [SerializeField] private List<CardInfo> cards = new List<CardInfo>();
    public List<CardInfo> Cards => cards;
}


