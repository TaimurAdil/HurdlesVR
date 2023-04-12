using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maximumSpeed = 5.5f;
	public float acceleration = 1f;
	public float jumpingForce = 400f;
	public float jumpingCooldown = 0.6f;

	public bool reachedFinishLine = false;

	private float speed = 0f;
	private float jumpingTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player forward.
		speed += acceleration * Time.deltaTime;
		if (speed > maximumSpeed) {
			speed = maximumSpeed;
		}
		transform.position += speed * Vector3.forward * Time.deltaTime;

		// Make the player jump.
		jumpingTimer -= Time.deltaTime;
		if (
			   Input.GetKeyDown(KeyCode.Space) 
			|| Input.GetKeyDown(KeyCode.UpArrow)
			|| Input.GetKeyDown(KeyCode.A)
			|| Input.GetKeyDown(KeyCode.B)
			|| Input.GetKeyDown(KeyCode.C)
			|| Input.GetKeyDown(KeyCode.D)
			|| Input.GetKeyDown(KeyCode.X)
			|| Input.GetKeyDown(KeyCode.Y)
			|| Input.GetKeyDown(KeyCode.Z)
		) {
			if (jumpingTimer <= 0f) {
				jumpingTimer = jumpingCooldown;
				
				Rigidbody rb = GetComponent<Rigidbody>();
				rb.AddForce(Vector3.up * jumpingForce); 
			}
		}
    }

    void OnTriggerEnter (Collider collider) {
		if (collider.tag == "Obstacle") {
			speed *= 0.3f;
		}

		if (collider.tag == "FinishLine") {
			reachedFinishLine = true;
		}
	}
}
