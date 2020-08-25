using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSimulation : MonoBehaviour
{
    public GameObject orbitingBodiesGameObject;

    private List<Transform> orbitingBodies = new List<Transform>();
    private void Start()
    {
        for (int i = 0; i < orbitingBodiesGameObject.transform.childCount; ++i)
        {
            orbitingBodies.Add(orbitingBodiesGameObject.transform.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(wasClicked())
        {
            foreach(Transform body in orbitingBodies)
            {
                GameObject bodyGameObject = body.gameObject;
                bodyGameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                bodyGameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                bodyGameObject.GetComponent<PositionReset>().resetInitials();
                bodyGameObject.GetComponentInChildren<TrailRenderer>().Clear();

                body.Find("VeloVec").gameObject.SetActive(true);
            }

            orbitingBodiesGameObject.GetComponent<IterateGravity>().isPaused = true;

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

                if (hit.collider.gameObject.name == "ResetButton")
                {
                    print("Hit start button");
                    return true;
                }
            }
        }

        return false;
    }
}
