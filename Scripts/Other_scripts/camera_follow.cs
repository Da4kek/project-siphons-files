using UnityEngine;

public class camera_follow : MonoBehaviour {
	public  Transform target;
	public Vector3 CameraZOffset;
	//public float smoothSpeed = 10f;
	public float dampTime;
	private Vector3 moveVelocity = Vector3.zero;
	void FixedUpdate()
	{
		Vector3 desiredPosition = target.position + CameraZOffset;
		//Vector3 SmoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed*Time.deltaTime);
		Vector3 SmoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref moveVelocity, dampTime * Time.deltaTime);
		transform.position  = SmoothedPosition;

	}
}
