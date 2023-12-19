using Emgu.CV;
using Emgu.CV.Aruco;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebcamMarkerDetector : MonoBehaviour
{
	[SerializeField] private List<int> markers;
	[SerializeField] private double threshold_maxvalue;


	private VideoCapture webcam;
	private Mat webcame_frame;

	// Start is called before the first frame update
	void Start()
	{
		webcam = new VideoCapture(0, VideoCapture.API.DShow);
		webcame_frame = new Mat();

		if(webcam != null)
		{
			webcam.ImageGrabbed += new System.EventHandler(HandleWebcamQueryFrame);
			webcam.Start();
		}
		
	}

	// Update is called once per frame
	void Update()
	{
		if (webcam != null && webcam.IsOpened)
		{
			webcam.Grab();
		}
	}

	private void HandleWebcamQueryFrame(object sender, System.EventArgs e)
	{
		if (webcam != null && webcam.IsOpened)
		{
			// retrieve frame
			webcam.Retrieve(webcame_frame);

			// detect marker
			DetectMarkers();
		}
	}

	private void DetectMarkers()
	{
        VectorOfVectorOfPointF corners = new VectorOfVectorOfPointF();
        VectorOfInt marker_ids = new VectorOfInt();
        Dictionary dict = new Dictionary(Dictionary.PredefinedDictionaryName.Dict4X4_1000);

        ArucoInvoke.DetectMarkers(webcame_frame, dict, corners, marker_ids, DetectorParameters.GetDefault());

        for (int i = 0; i < marker_ids.Size; i++)
        {
            Debug.Log(marker_ids[i]);
        }
    }

	void OnDestroy()
	{
		if (webcam != null)
		{
			webcam.Stop();
			webcam.Dispose();
		}
	}
}
