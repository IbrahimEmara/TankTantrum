using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moveme2 : MonoBehaviour
{
    //public Slider slider;
    public Text scoreText;
    private int count;
    public float timebetweenattacks;
    public float health;
    public float power = 2.5f;
    private Rigidbody2D rb;
    private float haxis;
    private float vaxis;
    //public Camera cam;
    public Transform bullet;

    // Use this for initialization
    void Start()
    {
        count = 10;
        scoreText.text = "Health: " + count.ToString();
        timebetweenattacks = 0f;
        health = 100f;
        rb = GetComponent<Rigidbody2D>();
        rb.inertia = 1;

    }

    // Update is called once per frame
    void Update()
    {
        timebetweenattacks -= Time.deltaTime;
        haxis = Input.GetAxis("Horizontal2");
        vaxis = Input.GetAxis("Vertical2");
        //cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
        if (Input.GetButtonDown("FireSpace") && timebetweenattacks <= 0)
        {
            Instantiate(bullet, transform.position + transform.up * 1f, transform.rotation);
            timebetweenattacks = 0.5f;

        }

    }
    private void FixedUpdate()
    {
        rb.AddTorque(power * -haxis, ForceMode2D.Force);
        rb.AddRelativeForce(new Vector2(0, 1) * power * -vaxis, ForceMode2D.Force);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision.gameObject.GetComponent<fireme>.timer = 0;
        //health -= 5;
        if (collision.gameObject.tag=="Bullet")
        {
            Destroy(collision.gameObject);
            timebetweenattacks = 0.5f;
            count -= 1;
            scoreText.text = "Health: " + count.ToString();

        }
        //slider.value = 1 - (health / 100f);
    }
}
