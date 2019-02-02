using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingAction : MonoBehaviour
{
    public Camera mainSetting;
    public Canvas Setting;
    public bool onSpriteHover = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void showSetting()
    {
        mainSetting.enabled = true;
        Setting.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        onSpriteHover = true;
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        onSpriteHover = false;
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
    }
}
