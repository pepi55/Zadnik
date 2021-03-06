﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IPathNode<T> {
	List<T> Connections { get; }
	Vector2 Position { get; }
	bool Invalid { get; }
	string Tag { get; }
}