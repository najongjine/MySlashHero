using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [HideInInspector]
    public int selectedCharacter = 0;

    [SerializeField]
    int char2UnlockScore = 10, char3UnlockScore = 20;

    [SerializeField]
    public GameObject[] player;

    private void Awake()
    {
        if (instance!=null)
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
        //PlayerPrefs.DeleteAll();
        // value will be 0 if not initailized
        int gameData = DataManager.GetData(TagManager.DATA_INITIALIZED);

        if (gameData <= 0)
        {
            // first time running the game, initilize data
            selectedCharacter = 0;
            DataManager.SaveData(TagManager.SELECTED_CHARACTER_DATA, selectedCharacter);
            DataManager.SaveData(TagManager.HIGHSCORE_DATA, 0);
            DataManager.SaveData(TagManager.CHARACTER_DATA+"0", 1);
            DataManager.SaveData(TagManager.CHARACTER_DATA + "1", 0);
            DataManager.SaveData(TagManager.CHARACTER_DATA + "2", 0);
            DataManager.SaveData(TagManager.MUSIC_DATA, 1);
            DataManager.SaveData(TagManager.DATA_INITIALIZED, 1);
        }
        else if (gameData==1)
        {
            selectedCharacter = DataManager.GetData(TagManager.SELECTED_CHARACTER_DATA);
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene,LoadSceneMode sceneMode)
    {
        if (scene.name == TagManager.GAMEPLAY_SCENE_NAME)
        {
            Instantiate(player[selectedCharacter]);
            Camera.main.GetComponent<CameraFollow>().FindPlayerReference();
        }
        
        /*
        MySoundManager.instance.CheckWhatBGToPlay();
        MySoundManager.instance.bgSource.Play();
        */
    }
    public void CheckToUnlockCharacter(int score)
    {
        if(score >= char3UnlockScore)
        {
            DataManager.SaveData(TagManager.CHARACTER_DATA+"1",1);
            DataManager.SaveData(TagManager.CHARACTER_DATA + "2", 1);
        }
        else if(score >= char2UnlockScore)
        {
            DataManager.SaveData(TagManager.CHARACTER_DATA + "1", 1);
        }
    }
   
}
