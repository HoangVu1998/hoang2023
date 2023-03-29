using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsController : MonoBehaviour
{
    // qu?n l� c�c ??i t??ng hoa qu?
    public GameObject[] fruitsPrefabsBeer;


    // M?ng v? tr� r?i c?a ??i t??ng hoa qu?
    public Transform[] PointThrowFruits;
    public void ChooseFurits(int number)
    {
        var position =new Vector2(Random.Range(PointThrowFruits[0].position.x,PointThrowFruits[1].position.x), PointThrowFruits[0].position.y);
        var a = Instantiate(fruitsPrefabsBeer[number],position,Quaternion.identity);
        if (DetectShake.instance.uonghet == true)
        {
            Destroy(a);
        }
    }
}
