using System;

namespace NInvigilator_CS
{
    /// <summary>
    /// کلاس برای ذخیره زمان ها
    /// </summary>
    class Time
    {
        private int hour;
        private int minute;
        private int second;
        public int Hour
        {
            get { return hour; }
            set
            {
                if (value < 24)
                    hour = value;
            }
        }
        public int Minute
        {
            get { return minute; }
            set
            {
                if (value < 60)
                    minute = value;
            }
        }
        public int Second
        {
            get { return second; }
            set
            {
                if (value < 60)
                    hour = value;
            }         
        }
        public Time(int hour, int minute, int second)
        {
            if (hour < 24)
                this.hour = hour;
            if (minute < 60)
                this.minute = minute;
            if (second < 60)
                this.second = second;
        }
        /// <summary>
        /// نمایش زمان
        /// </summary>
        public void Print()
        {
            Console.WriteLine(hour + ":" + minute + ":" + second);
        }
        /// <summary>
        /// دریافت دو زمان و مقایسه ها ان ها بر اساس بزرگتری
        /// </summary>
        /// <param name="f">زمان اول</param>
        /// <param name="s">زمان دوم</param>
        /// <returns>اگر زمان اول از دومی بیشتر بود خروجی درست است در غیر این صورت غلط</returns>
        public static bool operator >(Time f, Time s)
        {
            if (f.hour > s.hour)
                return true;
            else if (f.hour == s.hour)
                if (f.minute > s.minute)
                    return true;
                else if (f.minute == s.minute)
                    if (f.second > s.second)
                        return true;
                    else if (f.second == s.second)
                        return false;
                    else
                        return false;
                else
                    return false;
            else
                return false;
        }
        /// <summary>
        /// دریافت دو زمان و مقایسه ها ان ها بر اساس کوچیکتری
        /// </summary>
        /// <param name="f">زمان اول</param>
        /// <param name="s">زمان دوم</param>
        /// <returns>اگر زمان اول از دومی کمتر بود خروجی درست است در غیر این صورت غلط</returns>
        public static bool operator <(Time f, Time s)
        {
            if (f.hour < s.hour)
                return true;
            else if (f.hour == s.hour)
                if (f.minute < s.minute)
                    return true;
                else if (f.minute == s.minute)
                    if (f.second < s.second)
                        return true;
                    else if (f.second == s.second)
                        return false;
                    else
                        return false;
                else
                    return false;
            else
                return false;
        }
        /// <summary>
        /// دریافت دو زمان و مقایسه ها ان ها بر اساس بزرگتر و مساوی
        /// </summary>
        /// <param name="f">زمان اول</param>
        /// <param name="s">زمان دوم</param>
        /// <returns>اگر زمان اول از دومی بیشتر مساوی بود خروجی درست است در غیر این صورت غلط</returns>
        public static bool operator >=(Time f, Time s)
        {
            if (f.hour > s.hour)
                return true;
            else if (f.hour == s.hour)
                if (f.minute > s.minute)
                    return true;
                else if (f.minute == s.minute)
                    if (f.second >= s.second)
                        return true;
                    else
                        return false;
                else
                    return false;
            else
                return false;
        }
        /// <summary>
        /// دریافت دو زمان و مقایسه ها ان ها بر اساس کوچیکتر و مساوی
        /// </summary>
        /// <param name="f">زمان اول</param>
        /// <param name="s">زمان دوم</param>
        /// <returns>اگر زمان اول از دومی کمتر مساوی بود خروجی درست است در غیر این صورت غلط</returns>
        public static bool operator <=(Time f, Time s)
        {
            if (f.hour < s.hour)
                return true;
            else if (f.hour == s.hour)
                if (f.minute < s.minute)
                    return true;
                else if (f.minute == s.minute)
                    if (f.second <= s.second)
                        return true;
                    else
                        return false;
                else
                    return false;
            else
                return false;
        }
        /// <summary>
        /// جابجایی مقدار دو زمان باهم
        /// </summary>
        /// <param name="f">زمان اول</param>
        /// <param name="s">زمان دوم</param>
        private static void Swap(ref Time f, ref Time s)
        {
            Time temp;
            temp = f;
            f = s;
            s = temp;
        }
        /// <summary>
        /// مرتب سازی بر اساس زمان خاتمه ها
        /// </summary>
        /// <param name="S">زمان شروع حضور مراقب ها</param>
        /// <param name="F">زمان پایانی حضور مراقب ها</param>
        public static void sort(Time[] S, Time[] F)
        {
            for (int i = 0; i < F.Length; i++)
                for (int j = i + 1; j < F.Length; j++)
                    if (F[i] > F[j])
                    {
                        Swap(ref F[i], ref F[j]);
                        Swap(ref S[i], ref S[j]);
                        //Swap(ref t[i], ref t[i]);
                    }
        }

