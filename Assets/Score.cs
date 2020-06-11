using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text zombieLeft;
    public static int count = 10;

    void Start()
    {
        zombieLeft = GetComponent<Text>();
        zombieLeft.text = count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        zombieLeft.text = count.ToString();
    }
}
