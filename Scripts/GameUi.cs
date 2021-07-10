
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUi : MonoBehaviour
{
	[SerializeField]
	private Text score_text = null;
	private int score_int = 0;

	private void Start()
	{
		score_text.text = "" + score_int;
	}

	public void AddScore()
	{
		score_int++;
		score_text.text = "" + score_int;
	}
	public void NextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
