using System.Collections;
using UnityEngine;

namespace BalanseMaze
{
    public class Transitor : MonoBehaviour
    {
        [SerializeField] private int id;
        [SerializeField] private TypeTrigger typeTrigger;

        private IMazeController mazeController;
        private Collider collider;

        public void Initialize(IMazeController mazeController)
        {
            this.mazeController = mazeController;
            collider = GetComponent<Collider>();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                switch (typeTrigger)
                {
                    case TypeTrigger.Trasport:
                        mazeController.ChangeMaze(id);
                        StartCoroutine(BlockTrigger());
                        break;
                    case TypeTrigger.Finish:
                        mazeController.EndGame();
                        break;
                }
            }
        }

        private IEnumerator BlockTrigger()
        {
            collider.isTrigger = false;
            yield return new WaitForSeconds(1f);
            collider.isTrigger = true;
        }
    }
}