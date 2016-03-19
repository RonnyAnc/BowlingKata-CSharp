using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
	public static class MyExtension
	{
		public static IEnumerable<R> Map<T, R>(this IEnumerable<T> enumerable, Func<T, R> func)
		{
			return enumerable.Select(func);
		}
	}
}