using UnityEngine;

public class Coin : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField]private float _speed; 

    void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform; 
    }


    void FixedUpdate()
    {
        transform.Rotate(0, 0, _speed);
    }


    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _playerTransform.position);
        if (distanceToPlayer < 0.8f)
        { 
            Destroy(gameObject);
            CoinCounter.CoinsNumberChanger();
        }
    }
}
