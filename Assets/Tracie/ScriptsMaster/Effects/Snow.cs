using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    [SerializeField] private float snowfallSpeed = .5f;
    [SerializeField] private GameObject snowflake; 
    private void Start()
    {
        MakeSnow();
    }

    void Update()
    {
      
    }


    public void MakeSnow()
    {
        transform.Translate(snowfallSpeed * Time.deltaTime * Vector2.down);
        Debug.Log("its snowing");
        if (transform.position.y < -350f)
        {
            Destroy(gameObject);
            Debug.Log("snow destroyed");
        }

    
    }


    private void AnimateSnow()
    {
       //transform.Translate(snowfallSpeed * Time.deltaTime * Vector2.down);
       // Debug.Log("snow on the move"); 
       // if(transform.position.y < -20f)
       // {
       //     Destroy(gameObject);
       //     Debug.Log("snow destroyed"); 
       // }
    }
}
