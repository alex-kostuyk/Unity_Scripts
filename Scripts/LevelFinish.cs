using UnityEngine;

public class LevelFinish : MonoBehaviour
{
	[SerializeField]
	private Transform [] particle_spawn_point=null;
	[SerializeField]
	private GameObject finish_ui=null, particle=null,game_UI=null;

	private GameObject player_gameObj = null;
	private void Start()
	{
		player_gameObj = GameObject.FindGameObjectWithTag("Player");
	}
	private void OnTriggerEnter(Collider player)
	{
		
			for (int i = 0; i < particle_spawn_point.Length; i++)
				Instantiate( particle,particle_spawn_point[i].position,particle_spawn_point[i].rotation);
			
		  
		    Invoke("finish_UI_with_delay",0.6f);
			player_gameObj.GetComponent<PlayerMovingForward>().StopMoving();
		player_gameObj.GetComponent<PlayerScalingControll>().StopScaling();
	}

	private void finish_UI_with_delay()
	{
		
		finish_ui.SetActive(true);
		game_UI.SetActive(false);
	}
}
