using System;
using PayrolleeMate.ProcessService.Interfaces.Loggers;
using PayrolleeMate.ProcessService.Interfaces;
using System.Collections.Generic;
using System.IO;
using PayrolleeMate.ProcessConfig.Interfaces;
using System.Linq;

namespace Tests.ProcessService.Loggers
{
	public class TestTargetsLogger : IProcessServiceLogger
	{
		public TestTargetsLogger (string testNamespace)
		{
			TestNamespaceDir = "../../../LoggFiles/" + testNamespace + "/";

			LogSequenceId = 0;

			SequenceNames = new Dictionary<string, string> ();
		}

		private string TestNamespaceDir { get; set; }

		private Stream LogFileStream { get; set; }

		private UInt16 LogSequenceId { get; set; }

		private IDictionary<string, string> SequenceNames { get; set; }

		#region IGeneralLogger implementation

		public void OpenLogStream (string testName)
		{
			string TestFilenameExist = LogSequenceId.ToString () + "-" + testName;

			FileMode fileOpenMode = FileMode.Append;

			if (SequenceNames.ContainsKey (testName))
			{
				TestFilenameExist = SequenceNames[testName];
			}
			else
			{
				LogSequenceId ++; 

				TestFilenameExist = LogSequenceId.ToString () + "-" + testName;

				SequenceNames[testName] = TestFilenameExist;

				fileOpenMode = FileMode.Create;
			}

			string TestNamespaceFile = TestNamespaceDir + TestFilenameExist + ".txt";

			LogFileStream = new FileStream (TestNamespaceFile, fileOpenMode);
		}

		public void CloseLogStream ()
		{
			LogFileStream = null;
		}

		public void LogAppendMessageInfo (string message, string testName)
		{
			OpenLogStream(testName);

			using (StreamWriter logWriter = new StreamWriter (LogFileStream) ) 
			{
				logWriter.WriteLine (message);
			}
		}

		#endregion

		#region IProcessServiceLogger implementation

		public void LogEvaluationStream (ITargetStream targets, string testName)
		{
			OpenLogStream (testName);

			using (StreamWriter logWriter = new StreamWriter (LogFileStream)) 
			{
				string lineDefinition = "\n--- begin ---";

				lineDefinition += TargetStreamLogger.LogTargetStreamInfo (targets.Targets ());

				if (lineDefinition.Length > 0) 
				{
					logWriter.WriteLine (lineDefinition);
				}
				logWriter.WriteLine ("--- end ---");
			}
		}

		public void LogEvaluationList (IBookTarget[] targets, string testName)
		{
			OpenLogStream (testName);

			using (StreamWriter logWriter = new StreamWriter (LogFileStream)) 
			{
				string lineDefinition = "\n--- begin ---";

				lineDefinition += TargetStreamLogger.LogTargetListInfo (targets);

				if (lineDefinition.Length > 0) 
				{
					logWriter.WriteLine (lineDefinition);
				}
				logWriter.WriteLine ("--- end ---");
			}
		}

		public void LogResultStream (IResultStream results, string testName)
		{
			OpenLogStream (testName);

			using (StreamWriter logWriter = new StreamWriter (LogFileStream)) 
			{
				string lineDefinition = "\n--- begin ---";

				lineDefinition += ResultStreamLogger.LogResultStreamInfo (results.Results ());

				if (lineDefinition.Length > 0) 
				{
					logWriter.WriteLine (lineDefinition);
				}
				logWriter.WriteLine ("--- end ---");
			}
		}

		#endregion

		private static class TargetStreamLogger
		{
			public static string LogTargetStreamInfo(IDictionary<IBookIndex, IBookTarget> targets)
			{
				string lineDefinition = "";

				lineDefinition += "\n";

				lineDefinition += "----------------------------";

				foreach (var target in targets)
				{
					lineDefinition += LogArticleInfo (target.Value);
				}
				lineDefinition += "\n";

				lineDefinition += "----------------------------";

				return lineDefinition;
			}

			public static string LogTargetListInfo(IBookTarget[] targets)
			{
				string lineDefinition = "";

				lineDefinition += "\n";

				lineDefinition += "----------------------------";

				foreach (var target in targets)
				{
					lineDefinition += LogArticleInfo (target);
				}
				lineDefinition += "\n";

				lineDefinition += "----------------------------";

				return lineDefinition;
			}

			public static string LogArticleInfo(IBookTarget target)
			{
				IPayrollArticle article = target.Article ();

				IBookIndex element = target.Element ();

				string lineDefinition = string.Format("\n--- {0} - {1} - {2} - {3}", 
					article.ArticleName(), article.ConceptName(), article.ArticleCode(), element.ToString());

				return lineDefinition;
			}

		}

