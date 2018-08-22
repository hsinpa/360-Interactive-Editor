using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace _360ExMaker
{
	[CreateNodeMenu("Media/Video")]
	public class MediaVideoNode : MediaNode {
		[Input(connectionType = ConnectionType.Override)] public float time;


	}
}