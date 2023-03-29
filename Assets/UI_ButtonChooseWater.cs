using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ButtonChooseWater : MonoBehaviour
{
    public List<Button> waterList = new List<Button>();
    public List<TMP_Text> textMesh = new List<TMP_Text>();
    public List<Material> materials = new List<Material>();

    private void Start()
    {
        // Lấy tất cả các button con và gán vào List
        waterList = new List<Button>(GetComponentsInChildren<Button>());

        Transform child = waterList[0].transform.GetChild(0);
        child.gameObject.SetActive(true);

        textMesh[0].fontMaterial = materials[1];
        // Gán phương thức OnClick cho mỗi button trong List
        foreach (Button button in waterList)
        {
            button.onClick.AddListener(() => OnClick(button));
        }
    }

    private void OnClick(Button clickedButton)
    {
        // Tắt tất cả các button khác và gán Material Preset cho các TMP_Text
        foreach (Button button in waterList)
        {
            Transform child = button.transform.GetChild(0);
            child.gameObject.SetActive(false);
        }
        foreach (TMP_Text text in textMesh)
        {
            text.fontMaterial = materials[0];
        }
        for (int i = 0; i < waterList.Count; i++)
        {
            if (waterList[i] == clickedButton)
            {
                Transform child = waterList[i].transform.GetChild(0);
                child.gameObject.SetActive(true);

                TMP_Text text = textMesh[i];
                text.fontMaterial = materials[1];

                UIManager.Instance.numberTypeDIY = i;
            }
        }
    }
}
