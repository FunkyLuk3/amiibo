using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LightningDash : Capacite
{
	[SerializeField] float dash_distance;
	[SerializeField] GameObject dash_effect;

	private GameObject dash_effect_instance;

	public override void Activate(GameObject parent)
	{
		Rigidbody rb = parent.GetComponent<Rigidbody>();

		rb.transform.Translate(rb.velocity.normalized * dash_distance);

		//dash_effect_instance = Instantiate(dash_effect, parent.transform.position, Quaternion.Euler(0, parent.transform.Find("camera").transform.rotation.eulerAngles.y, 0));
	}

	public override void BeginCooldown(GameObject parent)
	{
		//Destroy(dash_effect_instance);
	}
}
