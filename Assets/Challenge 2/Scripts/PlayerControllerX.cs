using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerX : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject dogPrefab;
    [SerializeField] private float delayTime = 3.0f;
    
    private float _dogDelay = 0.0f;
    
    // Update is called once per frame
    void Update()
    {
        if (_dogDelay <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _dogDelay = delayTime;
                Instantiate(dogPrefab, spawnPoint.transform.position , spawnPoint.transform.rotation);
            }
        }
        else
        {
            _dogDelay -= Time.deltaTime;
            
            Debug.Log("Dog Delay: " + _dogDelay.ToString("F2") + "s");
        }
    }
}