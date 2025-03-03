using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance { get; private set; }

    public PlayerController playerController;
    public AIController aiController;

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        playerController.isPlayerTurn = true;
        aiController.isAIPlayerTurn = false;

        StartCoroutine(playerController.PlayerTurn());
    }

    public void EndTurn()
    {
        if (playerController.isPlayerTurn)
        {
            playerController.isPlayerTurn = false;
            aiController.isAIPlayerTurn = true;

            StartCoroutine(aiController.AITurn());
        }
        else if (aiController.isAIPlayerTurn)
        {
            aiController.isAIPlayerTurn = false;
            playerController.isPlayerTurn = true;

            StartCoroutine(playerController.PlayerTurn());
        }
        
        if ((playerController.Hand.Count == 0 && aiController.Hand.Count == 0) || playerController.health == 0 || aiController.health == 0)
        {
            GameManager.Instance.EndGame();
        }
    }
}
