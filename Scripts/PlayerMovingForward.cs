
using UnityEngine;

public class PlayerMovingForward : MonoBehaviour
{
	[SerializeField]
	private float speed = 1;
	private Transform player_transform;
	[SerializeField]
	private Animator pl_ani=null,finish_anim=null;
	private bool stop_moving = false;
	[SerializeField]
	private GameObject particle_wind = null,particle_blast=null,slider_ice=null;

	private void Start()
    {
		player_transform = transform;
		player_transform.position = new Vector3(player_transform.position.x, 0.38f, player_transform.position.z);
		
	}

    
	private void FixedUpdate()
    {
		if(!stop_moving)
		player_transform.Translate(Vector3.forward * Time.deltaTime * speed);
		
    }
	
	public void StopMoving()
	{
		stop_moving = true;
		

		gameObject.GetComponent<Rigidbody>().isKinematic = true;
		if (pl_ani != null)
		{
			pl_ani.SetBool("drag", true);

		}
		if (finish_anim != null)
		{
			finish_anim.SetBool("play_anim", true);

		}
		particle_wind.SetActive(false);
	}
	public void SpeedUP()
	{
		
		particle_wind.GetComponent<ParticleSystem>().Emit((int)(speed/3f));
		speed += 3f;
		pl_ani.Play("cameraDrag");
	
	}
	private void OnTriggerEnter(Collider triggered_collider)
	{
		if (triggered_collider.gameObject.tag == ("iceCream"))
		{
			Instantiate(particle_blast, triggered_collider.transform.position,Quaternion.identity);
			slider_ice.SetActive(false);
			Destroy(player.gameObject);
		}
	}
}
