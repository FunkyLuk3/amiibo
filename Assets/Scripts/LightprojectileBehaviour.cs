using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightprojectileBehaviour : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, duration);
	}

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * speed;
    }
}
