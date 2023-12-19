using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class MeteorCall : Capacite
{
    public GameObject spell;
    private GameObject spell_instance;
    public override void Activate(GameObject parent)
    {
        Personnage movement = parent.GetComponent<Personnage>();
        movement.acceleration = 0;

        spell_instance = Instantiate(spell);

    }

    public override void BeginCooldown(GameObject parent)
    {
        Personnage movement = parent.GetComponent<Personnage>();
        movement.acceleration = movement.speed;

        DestroyImmediate(spell_instance, true);
    }
}
