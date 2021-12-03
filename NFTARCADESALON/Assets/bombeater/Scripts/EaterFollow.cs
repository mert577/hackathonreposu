using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EaterFollow : MonoBehaviour {

    public Vector2 direction;
    public float movementSpeed;
    public static int Skor;
    public Text skorText;
    public Text healthText;
    public static int Health;
    public float knockBackforce;
    public GameObject restartText;
    public GameObject particles;
    bool isInvulnerable;
    public static bool isDead;
    public GameObject hurtSound;
    public GameObject button;
    public static bool gameStarted;

	// Use this for initialization
	void Start () {
        Health = 5;
	}
	
	// Update is called once per frame
	void Update () {


        if (gameStarted)
        {
            if (isDead)
                return;
            skorText.text = "SCORE: " + Skor;
            healthText.text = "HEALTH: " + Health;


            direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (direction.magnitude >= 0.1f)
                direction.Normalize();
            else if (direction.magnitude >= 0.8f)
                direction = direction.normalized * (direction.magnitude * 1f);
            else
                direction = Vector2.zero;




            transform.Translate(direction * -movementSpeed * Time.deltaTime);

            if (Health <= 0 && !isDead)
            {
                isDead = true;
                Instantiate(particles, transform.position, Quaternion.identity);
                restartText.SetActive(true);
                GetComponent<SpriteRenderer>().enabled = false;
                Destroy(this.gameObject, 3f);
            }

            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -4.78f, 4.78f), Mathf.Clamp(transform.position.y, -4.78f, 4.78f));
        }
        else
        {

            skorText.text = "";
            healthText.text = "";

        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
      

        if (collision.gameObject.CompareTag("Harmful")&& !isInvulnerable)
        {
            StartCoroutine(Invulenerable());
            Destroy(Instantiate(hurtSound), 2f);
            GetComponent<Animator>().SetTrigger("Blink");
            Health--;
            Vector2 forceDir = (Vector2)collision.transform.position - (Vector2)transform.position;
            Destroy(collision.gameObject);
            forceDir.Normalize();
            GetComponent<Rigidbody2D>().AddForce(forceDir * knockBackforce, ForceMode2D.Impulse);
        }
    }

    IEnumerator Invulenerable()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(0.5f);
        isInvulnerable = false;
    }

    IEnumerator StartTheGame()
    {
        GetComponent<Animator>().SetTrigger("shrink");
        yield return new WaitForSeconds(2f);
        gameStarted = true;
    }

    public void ButtonClickStart()
    {
       
        StartCoroutine(StartTheGame());
        Destroy(button);
    }
}
