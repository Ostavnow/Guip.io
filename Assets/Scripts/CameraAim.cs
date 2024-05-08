using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CameraAim : MonoBehaviour
{
    public static int countCell;
    float mass;
    GameObject camObject;
    public GameObject Ejection;
    Camera cam;
    public float camSize = 4;
    private float speedSizeCamera = 1f;
    public static int Iscore = 18;
    public TMP_Text Tscore;
    public static GameObject[] players = new GameObject[32];
    // Update is called once per frame
    private void Start() {
        camObject = gameObject;
        cam = camObject.GetComponent<Camera>();
    }
    void LateUpdate()
    {
        camSize = 4 + ((Player.TotalMass - 18) / 20);
            speedSizeCamera = camSize / cam.orthographicSize;
                    if(cam.orthographicSize  > 0.03 + camSize)
                {
                    cam.orthographicSize -= speedSizeCamera * Time.deltaTime;
                }
                else if (cam.orthographicSize + 0.03 < camSize)
                {
                    cam.orthographicSize += speedSizeCamera * Time.deltaTime;
                }  
                Tscore.text = "Счёт: " + Iscore;
                countCell = 0;
         Vector2 c = new Vector2();
        for(int i = 0;i < players.Length;i++)
        {
            if(players[i] == null){
                continue;
            }
            else
            {
              c += (Vector2)players[i].transform.position;  
              countCell++;
            }  
        }
          c /= countCell;
        cam.transform.position = c; 
        //средняя точка между всеми игроками = (игрок1.позциция + игрок2.позиция + игрок3.позиция) / 3
    }
}
