using Emgu.CV.Dnn;
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
        Personnage pers = parent.GetComponent<Personnage>();

        pers.rb.excludeLayers |= (1 << 6);

		pers.acceleration = dash_velocity;
        mr.enabled = false;
    }

    public override void BeginCooldown(GameObject parent) 
    {
        MeshRenderer mr = parent.GetComponent<MeshRenderer>();
        Personnage pers = parent.GetComponent<Personnage>();

        pers.rb.excludeLayers = 0;

		pers.acceleration = pers.speed;
        mr.enabled = true;
    }
}
