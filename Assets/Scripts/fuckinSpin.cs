using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuckinSpin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(10, 2, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
