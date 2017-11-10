﻿using System;
using System.IO;
using System.Linq;

namespace mobile.imagetools.shared.Utility
{
	public static class IoHelper
	{
		public static bool CreateDirectoryRecursive(string fullPath)
		{
			var paths = fullPath.Split(Path.DirectorySeparatorChar);
			if(paths.Length < 3)
				throw new ArgumentException("Path can't be seperated properly.", fullPath);

			if (Directory.Exists(fullPath))
				return false;

			var changes = false;

			for (int i = 2; i < paths.Length; i++)
			{
				var currentPath = string.Join(Path.DirectorySeparatorChar.ToString(), paths.Take(i+1).ToArray());
				if (!Directory.Exists(currentPath))
				{
					changes = true;
					Directory.CreateDirectory(currentPath);
				}
			}

			return changes;
		}
	}
}