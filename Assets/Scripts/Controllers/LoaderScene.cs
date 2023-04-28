using System.Collections.Generic;
using UnityEngine;

namespace BalanseMaze
{
    public class LoaderScene : MonoBehaviour
    {
        [SerializeField] private InputSystemConfig inputConfig;
        [SerializeField] private BalanceMazeConfig balanceMazeConfig;
        [SerializeField] private GameObject mazePrefab;
        [SerializeField] private Menu gameMenu;

        private List<IUpdateable> updatebles = new List<IUpdateable>();
        private List<IFixedUpdateble> fixedUpdatebles = new List<IFixedUpdateble>();

        private void Awake()
        {
            GameObject newObject = Instantiate(mazePrefab, Vector3.zero, Quaternion.identity);
            IMazeView mazeView = newObject.GetComponent<IMazeView>();

            Transitor[] transitors = newObject.GetComponentsInChildren<Transitor>();

            newObject = new GameObject("InputManager");
            InputManager inputManager = newObject.AddComponent<InputManager>();


            IMazeModel mazeModel = new MazeBoxModel(balanceMazeConfig);

            IMazeController mazeController = new BalanceMazeController(inputManager, gameMenu, mazeModel);


            inputManager.Initialize(inputConfig, mazeController);
            mazeView.Initialize(mazeModel);
            mazeModel.Initialize();
            foreach (Transitor transitor in transitors)
                transitor.Initialize(mazeController);


            updatebles.Add(inputManager);
            fixedUpdatebles.Add(mazeView as IFixedUpdateble);
        }

        private void Update()
        {
            updatebles.ForEach(updatable => updatable.LogicUpdate());
        }

        private void FixedUpdate()
        {
            fixedUpdatebles.ForEach(fixedUpdateble => fixedUpdateble.MoveUpdate());
        }
    }
}