using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
	public float RotateSpeed = 100.0f;

	private void Update()
	{
		RotateBlock();
	}

	private void RotateBlock()
	{
		transform.Rotate(0, 0, -RotateSpeed * Time.deltaTime);
	}
}
