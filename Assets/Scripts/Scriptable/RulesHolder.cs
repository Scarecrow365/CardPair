using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RulesHolder", menuName = "Rules Holder")]
public class RulesHolder : ScriptableObject
{
    [SerializeField] private LevelDataStruct[] levelData;

    public LevelDataStruct[] GetData() => levelData;

    [Serializable]
    public struct LevelDataStruct
    {
        [Range(1, 5)] public int gridRows;
        [Range(2, 10)] public int gridCols;

        [Tooltip("Use 2 like default")]
        public float offsetX;

        [Tooltip("Use 2.4 like default")]
        public float offsetY;

        public MemoryCard prefabCard;
        public Sprite[] images;
    }
}
