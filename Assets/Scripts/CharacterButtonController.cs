using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButtonController : MonoBehaviour
{
    [SerializeField]
    private string chracterName;

    [SerializeField]
    private Sprite chracterImage;

    [SerializeField]
    private GameObject chracterPrefab;

    private void Start()
    {
        GetComponentInChildren<TextMeshProUGUI>().SetText(chracterName);
        GetComponentsInChildren<Image>()[1].sprite = chracterImage;
        
    }

    public void SelectedCharacter()
    {
        Instantiate (chracterPrefab);
        closePanel();
    }

    private void closePanel() =>
        GameObject
            .FindGameObjectWithTag("ChracterSelectPanel")
            .SetActive(false);
}
