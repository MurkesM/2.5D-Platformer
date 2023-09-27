using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateCoinText(int coinCount)
    {
        coinText.text = $"Coins: {coinCount}";
    }
}