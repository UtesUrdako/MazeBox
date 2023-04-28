using UnityEngine;

namespace BalanseMaze
{
    public interface IMazeController
    {
        public void Rotate(Vector2 direction);
        public void ChangeMaze(int id);
        public void EndGame();
    }
}