using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startSimulation : MonoBehaviour
{
    public GameObject orbitingBodies;
    public float arrowDistanceMultiplier = 1;
    private List<Transform> bodies = new List<Transform>();



    private void Start()
    {
        for (int i = 0; i < orbitingBodies.transform.childCount; ++i)
        {
            bodies.Add(orbitingBodies.transform.GetChild(i));
        }
    }
    // Update is called once per frame
    void Update()
    {
        bool isPaused = orbitingBodies.GetComponent<IterateGravity>().isPaused;
        if (wasClicked() && isPaused)
        {
            // Iterate through arrows and give their bodies init velcoity
            foreach(Transform body in bodies)
            {
                Rigidbody rb = body.GetComponent<Rigidbody>();
                Transform arrowTransform = body.transform.Find("VeloVec");

                rb.velocity = arrowDistanceMultiplier * (arrowTransform.position - body.transform.position);

                arrowTransform.gameObject.SetActive(false);

            }

            // Hide all arrows
            

            // set orbiting bodies to run
            orbitingBodies.GetComponent<IterateGravity>().isPaused = false;

            // give each orbting body its velocty
        }
    }

    bool wasClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.gameObject.name == "StartButton")
                {
                    print("Hit start button");
                    return true;
                }
            }
        }

        return false;
    }
}
