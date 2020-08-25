using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maintainArrowHeading : MonoBehaviour
{
    [Range(-10,10)]
    public float x=0, y=1, z=0;
    // Update is called once per frame
    void Update()
    {
        Vector3 papaLoc = transform.parent.position;
        transform.rotation = Quaternion.LookRotation(transform.position - papaLoc, new Vector3(x,y,z));
    }
}
