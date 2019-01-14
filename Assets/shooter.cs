using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{

    // 1 - Designer variables

    /// <summary>
    /// Vitesse de déplacement
    /// </summary>
    public Vector2 speed = new Vector2(1, 1);

    /// <summary>
    /// Direction
    /// </summary>
    public Vector2 direction;

    private Vector2 movement;

    private bool shot = false;

    private GameObject g;

    private float width;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            // convert mouse position into world coordinates
            Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Allow shoot only if the player doesn't shoot downwards
            if (mouseScreenPosition.y > transform.position.y && !shot) {
                // get direction you want to point at
                direction = (mouseScreenPosition - (Vector2)transform.position).normalized;
                // Update movement vector
                movement = direction * speed;
                shot = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (g != null && g != col.gameObject) {
            movement = new Vector2(0, 0);
        } else if (col.gameObject.transform.parent.gameObject.name == "contourLeft" || col.gameObject.transform.parent.gameObject.name == "contourRight") {
            direction = new Vector2(-direction.x, direction.y);
            movement = direction * speed;
        } else {
            RectTransform rt = (RectTransform)transform;
            width = rt.rect.width;
            if (col.gameObject.transform.position.y > transform.position.y) {
                movement = direction / 3;
                if (col.gameObject.transform.position.x > transform.position.x) {
                    if (col.gameObject.transform.position.x - transform.position.x < width / 2) {
                        direction = new Vector2(-1, 1);
                        movement = direction / 2;
                    }
                } else if (transform.position.x - col.gameObject.transform.position.x < width / 2) {
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
        if (g != null) {
            if (g.transform.position.x > transform.position.x && g.transform.position.x - transform.position.x > width / 2) {
                movement = new Vector2(0, 0);
            } else if (transform.position.x - g.transform.position.x > width / 2) {
                movement = new Vector2(0, 0);
            }
        }
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}