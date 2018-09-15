using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Master : MonoBehaviour {
	public GameObject Moving_Block;
	public GameObject Player;

	public UnityEngine.UI.Text Score_Text;
	public UnityEngine.UI.Text Highscore_Text;
	public GameObject Start_Text;
	public GameObject End_Text;

	bool Game_Active = false;
	int Score = 0;


	void Update () {
		Score_Text.text = "Score: " + Score;
		Highscore_Text.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
		if (Player.transform.position.y + 5 < Score) {
			Game_Active = false;
			End_Text.SetActive(true);
			if (PlayerPrefs.GetInt("Highscore") < Score) {
				PlayerPrefs.SetInt("Highscore", Score);
			}
		}
		if (Input.GetMouseButtonDown(0) && Game_Active == false) {
			if (Score == 0) {
				Start_Text.SetActive(false);
				Game_Active = true;
				StartCoroutine(Generate());
			}else {
				SceneManager.LoadScene("Game");
			}
		}
	}

	IEnumerator Generate () {
		yield return new WaitForSeconds(3f);
		while (Game_Active == true) {
			if (Random.Range(0,2) == 0) {
				Instantiate(Moving_Block, new Vector3(-5.5f, Score - 1, 0), new Quaternion(0, 0, 0, 0));
			}else {
				Instantiate(Moving_Block, new Vector3(5.5f, Score - 1, 0), new Quaternion(0, 0, 0, 0));
			}
			Score++;
			yield return new WaitForSeconds(Random.Range(3, 6));
		}
	}
}
