using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour {

    public float limiteAtaque;
    public float velocidade;
	public int health = 10000;

	public GameObject deathEffect;

    private GameObject alvo;
    private Vector2 posicaoAtaque;
    private Animator an;
    private SpriteRenderer sr;
    private bool atacar;


    void Start()
    {
        an = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        alvo = GameObject.Find("SensorChao");
    }

    void Update()
    {
        // CALCULA A DISTANCIA ENTRE OS ININIGO E O JOGADOR
        float d = Vector2.Distance(transform.position, alvo.transform.position);

        // ALTERA O ESTADO DO INIMIGO PARA ATACAR
        if (d < limiteAtaque && !atacar && alvo.transform.position.y < transform.position.y)
        {
            posicaoAtaque = alvo.transform.position;
            sr.flipY = false;
            atacar = true;
            an.SetBool("pAtacar", atacar);
            GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        }

        // COMPORTAMENTO DE ATAQUE
        if (atacar)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                posicaoAtaque, velocidade * Time.deltaTime);
        }
    }

    public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die ()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}
