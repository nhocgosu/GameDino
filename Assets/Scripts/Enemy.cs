
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
      
    }
    private void Update()
    {
        transform.position += Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime;
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
     private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player")){
            GameManager.Instance.GameOver();
        }
    }
   

}
