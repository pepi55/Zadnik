using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IPathNode<T> {
	List<T> connections { get; }
	Vector2 position { get; }
	bool invalid { get; }
}