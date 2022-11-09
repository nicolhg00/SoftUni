using System;
using System.Collections.Generic;
using System.Text;

namespace TeisterMask.Common
{
    public static class GlobalConstants
    {
        //Employee
        public const int EMPLOYEE_USERNAME = 40;
        public const int EMPLOYEE_MIN_USERNAME = 3;
        public const string EMPLOYEE_USERNAME_REGEX = @"^[A-Za-z0-9]+$";
        public const int EMPLOYEE_PHONE = 12;
        public const string EMPLOYEE_PHONE_REGEX = @"^\d{3}\-\d{3}\-\d{4}$";

        //Project

        public const int PROJECT_NAME = 40;
        public const int PROJECT_MIN_NAME = 2;

        //Task
        public const int TASK_NAME = 40;
        public const int TASK_MIN_NAME = 2;
        public const int TASK_EXEC_TYPE_MIN_VALUE = 0;
        public const int TASK_EXEC_TYPE_MAX_VALUE = 3;
        public const int TASK_LAB_TYPE_MMIN_VALUE = 0;
        public const int TASK_LAB_TYPE_MAX_VALUE = 4;
    }
}