        public static Time operator-(Time s, Time f)
        {
            f.hour = f.hour - s.hour;
            f.minute = f.minute - s.minute;
            f.second = f.second - s.second;
            return f;
        }
    }

    class Program
    {
        /// <summary>
        /// به دست آوردن تعداد مراقب های امتحان
        /// </summary>
        /// <param name="a">زمان شروع امتحان</param>
        /// <param name="b">زمان خاتمه امتحان</param>
        /// <param name="S">زمان شروع حضور مراقب ها</param>
        /// <param name="F">زمان پایانی حضور مراقب ها</param>
        /// <param name="State">مشخص می کند که کدام مراقب می تواند در امتحان امر مراقبت را انجام دهد</param>
        /// <returns>تعداد مراقب هایی که می توانند امر مراقبت را  انجام دهند</returns>
        private static void CountInvigilator(Time a, Time b, Time[] S, Time[] F, ref Time[] s, ref Time[] f, int n)
        {
            //Time[] t = new Time[n];
            //for (int i = 0; i < n; i++)
            //    t[i].diffrens(S[index], F[index]);
            //for (int i = 0; i < n; i++)
            //    for (int j = 0; j < n; j++)
            //        if (t[i] < t[j]) 
            //        {
            //            Time temp = t[i];
            //            t[i] = t[j];
            //            t[j] = temp;
            //        }


            //int count = 0;
            //s = new Time[n];
            //f = new Time[n];


            for (int i = 0; i < n; i++)
            {
                s[i] = new Time(0, 0, 0);
                f[i] = new Time(0, 0, 0);
            }

            int k = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if ((a <= S[i] && S[i] < b) || (a < F[i] && F[i] <= b))
                {
                   
                    s[k] = S[i];
                    f[k++] = F[i];
                    //State[i] = true;
                    //count++;
                }
            } 
            //return count;
        }

        private static int Count(Time a, Time b, Time[] S, Time[] F, bool[] State, int n, int index = -1)
        {
            int m = index + 1;
            if (index >= 0)
                while (m < n && S[m] < F[index])
                    m++;
            if (m < n)
            {
                if (index != -1)
                {
                    State[m] = true;
                    return Count(a, b, S, F, State, n, index + 1) + 1;
                }
                else
                    return Count(a, b, S, F, State, n, index + 1);
            }
            else
                return 0;
        }
        
        //private static int f(Time a, Time b, Time[] S, Time[] F, bool[] State, bool[] s, int n)
        //{
        //    int count = 0;
        //    for (int i = 0; i < n-1; i++) 
        //        if (State[i] && S[i + 1] >= F[i]) 
        //        {
        //            count++;
        //            s[i] = true;
        //        }
        //    return count;
        //}

