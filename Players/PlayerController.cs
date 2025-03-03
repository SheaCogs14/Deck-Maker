using UnityEngine;
using System.Collections;

public class PlayerController : Player
{
    public bool isPlayerTurn = true;

    public void Start()
    {
        GameManager.Instance.StartGame();
    }

    public IEnumerator PlayerTurn()
    {
        yield return new WaitForSeconds(1f);

        DrawCard(GameManager.Instance.playerDeck);

        UIManager.Instance.UpdateHandUI();

        while (isPlayerTurn)
        {
            
            yield return null;
        }
    }

    public void PlayCard(SOCardData selectedCard)
    {
       
        selectedCard.ApplyEffect(this, GameManager.Instance.aiController);

        DiscardCard(selectedCard);
        
        UIManager.Instance.UpdateDiscardPileUI(selectedCard, true);

        TurnManager.Instance.EndTurn();
    }
}
