using Emgu.CV;
using Emgu.CV.Aruco;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class WebcamMarkerDetector : MonoBehaviour
{
	[SerializeField] RawImage webcam_display;

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
	}

	// Update is called once per frame
	void Update()
	{
		if (webcam != null && webcam.IsOpened)
		{
			webcam.Grab();

			DisplayFrameOnPlane();
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
			Rectangle rect = new Rectangle(new Point ((int)corners[i][0].X, (int)corners[i][0].Y),
										   new Size((int)corners[i][2].X - (int)corners[i][0].X, (int)corners[i][2].Y - (int)corners[i][0].Y));

			MCvScalar color = new MCvScalar(0, 0,255,0);

			CvInvoke.Rectangle(webcame_frame, rect, color, 3);

			if (markers.Contains(marker_ids[i]))
			{
				last_detected_valid_marker = marker_ids[i];
			}
        }
    }

	private void DisplayFrameOnPlane()
	{
		int w = webcam_display.texture.width;
		int h = webcam_display.texture.height;
		Texture2D t = new Texture2D(w, h, TextureFormat.RGBA32, false);

		Mat m = new Mat(h, w, Emgu.CV.CvEnum.DepthType.Cv8U, 4);
		CvInvoke.Resize(webcame_frame, m, new System.Drawing.Size(w, h));
		CvInvoke.Flip(m, m, Emgu.CV.CvEnum.FlipType.Vertical);
		CvInvoke.CvtColor(m, m, Emgu.CV.CvEnum.ColorConversion.Bgra2Rgba);

		t.LoadRawTextureData(m.GetDataPointer(), w*h*4);

		t.Apply();

		webcam_display.texture = t;
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
