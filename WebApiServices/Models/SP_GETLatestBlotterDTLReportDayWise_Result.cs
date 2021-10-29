﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class SP_GETLatestBlotterDTLReportDayWise_Result
    {
        public int Id { get; set; }
        public int CRRFinconId { get; set; }
        public System.DateTime ReportDate { get; set; }
        public string WeekDays { get; set; }
        public Nullable<decimal> KarachiTotal { get; set; }
        public Nullable<decimal> HyderabadTotal { get; set; }
        public Nullable<decimal> SukkurTotal { get; set; }
        public Nullable<decimal> LahoreTotal { get; set; }
        public Nullable<decimal> FaisalabadTotal { get; set; }
        public Nullable<decimal> GWalaTotal { get; set; }
        public Nullable<decimal> MultanTotal { get; set; }
        public Nullable<decimal> SialkotTotal { get; set; }
        public Nullable<decimal> Isalamabad { get; set; }
        public Nullable<decimal> PindiTotal { get; set; }
        public Nullable<decimal> PeshawarTotal { get; set; }
        public Nullable<decimal> BhawalpurTotal { get; set; }
        public Nullable<decimal> MuzafarbadTotal { get; set; }
        public Nullable<decimal> DIKhanTotal { get; set; }
        public Nullable<decimal> QuettaTotal { get; set; }
        public Nullable<decimal> GawadarTotal { get; set; }
        public Nullable<decimal> OtherTotal { get; set; }
        public Nullable<decimal> PakistanToTal { get; set; }
        public double CRR3PcrReq { get; set; }
        public double CRR5PcrReq { get; set; }
        public double BalMaintain3Pcr { get; set; }
        public double BalMaintain5Pcr { get; set; }
        public Nullable<decimal> Penalty { get; set; }
        public decimal AvgForRemDays { get; set; }
        public decimal ReserveSurplus { get; set; }
        public double Reserve { get; set; }
        public decimal CRR5PcrReqWithoutEB { get; set; }
        public decimal BlotterBalance { get; set; }
        public Nullable<double> BalMaintAgainstExtBenft { get; set; }
        public Nullable<double> BalMaintAgainstPenalty { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> BR { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}