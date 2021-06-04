using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    Rigidbody tempRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        tempRigidbody = GetComponentInParent<Rigidbody>();
        //Debug.Log(tempRigidbody.name);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(tempRigidbody.gameObject.name);
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TileManager.Instance.SpawnTile();
            StartCoroutine("FallDown");
        }
    }
    IEnumerator FallDown()
    {
       
        yield return new WaitForSeconds(3);
        tempRigidbody.isKinematic = false;
        yield return new WaitForSeconds(1);
        tempRigidbody.isKinematic = true;
        if (tempRigidbody.gameObject.name == "ForwardTile")
        {

            TileManager.Instance.AddForwardTilePool(tempRigidbody.gameObject);
       
        }
        else if (tempRigidbody.gameObject.name == "LeftTile")
        {

            TileManager.Instance.AddLeftTilePool(tempRigidbody.gameObject);
      
        }
    }
}