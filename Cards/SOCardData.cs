using UnityEngine;

public enum CardType { Attack, Heal, Buff, Special }

[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class SOCardData : ScriptableObject
{
    public string cardName;
    public int value;
    public CardType cardType; 
    public Sprite cardSprite; // The sprite for the card

    public virtual void ApplyEffect(Player owner, Player target)
    {
        if (target == null)
        {
            Debug.LogError("Target (Opponent) is null!");
            return;
        }

       
        switch (cardType)
        {
            case CardType.Attack:
                target.TakeDamage(value);
                break;
            case CardType.Heal:
                owner.Heal(value);
                break;
            case CardType.Buff:
                owner.BuffStat(value);
                break;
            case CardType.Special:
                owner.SpecialEffect(value);
                break;
        }
    }
}
