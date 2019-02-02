using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour
{

    // 1 - Designer variables

    /// <summary>
    /// Vitesse de déplacement
    /// </summary>
    private Vector2 speed = new Vector2(5, 5);

    /// <summary>
    /// Direction
    /// </summary>
    private Vector2 direction;

    public Vector2 movement;

    private bool shot = false;

    private GameObject g;

    private GameObject party;

    private GameObject mainBubble;

    private GameObject nextBubble;

    private float width;

    // Use this for initialization
    void Start()
    {
        Debug.Log("EZ");
    }

    // Update is called once per frame
    void Update()
    {

            if (Input.GetMouseButtonDown(0))
            {
                if (GameObject.Find("SettingButton").GetComponent<SettingAction>().onSpriteHover == true) {
                    GameObject.Find("SettingButton").GetComponent<SettingAction>().showSetting();
                    return;
                }
            if (GameObject.Find("MainMenu").GetComponent<Camera>().enabled != true && GameObject.Find("MainDiifficult").GetComponent<Camera>().enabled != true && GameObject.Find("MainSetting").GetComponent<Camera>().enabled != true)
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 0;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                // convert mouse position into world coordinates
                Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // Allow shoot only if the player doesn't shoot downwards
                if (mouseScreenPosition.y > transform.position.y && !shot)
                {
                    // get direction you want to point at
                    direction = (mouseScreenPosition - (Vector2)transform.position).normalized;
                    // Update movement vector
                    movement = direction * speed;
                    shot = true;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        if (g != null && g != col.gameObject)
        {
            movement = new Vector2(0, 0);
        }
        else if (col.gameObject.name == "contourLeft" || col.gameObject.name == "contourRight")
        {
            direction = new Vector2(-direction.x, direction.y);
            movement = direction * speed;
        }
        else
        {
            RectTransform rt = GetComponent<RectTransform>();
            width = rt.rect.width;
            if (col.gameObject.transform.position.y > transform.position.y)
            {
                movement = direction / 3;
                if (col.gameObject.transform.position.x > transform.position.x)
                {
                    if (col.gameObject.transform.position.x - transform.position.x < width / 2)
                    {
                        direction = new Vector2(-1, 1);
                        movement = direction / 2;
                    }
                }
                else if (transform.position.x - col.gameObject.transform.position.x < width / 2)
                {
                    direction = new Vector2(1, 1);
                    movement = direction / 2;
                }
                g = col.gameObject;
            }
        }
    }

    void FixedUpdate()
    {
        // Application du mouvement
        if (g != null)
        {
            if (g.transform.position.x > transform.position.x && g.transform.position.x - transform.position.x > width / 2)
            {
                movement = new Vector2(0, 0);
            }
            else if (transform.position.x - g.transform.position.x > width / 2)
            {
                movement = new Vector2(0, 0);
            }
        }
        if (GetComponent<Rigidbody2D>() != null)
        {
            GetComponent<Rigidbody2D>().velocity = movement;

        }
    }
}
