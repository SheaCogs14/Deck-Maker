using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; } 

    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform playerHandPanel;
    [SerializeField] private Transform aiHandPanel;
    [SerializeField] public Transform playerDiscardPanel;
    [SerializeField] public Transform aiDiscardPanel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdateHandUI()
    {
        foreach (Transform child in playerHandPanel)
        {
            Destroy(child.gameObject); 
        }

        foreach (SOCardData card in GameManager.Instance.playerController.Hand)
        {
            GameObject cardUI = Instantiate(cardPrefab, playerHandPanel);
            CardUI cardUIComponent = cardUI.GetComponent<CardUI>();
            cardUIComponent.SetCard(card, true); 
        }

        foreach (Transform child in aiHandPanel)
        {
            Destroy(child.gameObject);
        }

        foreach (SOCardData card in GameManager.Instance.aiController.Hand)
        {
            GameObject cardUI = Instantiate(cardPrefab, aiHandPanel);
            CardUI cardUIComponent = cardUI.GetComponent<CardUI>();
            cardUIComponent.SetCard(card, false); 
        }
    }

    public void UpdateDiscardPileUI(SOCardData discardedCard, bool isPlayerCard)
    {
        
        GameObject cardUI = Instantiate(cardPrefab);
        CardUI cardUIComponent = cardUI.GetComponent<CardUI>();
        cardUIComponent.SetCard(discardedCard, isPlayerCard);

        cardUIComponent.ShowInDiscardPile(isPlayerCard);
    }
}
