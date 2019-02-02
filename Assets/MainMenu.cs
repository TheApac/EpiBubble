using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button newGame;
    public Button loadGame;
    public Camera mainCam, dificultCam, mainSetting, mainParty;
    public GameObject party;
    public Canvas canvasSetting;


    // Start is called before the first frame update
    void Start()
    {
        mainCam.enabled = true;
        dificultCam.enabled = false;
        mainSetting.enabled = false;
        mainParty.enabled = false;
        newGame.onClick.AddListener(onClickNewGame);
        canvasSetting.gameObject.SetActive(false);
    }

    /// <summary>
    /// Fonction qui gère l'evenement du clique du boutton New game
    /// </summary>

    void onClickNewGame()
    {
        if (GameObject.Find("party").GetComponent<Camera>().enabled != true)
        {
            mainCam.enabled = false;
            dificultCam.enabled = true;
            dificultCam.tag = "MainCamera";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
