﻿using System;
using System.Text.RegularExpressions;

namespace Payrollee.Common.Libs
{
	public static class StringRubyExtension
	{
		public static string Camelize(this string value, bool firstLetterUppercase = true)
		{
			if (firstLetterUppercase)
			{
				return
					Regex.Replace(
						Regex.Replace(value, "/(.?)", p => "::" + p.Groups[1].Value.ToUpperInvariant()),
						"(?:^|_)(.)", p => p.Groups[1].Value.ToUpperInvariant()
					);
			}
			else
			{
				return
					value.Substring(0, 1).ToLowerInvariant() +
					Camelize(value.Substring(1));
			}
		}

		public static string Underscore(this string value)
		{
			value = value.Replace("::", "/");
			value = Regex.Replace(value, "([A-Z]+)([A-Z][a-z])", p => p.Groups[1].Value + "_" + p.Groups[2].Value);
			value = Regex.Replace(value, "([a-z\\d])([A-Z])", p => p.Groups[1].Value + "_" + p.Groups[2].Value);
			value = value.Replace("-", "_");

			return value.ToLowerInvariant();
		}

		public static string FormatAmount(this string value)
		{
			// .gsub(/(\d)(?=(\d\d\d)+(?!\d))/, "\\1 ")
			return Regex.Replace(value, "(\\d)(?=(\\d\\d\\d)+(?!\\d))", p => p.Groups[1].Value + " ", 
				RegexOptions.Singleline | RegexOptions.IgnoreCase);
		}
	}
}

