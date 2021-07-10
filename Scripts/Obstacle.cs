
using UnityEngine;

	public class Obstacle : MonoBehaviour
	{
		
		[SerializeField]
		private bool turn_left = false;
		[SerializeField]
		private GameObject pass = null;
		[SerializeField]
		private Transform proection_tr = null, player_tr = null, cube_prorction = null;
		private bool inzone = false;
		private void Start()
		{
			player_tr = GameObject.FindGameObjectWithTag("Player").transform;
		}


		private void LateUpdate()
		{
			if (inzone)
			{
				proection_tr.localScale = new Vector3(player_tr.localScale.x, player_tr.localScale.y, proection_tr.localScale.z);
				proection_tr.position = new Vector3(proection_tr.position.x, player_tr.GetChild(0).transform.position.y, proection_tr.position.z);

				if (!turn_left)
				{
					cube_prorction.position = new Vector3(player_tr.position.x, player_tr.GetChild(0).transform.position.y, player_tr.position.z + ((proection_tr.position.z - player_tr.position.z) / 2));

				}
				else
				{
					cube_prorction.position = new Vector3(player_tr.position.x + ((proection_tr.position.x - player_tr.position.x) / 2), player_tr.GetChild(0).transform.position.y, player_tr.position.z);

				}
				Vector3 direction = player_tr.position - cube_prorction.position;

				cube_prorction.localScale = new Vector3(proection_tr.localScale.x, proection_tr.localScale.y, direction.magnitude * 2f);
			}
		}
		private void OnTriggerStay(Collider other)
		{
			if (PlayerPrefs.GetInt("select") == 0)
			{
				inzone = true;
				PlayerPrefs.SetInt("select", 1);
				proection_tr.gameObject.SetActive(true);
				cube_prorction.gameObject.SetActive(true);
			}

		}

		private void OnTriggerExit(Collider other)
		{
			player_tr.gameObject.GetComponent<PlayerMovingForward>().SpeedUP();
			pass.SetActive(true);
			PlayerPrefs.SetInt("select", 0);
			proection_tr.gameObject.SetActive(false);
			cube_prorction.gameObject.SetActive(false);
			inzone = false;
			
		}
		
	}


