using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballmovement : MonoBehaviour
{
    //public int speed = 30;
    // public int counter = 0;
    public int counterP1 = 0;
    public int counterP2 = 0;
    public Text scoreText1;
     public Text scoreText2;
    public Rigidbody2D sesuatu;
    public Animator animtr;
    
    // Start is called before the first frame update
    void Start()
    { 
        int x = Random.Range(0, 2) * 2 - 1;
        int y = Random.Range(0, 2) * 2 - 1;
        int speed = Random.Range(20, 26);
        sesuatu.velocity = new Vector2 (x, y) * speed;
        sesuatu.GetComponent<Transform>().position = Vector2.zero;
        animtr.SetBool("IsMove",true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(sesuatu.velocity.x > 0){//bola bergerak ke kanan
        sesuatu.GetComponent<Transform>().localScale = new Vector3(1,1,1);
        }else{ //bola bergerak ke kiri
            sesuatu.GetComponent<Transform>().localScale = new Vector3(-1,1,1);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.name=="Kanan"){
            StartCoroutine(jedabolaP1());
            // GetComponent<Transform>().position = new Vector2 (0,0);
        } if (other.collider.name=="Kiri"){
            StartCoroutine(jedabolaP2());
        }
    }

    // perintah
    IEnumerator jedabolaP1() {
        
        int x = Random.Range(0, 2) * 2 - 1;
        int y = Random.Range(0, 2) * 2 - 1;
        int speed = Random.Range(20, 26);

    sesuatu.velocity = Vector2.zero;
    animtr.SetBool("IsMove",false);
    sesuatu.GetComponent<Transform>().position = Vector2.zero;
    counterP1++;
    scoreText1.text = counterP1.ToString();
    yield return new WaitForSeconds(1);
    sesuatu.velocity = new Vector2 (x, y)*speed;//Jika P1 mencetak score maka bola dimulai ke arah P1
    animtr.SetBool("IsMove",true);
    
    }

    IEnumerator jedabolaP2() {
        
        int x = Random.Range(0, 2) * 2 - 1;
        int y = Random.Range(0, 2) * 2 - 1;
        int speed = Random.Range(20, 26);

    sesuatu.velocity = Vector2.zero;
    animtr.SetBool("IsMove",false);
    sesuatu.GetComponent<Transform>().position = Vector2.zero;
    counterP2++;
    scoreText2.text = counterP2.ToString();
    yield return new WaitForSeconds(1);
    sesuatu.velocity = new Vector2 (x, y) * speed; //Jika P2 mencetak score maka bola dimulai ke arah P2
    animtr.SetBool("IsMove",true);
    
    }
    
}