		private static class ResultStreamLogger
		{
			public static string LogResultStreamInfo(IDictionary<IBookIndex, IBookResult> results)
			{
				string lineDefinition = "";

				lineDefinition += "\n";

				lineDefinition += "----------------------------";

				foreach (var result in results)
				{
					lineDefinition += LogResultInfo (result.Value);
				}
				lineDefinition += "\n";

				lineDefinition += "----------------------------";

				return lineDefinition;
			}

			public static string LogResultInfo(IBookResult result)
			{
				IPayrollArticle article = result.Article ();

				IBookIndex element = result.Element ();

				string lineDefinition = string.Format("\n--- {0} - {1} - {2} - {3}", 
					article.ArticleName(), article.ConceptName(), article.ArticleCode(), element.ToString());

				foreach (var targetValue in result.TargetValues()) 
				{
					lineDefinition += string.Format("\n\t--> {0} - {1}", targetValue, LogValueInfo(targetValue, result.Values()));
				}

				foreach (var resultValue in result.ResultValues()) 
				{
					lineDefinition += string.Format("\n\t<-- {0} - {1}", resultValue, LogValueInfo(resultValue, result.Values()));
				}

				return lineDefinition;
			}

			public static string LogValueInfo(string value, IResultValues result)
			{
				switch (value) 
				{
				case "contract_type":
					return LogObjectString (result.ContractType ());

				case "health_work":
					return LogObjectString (result.HealthWorkType ());

				case "social_work":
					return LogObjectString (result.SocialWorkType ());

				case "date_from":
					return LogObjectString (result.DateFrom ());

				case "date_ends":
					return LogObjectString (result.DateEnds ());

				case "timesheet_weekly":
					return LogObjectString (result.TimesheetWeekly ());

				case "workdays_weekly":
					return LogObjectString (result.WorkdaysWeekly ());

				case "timesheet_worked":
					return LogObjectString (result.TimesheetWorked ());

				case "timesheet_absent":
					return LogObjectString (result.TimesheetAbsent ());

				case "amount_monthly":
					return LogObjectString (result.AmountMonthly ());

				case "code_interests":
					return LogObjectString (result.CodeInterests ());

				case "code_residency":
					return LogObjectString (result.CodeResidency ());

				case "code_mandatory": 
					return LogObjectString (result.CodeMandatory ());

				case "code_statement": 
					return LogObjectString (result.CodeStatement ());

				case "code_handicaps": 
					return LogObjectString (result.CodeHandicaps ());

				case "code_cardinals": 
					return LogObjectString (result.CodeCardinals ());
				
				// RESULTS
				case "day_ordinal_from": 
					return LogObjectString (result.PeriodDayFromOrdinal ());

				case "day_ordinal_ends": 
					return LogObjectString (result.PeriodDayEndsOrdinal ());

				case "shift_timetable": 
					return LogInt32String (result.ShiftTimetable ());

				case "work_timetable": 
					return LogInt32String (result.WorkTimetable ());

				case "over_timetable": 
					return LogInt32String (result.OverTimetable ());

				case "absence_timetable": 
					return LogInt32String (result.AbsenceTimetable ());

				case "worktime_counts": 
					return LogObjectString (result.WorktimeCount ());

				case "overtime_counts": 
					return LogObjectString (result.OvertimeCount ());

				case "absence_counts": 
					return LogObjectString (result.AbsenceCount ());

				case "record_time": 
					return LogObjectString (result.RecordTime ());

				case "record_amount": 
					return LogObjectString (result.RecordAmount ());

				case "record_income": 
					return LogObjectString (result.RecordIncome ());

				case "amount_income": 
					return LogObjectString (result.AmountIncome ());

				case "amount_payments": 
					return LogObjectString (result.AmountPayments ());

				case "amount_deducted": 
					return LogObjectString (result.AmountDeducted ());

				default:
					return "NULL";
				}
			}

			public static string LogObjectString(object value)
			{
				if (value == null) 
				{
					return "NULL";
				}
				return value.ToString ();
			}

			public static string LogInt32String(Int32[] values)
			{
				if (values == null) 
				{
					return "NULL";
				}
				string valueInfo = values.Aggregate("[ ", (agr, x) => agr + x.ToString() + ", ");

				return valueInfo + " ]";
			}

			public static string LogArrayString(object[] values)
			{
				if (values == null) 
				{
					return "NULL";
				}
				string valueInfo = values.Aggregate("[ ", (agr, x) => agr + x.ToString() + ", ");

				return valueInfo + " ]";
			}
		}

	}
}