        static void Main()
        {
            int NumOfInvigilator;
            Console.Write("Please enter the number of invigilator :");
            try { NumOfInvigilator = Convert.ToInt32(Console.ReadLine()); } catch { NumOfInvigilator = 0; }

            bool[] State = new bool[NumOfInvigilator];
            for (int i = 0; i < State.Length; i++)
                State[i] = false;

            Time[] S = new Time[NumOfInvigilator];
            Time[] F = new Time[NumOfInvigilator];

            /// input
            int hour, minute, second;
            Console.Write("Please enter the start hour the exam   :");
            try { hour = Convert.ToInt32(Console.ReadLine()); } catch { hour = 0; }
            Console.Write("Please enter the start minute the exam :");
            try { minute = Convert.ToInt32(Console.ReadLine()); } catch { minute = 0; }
            Console.Write("Please enter the start second the exam :");
            try { second = Convert.ToInt32(Console.ReadLine()); } catch { second = 0; }
            Time a = new Time(hour, minute, second);

            Console.Write("Please enter the end hour the exam   :");
            try { hour = Convert.ToInt32(Console.ReadLine()); } catch { hour = 0; }
            Console.Write("Please enter the end minute the exam :");
            try { minute = Convert.ToInt32(Console.ReadLine()); } catch { minute = 0; }
            Console.Write("Please enter the end second the exam :");
            try { second = Convert.ToInt32(Console.ReadLine()); } catch { second = 0; }
            Time b = new Time(hour, minute, second);

            for (int i = 0; i < NumOfInvigilator; i++)
            {
                Console.WriteLine();
                Console.Write("Please enter from hour invigilator " + (i + 1) + "  : ");
                try { hour = Convert.ToInt32(Console.ReadLine()); } catch { hour = 0; }
                Console.Write("Please enter from minute invigilator " + (i + 1) + ": ");
                try { minute = Convert.ToInt32(Console.ReadLine()); } catch { minute = 0; }
                Console.Write("Please enter from second invigilator " + (i + 1) + ": ");
                try { second = Convert.ToInt32(Console.ReadLine()); } catch { second = 0; }
                S[i] = new Time(hour, minute, second);

                Console.Write("Please enter to hour invigilator " + (i + 1) + "  : ");
                try { hour = Convert.ToInt32(Console.ReadLine()); } catch { hour = 0; }
                Console.Write("Please enter to mintue invigilator " + (i + 1) + ": ");
                try { minute = Convert.ToInt32(Console.ReadLine()); } catch { minute = 0; }
                Console.Write("Please enter to second invigilator " + (i + 1) + ": ");
                try { second = Convert.ToInt32(Console.ReadLine()); } catch { second = 0; }
                F[i] = new Time(hour, minute, second);
            }

            /// output
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\ntime exam Algoritm Design");
            Console.Write("The exam Design Algoritm start from "); a.Print();
            Console.Write("The exam DEsign Algoritm end of     "); b.Print();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
           
            //Time[] t = new Time[NumOfInvigilator];
            //for (int i = 0; i < NumOfInvigilator; i++)
            //    t[i].diffrens(S[i], F[i]);
            Time.sort(S, F);
            //Time[] s = new Time[NumOfInvigilator];
            //Time[] f = new Time[NumOfInvigilator];
            //CountInvigilator(a, b, S, F, ref s, ref f, NumOfInvigilator);


            Console.WriteLine("\nSorted by the ending times!");

            for (int i = 0; i < NumOfInvigilator; i++)
            {
                Console.WriteLine();
                Console.Write("Invigilator " + (i + 1) + " from "); S[i].Print();
                Console.Write("Invigilator " + (i + 1) + " to   "); F[i].Print();
            }

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            //CountInvigilator(a, b, S, F, State, NumOfInvigilator);
            //bool[] s = new bool[NumOfInvigilator];

            Console.WriteLine("The number of examiners who can attend :" + Count(a, b, S, F, State, NumOfInvigilator));
            for (int i = 0; i < NumOfInvigilator; i++)
                if (State[i])
                    Console.WriteLine("The " + (i + 1) + " examiner can be present.");
            Console.ReadKey();
        }
    }
}
