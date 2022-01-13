using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] Vector3 offset = new Vector3(0, 4, -7);
    void Start()
    {
        
    }
    
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
