using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SnowSpawn : MonoBehaviour
{
    [Header("Snowflake Congrats Configurations")]
    [SerializeField] private Image snowflake;
    

    private void Start()
    {
        InvokeRepeating("MakeSnow", 8f, 10f); 
    }

    private void Update()
    {
     
    }
    public void MakeSnow()
    {
            Instantiate(snowflake, snowflake.transform.position, Quaternion.identity);
            Debug.Log("its snowing");
        }
    }


