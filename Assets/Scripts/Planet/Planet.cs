using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private int _gravityForce;
    [SerializeField] private int _reward;
    [SerializeField] private Planet _nextSize;
    [SerializeField] private PointEffector2D _orbit;

    public int GravityForce => _gravityForce;
    public int Reward => _reward;

    private void Start()
    {
       _orbit.forceMagnitude= -_gravityForce;
    }

    public void TryMerge(Planet planetForMerge)
    {
        if (planetForMerge.GravityForce == this.GravityForce && planetForMerge != this)
        {
            if (_nextSize != null)
            {
                Instantiate(_nextSize, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
                planetForMerge.gameObject.SetActive(false);
            }
        }
    }
}
