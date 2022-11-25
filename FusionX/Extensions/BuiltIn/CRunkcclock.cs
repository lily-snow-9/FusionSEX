//----------------------------------------------------------------------------------
//
// CRUNKCBUTTON
//
//----------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FusionX.Actions;
using FusionX.Application;
using FusionX.Banks;
using FusionX.Conditions;
using FusionX.Expressions;
using FusionX.Extensions;
using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;
using FusionX.Services;
using FusionX.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RuntimeXNA.Extensions;
using SpriteFontPlus;


namespace RuntimeXNA.Extensions
{
    class CRunkcclock : CRunExtension
    {
	    const int CND_CMPCHRONO = 0;
	    const int CND_NEWSECOND = 1;
	    const int CND_NEWMINUTE = 2;
	    const int CND_NEWHOUR = 3;
	    const int CND_NEWDAY= 4;
	    const int CND_NEWMONTH = 5;
	    const int CND_NEWYEAR = 6;
	    const int CND_CMPCOUNTDOWN = 7;
	    const int CND_VISIBLE = 8;
	    const int ACT_SETCENTIEMES = 0;
	    const int ACT_SETSECONDES = 1;
	    const int ACT_SETMINUTES = 2;
	    const int ACT_SETHOURS = 3;
	    const int ACT_SETDAYOFWEEK = 4;
	    const int ACT_SETDAYOFMONTH = 5;
	    const int ACT_SETMONTH = 6;
	    const int ACT_SETYEAR = 7;
	    const int ACT_RESETCHRONO = 8;
	    const int ACT_STARTCHRONO = 9;
	    const int ACT_STOPCHRONO = 10;
	    const int ACT_SHOW = 11;
	    const int ACT_HIDE = 12;
	    const int ACT_SETPOSITION = 13;
	    const int ACT_SETCOUNTDOWN = 14;
	    const int ACT_STARTCOUNTDOWN = 15;
	    const int ACT_STOPCOUNTDOWN = 16;
	    const int ACT_SETXPOSITION = 17;
	    const int ACT_SETYPOSITION = 18;
	    const int ACT_SETXSIZE = 19;
	    const int ACT_SETYSIZE = 20;
	    const int EXP_GETCENTIEMES = 0;
	    const int EXP_GETSECONDES = 1;
	    const int EXP_GETMINUTES = 2;
	    const int EXP_GETHOURS = 3;
	    const int EXP_GETDAYOFWEEK = 4;
	    const int EXP_GETDAYOFMONTH = 5;
	    const int EXP_GETMONTH = 6;
	    const int EXP_GETYEAR = 7;
	    const int EXP_GETCHRONO = 8;
	    const int EXP_GETCENTERX = 9;
	    const int EXP_GETCENTERY = 10;
	    const int EXP_GETHOURX = 11;
	    const int EXP_GETHOURY = 12;
	    const int EXP_GETMINUTEX = 13;
	    const int EXP_GETMINUTEY = 14;
	    const int EXP_GETSECONDX = 15;
	    const int EXP_GETSECONDY = 16;
	    const int EXP_GETCOUNTDOWN = 17;
	    const int EXP_GETXPOSITION = 18;
	    const int EXP_GETYPOSITION = 19;
	    const int EXP_GETXSIZE = 20;
	    const int EXP_GETYSIZE = 21;

	    const int ANALOG_CLOCK = 0;
	    const int DIGITAL_CLOCK = 1;
	    const int INVISIBLE = 2;
	    const int CALENDAR = 3;
	    const int CLOCK = 0;
	    const int STOPWATCH = 1;
	    const int COUNTDOWN = 2;
	    const int SHORTDATE = 0;
	    const int LONGDATE = 1;
	    const int FIXEDDATE = 2;

	    public uint[] months=
        {
	        0,
	        267840000,
	        509760000,
	        777600000,
	        1123200000,
	        1304640000,
	        1563840000,
	        1831680000,
	        2099520000,
	        2358720000,
	        2626560000,
	        2885760000,
        };
	    public string[] szRoman=
	    {
	        "I",
	        "II",
	        "III",
	        "IV",
	        "V",
	        "VI",
	        "VII",
	        "VIII",
	        "IX",
	        "X",
	        "XI",
	        "XII"
	    };
	    public int ADJ = 3;
	    public int sType;
	    public int sClockMode;
	    public bool sClockBorder;
	    public bool sAnalogClockLines;
	    public int  sAnalogClockMarkerType;
	    public CFontInfo sFont;
	    public int crFont;
	    public bool sAnalogClockSeconds;
	    public int crAnalogClockSeconds;
	    public bool sAnalogClockMinutes;
	    public int crAnalogClockMinutes;
	    public bool sAnalogClockHours;
	    public int crAnalogClockHours;
	    public int sDigitalClockType;
	    public int sCalendarType;
	    public int sCalendarFormat;
	    public int lCountdownStart;
	    public int sMinWidth;
	    public int sMinHeight;
	    public bool sVisible;
	    public DateTime lastRecordedTime;
	    public bool sDisplay;
	    public int sUpdateCounter;
	    public double dChronoCounter;
	    public double dChronoStart;
	    public int lChrono;
	    public int sEventCount;
	    public int sCenterX;
	    public int sCenterY;
	    public int sHourX;
	    public int sHourY;
	    public int sMinuteX;
	    public int sMinuteY;
	    public int sSecondX;
	    public int sSecondY;
	    public DateTime initialTime;
	    public DateTime startTimer;
        Texture2D circle=null;

        public override int getNumberOfConditions()
        {
            return 9;
        }

