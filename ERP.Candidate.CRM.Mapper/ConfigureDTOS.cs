using AutoMapper;
using ContactManagement;
using ERP.CustomerCare.Model;
using ERP.HRAdminStaff.Model;
using ERP.Notifications.Model;
using ERP.HRAdminStaff.Domain;
using ERP.TaskManagement.Model;
using ERP.Notifications.Domain;
using ERP.TaskManagement.Domain;
using ERP.CaseManagement.Domain;
using ERP.ProfileManagement.Model;
using ERP.ContactManagement.Model;
using ERP.ProfileManagement.Domain;
using ERP.DocumentManagement.Model;
using ERP.DocumentManagement.Domain;

namespace ERP.Candidate.CRM.Mapper
{
    public class ConfigureDTOS:Profile
    {
        public ConfigureDTOS()
        {
            CreateMap<Personal, PersonalModel>().ReverseMap();
            CreateMap<CandidateInfo, CandidateModel>().ReverseMap();
            CreateMap<Education, EducationModel>().ReverseMap();
            CreateMap<JobExperience, JobExperienceModel>().ReverseMap();
            CreateMap<ProfessionalLicense, ProfessionalLicenseModel>().ReverseMap();
            CreateMap<GENERALTASK, GeneralTaskModel>().ReverseMap();
            CreateMap<NOTIFICATIONS, NotificationsModel>().ReverseMap();
            CreateMap<Asset, AssetModel>().ReverseMap();
            CreateMap<Attachments, AttachmentModel>().ReverseMap();
            CreateMap<Case, CaseModel>().ReverseMap();
            CreateMap<CaseComment, CaseCommentModel>().ReverseMap();
            CreateMap<CONTACTDETAILS, ContactDetailModel>().ReverseMap();
            CreateMap<EmergencyContacts, EmergencyContactModel>().ReverseMap();
            CreateMap<HRNotes, HRNoteModel>().ReverseMap();
            CreateMap<Dependent, DependentModel>().ReverseMap();

        }
    }
}