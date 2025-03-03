using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{
    [SerializeField] private Image frontImage;
    [SerializeField] private GameObject frontCard;
    [SerializeField] private GameObject backCard;
    [SerializeField] private TextMeshProUGUI cardNameText; 
    [SerializeField] private TextMeshProUGUI cardValueText; 
    public Button cardButton;

    private SOCardData cardData;

    public void SetCard(SOCardData data, bool isPlayerCard)
    {
        if (data == null)
        {
            Debug.LogError("SOCardData is null in SetCard.");
            return;
        }

        cardData = data;

        frontImage.sprite = cardData.cardSprite;

        cardNameText.text = cardData.cardName;
        cardValueText.text = cardData.value.ToString();

        if (isPlayerCard)
        {
            ShowCard();
            cardButton.interactable = true;
        }
        else
        {
            HideCard();
            cardButton.interactable = false;
        }
    }

    public void ShowCard()
    {
        frontCard.gameObject.SetActive(true);
        backCard.gameObject.SetActive(false);
    }

    public void HideCard()
    {
        frontCard.gameObject.SetActive(false);
        backCard.gameObject.SetActive(true);
    }

    public void OnCardSelected()
    {
        GameManager.Instance.playerController.PlayCard(cardData);
    }
    public void ShowInDiscardPile(bool isPlayerCard)
    {
        frontImage.sprite = cardData.cardSprite;

        cardButton.interactable = false;

        if (isPlayerCard)
        {
            transform.SetParent(UIManager.Instance.playerDiscardPanel, false);
        }
        else
        {
            ShowCard();
            transform.SetParent(UIManager.Instance.aiDiscardPanel, false);
        }
    }
}
