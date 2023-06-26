using UnityEngine;

public class CameraController : MonoBehaviour
{    
	[SerializeField]
	private Vector3 _offset;
	[SerializeField]
	private float _zoomSpeed = 4f;
	[SerializeField]
	private float _minZoom = 5f;
	[SerializeField]
	private float _maxZoom = 15f;
	[SerializeField]
	private float yawSpeed = 100f;
	[SerializeField]
	private Player _target = null;

	private float pitch = 1.8f;        
	private float currentZoom = 5f;
	private float currentYaw = 0f;

    private void Start()
    {
		//_target = FindObjectOfType<Player>();
	}
    void Update()
	{
		
		currentZoom -= Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed;
		currentZoom = Mathf.Clamp(currentZoom, _minZoom, _maxZoom);

		
		currentYaw += Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
	}

	void LateUpdate()
	{
		
		transform.position = _target.transform.position - _offset * currentZoom;
		
		transform.LookAt(_target.transform.position + Vector3.up * pitch);
		
		transform.RotateAround(_target.transform.position, Vector3.up, currentYaw);
	}
    private void OnDrawGizmos()
    {
		Gizmos.color = Color.red;
		Gizmos.DrawRay(transform.position,_target.transform.position - transform.position);
    }
}