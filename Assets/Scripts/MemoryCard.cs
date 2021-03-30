using System;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    private GameObject _cardBack;

    public event Action<MemoryCard> OnCardClick; 

    public int id { get; private set; }

    private void Awake()
    {
        _cardBack = transform.GetChild(0).gameObject;
    }

    private void OnMouseDown()
    {
        if (_cardBack.activeSelf)
        {
            _cardBack.SetActive(false);
            OnCardClick?.Invoke(this);
        }
    }

    public void Unreveal()
    {
        _cardBack.SetActive(true);
    }

    public void SetCard(int id, Sprite image)
    {
        this.id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
}