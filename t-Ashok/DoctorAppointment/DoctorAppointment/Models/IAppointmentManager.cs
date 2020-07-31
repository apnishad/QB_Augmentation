using DoctorAppointment.Models.Entities;

namespace DoctorAppointment.Models
{
    public interface IAppointmentManager
    {
        Appointment MakeApppointment(Appointment apmt);
        Appointment GetAppointment(int aid);
    }
}