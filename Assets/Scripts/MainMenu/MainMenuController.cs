using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    GameObject characterSelectMenuPanel;

    [SerializeField]
    Text highScoreTxt;

    CharacterSelectMenu charSelectMenu;

    private void Awake()
    {
        charSelectMenu = GetComponent<CharacterSelectMenu>();
    }

    // Start is called before the first frame update
    void Start()
    {
        highScoreTxt.text = $"Highscore : {DataManager.GetData(TagManager.HIGHSCORE_DATA)} m";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenCloseCharacterSelectMenu(bool open)
    {
        if (open) {
            charSelectMenu.InitializeCharacterMenu();
        }
        characterSelectMenuPanel.SetActive(open);
    }
    public void SelectCharacter()
    {
        int selectedChar = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        GameplayController.instance.selectedCharacter = selectedChar;
        DataManager.SaveData(TagManager.SELECTED_CHARACTER_DATA, selectedChar);
        charSelectMenu.InitializeCharacterMenu();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(TagManager.GAMEPLAY_SCENE_NAME);
    }

}
