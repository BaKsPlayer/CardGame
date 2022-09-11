using UnityEngine;

[System.Serializable]
public class CardInfo
{
    [SerializeField] private string name = "Default chel";
    [SerializeField, TextArea(1, 2)] private string description;

    [SerializeField, Space(15)] private int mana;
    [SerializeField] private int damage;
    [SerializeField] private int life;

    public string Name => name;
    public string Description => description;

    public int Mana => mana;
    public int Damage => damage;
    public int Life => life;
}