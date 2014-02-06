using UnityEngine;
using System.Collections;

public class PublicClasses : MonoBehaviour {
	/*--- STRUCTS ---*/
	public struct Point {
		public int X, Y;

		public Point (int x, int y) {
			X = x;
			Y = y;
		}
	}
	/*--- END STRUCTS ---*/

	/*--- CLASSES ---*/
	public abstract class GridObject {
		public Point Location;

		public int X {
			get {
				return Location.X;
			}
		}

		public int Y {
			get {
				return Location.Y;
			}
		}

		public GridObject (Point location) {
			Location = location;
		}

		public GridObject (int x, int y) : this(new Point(x, y)) {}

		public override string ToString () {
			return string.Format ("({0}, {1})", X, Y);
		}
	}
	/*--- END CLASSES ---*/
}
