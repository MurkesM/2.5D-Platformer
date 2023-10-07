using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI livesText;

    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateCoinText(int coinCount)
    {
        coinText.text = $"Coins: {coinCount}";
    }

    public void UpdateLivesText(int livesCount)
    {
        livesText.text = $"Lives: {livesCount}";
    }
}