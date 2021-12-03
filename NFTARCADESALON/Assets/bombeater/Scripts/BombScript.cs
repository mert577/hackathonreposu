using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BombScript : MonoBehaviour {

    public GameObject projectile;
    public GameObject camera;
    public GameObject explosionSound;
    public GameObject powerUpSound;
    public float projectileSpeed;
    bool exploded;
	// Use this for initialization
	void Start () {
        StartCoroutine(ExplodeLevelOne());
        camera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
   
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BombEater"))
        {
           Destroy(Instantiate(powerUpSound),2f);
            camera.GetComponent<Animator>().SetTrigger("Plop");
            EaterFollow.Skor++;
            Destroy(this.gameObject);
            
        }
    }

    IEnumerator ExplodeLevelOne()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < 6; i++)
        {
           GameObject p = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, i * 60));
            p.GetComponent<Rigidbody2D>().velocity =(p.transform.up  * projectileSpeed);
            Destroy(p, 3f);
         
        }
        Destroy( Instantiate(explosionSound),2f);
        camera.GetComponent<Animator>().SetTrigger("Shake");
        GetComponent<SpriteRenderer>().enabled = false;
        exploded =true;
        Destroy(this.gameObject,3f);
    }
}
