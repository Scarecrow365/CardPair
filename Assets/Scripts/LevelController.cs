using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private MemoryCard _firstRevealed;
    private MemoryCard _secondRevealed;
    private MemoryCard[] _cards;

    public void StartGame(MemoryCard[] cards)
    {
        _cards = cards;

        foreach (var card in _cards)
        {
            card.OnCardClick += CardRevealed;
        }
    }

    private void OnDisable()
    {
        foreach (var card in _cards)
        {
            card.OnCardClick -= CardRevealed;
        }
    }

    private void CardRevealed(MemoryCard card)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.id == _secondRevealed.id)
        {
            Debug.Log("Pair is ok");
        }
        else
        {
            yield return new WaitForSeconds(.5f);

            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }

        _firstRevealed = null;
        _secondRevealed = null;
    }

}
