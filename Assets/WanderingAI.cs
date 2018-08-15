using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime); // Move forward continuously every frame, regardless of turning.

        Ray ray = new Ray(transform.position, transform.forward); // A ray at the same position and pointing the same direction as the character
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110); // Turn toward a semirandom new direction
                transform.Rotate(0, angle, 0);
            }
        }
    }
}
