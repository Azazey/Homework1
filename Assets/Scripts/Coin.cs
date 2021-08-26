using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]private float _speed; 
    
    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform; 
    }
    
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, _speed);
    }
    
    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _playerTransform.position);
        if (distanceToPlayer < 0.8f)
        { 
            Destroy(gameObject);
            CoinCounter.CoinsNumberChanger();
        }
    }
}
