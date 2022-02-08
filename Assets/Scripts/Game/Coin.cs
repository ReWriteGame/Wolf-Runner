using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<Dog>())
            gameObject.GetComponent<Destroyable>().Destroy();
        
      
    }


}
