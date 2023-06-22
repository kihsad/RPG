using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CharacterRemoved();

public class NPC : Character
{
    public event CharacterRemoved _characterRemoved;
    public virtual Transform Select()
    {
        return _hitBox;
    }
    public virtual void DeSelect()
    {

    }
    public void OnCharacterRemoved()
    {
        if(_characterRemoved is not null)
        {
            _characterRemoved();
        }
        Destroy(gameObject);
    }
}
