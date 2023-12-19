using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capacite : ScriptableObject
{
    [SerializeField] private string name;
    public float cooldown_time;
    public float active_time;

    public virtual void Activate(GameObject parent){}
    public virtual void BeginCooldown(GameObject parent){}
}
