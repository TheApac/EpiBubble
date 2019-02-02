using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Difficulty
{
    Easy,
    Classic,
    Hard
};

public class MainDifficulti : MonoBehaviour
{
    public Button easyButton, classicButton, hardButton, validateButton, cancelledButton;
    public Camera mainCam, mainSetting, dificultCam, mainParty;
    public Difficulty currentDifficulty = Difficulty.Easy;

    // Start is called before the first frame update
    void Start()
    {
        easyButton.onClick.AddListener(easyButtonClicked);
        classicButton.onClick.AddListener(classicButtonClicked);
        hardButton.onClick.AddListener(hardButtonClicked);
        validateButton.onClick.AddListener(validateButtonOnClick);
        cancelledButton.onClick.AddListener(cancelledButtonOnClick);
        easyButton.image.color = Color.white;
        classicButton.image.color = Color.gray;
        hardButton.image.color = Color.gray;

    }

    /// <summary>
    /// Fonction qui gère l'evenement du clique du boutton easy
    /// </summary>
    void easyButtonClicked()
    {
        if (GameObject.Find("party").GetComponent<Camera>().enabled != true)
        {
            Debug.Log("Clicked on easy button");
            currentDifficulty = Difficulty.Easy;
            easyButton.image.color = Color.white;
            classicButton.image.color = Color.gray;
            hardButton.image.color = Color.gray;
        }
    }

    /// <summary>
    /// Fonction qui gère l'evenement du clique du boutton classic
    /// </summary>
    void classicButtonClicked()
    {
        if (GameObject.Find("party").GetComponent<Camera>().enabled != true)
        {
            Debug.Log("Clicked on classic button");
            currentDifficulty = Difficulty.Classic;
            easyButton.image.color = Color.gray;
            classicButton.image.color = Color.white;
            hardButton.image.color = Color.gray;
        }
    }

    /// <summary>
    /// Fonction qui gère l'evenement du clique du boutton hard
    /// </summary>
    void hardButtonClicked()
    {
        if (GameObject.Find("party").GetComponent<Camera>().enabled != true)
        {
            Debug.Log("Clicked on hard button");
            currentDifficulty = Difficulty.Hard;
            easyButton.image.color = Color.gray;
            classicButton.image.color = Color.gray;
            hardButton.image.color = Color.white;
        }
    }

    /// <summary>
    /// Fonction qui gère l'evenement du clique du boutton valider
    /// </summary>
    void validateButtonOnClick()
    {
        if (GameObject.Find("party").GetComponent<Camera>().enabled != true)
        {
            Debug.Log("Clicked on Validate button");
            mainSetting.GetComponent<MainSetting>().refreshShow();
            // mainSetting.enabled = true;
            dificultCam.enabled = false;
            mainParty.enabled = true;
        }
    }

    /// <summary>
    /// Fonction qui gère l'evenement du clique du boutton annuler
    /// </summary>
    void cancelledButtonOnClick()
    {
        if (GameObject.Find("party").GetComponent<Camera>().enabled != true)
        {
            Debug.Log("Clicked on Cancelled button");
            dificultCam.enabled = false;
            mainCam.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
