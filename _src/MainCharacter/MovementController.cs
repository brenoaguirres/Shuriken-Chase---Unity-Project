using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : BasicMovement
{
    #region Lane-Change Related Variables
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    [SerializeField] private float _moveSpeed = 1.5f;
    [SerializeField] private Transform[] _lanes = {};
    [SerializeField] private int _currentLane = 1;
    private float _currentMovement = 0f;
    private bool _canChangeLane = true;
    #endregion

    #region State Machine Related

    [SerializeField] private PlayerStateMachine _playerStateMachine;

    #endregion

    #region Jump Variables

    [SerializeField] private float _jumpHeight = 0.5f;
    [SerializeField] private float _jumpDuration = 0.5f;
    private bool _jumpAllowed = true;

    #endregion

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        MovementLogic();
    }

    protected override void MovementLogic() {
        if (_canChangeLane) {
            if (Vector2.Distance(transform.position, _lanes[_currentLane].transform.position) < 0.01f) {
                _currentMovement = 0f;
                SetJumpAnim(false);
            }

            _currentMovement = Mathf.MoveTowards(_currentMovement, 1f, _moveSpeed * Time.deltaTime);
            transform.position = Vector2.Lerp(transform.position, _lanes[_currentLane].transform.position, _currentMovement);
        }

        if (_playerStateMachine.GetLaneChangeState()) {
            StartCoroutine(_playerStateMachine.WaitLaneChangeState());
        }
    }

    private void LaneUp() {
        if (_currentLane != 0) {
            _playerStateMachine.StartLaneChangeState();
            SetLane(_currentLane - 1);
            SetJumpAnim(true);
            BroadcastMessage("SFXLaneChange");
        }
    }

    private void LaneDown() {
        if (_currentLane != 2) {
            _playerStateMachine.StartLaneChangeState();
            SetLane(_currentLane + 1);
            SetJumpAnim(true);
            BroadcastMessage("SFXLaneChange");
        }
    }

    private void Duck_Start() {
        _playerStateMachine.StartDuckState();
        _canChangeLane = false;
        _animator.SetBool("isDucking", true);
    }

    private void Duck_End() {
        _canChangeLane = true;
        _animator.SetBool("isDucking", false);
        _playerStateMachine.EndDuckState();
    }

    private IEnumerator Leap() {
        _jumpAllowed = false;
        _canChangeLane = false;

        _playerStateMachine.StartJumpState();
        _animator.SetTrigger("Leap");

        Vector3 initialPosition = transform.position;
        Vector3 jumpDestination = initialPosition + new Vector3(0f, _jumpHeight, 0f);

        float elapsedTime = 0;
        while (elapsedTime < _jumpDuration) {
            float t = elapsedTime / _jumpDuration;

            transform.position = Vector3.Lerp(initialPosition, jumpDestination, t);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.position = jumpDestination;

        elapsedTime = 0;
        while (elapsedTime < _jumpDuration) {
            float t = elapsedTime / _jumpDuration;
            transform.position = Vector3.Lerp(jumpDestination, _lanes[_currentLane].position, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = _lanes[_currentLane].position;

        StartCoroutine(_playerStateMachine.WaitJumpState());

        _canChangeLane = true;
        _jumpAllowed = true;
    }

    private void CallLeap() {
        if (_jumpAllowed) {
            StartCoroutine(Leap());
        }
    }

    private void SetLane(int laneNumber) {
        _currentLane = laneNumber;
    }

    #region Animation Related Functions
    private void SetJumpAnim(bool jumping) {
        if (jumping) {
            _animator.SetBool("isJumping", true);
            BroadcastMessage("SFXJump");
        }
        else {
            _animator.SetBool("isJumping", false);
        }
    }
    #endregion
}
