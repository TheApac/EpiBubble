using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    public GameObject line;
    public GameObject[] bubbles;
    public GameObject shooter;
    int nbLines = 6;

    // Start is called before the first frame update
    void Start()
    {
        float x = 4.72f;
        float y = 3.62f;
        float z = 9.786432f;
        bool isPair = true;
        //Add line
        for (int i = 0; i <= nbLines; i++)
        {
            GameObject lineO = Instantiate(line, new Vector3(x, y, z), Quaternion.identity);
            lineO.transform.SetParent(gameObject.transform, false);
            y -= 0.56f;
            if (isPair)
            {
                x -= 0.3f;
                isPair = false;
            } else
            {
                x += 0.3f;
                isPair = true;
            }
            
            
        }

        //Add shooter
        GameObject shooter0 = Instantiate(shooter, new Vector3(0.3f, -4.5f, 9.786432f), Quaternion.identity);
        shooter0.transform.SetParent(gameObject.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
