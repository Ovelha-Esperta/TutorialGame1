using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePerson1 : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Rigidbody2D _rb2d;
    [SerializeField] Vector2 _move;
    [SerializeField] float _xSpeed;

    [SerializeField] float _jumpForce;
    [SerializeField] bool _isGround;
    [SerializeField] Transform _groundCheck;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask _whatIsGround;

    public int _numberJump;
    [SerializeField] int _nJump;

    [SerializeField] bool _faceFlip;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _isGround = Physics2D.OverlapCircle(_groundCheck.position, checkRadius, _whatIsGround);

        float horizontal = Input.GetAxisRaw("Horizontal");
        _move = new Vector2(horizontal, 0);

        _xSpeed = _move.normalized.x * _speed;
        _rb2d.velocity = new Vector2(_xSpeed, _rb2d.velocity.y);
        Flip(-horizontal);


    }
     void jumb()
    {
        _nJump--;
    }

     void Update()
    {
        if (_isGround)
        {
            _nJump = _numberJump;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow)&& _nJump > 0)
        {
            Invoke("jumb", .2f);
            _rb2d.velocity = Vector2.up * _jumpForce;
            
        }
    }

    void Flip(float horin)
    {
        if(horin>0 && !_faceFlip || horin<0 && _faceFlip)
        {
            _faceFlip = !_faceFlip;
            Vector3 scaleX = transform.localScale;
            scaleX.x *= -1;
            transform.localScale = scaleX;
        }
    }


}
