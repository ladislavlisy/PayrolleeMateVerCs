﻿using System;
using System.Globalization;

namespace PayrolleeMate.Common.Periods
{
	public class MonthPeriod : IComparable
	{
		public static readonly uint PRESENT = 0;

		public const uint TERM_BEG_FINISHED = 32;

		public const uint TERM_END_FINISHED =  0;

		public const int  WEEKSUN_SUNDAY =  0;

		public const int  WEEKMON_SUNDAY =  7;

		public static int DayOfWeekMonToSun(int periodDateCwd)
		{
			// DayOfWeek Sunday = 0,
			// Monday = 1, Tuesday = 2, Wednesday = 3, Thursday = 4, Friday = 5, Saturday = 6, 
			if (periodDateCwd == WEEKSUN_SUNDAY) {
				return WEEKMON_SUNDAY;
			} else {
				return periodDateCwd;
			}
		}

		public static MonthPeriod CreateFromYearAndMonth(uint year, byte month)
		{
			return new MonthPeriod(year*100 + month);
		}

		public static MonthPeriod Empty()
		{
			return new MonthPeriod(PRESENT);
		}

		public static MonthPeriod BeginYear(uint year)
		{
			return new MonthPeriod(year*100 + 1);
		}

		public static MonthPeriod EndYear(uint year)
		{
			return new MonthPeriod(year*100 + 12);
		}

		public MonthPeriod(uint code)
		{
			this.Code = code;
		}

		public MonthPeriod(uint year, byte month) : this(year*100 + month)
		{
		}

		public uint Code { get; private set; }

		public uint Year()
		{
			return (Code / 100);
		}

		public byte Month()
		{
			return (byte)(Code % 100);
		}

		public int YearInt()
		{
			return (int)(Code / 100);
		}

		public int MonthInt()
		{
			return (int)(Code % 100);
		}

		public int MonthOrder()
		{
			return (Math.Max(0, YearInt() - 2000)*12 + MonthInt());
		}

		public int DaysInMonth()
		{
			return DateTime.DaysInMonth(YearInt(), MonthInt());
		}

		public DateTime BeginOfMonth()
		{
			return new DateTime(YearInt(), MonthInt(), 1);
		}

		public DateTime EndOfMonth()
		{
			return new DateTime(YearInt(), MonthInt(), DaysInMonth());
		}

		public DateTime DateOfMonth(int dayOrdinal)
		{
			int periodDay = Math.Min (Math.Max (1, dayOrdinal), DaysInMonth ());

			return new DateTime(YearInt(), MonthInt(), periodDay);
		}

		public int WeekDayOfMonth(int dayOrdinal)
		{
			DateTime periodDate = DateOfMonth(dayOrdinal);

			int periodDateCwd = (int)periodDate.DayOfWeek;

			return DayOfWeekMonToSun(periodDateCwd);
		}

		public string Description()
		{
			CultureInfo enCultureInfo = new CultureInfo("en-US");
			DateTime firstPeriodDay = new DateTime(YearInt(), MonthInt(), 1);
			return firstPeriodDay.ToString("MMMM yyyy", enCultureInfo);
		}

		public static bool operator <(MonthPeriod x, MonthPeriod y)
		{
			return (x.Code < y.Code);
		}

		public static bool operator >(MonthPeriod x, MonthPeriod y)
		{
			return (x.Code > y.Code);
		}

		public static bool operator <=(MonthPeriod x, MonthPeriod y)
		{
			return (x.Code <= y.Code);
		}

		public static bool operator >=(MonthPeriod x, MonthPeriod y)
		{
			return (x.Code >= y.Code);
		}

		public int CompareTo(object obj)
		{
			MonthPeriod other = obj as MonthPeriod;

			return this.Code.CompareTo(other.Code);
		}

		public bool isEqualToPeriod(MonthPeriod other)
		{
			return (this.Code == other.Code);
		}

		public override bool Equals(object obj)
		{
			if (obj == this)
				return true;
			if (obj == null || this.GetType() != obj.GetType())
				return false;

			MonthPeriod other = obj as MonthPeriod;

			return this.isEqualToPeriod(other);
		}

		public override int GetHashCode()
		{
			int prime = 31;
			int result = 1;

			result += prime * result + (int)this.Code;

			return result;
		}

		public override string ToString()
		{
			return this.Code.ToString();
		}

		public virtual object Clone()
		{
			MonthPeriod otherPeriod = (MonthPeriod)this.MemberwiseClone();
			return otherPeriod;
		}

	}
}

