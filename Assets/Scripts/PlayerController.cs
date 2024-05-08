using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private float delta = 5;
    private float quotient;
    private Vector2 mousePosition;
    [HideInInspector]
    public Camera cam;
    Player player;
    CameraAim cameraAim;
    Rigidbody2D rb;
    public  Joystick joystick;
    float rotZ;
    public static Vector2 moveInput;
    private Vector2 randVect;
    public GameObject ejection;
    public GameObject PrefabPlayer;
    public RectTransform aimPanel;
    [HideInInspector]
    public RectTransform aim;
    public GameObject gm;
    public static int RandomCell;
    void Start()
    {
        aimPanel = GameObject.Find("Aim panel").GetComponent<RectTransform>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        aim = aimPanel.GetComponentInChildren<Transform>().GetChild(0).GetComponent<RectTransform>();
        player = gameObject.GetComponent<Player>();
        joystick = GameObject.Find("Floating Joystick").GetComponent<Joystick>();
        delta = 5;
        delta = 8 * Mathf.Pow(20, -Mathf.Log(2, 01.1f)) * Mathf.Pow(player.mass, Mathf.Log(2, 0.1f));
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        //Добавление клетки в массив что бы камера могла наблюдать за ним
        for(int i = 0;i < CameraAim.players.Length;i++)
        {
            if(CameraAim.players[i] == null)
            {
                CameraAim.players[i] = gameObject;
                player.index = i;
                break;
            }
        }  
        GameObject.Find("Spliting").GetComponent<Button>().onClick.AddListener(delegate {OnSplitting();});
        GameObject.Find("Ejection").GetComponent<Button>().onClick.AddListener(delegate {OnEjection();});
        ejection = GameObject.Find("EjectionP");
        cameraAim = GameObject.Find("Main Camera").GetComponent<CameraAim>();
        ejection = cameraAim.Ejection;
    }


    void Update()
    {
        delta = 8 * Mathf.Pow(20, -Mathf.Log(2, 0.1f)) * Mathf.Pow(player.mass, Mathf.Log(2, 0.1f));
            mousePosition = aim.position;
            mousePosition -= (Vector2)transform.position;
            quotient = Mathf.Sqrt(mousePosition.x * mousePosition.x + mousePosition.y * mousePosition.y) / delta;
            mousePosition /= quotient;
            transform.Translate(mousePosition *  Time.deltaTime);
            // transform.Translate(moveVelocity * Time.deltaTime);
            if(Mathf.Abs(joystick.Horizontal) > 0.0f || Mathf.Abs(joystick.Vertical) > 0.0f)
            {
            moveInput = new Vector2(joystick.Horizontal,joystick.Vertical);
            rotZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
            aimPanel.rotation = Quaternion.Euler(0,0,rotZ);
            }
    }
    public void OnEjection()
    {
        if(player.mass > 35)
        {
        Instantiate(ejection,transform.position,Quaternion.Euler(0,0,aim.transform.eulerAngles.z));
        player.mass -= 18;
        Player.TotalMass -= 18;
        }
    }
    public void OnSplitting()
    {
        if(player.mass > 35 & CameraAim.countCell < 17)
        {
        gameObject.tag = "Untagged";
        gameObject.GetComponentInChildren<Transform>().GetChild(2).gameObject.tag = "Untagged";
        Player playerNew = Instantiate(PrefabPlayer,transform.position,Quaternion.identity).GetComponent<Player>();
        player.mass = player.mass / 2;
        playerNew.mass = player.mass;
        cam.orthographicSize += 1f;
        playerNew.time = 0;
        player.time = 0;
        RandomCell = Random.Range(1,CameraAim.countCell + 1);
        }
    }
    // private void FixedUpdate() {
    //     rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    // }
}
