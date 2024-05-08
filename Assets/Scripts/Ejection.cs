using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejection : MonoBehaviour
{
    float speed = 25;
    [HideInInspector]
    public bool check;
    void Update()
    {
         if(check)
        {
            Destroy(gameObject);
        }
       else if(speed > 0)
        {
            speed -= speed * Time.deltaTime;
        transform.Translate(Vector2.up * (speed) * Time.deltaTime);
        }
        else if (speed > 1)
        {

           speed = 0;
        }   
        
    }
    void OnTriggerExit2D(Collider2D other) {
        Debug.Log("D");
            gameObject.GetComponentInChildren<Transform>().GetChild(0).GetComponent<CircleCollider2D>().enabled = true;
        }
}
