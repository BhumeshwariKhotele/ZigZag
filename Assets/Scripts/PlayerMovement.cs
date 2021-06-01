using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Vector3 direction;// 
    public float playerSpeed;
    public GameObject ParticleEffectPrefab;
    [SerializeField]
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (direction == Vector3.forward)
            {
                direction = Vector3.left;
                score++;
                Debug.Log("Score: " + score);
            }
            else
            {
                direction = Vector3.forward;
                score++;
                Debug.Log("Score: " + score);
            }
        }
        transform.Translate(direction * playerSpeed * Time.deltaTime);

        
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="PickUp")
        {
            score = score + 5;
            Debug.Log("Score: "+score);
            other.gameObject.SetActive(false);
            Instantiate(ParticleEffectPrefab,transform.position,Quaternion.identity);
        }
    }
}