        public override bool createRunObject(CFile file, CCreateObjectInfo cob, int version)
        {
            ho.setX(cob.cobX);
            ho.setY(cob.cobY);
            ho.hoImgXSpot = 0;
            ho.hoImgYSpot = 0;
            ho.setWidth(file.readAShort());
            ho.setHeight(file.readAShort());
            file.skipBytes(4 * 16);
            this.sType = file.readAShort();
            this.sClockMode = file.readAShort();
            this.sClockBorder = (file.readAShort() == 0) ? false : true;
            this.sAnalogClockLines = (file.readAShort() == 0) ? false : true;
            this.sAnalogClockMarkerType = file.readAShort();
            CFontInfo font = file.readLogFont();
            this.crFont = file.readAColor();
            file.readAString(40);
            this.sAnalogClockSeconds = (file.readAShort() == 0) ? false : true;
            this.crAnalogClockSeconds = file.readAColor();
            this.sAnalogClockMinutes = (file.readAShort() == 0) ? false : true;
            this.crAnalogClockMinutes = file.readAColor();
            this.sAnalogClockHours = (file.readAShort() == 0) ? false : true;
            this.crAnalogClockHours = file.readAColor();
            this.sDigitalClockType = file.readAShort();
            this.sCalendarType = file.readAShort();
            this.sCalendarFormat = file.readAShort();
            file.readAString(40);
            short sCountDownHours = file.readAShort();
            short sCountDownMinutes = file.readAShort();
            short sCountDownSeconds = file.readAShort();
            this.lCountdownStart = (sCountDownHours * 360000) + (sCountDownMinutes * 6000) + (sCountDownSeconds * 100);
            this.sMinWidth = file.readAShort();
            this.sMinHeight = file.readAShort();
            switch (this.sType)
            {
                case ANALOG_CLOCK:
                case CALENDAR:
                case DIGITAL_CLOCK:
                    {
                        this.sFont = font;
                    }
                    break;
                case INVISIBLE:
                    break;
            }
            this.sVisible = true;

            this.initialTime = DateTime.Now;
            this.startTimer = DateTime.Now;
            this.lastRecordedTime = DateTime.Now;
            this.sDisplay = true;
            return true;
        }

	    public DateTime getCurrentTime()
	    {
	        //output = initialTime + (currentTime - startTimer)
            DateTime now = DateTime.Now;
            long ticks=initialTime.Ticks+(now.Ticks-startTimer.Ticks);
	        return new DateTime(ticks);
	    }
	
	    public void changeTime(DateTime date)
	    {
	        this.initialTime=new DateTime(date.Ticks);
	        this.lastRecordedTime=new DateTime(date.Ticks);
	        this.startTimer = DateTime.Now;
	    }

