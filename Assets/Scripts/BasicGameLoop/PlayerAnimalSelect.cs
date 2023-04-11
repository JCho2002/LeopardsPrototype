using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalEventArgs : EventArgs
{
    public AnimalNames Name { get; set; }

    public AnimalEventArgs(AnimalNames name)
    {
        Name = name;
    }
}

public class PlayerAnimalSelect : MonoBehaviour
{
    private Transform _transform;

    [SerializeField]
    private float _playerSelectRadius;

    private AnimalView[] _animals;
    private AnimalView _closestAnimal;

    public event EventHandler<AnimalEventArgs> AnimalChosen;

    private void Awake()
    {
        _transform = this.transform;
    }

    private void Start()
    {
        _animals = FindObjectsOfType<AnimalView>();
    }

    private void Update()
    {
        float closestDistance = Mathf.Infinity;
        AnimalView closestAnimal = null;

        foreach(AnimalView animal in _animals)
        {
            animal.UnSelectedByPlayer();
            float distance = Vector3.Distance(_transform.position, animal.transform.position);

            if(distance < closestDistance)
            {
                closestDistance = distance;
                closestAnimal = animal;
            }

        }


        if(closestDistance <= _playerSelectRadius)
        {
            closestAnimal.SelectedByPlayer();

            if (Input.GetKeyDown("e"))
            {
                OnAnimalChosen(new AnimalEventArgs(closestAnimal.Name));
            }
        }
    }

    private void OnAnimalChosen(AnimalEventArgs eventArgs)
    {
        var handler = AnimalChosen;
        handler?.Invoke(this, eventArgs);
    }
}
