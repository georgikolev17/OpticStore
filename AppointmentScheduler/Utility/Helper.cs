using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppointmentScheduler.Utility
{
    public class Helper
    {
        public static string Admin = "Admin";
        public static string Patient = "Patient";
        public static string Doctor = "Doctor";
        public static string appointmentAdded = "Ангажиментът е добавен успешно.";
        public static string appointmentUpdated = "Назначаването е актуализирано успешно.";
        public static string appointmentDeleted = "Ангажиментът е изтрит успешно.";
        public static string appointmentExists = "Вече има уговорка за избраната дата и час.";
        public static string appointmentNotExists = "Назначаването не съществува.";

        public static string appointmentAddError = "Нещо се обърка. Моля, опитайте отново.";
        public static string appointmentUpdatError = "Нещо се обърка. Моля, опитайте отново.";
        public static string somethingWentWrong = "Нещо се обърка. Моля, опитайте отново.";
        public static int success_code = 1;
        public static int failure_code = 0;

        public static List<SelectListItem> GetRolesForDropDown()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value=Helper.Admin, Text="Администратор"},
                new SelectListItem{Value=Helper.Patient, Text="Пациент"},
                new SelectListItem{Value=Helper.Doctor, Text="Доктор"}
            };
        }

        public static List<SelectListItem> GetTimeDropDown()
        {
            int minute = 60;
            List<SelectListItem> duration = new List<SelectListItem>();
            for (int i = 1; i <= 12; i++)
            {
                duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + "ч." });
                minute = minute + 30;
                duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + " ч. 30 мин." });
                minute = minute + 30;
            }
            return duration;
        }
    }
}
