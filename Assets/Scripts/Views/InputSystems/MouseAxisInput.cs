using UnityEngine;

namespace BalanseMaze
{
    public class MouseAxisInput : Vector2Input, IMazeInput
    {
        public MouseAxisInput(float deathZone)
        {
            this.deathZone = deathZone;
        }

        public void UpdateInput()
        {
            x = Input.GetAxis("Mouse X") * -1;
            y = Input.GetAxis("Mouse Y");
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