using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IterateGravity : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isPaused = true;
    public float gravitationalConstant = 10;
    private List<Transform> orbitingBodies = new List<Transform>();
    void Start()
    {
        // throws all children of 

        for (int i = 0; i < transform.childCount; ++i) { 
            orbitingBodies.Add(transform.GetChild(i));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isPaused)
        {
            foreach (Transform beingPulled in orbitingBodies)
            {
                Vector3 resultant = Vector3.zero;
                Rigidbody beingPulledRb = beingPulled.gameObject.GetComponent<Rigidbody>();
                float beingPulledMass = beingPulledRb.mass;
                foreach (Transform pullingBody in orbitingBodies)
                {
                    if (beingPulled == pullingBody)
                    { continue; }

                    float pullingBodyMass = pullingBody.gameObject.GetComponent<Rigidbody>().mass;

                    Vector3 direction = pullingBody.position - beingPulled.position;
                    float magnitudeOfPull = gravitationalConstant * pullingBodyMass / Mathf.Pow(direction.magnitude, 2); // this is the gravitation equation
                    resultant += magnitudeOfPull * direction.normalized;
                }

                beingPulledRb.velocity += resultant * Time.fixedDeltaTime;
            }
        }
        
    }

    void calculateResultantPullVector()
    {
        // Will calculate resultant pull on a body based on the board
    }

    // In the future when the player add's a new orbiting body, this function will get triggered 
    // and update the list with the new body.
    void updateOrbitingBodyList(Transform newBody)
    {
        orbitingBodies.Add(newBody);
    }
}
