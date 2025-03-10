using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject PlayerBulletGO;
    public GameObject bulletPosition1;
    public GameObject bulletPosition2;


    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject bullet01 = (GameObject) Instantiate(PlayerBulletGO);
            bullet01.transform.position = bulletPosition1.transform.position;

            GameObject bullet02 = (GameObject) Instantiate(PlayerBulletGO);
            bullet02.transform.position = bulletPosition2.transform.position;


        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x, y).normalized;    
      
        Move(direction);

    }

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.y = max.x - 0.285f;
        min.y = min.x + 0.285f;

        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x , min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;

    }
}

