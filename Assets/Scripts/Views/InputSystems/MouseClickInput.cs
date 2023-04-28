using UnityEngine;
using UnityEngine.EventSystems;

namespace BalanseMaze
{
    public class MouseClickInput : Vector2Input, IMazeInput
    {
        private float mouseArea = 100;
        private Vector3 pointMouse;

        public MouseClickInput(float deathZone)
        {
            this.deathZone = deathZone;
        }

        public void UpdateInput()
        {
            if (Input.GetMouseButtonDown(0))
                pointMouse = Input.mousePosition;
            if (Input.GetMouseButtonUp(0))
                x = y = 0f;

            if (Input.GetMouseButton(0))
            {
                var direction = Input.mousePosition - pointMouse;
                x = direction.x / mouseArea * -1;
                y = direction.y / mouseArea;
            }
        }

        public Vector2 GetDirection()
        {
            var xRot = Mathf.Abs(x) < deathZone ? 0f : x;
            xRot = Mathf.Clamp(x, -1f, 1f);
            var yRot = Mathf.Abs(y) < deathZone ? 0f : y;
            yRot = Mathf.Clamp(y, -1f, 1f);

            return new Vector2(xRot, yRot);
        }
    }
}