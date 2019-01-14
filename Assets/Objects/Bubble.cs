using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour
{
    Sprite[] colors;

    // Use this for initialization
    void Start()
    {
        colors = Resources.LoadAll<Sprite>("./Textures");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
