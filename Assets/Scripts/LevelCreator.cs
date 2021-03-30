using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelCreator : MonoBehaviour
{
    private RulesHolder _rulesHolder;
    private List<MemoryCard> _memoryCards;

    public void StartGame(RulesHolder rulesHolder)
    {
        _rulesHolder = rulesHolder;
        CreateLevel();
    }

    public MemoryCard[] GetCards()
    {
        return _memoryCards.ToArray();
    }

    private void CreateLevel()
    {
        var data = _rulesHolder.GetData();

        var startPos = SetStartPosition(data[0]);

        var numbers = CreateIds(data[0]);
        numbers = ShuffleArray(numbers);

        SetCardPosition(data[0], numbers, startPos);
    }

    private List<int> CreateIds(RulesHolder.LevelDataStruct data)
    {
        var imagesLength = data.images.Length;
        var ids = new List<int>(imagesLength);

        for (int i = 0; i < imagesLength; i++)
        {
            ids.Add(i);
            ids.Add(i);
            //because we need pair cards with same id
        }

        return ids;
    }

    private Vector2 SetStartPosition(RulesHolder.LevelDataStruct data)
    {
        var countInCols = data.gridCols;
        var countInRows = data.gridRows;

        var offsetY = data.offsetY;
        return new Vector2(SetStartXPos(countInCols), SetStartYPos(offsetY, countInRows));
    }

    private void SetCardPosition(RulesHolder.LevelDataStruct data, List<int> numbers, Vector2 startPos)
    {
        _memoryCards = new List<MemoryCard>(data.gridCols * data.gridRows);
        for (var i = 0; i < data.gridCols; i++)
        {
            for (var j = 0; j < data.gridRows; j++)
            {
                var card = Instantiate(data.prefabCard);

                var index = j * data.gridCols + i;
                var id = numbers[index];

                if (id >= data.images.Length)
                {
                    Debug.LogError("CHECK COUNT CARD AND COUNT IMAGES. LOOKS LIKE YOU DON`T HAVE ENOUGH PIC FOR THIS CARDS COUNT");
                    card.SetCard(id, data.images[0]);
                }
                else
                {
                    card.SetCard(id, data.images[id]);
                }

                var posX = data.offsetX * i + startPos.x;
                var posY = -(data.offsetY * j) + startPos.y;

                card.transform.position = new Vector3(posX, posY);
                _memoryCards.Add(card);
            }
        }
    }

    private float SetStartXPos(int countInCols)
    {
        return -(countInCols - 1);
    }

    private float SetStartYPos(float offsetY, int countInRows)
    {
        float pos;

        if (countInRows > 1)
        {
            pos = offsetY / countInRows;
        }
        else
        {
            pos = 0;
        }

        return pos;
    }

    private List<int> ShuffleArray(List<int> numbers)
    {
        var newArray = new List<int>(numbers);

        for (var i = 0; i < newArray.Count; i++)
        {
            var tmp = newArray[i];
            var r = Random.Range(i, newArray.Count);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }

        return newArray;
    }
}
