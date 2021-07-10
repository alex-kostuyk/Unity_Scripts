using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Imphenzia
{



	public class changeSkyColor :  GradientSkyCommon
	{
		[SerializeField]
		private Color change_backGround;
		private Color defalt_col;
		private Gradient camera_gradient;
		private void Start()
        {
			camera_gradient = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GradientSkyCamera>().gradient;

		}
		private void OnTriggerEnter(Collider player)
		{

			defalt_col = camera_gradient.Evaluate(1);

			StartCoroutine(SmoothColorChange());

		}
		private IEnumerator SmoothColorChange()
		{
			float t = 0f;
				camera_gradient = new Gradient();

				GradientColorKey[] gradient_color_key = new GradientColorKey[2];
				GradientAlphaKey[] gradient_alpha_key = new GradientAlphaKey[2];

			gradient_color_key[0].color = Color.white;
			gradient_color_key[0].time = 0.0F;

			gradient_color_key[1].time =  1.0F;

			gradient_alpha_key[0].alpha = 1.0F;
			gradient_alpha_key[0].time = 0.0F;

			gradient_alpha_key[1].alpha = 1.0F;
			gradient_alpha_key[1].time = 1.0F;
			
			while (t <= 1.0)
			{
				t += Time.deltaTime / 0.3f;




				gradient_color_key[1].color = Color.Lerp(defalt_col, change_backGround, Mathf.SmoothStep(0f, 1f, t));
			
				camera_gradient.SetKeys(gck, gak);



				yield return null;
			}
		}
	}

}
