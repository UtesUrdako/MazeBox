using UnityEngine;

namespace BalanseMaze
{
    public interface IMazeInput
    {
        public Vector2 GetDirection();
        void UpdateInput();
    }
}