using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotEat : MonoBehaviour
{
    Bot bot;
    Vector2 randVect;
    private void Start() {
        bot = gameObject.transform.parent.GetComponent<Bot>();
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "eat")
        {
            bot.mass += 1;
            randVect.Set(Random.Range(74.5f,-74.5f),Random.Range(74.5f,-74.5f));
        other.gameObject.transform.position = randVect;
        }  
    }
}
