using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera;
    bool isJumpPressed = false;

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumpPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumpPressed = false;
            animationHandler.InvincibilityEnd(); //점프 애니메이션 종료 처리
        }

        if (isJumpPressed)
        {
            HandleJump();
        }
    }

    void HandleJump()
    {
        animationHandler.Jump();
    }
}
