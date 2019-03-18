using System;
using UnityEngine;
using UnityEngine.UI;

public class CardData : IComparable
{
    public Color color = Color.red;
    public int value = 10;

    public CardData(Color color, int value)
    {
        this.color = color;
        this.value = value;
    }

    public int CompareTo(object obj)
    {
        CardData otherCard = (CardData)obj;

        if (color != otherCard.color)
        {
            return color == Color.black ? 1 : -1;
        }
        else
        {
            return value.CompareTo(otherCard.value);
        }
    }
}

public class Card : MonoBehaviour
{
    [SerializeField] Text cardText;

    public void SetData(CardData cardData)
    {
        cardText.text = cardData.value.ToString();
        cardText.color = cardData.color;
    }
}
