using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySoundManager : MonoBehaviour
{
    public static MySoundManager instance;
    public AudioSource bgSource;
    public AudioSource fxSource;

    public AudioClip mainmenuBGClip;

    public AudioClip ingameBGClip;

    public AudioClip gameOverClip;

    public AudioClip jumpClip;

    public AudioClip slashClip;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckWhatBGToPlay()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            bgSource.clip = mainmenuBGClip;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            bgSource.clip = ingameBGClip;
        }
    }
}
