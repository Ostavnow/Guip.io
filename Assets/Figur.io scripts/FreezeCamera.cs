using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeCamera : MonoBehaviour
{
    public GameObject Camera;
    void LateUpdate()   
        
    {
        Camera.transform.rotation = Quaternion.Euler(0,0,0);
    }
}