        public override int handleRunObject()
        {
            short ret = 0;
            if (this.sDisplay)
            {
                this.sDisplay = false;
                ret = REFLAG_DISPLAY;
            }
            double dCurrentChronoCounter;

            this.sUpdateCounter = 0;

            DateTime cTime = getCurrentTime();

            // If system time change
            dCurrentChronoCounter = (double)((double)months[cTime.Month -1 ] + ((double)(cTime.Day - 1) * (double)8640000) + ((double)cTime.Hour * (double)360000) + ((double)cTime.Minute* (double)6000) + ((double)cTime.Second * (double)100) + (double)(cTime.Millisecond / 10.0));
            if ((dCurrentChronoCounter < this.dChronoCounter) || ((dCurrentChronoCounter > (this.dChronoCounter + 200)) && (this.dChronoCounter != 0)))
            {
                // Chrono: stop at old time, restart at new time
                if (this.dChronoStart != 0)
                {
                    // Correction de bug quand on iconifie un objet Clock qui est mis en Stop
                    this.lChrono += Math.Abs((int)(this.dChronoCounter - this.dChronoStart));
                    this.dChronoStart = dCurrentChronoCounter;
                }
            }
            this.dChronoCounter = dCurrentChronoCounter;
            switch (this.sType)
            {
                case ANALOG_CLOCK:
                case DIGITAL_CLOCK:
                case INVISIBLE:
                    if (this.lastRecordedTime.Second != cTime.Second)
                    {
                        this.sEventCount = (short)rh.rh4EventCount;
                        ho.pushEvent(CND_NEWSECOND, ho.getEventParam());
                        ret = REFLAG_DISPLAY;
                        if (this.lastRecordedTime.Minute != cTime.Minute)
                        {
                            this.sEventCount = (short)rh.rh4EventCount;
                            ho.pushEvent(CND_NEWMINUTE, ho.getEventParam());
                            if (this.lastRecordedTime.Hour != cTime.Hour)
                            {
                                this.sEventCount = (short)rh.rh4EventCount;
                                ho.pushEvent(CND_NEWHOUR, ho.getEventParam());
                            }
                        }
                    }
                    break;
                case CALENDAR:
                    if (this.lastRecordedTime.Hour != cTime.Hour)
                    {
                        if (this.lastRecordedTime.Day != cTime.Day)
                        {
                            this.sEventCount = (short)rh.rh4EventCount;
                            ho.pushEvent(CND_NEWDAY, ho.getEventParam());
                            ret = REFLAG_DISPLAY;
                            if (this.lastRecordedTime.Month != cTime.Month)
                            {
                                this.sEventCount = (short)rh.rh4EventCount;
                                ho.pushEvent(CND_NEWMONTH, ho.getEventParam());
                                if (this.lastRecordedTime.Year != cTime.Year)
                                {
                                    this.sEventCount = (short)rh.rh4EventCount;
                                    ho.pushEvent(CND_NEWYEAR, ho.getEventParam());
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            this.lastRecordedTime=new DateTime(cTime.Ticks);
            return ret;
        }

        public override void displayRunObject(SpriteBatchEffect batch)
        {
            CRun rhPtr = ho.hoAdRunHeader;
            CRect rc = new CRect();
            if (this.sVisible)
            {
                rc.left = this.ho.hoX - rhPtr.rhWindowX;
                rc.right = rc.left + this.ho.hoImgWidth;
                rc.top = this.ho.hoY - rhPtr.rhWindowY;
                rc.bottom = rc.top + this.ho.hoImgHeight;
                int ampm = this.lastRecordedTime.Hour>=12?1:0;
                short hour = (short)this.lastRecordedTime.Hour;
                short hsecond = (short)(this.lastRecordedTime.Millisecond / 10);
                short minute = (short)this.lastRecordedTime.Minute;
                short second = (short)this.lastRecordedTime.Second;
                short day = (short)this.lastRecordedTime.Day;
                short year = (short)this.lastRecordedTime.Year;
                short month = (short)this.lastRecordedTime.Month;
                short dayofweek = (short)this.lastRecordedTime.DayOfWeek;
                switch (this.sType)
                {
                    case ANALOG_CLOCK: // Analogue clock
                        if (CLOCK == this.sClockMode)
                        {
                            if (hour > 11)
                            {
                                hour -= 12;
                            }
                            if (this.sAnalogClockMarkerType != 2)
                            {
                                CRect rcNewRect = new CRect();
                                rcNewRect.left = rc.left + (this.sMinWidth / 2);
                                rcNewRect.right = rc.right - (this.sMinWidth / 2);
                                rcNewRect.top = rc.top + (this.sMinHeight / 2);
                                rcNewRect.bottom = rc.bottom - (this.sMinHeight / 2);
                                RunDisplayAnalogTime(batch, hour, minute, second, rcNewRect);
                            }
                            else
                            {
                                RunDisplayAnalogTime(batch, hour, minute, second, rc);
                            }
                        }
                        else
                        {
                            int lCurrentChrono;
                            int usHour, usMinute, usSecond;

                            // 	Get current chrono
                            if (this.dChronoStart != 0)
                            {
                                double dChronoStop = this.months[month - 1] + ((day-1) * 8640000) + (hour * 360000) + (minute * 6000) + (second * 100) + hsecond;
                                lCurrentChrono = this.lChrono + (int)(dChronoStop - this.dChronoStart);
                            }
                            else
                            {
                                lCurrentChrono = this.lChrono;
                            }

                            // Countdown
                            if (COUNTDOWN == this.sClockMode)
                            {
                                lCurrentChrono = this.lCountdownStart - lCurrentChrono;
                                if (lCurrentChrono < 0)
                                {
                                    lCurrentChrono = 0;
                                }
                            }

                            // Compute hours, minutes & seconds
                            usHour = (int)(lCurrentChrono / 360000L);
                            if (usHour > 11)
                            {
                                usHour -= 12;
                            }
                            usMinute = (int)((lCurrentChrono - ((int)usHour * 360000L)) / 6000L);
                            usSecond = (int)((lCurrentChrono - ((int)usHour * 360000L) - ((int)usMinute * 6000L)) / 100L);

                            // Display
                            if (this.sAnalogClockMarkerType != 2)
                            {
                                CRect rcNewRect = new CRect();
                                rcNewRect.left = rc.left + (this.sMinWidth / 2);
                                rcNewRect.right = rc.right - (this.sMinWidth / 2);
                                rcNewRect.top = rc.top + (this.sMinHeight / 2);
                                rcNewRect.bottom = rc.bottom - (this.sMinHeight / 2);
                                RunDisplayAnalogTime(batch, usHour, usMinute, usSecond, rcNewRect);
                            }
                            else
                            {
                                RunDisplayAnalogTime(batch, usHour, usMinute, usSecond, rc);
                            }
                        }
                        break;

                    case DIGITAL_CLOCK: // Digital clock
                        {
                            String szTime;

                            switch (this.sDigitalClockType)
                            {
                                case 0:
                                    if (CLOCK == this.sClockMode)
                                    {
                                        if (hour > 11)
                                        {
                                            hour -= 12;
                                        }
                                        szTime = hour.ToString();
                                        szTime = "0".Substring(0, 2-szTime.Length ) + szTime;
                                        String tempMin = minute.ToString();
                                        tempMin = "0".Substring(0, 2-tempMin.Length ) + tempMin;
                                        szTime += ":" + tempMin;
                                        RunDisplayDigitalTime(batch, szTime, rc);
                                    }
                                    else
                                    {
                                        int lCurrentChrono;
                                        int usHour, usMinute;
                                        // Get current chrono
                                        if (this.dChronoStart != 0)
                                        {
                                            double dChronoStop = this.months[month - 1] + ((day-1) * 8640000) + (hour * 360000) + (minute * 6000) + (second * 100) + hsecond;
                                            lCurrentChrono = this.lChrono + (int)(dChronoStop - this.dChronoStart);
                                        }
                                        else
                                        {
                                            lCurrentChrono = this.lChrono;
                                        }
                                        // Countdown
                                        if (COUNTDOWN == this.sClockMode)
                                        {
                                            lCurrentChrono = this.lCountdownStart - lCurrentChrono;
                                            if (lCurrentChrono < 0)
                                            {
                                                lCurrentChrono = 0;
                                            }
                                        }
                                        // Compute hours, minutes & seconds
                                        usHour = (int)(lCurrentChrono / 360000L);
                                        if (usHour > 11)
                                        {
                                            usHour -= 12;
                                        }
                                        usMinute = (int)((lCurrentChrono - ((int)usHour * 360000L)) / 6000L);
                                        szTime = usHour.ToString();
                                        szTime = "0".Substring(0, 2-szTime.Length ) + szTime;
                                        String tempMin = usMinute.ToString();
                                        tempMin = "0".Substring(2-tempMin.Length ) + tempMin;
                                        szTime += ":" + tempMin;
                                        RunDisplayDigitalTime(batch, szTime, rc);
                                    }
                                    break;

                                case 1:
                                    if (CLOCK == this.sClockMode)
                                    {
                                        if (hour > 11)
                                        {
                                            hour -= 12;
                                        }
                                        szTime = hour.ToString();
                                        szTime = "0".Substring(0, 2-szTime.Length ) + szTime;
                                        String tempMin = minute.ToString();
                                        tempMin = "0".Substring(2-tempMin.Length ) + tempMin;
                                        String tempSec = second.ToString();
                                        tempSec = "0".Substring(0, 2-tempSec.Length ) + tempSec;
                                        szTime += ":" + tempMin + ":" + tempSec;
                                        RunDisplayDigitalTime(batch, szTime, rc);
                                    }
                                    else
                                    {
                                        int lCurrentChrono;
                                        int usHour, usMinute, usSecond;
                                        // Get current chrono
                                        if (this.dChronoStart != 0)
                                        {
                                            double dChronoStop = this.months[month - 1] + ((day-1) * 8640000) + (hour * 360000) + (minute * 6000) + (second * 100) + hsecond;
                                            lCurrentChrono = this.lChrono + (int)(dChronoStop - this.dChronoStart);
                                        }
                                        else
                                        {
                                            lCurrentChrono = this.lChrono;
                                        }
                                        // Countdown
                                        if (COUNTDOWN == this.sClockMode)
                                        {
                                            lCurrentChrono = this.lCountdownStart - lCurrentChrono;
                                            if (lCurrentChrono < 0)
                                            {
                                                lCurrentChrono = 0;
                                            }
                                        }
                                        // Compute hours, minutes & seconds
                                        usHour = (int)(lCurrentChrono / 360000L);
                                        if (usHour > 11)
                                        {
                                            usHour -= 12;
                                        }
                                        usMinute = (int)((lCurrentChrono - ((int)usHour * 360000L)) / 6000L);
                                        usSecond = (int)((lCurrentChrono - ((int)usHour * 360000L) - ((int)usMinute * 6000L)) / 100L);

                                        // Display
                                        if (usHour > 11)
                                        {
                                            usHour -= 12;
                                        }

                                        szTime = usHour.ToString();
                                        szTime = "0".Substring(0, 2-szTime.Length) + szTime;
                                        String tempMin = usMinute.ToString();
                                        tempMin = "0".Substring(0, 2-tempMin.Length) + tempMin;
                                        String tempSec = usSecond.ToString();
                                        tempSec = "0".Substring(0, 2-tempSec.Length) + tempSec;
                                        szTime += ":" + tempMin + ":" + tempSec;

//                                        szTime = lCurrentChrono.ToString();
                                        RunDisplayDigitalTime(batch, szTime, rc);
                                    }
                                    break;

                                case 2:
                                    if (CLOCK == this.sClockMode)
                                    {
                                        if (ampm != 0 && hour < 12)
                                        {
                                            hour += 12;
                                        }
                                        // Display
                                        szTime = hour.ToString();
                                        szTime = "0".Substring(0, 2-szTime.Length) + szTime;
                                        String tempMin = minute.ToString();
                                        tempMin = "0".Substring(0, 2-tempMin.Length) + tempMin;
                                        szTime += ":" + tempMin;
                                        RunDisplayDigitalTime(batch, szTime, rc);
                                    }
                                    else
                                    {
                                        int lCurrentChrono;
                                        int usHour, usMinute;

                                        // Get current chrono
                                        if (this.dChronoStart != 0)
                                        {
                                            double dChronoStop = this.months[month - 1] + ((day-1) * 8640000) + (hour * 360000) + (minute * 6000) + (second * 100) + hsecond;
                                            lCurrentChrono = this.lChrono + (int)(dChronoStop - this.dChronoStart);
                                        }
                                        else
                                        {
                                            lCurrentChrono = this.lChrono;
                                        }

                                        // Countdown
                                        if (COUNTDOWN == this.sClockMode)
                                        {
                                            lCurrentChrono = this.lCountdownStart - lCurrentChrono;
                                            if (lCurrentChrono < 0)
                                            {
                                                lCurrentChrono = 0;
                                            }
                                        }

                                        // Compute hours, minutes & seconds
                                        usHour = (int)(lCurrentChrono / 360000L);
                                        usMinute = (int)((lCurrentChrono - ((int)usHour * 360000L)) / 6000L);

                                        // Display
                                        szTime = usHour.ToString();
                                        szTime = "0".Substring(0, 2-szTime.Length ) + szTime;
                                        String tempMin = usMinute.ToString();
                                        tempMin = "0".Substring(0, 2-tempMin.Length ) + tempMin;
                                        szTime += ":" + tempMin;
                                        RunDisplayDigitalTime(batch, szTime, rc);
                                    }
                                    break;

                                case 3:
                                    if (CLOCK == this.sClockMode)
                                    {
                                        if (ampm != 0 && hour < 12)
                                        {
                                            hour += 12;
                                        }
                                        // Display
                                        szTime = hour.ToString();
                                        szTime = "0".Substring(0, 2-szTime.Length ) + szTime;
                                        String tempMin = minute.ToString();
                                        tempMin = "0".Substring(0, 2-tempMin.Length ) + tempMin;
                                        String tempSec = second.ToString();
                                        tempSec = "0".Substring(0, 2-tempSec.Length ) + tempSec;
                                        szTime += ":" + tempMin + ":" + tempSec;
                                        RunDisplayDigitalTime(batch, szTime, rc);
                                    }
                                    else
                                    {
                                        int lCurrentChrono;
                                        int usHour, usMinute, usSecond;
                                        // Get current chrono
                                        if (this.dChronoStart != 0)
                                        {
                                            double dChronoStop = this.months[month - 1] + ((day-1) * 8640000) + (hour * 360000) + (minute * 6000) + (second * 100) + hsecond;
                                            lCurrentChrono = this.lChrono + (int)(dChronoStop - this.dChronoStart);
                                        }
                                        else
                                        {
                                            lCurrentChrono = this.lChrono;
                                        }

                                        // Countdown
                                        if (COUNTDOWN == this.sClockMode)
                                        {
                                            lCurrentChrono = this.lCountdownStart - lCurrentChrono;
                                            if (lCurrentChrono < 0)
                                            {
                                                lCurrentChrono = 0;
                                            }
                                        }

                                        // Compute hours, minutes & seconds
                                        usHour = (int)(lCurrentChrono / 360000L);
                                        usMinute = (int)((lCurrentChrono - ((int)usHour * 360000L)) / 6000L);
                                        usSecond = (int)((lCurrentChrono - ((int)usHour * 360000L) - ((int)usMinute * 6000L)) / 100L);

                                        // Display
                                        szTime = usHour.ToString();
                                        szTime = "0".Substring(0, 2-szTime.Length ) + szTime;
                                        String tempMin = usMinute.ToString();
                                        tempMin = "0".Substring(0, 2-tempMin.Length ) + tempMin;
                                        String tempSec = usSecond.ToString();
                                        tempSec = "0".Substring(0, 2-tempSec.Length ) + tempSec;
                                        szTime += ":" + tempMin + ":" + tempSec;
                                        RunDisplayDigitalTime(batch, szTime, rc);
                                    }
                                    break;

                                default:
                                    break;
                            }
                            break;
                        }

                    case CALENDAR: // Calendar
                        String szDate;
                        switch (this.sCalendarType)
                        {
                            case SHORTDATE:
                                szDate = lastRecordedTime.ToShortDateString();
                                RunDisplayCalendar(batch, szDate, rc);
                                break;

                            case LONGDATE:
                                szDate = lastRecordedTime.ToLongDateString();
                                RunDisplayCalendar(batch, szDate, rc);
                                break;

                            case FIXEDDATE:
                                szDate = lastRecordedTime.ToShortDateString();
                                RunDisplayCalendar(batch, szDate, rc);
                                break;

                            default:
                                break;
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        void RunDisplayAnalogTime(SpriteBatchEffect batch, int sHour, int sMinutes, int sSeconds, CRect rc)
        {
            CPoint[] pntPoints =
            {
                new CPoint(), new CPoint(), new CPoint()
            };
            int sRayon;
            // Set center
            pntPoints[0].y = rc.top + ((rc.bottom - rc.top) / 2);
            pntPoints[0].x = rc.left + ((rc.right - rc.left) / 2);
            this.sCenterY = (short) pntPoints[0].x;
            this.sCenterX = (short) pntPoints[0].y;

            // Set radius
            if ((rc.right - rc.left) > (rc.bottom - rc.top))
            {
                sRayon = ((rc.bottom - rc.top) / 2);
            }
            else
            {
                sRayon = ((rc.right - rc.left) / 2);
            }
            sRayon--;

            // Draw border if needed
            if (true == this.sClockBorder)
            {
                CRunApp app=ho.hoAdRunHeader.rhApp;
                if (circle==null)
                {
                    circle=CServices.createEllipse(app, sRayon*2, sRayon*2, 2, crFont);
                }
                app.tempRect.X = pntPoints[0].x-sRayon;
                app.tempRect.Y = pntPoints[0].y-sRayon;
                app.tempRect.Width = circle.Width;
                app.tempRect.Height = circle.Height;
                batch.Draw(circle, app.tempRect, null, Color.White, 0, 0);
            }

            // Display hours
            if (true == this.sAnalogClockHours)
            {
                pntPoints[1].x = pntPoints[0].x + (int) (Math.Cos((((float) sHour + (float) sMinutes / 60.0) * 0.523) - 1.570) * (sRayon / 1.5));
                pntPoints[1].y = pntPoints[0].y + (int) (Math.Sin((((float) sHour + (float) sMinutes / 60.0) * 0.523) - 1.570) * (sRayon / 1.5));
                this.sHourX = (short) pntPoints[1].x;
                this.sHourY = (short) pntPoints[1].y;
                ho.hoAdRunHeader.rhApp.services.drawLine(batch, pntPoints[0].x, pntPoints[0].y, pntPoints[1].x, pntPoints[1].y, crAnalogClockHours, 2, 0, 0);
            }
            // Display minutes
            if (true == this.sAnalogClockMinutes)
            {
                pntPoints[1].x = pntPoints[0].x + (int) (Math.Cos((sMinutes * 0.104) - 1.570) * sRayon);
                pntPoints[1].y = pntPoints[0].y + (int) (Math.Sin((sMinutes * 0.104) - 1.570) * sRayon);
                this.sMinuteX = (short) pntPoints[1].x;
                this.sMinuteY = (short) pntPoints[1].y;
                ho.hoAdRunHeader.rhApp.services.drawLine(batch, pntPoints[0].x, pntPoints[0].y, pntPoints[1].x, pntPoints[1].y, crAnalogClockMinutes, 2, 0, 0);
            }
            // Display seconds
            if (true == this.sAnalogClockSeconds)
            {
                pntPoints[1].x = pntPoints[0].x + (int) (Math.Cos((sSeconds * 0.104) - 1.570) * sRayon);
                pntPoints[1].y = pntPoints[0].y + (int) (Math.Sin((sSeconds * 0.104) - 1.570) * sRayon);
                this.sSecondX = (short) pntPoints[1].x;
                this.sSecondY = (short) pntPoints[1].y;
                ho.hoAdRunHeader.rhApp.services.drawLine(batch, pntPoints[0].x, pntPoints[0].y, pntPoints[1].x, pntPoints[1].y, crAnalogClockSeconds, 1, 0, 0);
            }

            // Draw lines
            if (true == this.sAnalogClockLines)
            {
                //WinPen(rhPtr->rhIdEditWin, rdPtr->crFont, PS_SOLID, 2);	
                for (int a = 1; a < 13; a++)
                {
                    pntPoints[1].x = pntPoints[0].x + (int) (Math.Cos((a * 0.523) - 1.570) * (sRayon * 0.9));
                    pntPoints[1].y = pntPoints[0].y + (int) (Math.Sin((a * 0.523) - 1.570) * (sRayon * 0.9));
                    pntPoints[2].x = pntPoints[0].x + (int) (Math.Cos((a * 0.523) - 1.570) * sRayon);
                    pntPoints[2].y = pntPoints[0].y + (int) (Math.Sin((a * 0.523) - 1.570) * sRayon);
                    ho.hoAdRunHeader.rhApp.services.drawLine(batch, pntPoints[1].x, pntPoints[1].y, pntPoints[2].x, pntPoints[2].y, crFont, 2, 0, 0);
                }
            }

            // Draw markers
            if (this.sAnalogClockMarkerType != 2)
            {
                CFont cFont=CFont.createFromFontInfo(sFont, ho.hoAdRunHeader.rhApp);
                DynamicSpriteFont spriteFont = cFont.getFont();

                String szString;
                int textWidth;
                int textHeight;
                CRect rcFont = new CRect();

                // Display
                Color c=CServices.getColor(crFont);
                for (int a = 1; a < 13; a++)
                {
                    int x, y;
                    if (0 == this.sAnalogClockMarkerType)
                    {
                        szString = a.ToString();
                    }
                    else
                    {
                        szString = szRoman[a - 1];
                    }
                    Vector2 v = spriteFont.MeasureString(szString);
                    textWidth = (int)v.X;
                    textHeight = (int)v.Y;

                    x = pntPoints[0].x + (int) (Math.Cos((a * 0.523) - 1.570) * sRayon);
                    y = pntPoints[0].y + (int) (Math.Sin((a * 0.523) - 1.570) * sRayon);
                    switch (a)
                    {
                        case 1:
                        case 2:
                            rcFont.left = x;
                            rcFont.bottom = y;
                            rcFont.right = rcFont.left + textWidth;
                            rcFont.top = rcFont.bottom - textHeight;
                            break;

                        case 3:
                            rcFont.left = x + 2;
                            rcFont.top = y - (textHeight / 2);
                            rcFont.right = rcFont.left + textWidth;
                            rcFont.bottom = rcFont.top + textHeight;
                            break;

                        case 4:
                        case 5:
                            rcFont.left = x;
                            rcFont.top = y;
                            rcFont.right = rcFont.left + textWidth;
                            rcFont.bottom = rcFont.top + textHeight;
                            break;

                        case 6:
                            rcFont.left = x - (textWidth / 2);
                            rcFont.top = y + 1;
                            rcFont.right = rcFont.left + textWidth;
                            rcFont.bottom = rcFont.top + textHeight;
                            break;

                        case 7:
                        case 8:
                            rcFont.right = x;
                            rcFont.top = y;
                            rcFont.left = rcFont.right - textWidth;
                            rcFont.bottom = rcFont.top + textHeight;
                            break;

                        case 9:
                            rcFont.right = x - 2;
                            rcFont.top = y - (textHeight / 2);
                            rcFont.left = rcFont.right - textWidth;
                            rcFont.bottom = rcFont.top + textHeight;
                            break;

                        case 10:
                        case 11:
                            rcFont.right = x;
                            rcFont.bottom = y;
                            rcFont.left = rcFont.right - textWidth;
                            rcFont.top = rcFont.bottom - textHeight;
                            break;

                        case 12:
                            rcFont.left = x - (textWidth / 2);
                            rcFont.bottom = y - 1;
                            rcFont.right = rcFont.left + textWidth;
                            rcFont.top = rcFont.bottom - textHeight;
                            break;
                    }
                    v.X = rcFont.left + (rcFont.right - rcFont.left) / 2 - textWidth / 2;
                    v.Y = rcFont.top + (rcFont.bottom - rcFont.top) / 2 + textHeight / 2 - textHeight+2;
                    batch.DrawString(spriteFont, szString, v, c);
                }
            }

        }

        private void RunDisplayDigitalTime(SpriteBatchEffect batch, String szTime, CRect rc)
        {
            CFont cFont = CFont.createFromFontInfo(sFont, ho.hoAdRunHeader.rhApp);
            DynamicSpriteFont spriteFont = cFont.getFont();

            // Display text
            Vector2 v = spriteFont.MeasureString(szTime);
            v.X = rc.left + (rc.right - rc.left) / 2 - v.X / 2;
            v.Y = rc.top + (rc.bottom - rc.top) / 2 + v.Y / 2 - ADJ;
            Color c = CServices.getColor(crFont);
            batch.DrawString(spriteFont, szTime, v, c);

            if (true == this.sClockBorder)
            {
                ho.hoAdRunHeader.rhApp.services.drawRect(batch, rc.left + 1, rc.top + 1, rc.right - rc.left, rc.bottom - rc.top, crFont, 0, 0);
            }
        }

        private void RunDisplayCalendar(SpriteBatchEffect batch, String szDate, CRect rc)
        {
            CFont cFont = CFont.createFromFontInfo(sFont, ho.hoAdRunHeader.rhApp);
            DynamicSpriteFont spriteFont = cFont.getFont();

            Vector2 v = spriteFont.MeasureString(szDate);
            v.X = rc.left + (rc.right - rc.left) / 2 - v.X / 2;
            v.Y = rc.top + (rc.bottom - rc.top) / 2 + v.Y / 2 -v.Y ;
            Color c = CServices.getColor(crFont);
            batch.DrawString(spriteFont, szDate, v, c);
        }


        public override bool condition(int num, CCndExtension cnd)
        {
            switch (num)
            {
                case CND_CMPCHRONO:
                    return CmpChrono(cnd);
                case CND_NEWSECOND:
                    return NewSecond();
                case CND_NEWMINUTE:
                    return NewSecond();
                case CND_NEWHOUR:
                    return NewSecond();
                case CND_NEWDAY:
                    return NewSecond();
                case CND_NEWMONTH:
                    return NewSecond();
                case CND_NEWYEAR:
                    return NewSecond();
                case CND_CMPCOUNTDOWN:
                    return CmpCountdown(cnd);
                case CND_VISIBLE:
                    return IsVisible();
            }
            return false;//won't happen
        }

        bool CmpChrono(CCndExtension cnd)
        {
            if (this.dChronoStart != 0)
            {
                DateTime c = DateTime.Now;
                double dChronoStop = months[c.Month-1] +
                        ((c.Day - 1) * 8640000) + (c.Hour * 360000) +
                        (c.Minute * 6000) + (c.Second * 100) + (c.Millisecond / 10);
                return cnd.compareTime(rh, 0, ((lChrono + (int)(dChronoStop - dChronoStart)) * 10));
            }
            else
            {
                return cnd.compareTime(rh, 0, lChrono * 10);
            }
        }

        bool NewSecond()
        {
            if ((this.ho.hoFlags & CObject.HOF_TRUEEVENT) != 0)
            {
                return true;
            }
            if (this.rh.rh4EventCount == this.sEventCount)
            {
                return true;
            }
            return false;
        }

        bool CmpCountdown(CCndExtension cnd)
        {
            int lCurrentChrono;
            if (this.dChronoStart != 0)
            {
                DateTime c = DateTime.Now;
                double dChronoStop = months[c.Month-1] +
                        ((c.Day - 1) * 8640000) + (c.Hour * 360000) +
                        (c.Minute * 6000) + (c.Second * 100) + (c.Millisecond / 10);
                lCurrentChrono = this.lCountdownStart - (this.lChrono + (int)(dChronoStop - this.dChronoStart));
            }
            else
            {
                lCurrentChrono = this.lCountdownStart - this.lChrono;
            }
            if (lCurrentChrono < 0)
            {
                lCurrentChrono = 0;
            }
            return cnd.compareTime(rh, 0, lCurrentChrono * 10);
        }

        bool IsVisible()
        {
            return this.sVisible;
        }


        public override void action(int num, CActExtension act)
        {
            switch (num)
            {
                case ACT_SETCENTIEMES:
                    SetCentiemes(act.getParamExpression(rh, 0));
                    break;
                case ACT_SETSECONDES:
                    SetSeconds(act.getParamExpression(rh, 0));
                    break;
                case ACT_SETMINUTES:
                    SetMinutes(act.getParamExpression(rh, 0));
                    break;
                case ACT_SETHOURS:
                    SetHours(act.getParamExpression(rh, 0));
                    break;
                case ACT_SETDAYOFWEEK:
                    SetDayOfWeek(act.getParamExpression(rh, 0));
                    break;
                case ACT_SETDAYOFMONTH:
                    SetDayOfMonth(act.getParamExpression(rh, 0));
                    break;
                case ACT_SETMONTH:
                    SetMonth(act.getParamExpression(rh, 0));
                    break;
                case ACT_SETYEAR:
                    SetYear(act.getParamExpression(rh, 0));
                    break;
                case ACT_RESETCHRONO:
                    ResetChrono();
                    break;
                case ACT_STARTCHRONO:
                    StartChrono();
                    break;
                case ACT_STOPCHRONO:
                    StopChrono();
                    break;
                case ACT_SHOW:
                    Show();
                    break;
                case ACT_HIDE:
                    Hide();
                    break;
                case ACT_SETPOSITION:
                    SetPosition(act.getParamPosition(rh, 0));
                    break;
                case ACT_SETCOUNTDOWN:
                    SetCountdown(act.getParamTime(rh, 0));
                    break;
                case ACT_STARTCOUNTDOWN:
                    StartCountdown();
                    break;
                case ACT_STOPCOUNTDOWN:
                    StopCountdown();
                    break;
                case ACT_SETXPOSITION:
                    SetXPosition(act.getParamExpression(rh, 0));
                    break;
                case ACT_SETYPOSITION:
                    SetYPosition(act.getParamExpression(rh, 0));
                    break;
                case ACT_SETXSIZE:
                    SetXSize(act.getParamExpression(rh, 0));
                    break;
                case ACT_SETYSIZE:
                    SetYSize(act.getParamExpression(rh, 0));
                    break;
            }
        }

        private void SetCentiemes(int hundredths)
        {
            if ((hundredths >= 0) && (hundredths < 100))
            {
                DateTime c = DateTime.Now;
                DateTime cc=new DateTime(c.Year, c.Month, c.Day, c.Hour, c.Minute, c.Second, hundredths * 10);
                changeTime(cc);
                ho.redraw();
            }
        }

        private void SetSeconds(int secs)
        {
            if ((secs >= 0) && (secs < 60))
            {
                DateTime c = DateTime.Now;
                DateTime cc = new DateTime(c.Year, c.Month, c.Day, c.Hour, c.Minute, secs, c.Millisecond);
                changeTime(cc);
                ho.redraw();
            }
        }

        private void SetMinutes(int mins)
        {
            if ((mins >= 0) && (mins < 60))
            {
                DateTime c = DateTime.Now;
                DateTime cc = new DateTime(c.Year, c.Month, c.Day, c.Hour, mins, c.Second, c.Millisecond);
                changeTime(cc);
                ho.redraw();
            }
        }

        private void SetHours(int hours)
        {
            if ((hours >= 0) && (hours < 24))
            {
                DateTime c = DateTime.Now;
                DateTime cc = new DateTime(c.Year, c.Month, c.Day, hours, c.Minute, c.Second, c.Millisecond);
                changeTime(cc);
                ho.redraw();
            }
        }

        private void SetDayOfWeek(int day)
        {
            if ((day >= 0) && (day < 7))
            {
//                DateTime c = DateTime.Now;
//                DateTime cc = new DateTime(c.Year, c.Month, day, c.Hour, c.Minute, c.Second, c.Millisecond);
//                changeTime(cc);
//                ho.redraw();
            }
        }

        private void SetDayOfMonth(int day)
        {
            if ((day >= 1) && (day < 32)) //1 based from c++
            {
                DateTime c = DateTime.Now;
                DateTime cc = new DateTime(c.Year, c.Month, day, c.Hour, c.Minute, c.Second, c.Millisecond);
                changeTime(cc);
                ho.redraw();
            }
        }

        private void SetMonth(int month)
        {
            if ((month >= 1) && (month < 13)) //1 based from c++
            {
                DateTime c = DateTime.Now;
                DateTime cc = new DateTime(c.Year, month, c.Day, c.Hour, c.Minute, c.Second, c.Millisecond);
                changeTime(cc);
                ho.redraw();
            }
        }

        private void SetYear(int year)
        {
            if ((year > 1979) && (year < 2100)) //y2.1k
            {
                DateTime c = DateTime.Now;
                DateTime cc = new DateTime(year, c.Month, c.Day, c.Hour, c.Minute, c.Second, c.Millisecond);
                changeTime(cc);
                ho.redraw();
            }
        }

        private void ResetChrono()
        {
            dChronoStart = 0;
            lChrono = 0;
            ho.redraw();
        }

        private void StartChrono()
        {
            if (dChronoStart == 0)
            {
                DateTime c = DateTime.Now;
                dChronoStart = months[c.Month-1] +
                        ((c.Day - 1) * 8640000) + (c.Hour * 360000) +
                        (c.Minute * 6000) + (c.Second * 100) + (c.Millisecond / 10);
            }
        }

        private void StopChrono()
        {
            if (dChronoStart != 0)
            {
                DateTime c = DateTime.Now;
                double dChronoStop = months[c.Month-1] +
                        ((c.Day - 1) * 8640000) + (c.Hour * 360000) +
                        (c.Minute * 6000) + (c.Second * 100) + (c.Millisecond / 10);
                lChrono += (int)(dChronoStop - dChronoStart);
                dChronoStart = 0;
            }
        }

        private void Show()
        {
            if (!sVisible)
            {
                sVisible = true;
                ho.redraw();
            }
        }

        private void Hide()
        {
            if (sVisible)
            {
                sVisible = false;
                ho.redraw();
            }
        }

        private void SetPosition(CPositionInfo pos)
        {
            ho.setPosition(pos.x, pos.y);
            ho.redraw();
        }

        private void SetCountdown(int time)
        {
            lCountdownStart = time / 10;
            dChronoStart = 0;
            lChrono = 0;
            ho.redraw();
        }

        private void StartCountdown()
        {
            if (dChronoStart == 0)
            {
                DateTime c = DateTime.Now;
                dChronoStart = months[c.Month-1] +
                        ((c.Day - 1) * 8640000) + (c.Hour * 360000) +
                        (c.Minute * 6000) + (c.Second * 100) + (c.Millisecond / 10);
            }
        }

        private void StopCountdown()
        {
            if (dChronoStart != 0)
            {
                DateTime c = DateTime.Now;
                double dChronoStop = months[c.Month-1] +
                        ((c.Day - 1) * 8640000) + (c.Hour * 360000) +
                        (c.Minute * 6000) + (c.Second * 100) + (c.Millisecond / 10);
                lChrono += (int)(dChronoStop - dChronoStart);
                dChronoStart = 0;
            }
        }

        private void SetXPosition(int x)
        {
            ho.setX(x);
            ho.redraw();
        }

        private void SetYPosition(int y)
        {
            ho.setY(y);
            ho.redraw();
        }

        private void SetXSize(int w)
        {
            ho.setWidth(w);
            circle = null;
            ho.redraw();
        }

        private void SetYSize(int h)
        {
            ho.setHeight(h);
            circle = null;
            ho.redraw();
        }


        public override CValue expression(int num)
        {
            switch (num)
            {
                case EXP_GETCENTIEMES:
                    return GetCentiemes();
                case EXP_GETSECONDES:
                    return GetSeconds();
                case EXP_GETMINUTES:
                    return GetMinutes();
                case EXP_GETHOURS:
                    return GetHours();
                case EXP_GETDAYOFWEEK:
                    return GetDayOfWeek();
                case EXP_GETDAYOFMONTH:
                    return GetDayOfMonth();
                case EXP_GETMONTH:
                    return GetMonth();
                case EXP_GETYEAR:
                    return GetYear();
                case EXP_GETCHRONO:
                    return GetChrono();
                case EXP_GETCENTERX:
                    return GetCentreX();
                case EXP_GETCENTERY:
                    return GetCentreY();
                case EXP_GETHOURX:
                    return GetHourX();
                case EXP_GETHOURY:
                    return GetHourY();
                case EXP_GETMINUTEX:
                    return GetMinuteX();
                case EXP_GETMINUTEY:
                    return GetMinuteY();
                case EXP_GETSECONDX:
                    return GetSecondX();
                case EXP_GETSECONDY:
                    return GetSecondY();
                case EXP_GETCOUNTDOWN:
                    return GetCountdown();
                case EXP_GETXPOSITION:
                    return GetXPosition();
                case EXP_GETYPOSITION:
                    return GetYPosition();
                case EXP_GETXSIZE:
                    return GetXSize();
                case EXP_GETYSIZE:
                    return GetYSize();
            }
            return new CValue(0);//won't happen
        }

        private CValue GetCentiemes()
        {
            return new CValue(getCurrentTime().Millisecond / 10);
        }

        private CValue GetSeconds()
        {
            return new CValue(getCurrentTime().Second);
        }

        private CValue GetMinutes()
        {
            return new CValue(getCurrentTime().Minute);
        }

        private CValue GetHours()
        {
            int hour = getCurrentTime().Hour;
            return new CValue(hour);
        }

        private CValue GetDayOfWeek()
        {
            return new CValue((int)getCurrentTime().DayOfWeek);
        }

        private CValue GetDayOfMonth()
        {
            return new CValue(getCurrentTime().Day);
        }

        private CValue GetMonth()
        {
            return new CValue(getCurrentTime().Month);
        }

        private CValue GetYear()
        {
            return new CValue(getCurrentTime().Year);
        }

        private CValue GetChrono()
        {
            if (dChronoStart != 0)
            {
                DateTime c = DateTime.Now;
                double dChronoStop = months[c.Month-1] +
                        ((c.Day - 1) * 8640000) + (c.Hour * 360000) +
                        (c.Minute * 6000) + (c.Second * 100) + (c.Millisecond / 10);
                return new CValue(lChrono + (int)(dChronoStop - dChronoStart));
            }
            else
            {
                return new CValue(lChrono);
            }
        }

        private CValue GetCentreX()
        {
            if (ANALOG_CLOCK == sType)
            {
                return new CValue(sCenterX + rh.rhWindowX);
            }
            else
            {
                return new CValue(0);
            }
        }

        private CValue GetCentreY()
        {
            if (ANALOG_CLOCK == sType)
            {
                return new CValue(sCenterY + rh.rhWindowY);
            }
            else
            {
                return new CValue(0);
            }
        }

        private CValue GetHourX()
        {
            if (ANALOG_CLOCK == sType)
            {
                return new CValue(sHourX + rh.rhWindowX);
            }
            else
            {
                return new CValue(0);
            }
        }

        private CValue GetHourY()
        {
            if (ANALOG_CLOCK == sType)
            {
                return new CValue(sHourY + rh.rhWindowY);
            }
            else
            {
                return new CValue(0);
            }
        }

        private CValue GetMinuteX()
        {
            if (ANALOG_CLOCK == sType)
            {
                return new CValue(sMinuteX + rh.rhWindowX);
            }
            else
            {
                return new CValue(0);
            }
        }

        private CValue GetMinuteY()
        {
            if (ANALOG_CLOCK == sType)
            {
                return new CValue(sMinuteY + rh.rhWindowY);
            }
            else
            {
                return new CValue(0);
            }
        }

        private CValue GetSecondX()
        {
            if (ANALOG_CLOCK == sType)
            {
                return new CValue(sSecondX + rh.rhWindowX);
            }
            else
            {
                return new CValue(0);
            }
        }

        private CValue GetSecondY()
        {
            if (ANALOG_CLOCK == sType)
            {
                return new CValue(sSecondY + rh.rhWindowY);
            }
            else
            {
                return new CValue(0);
            }
        }

        private CValue GetCountdown()
        {
            int lCurrentChrono;
            if (dChronoStart != 0)
            {
                DateTime c = DateTime.Now;
                double dChronoStop = months[c.Month-1] +
                        ((c.Day - 1) * 8640000) + (c.Hour * 360000) +
                        (c.Minute * 6000) + (c.Second * 100) + (c.Millisecond / 10);

                lCurrentChrono = lCountdownStart - (lChrono + (int)(dChronoStop - dChronoStart));
                if (lCurrentChrono < 0)
                {
                    lCurrentChrono = 0;
                }
                return new CValue(lCurrentChrono);
            }
            else
            {
                lCurrentChrono = lCountdownStart - lChrono;
                if (lCurrentChrono < 0)
                {
                    lCurrentChrono = 0;
                }
                return new CValue(lCurrentChrono);
            }
        }

        private CValue GetXPosition()
        {
            return new CValue(ho.getX());
        }

        private CValue GetYPosition()
        {
            return new CValue(ho.getY());
        }

        private CValue GetXSize()
        {
            return new CValue(ho.getWidth());
        }

        private CValue GetYSize()
        {
            return new CValue(ho.getHeight());
        }

    }
}
