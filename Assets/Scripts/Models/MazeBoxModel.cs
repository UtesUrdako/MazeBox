using System.Collections.Generic;
using UnityEngine;

namespace BalanseMaze
{
    public class MazeBoxModel : IMazeModel
    {
        private List<IObserver> observers = new List<IObserver>();

        private BalanceMazeConfig mazeConfig;
        private Quaternion originRotation;
        private Vector3 rotation;
        private int mazeId;

        public MazeBoxModel(BalanceMazeConfig balanceMazeConfig)
        {
            mazeConfig = balanceMazeConfig;
        }

        public void Initialize()
        {
            originRotation = Quaternion.identity;
            NotifyObservers();
        }

        public Quaternion GetRotation()
        {
            return originRotation * Quaternion.Euler(rotation);
        }

        public void SetRotation(Vector3 rotation)
        {
            this.rotation = rotation * mazeConfig.MaxAngle;
            NotifyObservers();
        }

        public void ChangeMaze(int id)
        {
            mazeId = id;
            NotifyObservers();
        }

        public void RegisterObserver(IObserver o)
        {
            if (!observers.Contains(o))
                observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            if (observers.Contains(o))
                observers.Remove(o);
        }

        public void NotifyObservers()
        {
            observers.ForEach(observer => observer.UpdateData());
        }

        public int GetMazeId()
        {
            return mazeId;
        }
    }
}