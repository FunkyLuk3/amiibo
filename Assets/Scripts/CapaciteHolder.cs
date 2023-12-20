using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapaciteHolder : MonoBehaviour
{
    public Capacite capacite;
    private float cooldown_time;
    private float active_time;

    enum EtatCapacite
    {
        ready,
        active,
        coodown
    }

    EtatCapacite state = EtatCapacite.ready;

    public KeyCode cle;

    void Update()
    {
        switch (state)
        {
            case EtatCapacite.ready:
                if (Input.GetKeyDown(cle))
                {
                    capacite.Activate(gameObject);
                    state = EtatCapacite.active;
                    active_time = capacite.active_time;
                }
                break;
            case EtatCapacite.active:
                if (active_time > 0)
                {
                    active_time -= Time.deltaTime;
                }
                else
                {
                    capacite.BeginCooldown(gameObject);
                    state = EtatCapacite.coodown;
                    cooldown_time = capacite.cooldown_time;
                }
                break;
            case EtatCapacite.coodown:
                if (cooldown_time > 0)
                {
                    cooldown_time -= Time.deltaTime;
                }
                else
                {
                    state = EtatCapacite.ready;
                }
                break;
        }
    }
}
