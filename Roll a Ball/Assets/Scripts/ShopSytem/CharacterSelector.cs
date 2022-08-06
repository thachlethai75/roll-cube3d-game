using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public int currentCharacterIndex;
    public GameObject[] characters;

    void Start()
    {
        currentCharacterIndex = PlayerPrefs.GetInt("SelectCharacter", 0);
        foreach (GameObject character in characters)
            character.SetActive(false);
        characters[currentCharacterIndex].SetActive(true);
    }
}
