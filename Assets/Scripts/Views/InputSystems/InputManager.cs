using UnityEngine;

namespace BalanseMaze
{
    public class InputManager : MonoBehaviour, IUpdateable
    {
        private IMazeController mazeController;
        private IMazeInput mazeInput;
        private bool isBlockInput;

        public void Initialize(InputSystemConfig inputConfig, IMazeController mazeController)
        {
            this.mazeController = mazeController;

            mazeInput = inputConfig.TypeInput switch
            {
                TypeInput.MouseAxisInput => new MouseAxisInput(inputConfig.DeathZone),
                TypeInput.MouseWithClickInput => new MouseClickInput(inputConfig.DeathZone),
                _ => new MouseAxisInput(inputConfig.DeathZone)
            };
        }

        public void LogicUpdate()
        {
            if (isBlockInput) return;

            mazeInput.UpdateInput();
            mazeController.Rotate(mazeInput.GetDirection());
        }

        public void BlockInput()
        {
            isBlockInput = true;
        }
    }
}