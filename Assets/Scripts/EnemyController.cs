using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject EyesPivot;
    public LayerMask BlockLayer;

    private BlockFaceBehaviour _inner;
    private Animator _animator;

    private Vector3 _newPosition;

    private bool _isMoving;
    // Use this for initialization
    void Start ()
	{
	    _inner = GetComponentInChildren<BlockFaceBehaviour>();
	    _animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (_isMoving)
	    {
	        if (Vector3.Distance(transform.position, _newPosition) <= 0.01f)
	        {
	            transform.position = _newPosition;
	            _isMoving = false;
	        }
	        else
	        {
	            transform.Translate((_newPosition - transform.position).normalized * Time.deltaTime);

            }
        }
	}


    public void MoveEnemy(BlockFace face)
    {
        if (!_inner.FireRaycastFromFace(0.1f, BlockLayer, face))
        {
            // rotate eyes
            EyesPivot.transform.forward = face.GetNormal();
            _newPosition = transform.position + face.GetNormal();
            _isMoving = true;
            _animator.SetTrigger("Bounce");
        }
    }

    public bool IsMoving()
    {
        return _isMoving;
    }
}
