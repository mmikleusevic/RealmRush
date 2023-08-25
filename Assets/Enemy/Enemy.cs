using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;
    [SerializeField] int damage = 5;

    Bank bank;
    Health health;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
        health = FindObjectOfType<Health>();
    }

    public void RewardGold()
    {
        if (bank == null) return;
        bank.Deposit(goldReward);
    }

    public void StealGold()
    {
        if (bank == null) return;

        health.DecreaseHealth(damage);

        bank.Withdraw(goldPenalty);
    }
}
