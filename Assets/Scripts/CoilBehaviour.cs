using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilBehaviour : MonoBehaviour
{ 
    [SerializeField] GameObject wall_instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Lightning"))
        {
            Destroy(wall_instance);
        }
	}
}
