using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInController : MonoBehaviour
{
    public float FadeInSpeed = 5f;

    private Vector3 _originalScale;
    private float _SpawnInT = 0;
    private bool _isSpawned = true;

    // Use this for initialization
    void Start()
    {
        _originalScale = transform.localScale;
        transform.localScale = Vector3.zero;
        StartCoroutine(Delay());
    }


    IEnumerator Delay()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Vector3 playerTransform = player.transform.position;
        Vector3 blockTransform = transform.position;
        playerTransform.y = 0;
        blockTransform.y = 0;
        float timeToWait = Mathf.FloorToInt(Vector3.Distance(playerTransform, blockTransform));
        yield return new WaitForSeconds(timeToWait * 0.2f);
        _isSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isSpawned) return;

        _SpawnInT += FadeInSpeed * Time.deltaTime;
        transform.localScale = _originalScale * _SpawnInT;

        if (_SpawnInT >= 1)
        {
            transform.localScale = _originalScale;
            _isSpawned = true;
        }
    }
}
