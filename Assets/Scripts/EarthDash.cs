using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class EarthDash : Capacite
{

    public float dash_velocity;

    public override void Activate(GameObject parent)
    {
        MeshRenderer mr = parent.GetComponent<MeshRenderer>();
        Personnage movement = parent.GetComponent<Personnage>();

        movement.acceleration = dash_velocity;
        mr.enabled = false;
    }

    public override void BeginCooldown(GameObject parent) 
    {
        MeshRenderer mr = parent.GetComponent<MeshRenderer>();
        Personnage movement = parent.GetComponent<Personnage>();

        movement.acceleration = movement.speed;
        mr.enabled = true;
    }
}
