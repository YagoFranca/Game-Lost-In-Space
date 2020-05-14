using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudVidas : MonoBehaviour
{

    public Sprite[] spriteVidas;

    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = spriteVidas[Dados.vidas];        
    }
}
