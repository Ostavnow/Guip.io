using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static float TotalMass = 18;
    public static GameObject[] IsPlayers = new GameObject[32];
    private int Iscount = 0;
    Rigidbody2D rb;
    public float mass = 18;
    [HideInInspector]
    public int massCoint = 1;
    [HideInInspector]
    private Vector2 randVect;
    PlayerController pl;
    Vector2 vecScale;
    float rangeAim = 68.4f;
    float Pspeed = 30;
    Vector2 PmoveInput;
    bool check = true;
    [HideInInspector]
    public float time = 0;
    public float timer = 30;
    [HideInInspector]
    public int index;
    float IsMass;
    float currentMass = 0.955f;
    bool check1 = true;
    void Start()
    {
        pl = gameObject.GetComponent<PlayerController>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(time > 1 & check1)
        {
            gameObject.tag = "Player";
            gameObject.GetComponentInChildren<Transform>().GetChild(2).gameObject.tag = "PlayerEat";
            check1 = false;
        }
        if(check)
        {
            PmoveInput = PlayerController.moveInput;
        }
            if(Pspeed > 1)
            {
                Pspeed -= Pspeed * 2  * Time.deltaTime;
             transform.Translate(PmoveInput * (Time.deltaTime * Pspeed));
            
            }
            time += Time.deltaTime;
            timer = 30 + mass / 100 * 2.33f;
            IsMass = mass / 20 + 0.095f;
            if(IsMass > currentMass)
            {
                currentMass += (IsMass - currentMass) * Time.deltaTime;
            }
            else if(IsMass < currentMass)
            {
                currentMass += (IsMass - currentMass) * Time.deltaTime;
            }
            vecScale.Set(currentMass,currentMass);
        transform.localScale = vecScale;
    }
    void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "eat")
    {
        mass += massCoint;
        TotalMass += massCoint;
        if(TotalMass / massCoint > CameraAim.Iscore)
        {
        CameraAim.Iscore = (int)TotalMass;  
        }
        randVect.Set(Random.Range(74.5f,-74.5f),Random.Range(74.5f,-74.5f));
        other.gameObject.transform.position = randVect;
    }    
    else if(other.tag == "virus" & mass > 132)
    {
        TotalMass += 100;
        int quantityCell = (int) mass / 18 - 1; 
        for(int i = 0;i < quantityCell;i++)
        {
            gameObject.tag = "Untagged";
        gameObject.GetComponentInChildren<Transform>().GetChild(2).gameObject.tag = "Untagged";
        Player playerNew = Instantiate(pl.PrefabPlayer,transform.position,Quaternion.identity).GetComponent<Player>();
        mass -= 18;
        playerNew.mass = mass;
        pl.cam.orthographicSize += 0.5f;
        playerNew.time = 0;
        time = 0;
        }
        PlayerController.RandomCell = Random.Range(1,CameraAim.countCell + 1);
        randVect.Set(Random.Range(74.5f,-74.5f),Random.Range(74.5f,-74.5f));
        if(TotalMass / massCoint > CameraAim.Iscore)
        {
        CameraAim.Iscore = (int)TotalMass;  
        }
        other.gameObject.transform.position = randVect;
    }
    else if(other.tag == "ejection" & mass > 21)
    {
        mass += 13;
        TotalMass += 13;
        if(TotalMass / massCoint > CameraAim.Iscore)
        {
        CameraAim.Iscore = (int)TotalMass;  
        }
        other.gameObject.transform.parent.GetComponent<Ejection>().check = true;
    }
    else if(other.tag == "PlayerEat")
    {
        Player player = other.GetComponentInParent<Player>();
        if(mass > player.mass)
        {
        mass += player.mass;
        CameraAim.players[player.index] = null;
        Destroy(player.gameObject);
        time = 0;  
        }
        else if(player.mass > mass)
        {
        player.mass += mass;
        CameraAim.players[index] = null;
        Destroy(gameObject);
        player.time = 0;  
        }
        else if(index != PlayerController.RandomCell){
        player.mass += mass;
        CameraAim.players[index] = null;
        Destroy(gameObject);
        player.time = 0;
            }
    }
    // private void FixedUpdate() {
    //     rb.MovePosition(rb.position + PmoveVelocity * Time.deltaTime);
    // }
    }
    void OnTriggerStay2D(Collider2D other) {
           if(other.tag == "Player")
        {
         if(time >= timer)
        {   
            Player player = other.GetComponent<Player>();
        GameObject PlayerTriger = player.GetComponentInChildren<Transform>().GetChild(2).gameObject;
        GameObject triger = gameObject.GetComponentInChildren<Transform>().GetChild(2).gameObject;
            if(mass > player.mass)
            {
               player.gameObject.layer = 6; 
               PlayerTriger.layer = 3;
            }
            else if(mass < player.mass)
            {
            gameObject.layer = 6;
            triger.layer = 3; 
            }
            else if(index == PlayerController.RandomCell){
                player.gameObject.layer = 6;
                PlayerTriger.layer = 3; 
            }
            else {
                gameObject.layer = 6;
                triger.layer = 3; 
            }
        } 
        }
    }
}
