using DoctorAppointment_Skeleton.Models.Entities;

namespace DoctorAppointment_Skeleton.Models
{
    public interface IAppointmentManager
    {
        Appointment MakeApppointment(Appointment apmt);
        Appointment GetAppointment(int aid);
    }
}