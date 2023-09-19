using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// tt : handles trigger related game events 
/// </summary>
public class Triggers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    ///  when trigger destroyed tell npc script 
    /// </summary>
    /// <param name="collision"></param>

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
