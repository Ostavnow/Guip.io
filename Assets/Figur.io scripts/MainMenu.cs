using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenu : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[2];
    public TMP_InputField inputField;
    public Image offSound;
    bool check = true;
   public void SetName()
    {
        if(inputField.text == "")
        {
            Debug.Log("Введите имя!!!");
        }
        else
        {
            GLOBAL.Nickname = inputField.text;
        }
        SceneManager.LoadScene("GameScene");
    }
    public void Sound()
    {
        if(check)
        {
        offSound.sprite = sprites[0];
        check = false;
        }
        else
        {
        offSound.sprite = sprites[1];
        check = true;
        }
    }
}
