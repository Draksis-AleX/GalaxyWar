using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float minTimeModifier;
    [SerializeField] float maxTimeModifier;
    bool isFollowing = false;

    Vector3 _velocity = Vector3.zero;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (isFollowing)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref _velocity, Time.deltaTime * Random.Range(minTimeModifier, maxTimeModifier));
        }
        
    }

    public void StartFollowing()
    {
        isFollowing = true;
    }

    public void setTarget(Transform target)
    {
        this.target = target;
    }
}
