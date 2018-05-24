using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using System.IO;

public class OnClickHandler : MonoBehaviour {

	private List<FeaturePoint> m_PointCloudPoints = new List<FeaturePoint>();

	private string FILEPATH;

	private StreamWriter sr;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetAnchorPoints()
	{
		Session.GetTrackables<FeaturePoint>(m_PointCloudPoints, TrackableQueryFilter.New);

		FILEPATH = Application.persistentDataPath + "/" + "point_cloud_data.obj";
		sr = File.CreateText(FILEPATH);

		for (int i = 0; i <= m_PointCloudPoints.Count; i++) {
			Pose mypose = m_PointCloudPoints [i].Pose;
			float x = mypose.position.x;
			float y = mypose.position.y;
			float z = mypose.position.z;

			string point_cloud = "v " + x.ToString () + " " + y.ToString () + " " + z.ToString ();
			sr.WriteLine (point_cloud);
		}

		sr.Close ();
	}
}
