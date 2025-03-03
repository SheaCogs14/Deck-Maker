using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 20;
    public int health;
    public int attackPower = 5;
    public List<SOCardData> Hand = new List<SOCardData>();
    public List<SOCardData> DiscardPile = new List<SOCardData>();

    public SOCardData LastPlayedCard {  get; protected set; }

    private void Awake()
    {
        health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health = Mathf.Clamp(health - damage, 0, _maxHealth);
        Debug.Log($"{gameObject.name} took {damage} damage! Health: {health}");
    }

    public void Heal(int heal)
    {
        health = Mathf.Clamp(health + heal, 0, _maxHealth);
        Debug.Log($"{gameObject.name} healed for {heal}! Health: {health}");
    }

    public void BuffStat(int statIncrease)
    {
        attackPower += statIncrease;
        Debug.Log($"{gameObject.name} increased attack power by {statIncrease}! Attack Power: {attackPower}");
    }

    public void SpecialEffect(int effectValue)
    {
        Debug.Log($"{gameObject.name} used a special effect with value {effectValue}!");
    }

    public void DrawCard(List<SOCardData> deck)
    {
        if (Hand.Count < 4 && deck.Count != 0) 
        {
            int cardIndex = Random.Range(0, deck.Count);
            Hand.Add(deck[cardIndex]);

            deck.Remove(deck[cardIndex]);
        }
        else
        {
            return;
        }
    }

    public void DiscardCard(SOCardData card)
    {
        Hand.Remove(card);
        DiscardPile.Add(card);
        UIManager.Instance.UpdateHandUI();
    }
}
