using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
	public static class MyExtensions
	{
		public static IEnumerable<R> Map<T, R>(this IEnumerable<T> enumerable, Func<T, R> func)
		{
			return enumerable.Select(func);
		}

	    public static int Value(this Roll roll)
	    {
	        return (int) roll;
	    }
	}
}