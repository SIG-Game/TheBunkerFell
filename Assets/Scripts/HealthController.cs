using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private UI ui;

    //public event Action OnHealthSet = () => { };

    public int Health
    {
        get => _health;
        set
        {
            _health = value;

            if (_health > maxHealth)
            {
                _health = maxHealth;
            }
            else if (_health < 0)
            {
                // TODO: Make something happen on player death
                _health = 0;
            }

            // TODO: Remove this when the player health UI is added
            Debug.Log($"Health: {_health}");

            ui.SetHealthBar(_health);

            //OnHealthSet();
        }
    }

    private int _health;

    private void Awake()
    {
        _health = maxHealth;
    }

    private void Start()
    {
        //OnHealthSet();
    }

    private void Update()
    {
        // TODO: Remove this when health can be changed by something else in-game
        if (Input.GetKeyDown(KeyCode.W))
        {
            Health++;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Health--;
        }
    }
}
