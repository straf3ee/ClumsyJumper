using System.Collections;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    
    private BlocksCreator _blocksCreator;
    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        StartCoroutine(Move());
    }
    
    IEnumerator Move()
    {
        while (transform.position.x < 0)
        {
            _rigidbody.MovePosition(transform.position + transform.forward * Time.deltaTime * _speed);
            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StopAllCoroutines();
            //_blocksCreator.InstantiateBlock();
        }
    }
}
