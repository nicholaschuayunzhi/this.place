using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public GameObject block;
    public EnemyController EnemyControl;
    private bool _waiting;
    private int _count;
    private Vector3 _deathPosition;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_waiting)
        {
            return;
        }

        if (_count > 1)
        {
            EnemyDeath();
            _waiting = true;
        }
        else if (!EnemyControl.IsMoving())
        {
            StartCoroutine(waitThenMove());
            _waiting = true;
        }

    }

    void EnemyDeath()
    {
        //block.transform.position = transform.position;
        // block.transform.parent = null;
        //block.transform.position = transform.position;
        //block.GetComponent<Animator>().enabled = false;
        block.GetComponent<Animator>().SetTrigger("Death");
        
        //block.transform.parent = null;
        //
        //Destroy(gameObject);
    }

    IEnumerator waitThenMove()
    {
        yield return new WaitForSeconds(1);
        Vector3 enemyToPlayer = player.transform.position - transform.position;
        if (Mathf.Abs(enemyToPlayer.x) > Mathf.Abs(enemyToPlayer.z))
        {
            Vector3 dir = Vector3.right * Mathf.Sign(enemyToPlayer.x);
            BlockFace face = BlockFaceMethods.BlockFaceFromNormal(dir.normalized);
            EnemyControl.MoveEnemy(face);
        }
        else
        {
            Vector3 dir = Vector3.forward * Mathf.Sign(enemyToPlayer.z);
            BlockFace face = BlockFaceMethods.BlockFaceFromNormal(dir.normalized);
            EnemyControl.MoveEnemy(face);
        }

        _count++;
        _waiting = false;
    }

    void OnEnemyDeathFinish()
    {
        transform.parent = null;
        //GetComponent<Animator>.Rebind();
        transform.localScale = new Vector3(1, 1, 1);
        block.GetComponent<BlockBehaviour>().enabled = true;
        _deathPosition = transform.position;
        //Destroy(EnemyControl.gameObject);
    }
}
