using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D _boxCollider;
    private Collider2D[] _hits = new Collider2D[10];

    protected virtual void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        // collision
        _boxCollider.Overlap(filter, _hits);
        for (int i = 0; i < _hits.Length; i++)
        {
            if (_hits[i] is null)
                continue;

            OnCollide(_hits[i]);
            
            // the array is not cleaned up so we do it ourself
            _hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D coll)
    {
        Debug.Log(coll.name);
    }
}
