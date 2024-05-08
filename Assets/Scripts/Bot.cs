using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public float mass = 18;
    float quotient;
    float delta;
    Vector2 target;
    Vector2 vecScale;
    Vector2 randVect;
    GameObject objTarget;
    bool IsEat = true;
    void Update() {
        if(objTarget != null)
        {
            target = objTarget.transform.position;
        }
        delta = 8 * Mathf.Pow(20, -Mathf.Log(2, 0.1f)) * Mathf.Pow(mass, Mathf.Log(2, 0.1f));
        target -= (Vector2) transform.position;
        quotient = Mathf.Sqrt(target.x * target.x + target.y * target.y) / delta;
        target /= quotient;
        Debug.Log(target);
        transform.Translate(target * Time.deltaTime);
        vecScale.Set(mass / 20 + 0.095f,mass / 20 + 0.095f);
         transform.localScale = vecScale;
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "eat" & IsEat)
        {
            objTarget = other.gameObject;
        }  
    }
}
