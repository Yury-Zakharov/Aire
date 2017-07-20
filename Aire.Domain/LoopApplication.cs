using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Aire.Domain
{
    [DataContract]
    public sealed class LoopApplication
    {
#pragma warning disable IDE1006 // Naming Styles
        [DataMember] [Key] public string a { get; set; }
        [DataMember] public string desc { get; set; }
        [DataMember] public string num_il_tl { get; set; }
        [DataMember] public string num_bc_sats { get; set; }
        [DataMember] public string total_il_high_credit_limit { get; set; }
        [DataMember] public string acc_open_past_24mths { get; set; }
        [DataMember] public string delinq_2yrs { get; set; }
        [DataMember] public string pub_rec_bankruptcies { get; set; }
        [DataMember] public string mo_sin_rcnt_rev_tl_op { get; set; }
        [DataMember] public string num_actv_rev_tl { get; set; }
        [DataMember] public string open_il_6m { get; set; }
        [DataMember] public string verification_status { get; set; }
        [DataMember] public string mths_since_recent_inq { get; set; }
        [DataMember] public string num_tl_op_past_12m { get; set; }
        [DataMember] public string tax_liens { get; set; }
        [DataMember] public string issue_d { get; set; }
        [DataMember] public string mths_since_last_delinq { get; set; }
        [DataMember] public string total_cu_tl { get; set; }
        [DataMember] public string mort_acc { get; set; }
        [DataMember] public string inq_last_6mths { get; set; }
        [DataMember] public string inq_last_12m { get; set; }
        [DataMember] public string num_actv_bc_tl { get; set; }
        [DataMember] public string addr_state { get; set; }
        [DataMember] public string num_op_rev_tl { get; set; }
        [DataMember] public string open_acc_6m { get; set; }
        [DataMember] public string mo_sin_rcnt_tl { get; set; }
        [DataMember] public string num_tl_120dpd_2m { get; set; }
        [DataMember] public string total_rev_hi_lim { get; set; }
        [DataMember] public string emp_title { get; set; }
        [DataMember] public string delinq_amnt { get; set; }
        [DataMember] public string mths_since_recent_bc { get; set; }
        [DataMember] public string total_bal_il { get; set; }
        [DataMember] public string bc_util { get; set; }
        [DataMember] public string num_tl_30dpd { get; set; }
        [DataMember] public string dti { get; set; }
        [DataMember] public string avg_cur_bal { get; set; }
        [DataMember] public string purpose { get; set; }
        [DataMember] public string mths_since_last_major_derog { get; set; }
        [DataMember] public string bc_open_to_buy { get; set; }
        [DataMember] public string open_il_12m { get; set; }
        [DataMember] public string revol_bal { get; set; }
        [DataMember] public string tot_hi_cred_lim { get; set; }
        [DataMember] public string num_sats { get; set; }
        [DataMember] public string percent_bc_gt_75 { get; set; }
        [DataMember] public string tot_cur_bal { get; set; }
        [DataMember] public string total_bc_limit { get; set; }
        [DataMember] public string il_util { get; set; }
        [DataMember] public string home_ownership { get; set; }
        [DataMember] public string earliest_cr_line { get; set; }
        [DataMember] public string open_rv_12m { get; set; }
        [DataMember] public string num_bc_tl { get; set; }
        [DataMember] public string mths_since_recent_bc_dlq { get; set; }
        [DataMember] public string num_tl_90g_dpd_24m { get; set; }
        [DataMember] public string num_rev_accts { get; set; }
        [DataMember] public string pct_tl_nvr_dlq { get; set; }
        [DataMember] public string zip_code { get; set; }
        [DataMember] public string revol_util { get; set; }
        [DataMember] public string collection_recovery_fee { get; set; }
        [DataMember] public string open_acc { get; set; }
        [DataMember] public string open_il_24m { get; set; }
        [DataMember] public string mo_sin_old_il_acct { get; set; }
        [DataMember] public string acc_now_delinq { get; set; }
        [DataMember] public string inq_fi { get; set; }
        [DataMember] public string mths_since_last_record { get; set; }
        [DataMember] public string emp_length { get; set; }
        [DataMember] public string title { get; set; }
        [DataMember] public string mths_since_rcnt_il { get; set; }
        [DataMember] public string total_acc { get; set; }
        [DataMember] public string pub_rec { get; set; }
        [DataMember] public string annual_inc { get; set; }
        [DataMember] public string num_accts_ever_120_pd { get; set; }
        [DataMember] public string max_bal_bc { get; set; }
        [DataMember] public string all_util { get; set; }
        [DataMember] public string mo_sin_old_rev_tl_op { get; set; }
        [DataMember] public string tot_coll_amt { get; set; }
        [DataMember] public string open_rv_24m { get; set; }
        [DataMember] public string total_bal_ex_mort { get; set; }
        [DataMember] public string mths_since_recent_revol_delinq { get; set; }
        [DataMember] public string collections_12_mths_ex_med { get; set; }
        [DataMember] public string chargeoff_within_12_mths { get; set; }
        [DataMember] public string num_rev_tl_bal_gt_0 { get; set; }

        // Quick & dirty - filtering records with significant fields empty.
        [IgnoreDataMember]
        [NotMapped]
        public bool IsValid =>
            !string.IsNullOrWhiteSpace(a)
            && !string.IsNullOrWhiteSpace(annual_inc)
            && !string.IsNullOrWhiteSpace(addr_state)
            && !string.IsNullOrWhiteSpace(emp_length)
            && !string.IsNullOrWhiteSpace(issue_d)
            && !issue_d.Equals("NaT", StringComparison.OrdinalIgnoreCase);

        [IgnoreDataMember]
        [NotMapped]
        public decimal AnnualIncome => decimal.TryParse(annual_inc?.Trim(), out decimal res) ? res : decimal.Zero;

        [IgnoreDataMember]
        [NotMapped]
        public int IssueDate
        {
            get
            {
                // Dirty but qiuck. That's enough for the homework PoC.
                // 5 times faster then converting to DataTime.
                var month_ = issue_d.Substring(0, 3);
                var year = issue_d.Substring(4, 2);
                var month = Array.FindIndex(months, p => p.Equals(month_, StringComparison.OrdinalIgnoreCase))+1;
                var zero = month < 10 ? "0" : string.Empty;
                int.TryParse($"{year}{zero}{month}", out int total);
                return total;
            }
        }

        private static string[] months =
         {
            "Jan",
            "Feb",
            "Mar",
            "Apr",
            "May",
            "Jun",
            "Jul",
            "Aug",
            "Sep",
            "Oct",
            "Nov",
            "Dec"
        };
#pragma warning restore IDE1006 // Naming Styles
    }
}

