using UnityEngine;
using UnityEngine.UI;

public class FlexibleScreen : MonoBehaviour
{
    public Vector2 phoneReferenceResolution = new Vector2(1080, 1920);
    public Vector2 tabletReferenceResolution = new Vector2(2048, 1536);
    public float matchWidthOrHeight = 0.5f;

   void Awake()
    {
        CanvasScaler canvasScaler = GetComponent<CanvasScaler>();

        float screenRatio = (float)Screen.width / Screen.height;
        float phoneRatio = phoneReferenceResolution.x / phoneReferenceResolution.y;
        float tabletRatio = tabletReferenceResolution.x / tabletReferenceResolution.y;

        if (screenRatio < 0.6f)
        {
            canvasScaler.matchWidthOrHeight = 0;
            Debug.Log("screenRatio" + screenRatio);
        }
        else
        {
            canvasScaler.matchWidthOrHeight = 1;
            Debug.Log("screenRatio" + screenRatio);
        }
    }
}
