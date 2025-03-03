using UnityEngine;
using System.Collections;

public class AIController : Player
{
    [SerializeField] private float minThinkingTime = 2f; 
    [SerializeField] private float maxThinkingTime = 4f; 

    public bool isAIPlayerTurn = false;

    public IEnumerator AITurn()
    {
        yield return new WaitForSeconds(1f);

        DrawCard(GameManager.Instance.aiDeck);
        
        UIManager.Instance.UpdateHandUI();

        yield return new WaitForSeconds(Random.Range(minThinkingTime, maxThinkingTime));

        if (Hand.Count > 0)
        {
            int randomIndex = Random.Range(0, Hand.Count);
            SOCardData playedCard = Hand[randomIndex];

            PlayCard(playedCard);
        }
    }

    public void PlayCard(SOCardData selectedCard)
    {
        selectedCard.ApplyEffect(this, GameManager.Instance.playerController);
        
        DiscardCard(selectedCard);
        UIManager.Instance.UpdateDiscardPileUI(selectedCard, false);

        TurnManager.Instance.EndTurn();
    }
}
