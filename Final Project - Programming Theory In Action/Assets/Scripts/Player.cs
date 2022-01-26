using UnityEngine;

public class Player : MonoBehaviour
{
    // ENCAPSULATION
    public static Player Instance { get; private set; }

    // ENCAPSULATION
    private int _score = 0;
    public int Score { get => _score; set => _score = value; }

    private int _health = 10;
    public int Health
    {
        get { return _health; }
        set 
        { 
            _health = value;

            if (_health < 0)
            {
                _health = 0;
            }
        }
    }
    

    private void Start()
    {
        Instance = this;
    }
}
