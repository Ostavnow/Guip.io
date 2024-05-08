using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEat : MonoBehaviour
{
    public GameObject [] eats;
    private Vector2 randVector;
    private void Awake() {
        Transform TgGameObject = gameObject.GetComponent<Transform>();
        for(int i = 0; i < 1500; i++)
        {
            randVector.Set(Random.Range(-74.5f,74.5f),Random.Range(-74.5f,74.5f));
            if(i % 6 == 0)
            {
                Instantiate(eats[0],randVector,Quaternion.identity,TgGameObject);
            }
            else if(i % 6 == 1)
            {
                Instantiate(eats[1],randVector,Quaternion.identity,TgGameObject);
            }
            else if(i % 6 == 2)
            {
                Instantiate(eats[2],randVector,Quaternion.identity,TgGameObject);
            }
            else if(i % 6 == 3)
            {
                Instantiate(eats[3],randVector,Quaternion.identity,TgGameObject);
            }
            else if(i % 6 == 4)
            {
                Instantiate(eats[4],randVector,Quaternion.identity,TgGameObject);
            }
            else if(i % 6 == 5)
            {
                Instantiate(eats[5],randVector,Quaternion.identity,TgGameObject);
            }
            if(i % 100 == 0)
            {
                Instantiate(eats[6],randVector,Quaternion.identity,TgGameObject);
            }
        }
    }
}
