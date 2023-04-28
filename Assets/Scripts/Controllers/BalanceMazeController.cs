using UnityEngine;

namespace BalanseMaze
{
    public class BalanceMazeController : IMazeController
    {
        private InputManager inputManager;
        private Menu gameMenu;
        private IMazeModel mazeModel;
        private bool isBlockInput;

        public BalanceMazeController(InputManager inputManager, Menu gameMenu, IMazeModel mazeModel)
        {
            this.inputManager = inputManager;
            this.gameMenu = gameMenu;
            this.mazeModel = mazeModel;
        }

        public void ChangeMaze(int id)
        {
            if (isBlockInput) return;

            mazeModel.ChangeMaze(id);
        }

        public void EndGame()
        {
            inputManager.BlockInput();
            gameMenu.Finish();
            Debug.Log("CONGRATULATION!");
        }

        public void Rotate(Vector2 direction)
        {
            if (isBlockInput) return;

            mazeModel.SetRotation(new Vector3(direction.y, 0, direction.x));
        }
    }
}