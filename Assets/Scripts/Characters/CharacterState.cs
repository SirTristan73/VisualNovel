using System;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class CharacterState : MonoBehaviour
{
    [Header("Resolvers")]
    [SerializeField] private SpriteResolver _bodyResolver;
    [SerializeField] private SpriteResolver _faceResolver;
    [SerializeField] private SpriteResolver _clothingResolver;
    [SerializeField] private SpriteResolver _hairResolver;


    public int _characterProgress { get; private set; }
    public string _characterName { get; private set; }

    private CurrentCharacterState _currentState;


    public void Init(string name, int progress, CurrentCharacterState savedState = null)
    {
        _characterName = name;
        _characterProgress = progress;

        if (savedState != null)
        {
            _currentState = savedState;
        }
        else
        {
            _currentState = new CurrentCharacterState();
        }

        ApplyState();
    }


    private void ApplyState()
    {
        _faceResolver.SetCategoryAndLabel("Face", _currentState._face);
        _bodyResolver.SetCategoryAndLabel("Body", _currentState._body);
        _clothingResolver.SetCategoryAndLabel("Clothing", _currentState._clothing);
        _hairResolver.SetCategoryAndLabel("Hair", _currentState._clothing);
    }


    public void IncreaseCharacterProgress(int value)
    {
        _characterProgress += value;
    }


    public void SetBody(string body)
    {
        _currentState._body = body;
        _bodyResolver.SetCategoryAndLabel("Body", body);
    }


    public void SetFace(string face)
    {
        _currentState._face = face;
        _faceResolver.SetCategoryAndLabel("Face", face);
    }


    public void SetHair(string hair)
    {
        _currentState._hair = hair;
        _hairResolver.SetCategoryAndLabel("Hair", hair);
    }


    public void SetClothes(string clothes)
    {
        _currentState._clothing = clothes;
        _clothingResolver.SetCategoryAndLabel("Clothing", clothes);
    }


    public CurrentCharacterState GetCurrentCharacterState()
    {
        return _currentState;
    }

    public int GetCurrentCharacterProgress()
    {
        return _characterProgress;
    }
}

