using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spritesIndex;
    public float speedRate;

    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;

    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    void Start(){
        InvokeRepeating(nameof(AnimationSprite), 0.15f, 0.15f);

    }
    void OnEnable(){
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
    public void GetJump(){
        if (Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.Space)){
            direction = Vector3.up*strength;
        }
        //get in lap
        if (Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began){
                direction = Vector3.up * strength;

            }
        }
        //get on smartphone
    }
    void Update(){
        GetJump();
        Time.timeScale += speedRate;       
        direction.y += gravity * Time.deltaTime;
        // v = -g.t
        transform.position += direction * Time.deltaTime;
        // d = v.t
    }
    private void AnimationSprite(){
        spritesIndex ++;
        if (spritesIndex >= sprites.Length){
            spritesIndex = 0;
        }   
        spriteRenderer.sprite = sprites[spritesIndex];

    }
    void OnTriggerEnter2D(Collider2D orther){
        if (orther.tag == "Obstacle"){
            FindObjectOfType<GameManager>().GameOver();
        } else   
        if (orther.tag == "Scoring"){
            FindObjectOfType<GameManager>().IncreaseScore();
           
        }
    }
}
