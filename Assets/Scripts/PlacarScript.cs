using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacarScript : MonoBehaviour
{
    public static int pontos;
   
    public Text textoPontos;
    
    void Start()
    {
        pontos = 0;
    }
    
    void Update()
    {
        textoPontos.text = pontos.ToString();
    }

}
