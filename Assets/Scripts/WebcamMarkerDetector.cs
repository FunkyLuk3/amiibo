using Emgu.CV;
using Emgu.CV.Aruco;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WebcamMarkerDetector : MonoBehaviour
{
	public List<int> markers;
	public int last_detected_valid_marker;

	private VideoCapture webcam;
	private Mat webcame_frame;

	// Start is called before the first frame update
	void Start()
	{
		last_detected_valid_marker = 0;

		webcam = new VideoCapture(0, VideoCapture.API.DShow);
		webcame_frame = new Mat();

		if(webcam != null)
		{
			webcam.ImageGrabbed += new System.EventHandler(HandleWebcamQueryFrame);
			webcam.Start();
		}
		
		markers = new List<int>();
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
			if (markers.Contains(marker_ids[i]))
			{
				last_detected_valid_marker = marker_ids[i];
			}
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
