using UnityEngine;

namespace BalanseMaze
{
    public class MazeBoxView : MonoBehaviour, IMazeView, IObserver, IFixedUpdateble
    {
        [SerializeField] private Transform targetTransform;
        [SerializeField] private Transform changeRotateable;

        private IMazeModel mazeModel;
        private Quaternion targetRotate;
        private int activeMazeId;

        private void Awake()
        {
            targetTransform = transform;
        }

        private void OnDestroy()
        {
            mazeModel.RemoveObserver(this);
        }

        public void Initialize(IMazeModel mazeModel)
        {
            this.mazeModel = mazeModel;

            mazeModel.RegisterObserver(this);

            SetRotation(mazeModel.GetRotation());
        }

        public void ChangeMaze(int id)
        {
            if (activeMazeId == id) return;
            activeMazeId = id;

            targetTransform.rotation = Quaternion.identity;
            changeRotateable.rotation = id switch
            {
                0 => Quaternion.identity,
                1 => Quaternion.Euler(-90, 0, 0),
                2 => Quaternion.Euler(180, 0, 0),
                3 => Quaternion.Euler(-270, 0, 0),
                4 => Quaternion.Euler(0, 0, 90),
                5 => Quaternion.Euler(0, 0, 270),
                _ => Quaternion.identity
            };
        }

        public void SetRotation(Quaternion rotation)
        {
            targetRotate = rotation;
        }

        public void UpdateData()
        {
            SetRotation(mazeModel.GetRotation());
            ChangeMaze(mazeModel.GetMazeId());
        }

        public void MoveUpdate()
        {
            targetTransform.rotation = Quaternion.Lerp(targetTransform.rotation, targetRotate, Time.fixedDeltaTime * 100);
        }
    }
}