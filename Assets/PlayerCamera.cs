using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public float movementAmplitude = 0.1f;
	public float movementFrequency = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3 (
			transform.localPosition.x,
			Mathf.Cos(transform.position.z * movementFrequency) * movementAmplitude,
			transform.localPosition.z
		);
    }
}
