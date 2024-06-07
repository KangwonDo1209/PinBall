using UnityEngine;
using Unity.Cinemachine;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class CameraTracking : MonoBehaviour
{
	[HideInInspector]
	public List<GameObject> Balls;
	public Vector3 CameraStartPoint;
	public Vector3 CameraLowPoint;
	private void Awake()
	{
		AddBallList();
	}

	public void AddBallList()
	{
		GameObject[] list = GameObject.FindGameObjectsWithTag("Ball");
		foreach (GameObject ball in list)
		{
			Balls.Add(ball);
		}
	}

	private void Update()
	{
		TrackFirstObject();
	}

	private void TrackFirstObject()
	{
		if (Balls.Count == 0) return;

		Vector3 firstPosition = CameraStartPoint;

		foreach (GameObject item in Balls)
		{
			Vector3 pos = item.transform.position;
			if (firstPosition.y > pos.y && pos.y > CameraLowPoint.y)
				firstPosition = pos;
		}
		transform.position = firstPosition;
	}
}
