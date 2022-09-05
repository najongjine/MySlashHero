using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectMenu : MonoBehaviour
{
    [SerializeField]
    Button[] charSelectedButton;

    [SerializeField]
    GameObject[] selectedCharCheckbox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InitializeCharacterMenu()
    {
        for(int i=0;i<charSelectedButton.Length; i++)
        {
            int charData = DataManager.GetData(TagManager.CHARACTER_DATA + i.ToString()); 
            if(charData == 0)
            {
                charSelectedButton[i].interactable = false;
            }
            selectedCharCheckbox[i].SetActive(false);
        }
        selectedCharCheckbox[DataManager.GetData(TagManager.SELECTED_CHARACTER_DATA)].SetActive(true);
    }

}
