using UnityEngine;
using System.Collections;
using System;
using System.IO;
using OpenCvSharp;

//using OpenCvSharp.Extensions;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;

public class webcamCanny : MonoBehaviour
{
	public GameObject planeObj;
	public WebCamTexture webcamTexture;
	public Texture2D texImage;
	public string deviceName;
	private int devId = 1;
	private int imWidth = 320;
	private int imHeight = 240;
	private string errorMsg = "";
	public string updateMsg = "";
	public float test;
	static IplImage matrix;
	
	// Use this for initialization
	void Start ()
	{
		WebCamDevice[] devices = WebCamTexture.devices;
		Debug.Log ("num:" + devices.Length);
		
		for (int i=0; i<devices.Length; i++) {
			print (devices [i].name);
			if (devices [i].name.CompareTo (deviceName) == 1) {
				devId = i;
			}
		}
		
		if (devId >= 0) {
			planeObj = GameObject.Find ("Plane");
			texImage = new Texture2D (imWidth, imHeight, TextureFormat.RGB24, false);
			webcamTexture = new WebCamTexture (devices [devId].name, imWidth, imHeight, 60);
			webcamTexture.Play ();
			
			matrix = new IplImage (imWidth, imHeight, BitDepth.U8, 3);
		}

		test = Time.realtimeSinceStartup;
	}
	
	void Update ()
	{
		float t = Time.realtimeSinceStartup;
		if (devId >= 0) {
			errorMsg = "";
			Texture2DtoIplImage ();
			
			IplImage cny = new IplImage (imWidth, imHeight, BitDepth.U8, 1);
			matrix.CvtColor (cny, ColorConversion.RgbToGray);
			
			Cv.Canny (cny, cny, 50, 50, ApertureSize.Size3);
			//Cv.Sobel(cny,cny,5,5,ApertureSize.Size7);
			
			Cv.CvtColor(cny, matrix, ColorConversion.GrayToBgr);

			if (webcamTexture.didUpdateThisFrame) {
				IplImageToTexture2D ();
			}
			
			
		} else {
			Debug.Log ("Can't find camera!");
		}
		updateMsg += Time.realtimeSinceStartup - t + "\t";
		if (Time.realtimeSinceStartup - test >= 10) {
			Debug.Log (updateMsg);
			test = Time.realtimeSinceStartup;
		}
	}
	
	void OnGUI ()
	{
		GUI.Label (new Rect (200, 200, 400, 400), errorMsg);
	}
	
	void IplImageToTexture2D ()
	{
		int y = imHeight;
		int x = imWidth;
		Color[] c = new Color[imWidth*imHeight];

		for (int i = 0; i < c.Length; i++) {
			y = imHeight - (i / imWidth) - 1;
			x = i % imWidth;

			c[i] = new Color(((float)matrix [y, x].Val0)/255.0f,((float)matrix [y, x].Val1)/255.0f,((float)matrix [y, x].Val2)/255.0f);
		}
		texImage.SetPixels (c);


		texImage.Apply ();
		planeObj.renderer.material.mainTexture = texImage;

	}
	
	void Texture2DtoIplImage ()
	{
		int jBackwards = imHeight;
		
		for (int v=0; v<imHeight; ++v) {
			for (int u=0; u<imWidth; ++u) {
				
				CvScalar col = new CvScalar ();
				col.Val0 = (double)webcamTexture.GetPixel (u, v).b * 255;
				col.Val1 = (double)webcamTexture.GetPixel (u, v).g * 255;
				col.Val2 = (double)webcamTexture.GetPixel (u, v).r * 255;
				
				jBackwards = imHeight - v - 1;
				
				matrix.Set2D (jBackwards, u, col);
				//matrix [jBackwards, u] = col;
			}
		}
		//Cv.SaveImage ("C:\\Hasan.jpg", matrix);
	}
}
