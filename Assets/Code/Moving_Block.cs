using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Block : MonoBehaviour {
	float Speed = 1;

	void Start () {
		Speed = Speed * Random.Range(1.00f, 3.00f);

		this.GetComponent<MeshRenderer>().material.color = new Color32((byte)Random.Range(0,251), (byte)Random.Range(0,251), (byte)Random.Range(0,251), (byte)250);
		if (this.transform.transform.position.x > .2f) {
			this.GetComponent<Rigidbody>().AddForce(new Vector3(Speed * -1, 0, 0), ForceMode.VelocityChange);
		}else if (this.transform.transform.position.x < -.2f) {
			this.GetComponent<Rigidbody>().AddForce(new Vector3(Speed, 0, 0), ForceMode.VelocityChange);
		}
	}

	void Update () {
		if (this.transform.transform.position.x < .05f && this.transform.transform.position.x > -.05f) {
			if (this.GetComponent<Rigidbody>().velocity.x > 0) {
				this.GetComponent<Rigidbody>().AddForce(new Vector3(Speed * -1, 0, 0), ForceMode.VelocityChange);
			}else if (this.GetComponent<Rigidbody>().velocity.x < 0) {
				this.GetComponent<Rigidbody>().AddForce(new Vector3(Speed, 0, 0), ForceMode.VelocityChange);
			}
			Destroy(this.GetComponent<Rigidbody>());
			this.transform.position = new Vector3(0, this.transform.transform.position.y, 0);
			Destroy(this);
		}
	}
}
