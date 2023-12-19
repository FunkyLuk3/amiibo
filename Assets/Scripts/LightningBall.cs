using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LightningBall : Capacite
{
	[SerializeField] GameObject projectile;

	private GameObject projectile_instance;

	public override void Activate(GameObject parent)
	{
		projectile_instance = Instantiate(projectile, parent.transform.position, parent.transform.rotation);

		projectile_instance.GetComponent<LightprojectileBehaviour>().direction = Quaternion.Euler(0, parent.transform.Find("camera").transform.rotation.eulerAngles.y, 0) * new Vector3(0, 0, 1);
	}

	public override void BeginCooldown(GameObject parent)
	{
	}
}
