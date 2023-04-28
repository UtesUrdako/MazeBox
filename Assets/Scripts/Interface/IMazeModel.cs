using UnityEngine;

namespace BalanseMaze
{
    public interface IMazeModel : IObservable
    {
        public void Initialize();
        public void SetRotation(Vector3 rotation);
        public void ChangeMaze(int id);
        public Quaternion GetRotation();
        public int GetMazeId();
    }
}
