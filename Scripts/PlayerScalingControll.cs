
using UnityEngine;
using UnityEngine.UI;
public class PlayerScalingControll : MonoBehaviour
{
	[SerializeField]
	private Slider sliderCont=null;
	[SerializeField]
	private float speed=6;
	private Transform player_tr;
	private bool finished = false;
	private float sum;
    private void Start()
    {
        player_tr = GameObject.FindGameObjectWithTag("Player").transform;
		sum = sliderCont.minValue + sliderCont.maxValue;
    }

   
	private void FixedUpdate()
    {
		if (!finished)
		{
			

			
			player_tr.localScale = Vector3.Lerp(player_tr.localScale, new Vector3(sliderCont.value, sum-sliderCont.value, player_tr.localScale.z), speed * Time.deltaTime);
			
		}
    }
	public void StopScaling()
	{
		finished = true;
		player_tr.localScale = new Vector3(1.3f, 1.3f, 1.3f);
	}
	
}
