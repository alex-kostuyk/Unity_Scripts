
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform player_tr,camera_tr;
	[SerializeField]
	private float smooth_speed = 10f;


	private void Start()
	{
		player_tr = GameObject.FindGameObjectWithTag("Player").transform;
		camera_tr = transform;
	}
	private void FixedUpdate()
	{
		if (player_tr == null)
		{

		}
		else
		{
			camera_tr.position = Vector3.Lerp(camera_tr.position, player_tr.position, smooth_speed * Time.fixedDeltaTime);
			camera_tr.rotation = Quaternion.Lerp(camera_tr.rotation, player_tr.rotation, smooth_speed * Time.fixedDeltaTime);
		}
	}

}
