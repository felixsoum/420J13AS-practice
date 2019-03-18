using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    [SerializeField] Card[] cards;
    List<CardData> cardData = new List<CardData>()
    {
        new CardData(Color.red, 2),
        new CardData(Color.black, 2),
        new CardData(Color.red, 5),
        new CardData(Color.black, 5),
        new CardData(Color.black, 3),
        new CardData(Color.red, 4),
        new CardData(Color.black, 4),
        new CardData(Color.red, 3),
    };

    private void Awake()
    {
        SetData();
    }

    public void Sort()
    {
        cardData.Sort();
        SetData();
    }

    private void SetData()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].SetData(cardData[i]);
        }
    }

    public void Shuffle()
    {
        for (int i = cards.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            var temp = cardData[i];
            cardData[i] = cardData[j];
            cardData[j] = temp;
        }
        SetData();
    }
}
