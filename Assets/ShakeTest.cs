using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShakeTest : MonoBehaviour
{
    Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => Onclick1());
    }
    void Onclick1()
    {
        BeerManager1.instance. isMan7 = false;
        BeerManager1.instance.menuIsShakeDIY.SetActive(false);
        BeerManager1.instance.man6.SetActive(true);
        BeerManager1.instance.ImageMan6DIY.sprite = DIYController.instance.characterDIY[UIManager.Instance.CharacterType].CharacterUI[DIYController.instance.buttonseLect];
    }
}
