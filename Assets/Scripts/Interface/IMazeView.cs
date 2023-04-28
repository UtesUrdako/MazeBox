using UnityEngine;

namespace BalanseMaze
{
    public interface IMazeView
    {
        public void Initialize(IMazeModel mazeModel);
        public void SetRotation(Quaternion rotation);
        public void ChangeMaze(int id);
    }
}