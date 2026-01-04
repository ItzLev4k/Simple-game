using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinCollect : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerControllerCoin player = other.GetComponent<PlayerControllerCoin>();
            if (player != null)
            {
                player.AddCoins(coinValue);
            }

            Destroy(gameObject);
        }
    }
    public void WinGame()
    {
        SceneManager.LoadScene("WinScene");
    }
}
