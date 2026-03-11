using System;
using UnityEngine;
using UnityEngine.Rendering;

public class Character
{
    private float maxHealth;
    private float health;
    private float maxMana;
    private float mana;
    private float speed;

    public event Action<float> onHealthChanged;
    public event Action<float> onManaChanged;
    public event Action<float> onSpeedChanged;

    public float Health
    {
        get { return health; }
        private set
        {
            health = value;
            onHealthChanged?.Invoke(health);
        }
    }
    public float Mana
    {
        get { return mana; }
        set
        {
            mana = value;
            onManaChanged?.Invoke(mana);
        }
    }
    public float Speed
    {
        get { return speed; }
        set
        {
            speed = value;
            onSpeedChanged?.Invoke(speed);
        }
    }

    public Character(CharacterData data)
    {
        maxHealth = data.maxHealth;
        health = maxHealth;
        maxMana = data.maxMana;
        mana = maxMana;
        speed = data.speed;
    }


}
