using UnityEngine;
using TMPro;

public class PlayerControllerCoin : MonoBehaviour
{
    public int coins = 0; // Счетчик монет
    public TMPro.TextMeshProUGUI coinText; // Ссылка на текстовый UI элемент (TextMeshPro)

    // Метод для добавления монет
    public void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log("Coins collected: " + coins); // Выводим в консоль
        UpdateCoinUI(); // Обновляем UI
    }

    // Метод для обновления UI
    void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coins;
        }
    }

    // Можно добавить метод для отображения UI при старте
    void Start()
    {
        UpdateCoinUI();
    }
}
