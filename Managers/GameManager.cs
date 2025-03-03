using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public PlayerController playerController;
    public AIController aiController;
    public GameObject cardPrefab; 

    public List<SOCardData> playerDeck;
    public List<SOCardData> aiDeck;

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        Debug.Log("Player Deck Count: " + playerDeck.Count);
        Debug.Log("AI Deck Count: " + aiDeck.Count);

        playerController.DrawCard(playerDeck);
        playerController.DrawCard(playerDeck);
        aiController.DrawCard(aiDeck);
        aiController.DrawCard(aiDeck);

        UIManager.Instance.UpdateHandUI();
        TurnManager.Instance.StartGame();
    }

    public void EndGame()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0;
    }
}
