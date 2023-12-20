using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player_instance;
	[SerializeField] List<GameObject> character_prefabs;

    private WebcamMarkerDetector instance_webcam;


	// Start is called before the first frame update
	void Start()
    {
        instance_webcam = gameObject.GetComponent<WebcamMarkerDetector>();

        instance_webcam.markers.Clear();

        foreach (GameObject character in character_prefabs)
        {
            instance_webcam.markers.Add(character.GetComponent<Personnage>().marker_id);
        }
	}

    // Update is called once per frame
    void Update()
    {
        // change character
        ChangeCharacterIfDifferentMarker();

	}

    public void ChangeCharacterIfDifferentMarker()
    {
        if(instance_webcam.last_detected_valid_marker != player_instance.GetComponent<Personnage>().marker_id)
        {
            Vector3 location = player_instance.transform.position;
            Quaternion camera_rotation = player_instance.GetComponent<Personnage>().camera.rotation;

            GameObject prefab_to_instantiate = null;
            foreach(GameObject character in character_prefabs)
            {
                if(character.GetComponent<Personnage>().marker_id == instance_webcam.last_detected_valid_marker)
                {
                    prefab_to_instantiate = character;
                }
            }
            
            if(prefab_to_instantiate != null)
            {
				Destroy(player_instance);

				player_instance = Instantiate(prefab_to_instantiate, location, new Quaternion());
                player_instance.GetComponent<Personnage>().camera.rotation = camera_rotation;
			}
        }
    }
}
