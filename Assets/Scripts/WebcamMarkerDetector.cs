using Emgu.CV;
using Emgu.CV.Aruco;
using Emgu.CV.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebcamMarkerDetector : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	private void DetectMarkers()
	{
        Emgu.CV.Mat img = new Mat("Assets\\Images\\35.png");

        VectorOfVectorOfPointF corners = new VectorOfVectorOfPointF();
        VectorOfInt marker_ids = new VectorOfInt();
        Dictionary dict = new Dictionary(Dictionary.PredefinedDictionaryName.Dict4X4_1000);
        ArucoInvoke.DetectMarkers(img, dict, corners, marker_ids, DetectorParameters.GetDefault());

        for (int i = 0; i < marker_ids.Size; i++)
        {
            Debug.Log(marker_ids[i]);
        }
    }
}
