using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OpenScrollbar : MonoBehaviour
{
    float scaleSpeed = 30; // Tốc độ thay đổi tỷ lệ
    float defaultHeight = 960; // Giá trị mặc định cho chiều cao của ScrollView

    private RectTransform rectTransform; // RectTransform của ScrollView

    private Coroutine scaleCoroutine; // Coroutine thay đổi tỷ lệ của ScrollView
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();  
    }
    void Start()
    {
        if (scaleCoroutine != null)
        {
            StopCoroutine(scaleCoroutine);
        }
        scaleCoroutine = StartCoroutine(ScaleScrollView());
    }
    void OnEnable()
    {
        if (scaleCoroutine != null)
        {
            StopCoroutine(scaleCoroutine);
        }
        scaleCoroutine = StartCoroutine(ScaleScrollView());
    }
    IEnumerator ScaleScrollView()
    {
        float currentHeight = 0f;
        while (currentHeight < defaultHeight)
        {
            currentHeight += scaleSpeed;
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, currentHeight);
            yield return null;
        }
    }
}