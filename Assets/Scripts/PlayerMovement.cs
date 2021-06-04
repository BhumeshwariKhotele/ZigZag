using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
 
    public GameObject EndScreen;
    public Text scoreText;
    public Text finalScore;
 
    [SerializeField]
    Vector3 direction;// 
    public float playerSpeed;
    public GameObject ParticleEffectPrefab;
    
    [SerializeField]
    int score = 0;
    
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (direction == Vector3.forward)
            {
                direction = Vector3.left;
                score++;
                scoreText.text = "Score : " + score;
            }
            else
            {
                direction = Vector3.forward;
                score++;
                scoreText.text = "Score : " + score;
              
            }
        }
        transform.Translate(direction * playerSpeed * Time.deltaTime);
        
        if(this.transform.position.y < 0)
        {
            EndScreen.SetActive(true);
            scoreText.text = "";
            finalScore.text = "Score :" + score;
        }
        
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="PickUp")
        {
            score = score + 5;
            
            scoreText.text = "Score : " + score;
            other.gameObject.SetActive(false);
            Instantiate(ParticleEffectPrefab,transform.position,Quaternion.identity);
        }
    }
}