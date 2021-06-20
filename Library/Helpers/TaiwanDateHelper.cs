using System;
using System.Globalization;

namespace Library.Helpers
{
    public static class TaiwanDateHelper
    {
        public static DateTime? YearInTaiwanFormat(string DateInOriFormat, string TimeInOriFormat = "")
        {
            string convertedDate = "";
            string convertedTime = "";

            if (string.IsNullOrWhiteSpace(DateInOriFormat))
            {
                return null;
            }

            convertedDate = DateInOriFormat.Insert(3, "-").Insert(6, "-");

            if(!string.IsNullOrWhiteSpace(TimeInOriFormat))
            {
                convertedTime = TimeStringFormat(TimeInOriFormat);
            }
        
            return ParseTaiwanDatetime(convertedDate, convertedTime);
        }
        /// <summary>
        /// 時間轉TimeSpan
        /// </summary>
        /// <param name="designatedTime"></param>
        /// <returns></returns>
        public static TimeSpan? TimeParse(string designatedTime)
        {
            if (string.IsNullOrWhiteSpace(designatedTime))
            {
                return null;
            }
            
            return TimeSpan.Parse(TimeStringFormat(designatedTime));
        }

        /// <summary>
        /// 0000 轉 00:00
        /// </summary>
        /// <param name="designatedTime"></param>
        /// <returns></returns>
        private static string TimeStringFormat(string designatedTime)
        {
            switch (designatedTime.Length)
            {
                case 4:
                    return designatedTime.Insert(2, ":");
                case 6:
                    return designatedTime.Insert(2, ":").Insert(5, ":");
                case 9:
                    return designatedTime.Insert(2, ":").Insert(5, ":").Insert(8, ".");
                default:
                    throw new Exception("日期長度不正確");
            }
        }

        /// <summary>
        /// 民國年轉西元年
        /// </summary>
        /// <param name="date">日期(格式請輸入yyy-MM-dd)</param>
        /// <param name="time">(hh:mm:ss)</param>
        /// <returns></returns>

        private static DateTime ParseTaiwanDatetime(string dateStr, string time = "")
        {
            try
            {
                System.Globalization.CultureInfo tc = new System.Globalization.CultureInfo("zh-TW");
                tc.DateTimeFormat.Calendar = new System.Globalization.TaiwanCalendar();
                DateTime resualtDate = DateTime.Parse(dateStr, tc);
                
                if (!string.IsNullOrWhiteSpace(time))
                {
                    TimeSpan timeSpan = TimeSpan.Parse(time);
                    resualtDate = resualtDate.AddTicks(timeSpan.Ticks);
                }
                
                return resualtDate;
            }
            catch
            {
                throw new Exception("日期或時間格式有誤");
            }
        }

        /// <summary>
        /// 取得現在民國年月日
        /// </summary>
        /// <returns></returns>
        public static string TaiwanYear()
        {
            DateTime d = DateTime.Now;
            TaiwanCalendar tc = new TaiwanCalendar();

            return tc.GetYear(d).ToString().PadLeft(3, '0') + tc.GetMonth(d).ToString().PadLeft(2, '0') + tc.GetDayOfMonth(d).ToString().PadLeft(2, '0');
        }

        /// <summary>
        /// 取得現在時間
        /// </summary>
        /// <returns></returns>
        public static string NowTime(string format = "HHmmssfff")
        {
            return DateTime.Now.ToString(format);
        }

        /// <summary>
        /// 取得現在時間(可用參數)
        /// </summary>
        /// <param name="paramet"></param>
        /// <returns></returns>
        public static string NowDateTime(string paramet)
        {
            return DateTime.Now.ToString(paramet);
        }

        /// <summary>
        /// 民國轉西日期
        /// </summary>
        /// <param name="dtx"></param>
        /// <returns></returns>
        public static string ToSimpleUSDate(this DateTime dtx)
        {
            return string.Format("{0}{1}{2}", (Int32.Parse(dtx.Year.ToString()) + 1911), dtx.Month, dtx.Day);
        }
    }
}
