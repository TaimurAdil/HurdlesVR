using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

	public TextMesh infoText;
	public Player player;

	private float gameTimer = 0f;
	private float restartTimer = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player.reachedFinishLine == true) {
			infoText.text = "You win! \nYour time: " + Mathf.Floor (gameTimer);

			restartTimer -= Time.deltaTime;
			if (restartTimer <= 0f) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().name);
			}
		} else {
			gameTimer += Time.deltaTime;
			infoText.text = "Avoid the obstacles! \nTime: " + Mathf.Floor (gameTimer);
		}
	}
}
