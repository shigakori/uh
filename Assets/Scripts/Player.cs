using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private Vector3 _moveDelta;
    private RaycastHit2D _hit;
    
    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        // reset the moveDelta    
        _moveDelta = new Vector3(x,y,0);
        
        // swap sprite direction, right or left
        if(_moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if(_moveDelta.x < 0)
            transform.localScale = new Vector3(-1,1,1);
        
        // make sure we can move in this direction, by casting a box there first, if the box returns null, we're free to move
        _hit = Physics2D.BoxCast(transform.position,_boxCollider.size, 0, 
            new Vector2(0, _moveDelta.y), Mathf.Abs(_moveDelta.y * Time.deltaTime), 
            LayerMask.GetMask("Actor", "Blocking"));
        if (_hit.collider is null)
        {
            // make a moving
            transform.Translate(0, _moveDelta.y * Time.deltaTime, 0);
        }
        
        _hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, 
            new Vector2(_moveDelta.x, 0), Mathf.Abs(_moveDelta.x * Time.deltaTime), 
            LayerMask.GetMask("Actor", "Blocking"));
        if (_hit.collider is null)
        {
            // make a moving
            transform.Translate(_moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
