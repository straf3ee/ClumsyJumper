using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BlocksCreator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _blocks;

    [SerializeField]
    private Vector3 _leftSide;

    [SerializeField]
    private Vector3 _rightSide;

    [SerializeField]
    private float _lastHeight = 1f;
    
    private bool _isFirstBlock = true;

    private void Start()
    {
        InstantiateFirstBlock();
        _isFirstBlock = false;
    }
    
    private void InstantiateFirstBlock()
    {
        _lastHeight += 1f;
        var block = GetBlock();
        var sideIndex = Random.Range(0, 1);

        var newRightPosition = new Vector3(_rightSide.x, _lastHeight, _rightSide.z);
        var newLeftSide = new Vector3(_leftSide.x, _lastHeight, _leftSide.z);

        switch (sideIndex)
        {
            case 0:
                Instantiate(block, newLeftSide, Quaternion.identity);
                break;
            case 1:
                Instantiate(block, newRightPosition, Quaternion.identity);
                break;
        }
    }

    public void InstantiateBlock()
    {
        _lastHeight += 1f;
        var block = GetBlock();
        var sideIndex = Random.Range(0, 1);

        var newRightPosition = new Vector3(_rightSide.x, _lastHeight, _rightSide.z);
        var newLeftSide = new Vector3(_leftSide.x, _lastHeight, _leftSide.z);

        switch (sideIndex)
        {
            case 0:
                Instantiate(block, newLeftSide, Quaternion.identity);
                break;
            case 1:
                Instantiate(block, newRightPosition, Quaternion.identity);
                break;
        }
    }

    private GameObject GetBlock()
    {
        if (_isFirstBlock)
        {
            return _blocks[0];
        }
        
        var blockIndex = Random.Range(0, _blocks.Count);
        return _blocks[blockIndex];
    }
}