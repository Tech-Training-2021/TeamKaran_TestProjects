using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace VoIP_CustomerPortal.Application.Features
{
    public class AllEnums
    {
        public enum TransactionType
        {
            Debit = 0, Credit = 1, Contra = 2, Reversal = 3
        }

        public enum FinacialYear
        {
            [Description("2021")]
            _2021 = 0,

            [Description("2022")]
            _2022 = 1,

            [Description("2023")]
            _2023 = 2,

            [Description("2024")]
            _2024 = 3
        }

        public enum CustomerType
        {
            Users = 0, Demo = 1, Admin = 2
        }

        public enum SubscriptionType
        {
            Plan1 = 0, Plan2 = 1, Plan3 = 2
        }

        public enum DeviceProfileType
        {
            DeviceProfile1= 0, DeviceProfile2 = 1, DeviceProfile3 = 2
        }

        public enum SettingType
        {
            EmailConfig = 0, 
            ConfigureAPI = 1, 
            Systemlogs = 2, 
            ManageTrialBalanceRequest = 3, 
            ConfigureStaticContent = 4, 
            ConfigureSubscription = 5, 
            Amount = 6, 
            API = 7, 
            SMTP = 8, 
            Theme = 9, 
            AddLanguage = 10
        }

        public enum MenuLink
        {
            DashboardUsers = 0,
            Billing = 1,
            ManageCallRecording = 2,
            ManageCallHistory = 3,
            ManageSubUser = 4,
            ManageSubscription = 5,
            CallRates = 6,
            DashboardURL = 7,
            Link9 = 8,
            Link10 = 9,
            Link11 = 10,
            DashboardDemoUsers =11,
            DashboardAdminUsers=12
        }

        public enum Country
        {
            India = 0,
            Afghanistan = 1,
            Albania = 2,
            Algeria = 3,
            Andorra = 4,
            Angola = 5,
            Antigua_and_Barbuda = 5,
            Argentina = 7,
            Armenia = 8
        }

        public enum CallStatus
        {
            AnsweredCalls = 0,
            UnAnsweredCalls = 1,
            FailedCalls = 2
        }
    }
}
