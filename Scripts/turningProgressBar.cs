
using UnityEngine;
using UnityEngine.UI;

public class turningProgressBar : MonoBehaviour
{
    [SerializeField]
	private Slider progress_bar = null;


	[SerializeField]
	private Transform start_point = null, finish_point = null,midle_point=null;
	[SerializeField]
	private Transform player_tr=null;



	private void Start()
	{
		


		progress_bar.minValue = start_point.position.z;
		progress_bar.maxValue = midle_point.position.z-(finish_point.position.x-midle_point.position.x);



	}

	private void LateUpdate()
	{
		if (player_tr != null)
		{
			progress_bar.value = player_tr.position.z - (player_tr.position.x - midle_point.position.x);
		
		}
	}
}
