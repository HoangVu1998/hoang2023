using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollFuritsManager : MonoBehaviour
{
    public List<GameObject> scrollFurits = new List<GameObject>();
    private void OnEnable()
    {

        scrollFurits[0].gameObject.SetActive(true);
    }
    private void OnDisable()
    {
        scrollFurits[0].gameObject.SetActive(false);
    }
}
