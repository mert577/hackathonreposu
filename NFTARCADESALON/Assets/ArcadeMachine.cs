using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class ArcadeMachine : MonoBehaviour
{
    SpriteRenderer sr;
    public Color highlightColor;
    public Color defaultColor;

    public VideoClip videoClip;
    VideoPlayer vp;
    public int gameSceneBuildIndex;
    public GameObject playTexture;
    // Start is called before the first frame update
    void Start()
    {
        vp = GameObject.Find("VideoPlayer").GetComponent<VideoPlayer>();
        sr = GetComponent<SpriteRenderer>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Highlight()
    {
        playTexture.SetActive(true);
        vp.clip = videoClip;
        vp.Play();

        sr.color = highlightColor ;
    }
    public void UnHighlight()
    {
       playTexture.SetActive(false);
        vp.Stop();
        sr.color = defaultColor;
    }

    public void Interaction()
    {
        Debug.Log("This is " + gameObject.name);
        SceneManager.LoadScene(gameSceneBuildIndex);

    }
}
