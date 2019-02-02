using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSetting : MonoBehaviour
{
    public Camera mainSetting;
    public InputField shotNumber, lowNumber, normalNumber, fastNumber;
    public Button cancelMainSetting, validerMainSetting, easyButton, normalButton, hardButton;
    public Difficulty currentDifficulty = Difficulty.Easy;
    public Canvas canvasSetting;
    public Button arrowColorAstral, arrowColorRed, arrowColorOlive, arroxColorGrey, arrowColorMaroon, arrowColorGold;
    public Sprite arrowColorAstralSprite, arrowColorRedSprite, arrowColorOliveSprite, arrowColorGreySprite, arrowColorMaroonSprite, arrowColorGoldSprite;


    // Start is called before the first frame update
    void Start()
    {
        shotNumber.text = "10";

        cancelMainSetting.onClick.AddListener(cancelMainSettingOnClick);
        easyButton.onClick.AddListener(easyButtonOnClick);
        normalButton.onClick.AddListener(classicButtonOnClick);
        hardButton.onClick.AddListener(hardButtonOnClick);
        validerMainSetting.onClick.AddListener(validerMainSettingOnClick);
        arrowColorAstral.onClick.AddListener(changeAstralArrow);
        arrowColorRed.onClick.AddListener(changeRedArrow);
        arrowColorOlive.onClick.AddListener(changeOliveArrow);
        arroxColorGrey.onClick.AddListener(changeGreyArrow);
        arrowColorMaroon.onClick.AddListener(changeMaroonArrow);
        arrowColorGold.onClick.AddListener(changeGoldArrow);
    }

    void changeAstralArrow()
    {
        GameObject.Find("arrow").GetComponent<SpriteRenderer>().sprite = arrowColorAstralSprite;
    }

    void changeRedArrow()
    {
        GameObject.Find("arrow").GetComponent<SpriteRenderer>().sprite = arrowColorRedSprite;
    }

    void changeOliveArrow()
    {
        GameObject.Find("arrow").GetComponent<SpriteRenderer>().sprite = arrowColorOliveSprite;
    }

    void changeGreyArrow()
    {
        GameObject.Find("arrow").GetComponent<SpriteRenderer>().sprite = arrowColorGreySprite;
    }

    void changeMaroonArrow()
    {
        GameObject.Find("arrow").GetComponent<SpriteRenderer>().sprite = arrowColorMaroonSprite;
    }

    void changeGoldArrow()
    {
        GameObject.Find("arrow").GetComponent<SpriteRenderer>().sprite = arrowColorGoldSprite;
    }

    /// <summary>
    /// Fonction qui gère l'évènement du clique du bouton fermer 
    /// </summary>
    void cancelMainSettingOnClick()
    {
        mainSetting.enabled = false;
        canvasSetting.gameObject.SetActive(false);
    }

    void validerMainSettingOnClick()
    {
        mainSetting.enabled = false;
        canvasSetting.gameObject.SetActive(false);
    }

    /// <summary>
    /// Fonction qui gère l'évènement du clique du bouton easy
    /// </summary>
    void easyButtonOnClick()
    {
        Debug.Log("Clicked on easy button");
        currentDifficulty = Difficulty.Easy;
        easyButton.image.color = Color.white;
        normalButton.image.color = Color.gray;
        hardButton.image.color = Color.gray;
        lowNumber.text = "80";
        normalNumber.text = "150";
        fastNumber.text = "300";
    }

    /// <summary>
    /// Fonction qui gère l'évènement du clique du boutton classic
    /// </summary>
    void classicButtonOnClick()
    {
        Debug.Log("Clicked on classic button");
        currentDifficulty = Difficulty.Classic;
        easyButton.image.color = Color.gray;
        normalButton.image.color = Color.white;
        hardButton.image.color = Color.gray;
        lowNumber.text = "100";
        normalNumber.text = "170";
        fastNumber.text = "320";
    }

    /// <summary>
    /// Fonction qui gère l'évènement du clique boutton hard
    /// </summary>
    void hardButtonOnClick()
    {
        Debug.Log("Clicked on hard button");
        currentDifficulty = Difficulty.Hard;
        easyButton.image.color = Color.gray;
        normalButton.image.color = Color.gray;
        hardButton.image.color = Color.white;
        lowNumber.text = "150";
        normalNumber.text = "220";
        fastNumber.text = "400";
    }

    /// <summary>
    /// Fonction qui permet de récupérer les différentes variables enregistrer pour le setting
    /// </summary>
   public void refreshShow()
    {
        canvasSetting.gameObject.SetActive(true);
        currentDifficulty = GameObject.Find("MainDiifficult").GetComponent<MainDifficulti>().currentDifficulty;
        switch (currentDifficulty)
        {
            case Difficulty.Easy:
                easyButtonOnClick();
                break;
            case Difficulty.Classic:
                classicButtonOnClick();
                break;
            case Difficulty.Hard:
                hardButtonOnClick();
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
