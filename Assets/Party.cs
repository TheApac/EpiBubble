using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    public GameObject line;
    public GameObject[] shooter;
    public int nbLines = 2;

    // Start is called before the first frame update
    void Start()
    {
        float x = 0f;
        float y = 3.62f;
        float z = 0f;

        //Add Components
        for (int i = 0; i < nbLines; i++)
        {
            GameObject test = Instantiate(line, new Vector3(x, y, z), Quaternion.identity);
            y -= 0.56f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
