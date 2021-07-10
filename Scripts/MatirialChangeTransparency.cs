using System.Collections;
using UnityEngine;

public class MatirialChangeTransparency : MonoBehaviour
{
	[SerializeField]
	private Renderer render=null;
   private void OnTriggerEnter(Collider player)
	{

		StartCoroutine(SmoothColorChange());

	}
  private IEnumerator SmoothColorChange()
	{
		float t = 0f;

		while (t <= 1.0)
		{
			t += Time.deltaTime / 1.7f;


			render.material.color = Color.Lerp(render.material.color, Color.clear, Mathf.SmoothStep(0f, 1f, t));

			yield return null;
		}
	}
}
