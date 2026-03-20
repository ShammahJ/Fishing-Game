using System;
using Unity.Mathematics;
using UnityEngine;

public class HookFollow : MonoBehaviour {
    [SerializeField] private Hook hook;
    [SerializeField] private SpriteRenderer sprite;
    private void Update()
    {
        transform.position = new Vector2(transform.position.x, hook.transform.position.y);
        float dist = math.abs(transform.position.x - hook.transform.position.x);
        float transparency = math.min(5 - dist,1);
        print(transparency);
        sprite.color = new Color(1,1,1,transparency);
    }
}
