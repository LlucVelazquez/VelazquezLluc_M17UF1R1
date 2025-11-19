using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float _startingPos;
    private float _lengthOfSprite;
    public float AmountOfParallax;
    public Camera MainCamera;
    private float posY;

    private void Start()
    {
        _startingPos = transform.position.x;
        _lengthOfSprite = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    private void FixedUpdate()
    {
        Vector3 Position = MainCamera.transform.position;
        float Temp = Position.x * (1 - AmountOfParallax);
        float Distance = Position.x * AmountOfParallax;
        if(1 - AmountOfParallax == 0)
        {
            posY = Position.y;
        }else
        {
            posY = transform.position.y;
        }

        Vector3 NewPosition = new Vector3(_startingPos + Distance, posY, transform.position.z);

        transform.position = NewPosition;

        if (Temp > _startingPos + (_lengthOfSprite / 2))
        {
            _startingPos += _lengthOfSprite;
        }
        else if (Temp < _startingPos - (_lengthOfSprite / 2))
        {
            _startingPos -= _lengthOfSprite;
        }
    }
}
