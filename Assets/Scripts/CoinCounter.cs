using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private Text _coinsNumberText;
    [SerializeField] private Text _winText;
    
    private GameObject[] _coinsObjects;
    private static int _coinsNumber;

    void Start()
    {
        _coinsObjects = GameObject.FindGameObjectsWithTag("Coin");
    }

    void Update()
    {
        TextWriter();
    }

    void TextWriter()
    {
        if (_coinsNumber != _coinsObjects.Length)
        {
            _winText.enabled = false;
            _coinsNumberText.text = "Монет нужно еще собрать " + _coinsNumber + " из " + _coinsObjects.Length;
        }
        else
        {
            _coinsNumberText.enabled = false;
            _winText.enabled = true;
            _winText.text = "Поздравляю ты победил!";
        }
    }

    public static void CoinsNumberChanger()
    {
        _coinsNumber++;
    }
}