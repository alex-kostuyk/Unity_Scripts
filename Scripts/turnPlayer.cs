using System.Collections;
using UnityEngine;

public class turnPlayer : MonoBehaviour
{
	private Transform player=null;
	[SerializeField]
	private float seconds=1.7f;
	private bool turn = false;
	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private void OnTriggerEnter(Collider collider)
	{

		turn = true;
	
	}

	private void FixedUpdate()
	{
		if(turn)
		{

			player.rotation = Quaternion.Lerp(player.rotation,Quaternion.Euler(0,-90,0),seconds*Time.fixedDeltaTime);
		


		}
	}



}
