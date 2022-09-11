using UnityEngine;

[System.Serializable]
public class CardInfo
{
    public string Name = "Default chel";
    [TextArea(1, 2)] public string Description;

    [Space(15)] public int Mana;
    public int Damage;
    public int HP;
}