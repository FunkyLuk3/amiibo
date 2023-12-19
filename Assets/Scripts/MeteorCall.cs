using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class MeteorCall : Capacite
{
    [SerializeField] float destruction_range;
    public GameObject spell;
    private GameObject spell_instance;

    public override void Activate(GameObject parent)
    {
        Personnage movement = parent.GetComponent<Personnage>();
        movement.acceleration = 0;

        spell_instance = Instantiate(spell, parent.transform);

        GameObject[] bushes = GameObject.FindGameObjectsWithTag("Bush");
        foreach(GameObject bush in bushes)
        {
            if(Vector3.Distance(bush.transform.position, parent.transform.position) < destruction_range)
            {
                Destroy(bush);
            }
        }
    }

    public override void BeginCooldown(GameObject parent)
    {
        Personnage movement = parent.GetComponent<Personnage>();
        movement.acceleration = movement.speed;

        DestroyImmediate(spell_instance, true);
    }
}
