using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemy;
    public Transform player;
    public Vector2 öncekiPos;
    bool once;
	// Use this for initialization
	void Start () {
        Screen.SetResolution(900, 900, true);
        öncekiPos = Vector2.zero;

	}
	
	// Update is called once per frame
	void Update () {

        if (EaterFollow.gameStarted&& !once)
        {
            once = true;
            StartCoroutine(SpawnEnemy());
        }

        if (EaterFollow.isDead)
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                EaterFollow.isDead = false;
                EaterFollow.Health = 5;
                EaterFollow.Skor = 0;
                EaterFollow.gameStarted = false;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        Vector2 randomPos = new Vector2(Random.Range(-16, 16) / 4, Random.Range(-16, 16) / 4);

        while ((randomPos- (Vector2)player.position).magnitude < 2f|| öncekiPos==randomPos )
        {
             randomPos = new Vector2(Random.Range(-16, 16) / 4, Random.Range(-16, 16) / 4);
        }
        Instantiate(enemy, randomPos, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(1f, 1.5f));
        öncekiPos = randomPos;
        StartCoroutine(SpawnEnemy());


    }
}
