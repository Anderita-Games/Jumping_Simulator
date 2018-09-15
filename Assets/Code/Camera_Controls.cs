using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controls : MonoBehaviour {
	public GameObject Player;

	// Update is called once per frame
	void Update () {
		if (Player.transform.position.y + 1 > this.transform.position.y) {
			this.transform.position = new Vector3(0, Player.transform.position.y + 1, -10);
		}
	}
}
