using Emgu.CV;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amiibo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Emgu.CV.Mat img = new Mat("Assets\\Images\\jane_comi.png");
        Debug.Log(img.Size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
