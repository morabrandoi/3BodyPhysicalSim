using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PositionReset : MonoBehaviour
{

    private Vector3 defPos;
    private Quaternion defRot;
    private Vector3 defScale;
    // Start is called before the first frame update
    void Start()
    {
        defPos = transform.position;
        defRot = transform.localRotation;
        defScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetInitials()
    {
        transform.position = defPos;
        transform.localRotation = defRot;
        transform.localScale = defScale;
    }
}
