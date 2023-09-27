using UnityEngine;

public class Coin : MonoBehaviour
{
    static int coinCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        coinCount++;

        UIManager.instance.UpdateCoinText(coinCount);

        Destroy(gameObject);
    }
}