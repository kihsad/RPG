using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class CameraRotateAround : MonoBehaviour
	{

		public Transform target;
		public Vector3 offset;
		public float sensitivity = 3; // чувствительность мышки
		public float limit = 80; // ограничение вращения по Y
		public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
		public float zoomMax = 10; // макс. увеличение
		public float zoomMin = 3; // мин. увеличение
		private float X, Y;
		void Start()
		{
			limit = Mathf.Abs(limit);
			if (limit > 90) limit = 90;
			offset = new Vector3(0, 0, Mathf.Abs(zoomMax));
			transform.position = target.position + new Vector3(0,20,20);
		    transform.LookAt(target);
		}

	void Update()
	{
			if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
			else if (Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
			offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));
		if (Input.GetKey(KeyCode.Mouse2))
		{
			X = transform.localEulerAngles.y + Input.GetAxis("Horizontal") * sensitivity;
			Y += Input.GetAxis("Vertical") * sensitivity;
			Y = Mathf.Clamp(Y, -limit, 0);
			transform.localEulerAngles = new Vector3(-Y, X, 0);
		}
			transform.position = transform.localRotation * offset + target.position;
	}
	} 
