using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    private void Update()
    {
        Vector3 pos = transform.position;
        if ((pos.z < 0.3) && (pos.z > -1.7) && (pos.x > 0.75) && (pos.x < 2)){
            SceneManager.LoadScene(1);
        }
    }
}
  