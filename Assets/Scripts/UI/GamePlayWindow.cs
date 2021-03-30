using TMPro;
using UnityEngine;

public class GamePlayWindow : MonoBehaviour, ISubWindow
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI levelText;

    private const subWindowName SubWindowName = subWindowName.None;

    public void SetScore(int score) => scoreText.text = $"Pair count: {score}";
    public void SetLevel(int level) => levelText.text = $"Level: {level}";

    public void ChangeState(subWindowName subWindowName)
    {
        gameObject.SetActive(SubWindowName == subWindowName);
    }
}