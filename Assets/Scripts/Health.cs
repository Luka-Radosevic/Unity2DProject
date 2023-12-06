using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] int scoreValue = 10;

    public SpriteRenderer spriteRenderer {get; private set;}
    public Sprite[] states;

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ball")
        {
            health--;
            if(health <= 0)
            {
                FindObjectOfType<GameSession>().IncreaseScore(scoreValue);
                Destroy(gameObject);
            }
            else
            {
                this.spriteRenderer.sprite = this.states[this.health - 1];
            }
        }
    }
}
