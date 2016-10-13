using UnityEngine;
using System.Collections;

public class spherePlayer : MonoBehaviour {
	int health;
	int damage;
	float moveFactor;
	bool midAir;
	float counter;

	//public = accessor
	public GameObject gameOver;

	Transform tf;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		health = 10;
		damage = 10;
		moveFactor = 10f;
		tf = GetComponent<Transform> ();
		rb = GetComponent<Rigidbody2D> ();
		midAir = false;
		counter = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		
		if (Input.GetKey(KeyCode.D)) {
			rb.AddForce (new Vector2 (10f, 0));
		}
		if (Input.GetKey(KeyCode.A)) {
			rb.AddForce (new Vector2 (-10f, 0));
		}
		if (Input.GetKeyDown(KeyCode.W) && counter <= Time.time) {
			//midAir = true;
			print (midAir);
			rb.AddForce (new Vector2 (0, 500f));
			counter = Time.time + 2f;
		}

		//destroyed here
		if (tf.position.y <= -13) {
			gameOver.SetActive (true);
			Destroy (gameObject);
		}
	}

	void OnCollisionStay2D(Collision2D col){
		if (col.gameObject.tag == "Wall") {
			midAir = false;
			print (midAir);
			Debug.Log ("u r touching");
		}
	}
}
