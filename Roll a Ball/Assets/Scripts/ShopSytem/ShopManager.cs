using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{

    public GameObject[] characterModels;
    public int currentCharacterIndex;
    public CharacterBluePrint[] characters;
    public Button buyButton;
    // Start is called before the first frame update
    void Start()
    {
        foreach (CharacterBluePrint character in characters)
        {
            if (character.cost == 0)
                character.isUnlock = true;
            else
                character.isUnlock = PlayerPrefs.GetInt(character.name, 0) == 0 ? false : true;
        }


        currentCharacterIndex = PlayerPrefs.GetInt("SelectCharacter", 0);
        foreach (GameObject character in characterModels)
            character.SetActive(false);
        characterModels[currentCharacterIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void UnlockCharacter()
    {
        CharacterBluePrint c = characters[currentCharacterIndex];
        PlayerPrefs.SetInt(c.name, 1);
        PlayerPrefs.SetInt("SelectCharacter", currentCharacterIndex);
        c.isUnlock = true;
        PlayerPrefs.SetInt("CoinAmount", PlayerPrefs.GetInt("CoinAmount", 0) - c.cost);

    }
    public void ChangeNextCharacter()
    {
        characterModels[currentCharacterIndex].SetActive(false);

        currentCharacterIndex++;
        if (currentCharacterIndex == characterModels.Length)
            currentCharacterIndex = 0;

        characterModels[currentCharacterIndex].SetActive(true);
        CharacterBluePrint c = characters[currentCharacterIndex];
        if (!c.isUnlock)
            return;
        PlayerPrefs.SetInt("SelectCharacter", currentCharacterIndex);
    }

    public void ChangeBackCharacter()
    {
        characterModels[currentCharacterIndex].SetActive(false);

        currentCharacterIndex--;
        if (currentCharacterIndex == -1)
            currentCharacterIndex = characterModels.Length - 1;

        characterModels[currentCharacterIndex].SetActive(true);
        CharacterBluePrint c = characters[currentCharacterIndex];
        if (!c.isUnlock)
            return;
        PlayerPrefs.SetInt("SelectCharacter", currentCharacterIndex);
    }

    private void UpdateUI()
    {
        CharacterBluePrint c = characters[currentCharacterIndex];
        if (c.isUnlock)
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy-" + c.cost;
            if (c.cost < PlayerPrefs.GetInt("CoinAmount", 0))
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
            }
        }
    }
}
