﻿using AutoMapper;
using System.Net.Mail;
using ContactManagement;
using ERP.Common.Services;
using CandidateCRM.Controllers;
using Microsoft.AspNetCore.Mvc;
using ERP.Notification.Service;
using ERP.Notifications.Domain;
using ERP.TaskManagement.Domain;
using System.Collections.Generic;
using ERP.ProfileManagement.Model;
using ERP.ProfileManagement.Domain;
using ERP.ProfileManagement.Service;
using ERP.DocumentManagement.Domain;
using ERP.CRM.TaskManagement.Service;
using ERP.CRM.ContactManagement.Service;
using ERP.CRM.DocumentManagement.Service;
using System.Runtime.ConstrainedExecution;

namespace CandidateCRM.API.Profile
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ParentController<Personal, PersonalModel>
    {
        private readonly IProfile_Service _Service;
        private readonly IAuthManager    _authManager;
        private readonly IEmergencyContact_Service _emergencyContactService;
        private readonly IJobExperience_Service _jobExperienceService;
        private readonly IProfessionalLicense_Service _professionalLicenseService;
        private readonly IDependent_Service _dependentService;
        private readonly IAttachments_Service _attachments_Service;
        private readonly IEducations_Service _educations_Service;
        private readonly IGeneralTask_Service _generalTask_Service;
        private readonly INotifications_Service _notifications_Service;
      
        public PersonalController
        (
            IProfile_Service               service,
            IMapper                        mapper,
            IAuthManager                   authManager,
            IEmergencyContact_Service      emergencyContact_Service,
            IJobExperience_Service         jobExperience,
            IAttachments_Service           attachments_Service,
            IProfessionalLicense_Service   professionalLicense_Service,
            IDependent_Service             dependent_Service,
            IEducations_Service            educations_Service,
            IGeneralTask_Service           generalTask_Service,
            INotifications_Service         notifications_Service
        ) : base(service, mapper)
        {
            _Service                    = service;
            _authManager                = authManager;
            _emergencyContactService    = emergencyContact_Service;
            _jobExperienceService       = jobExperience;
            _attachments_Service        = attachments_Service;
            _professionalLicenseService = professionalLicense_Service;
            _dependentService           = dependent_Service;
            _educations_Service         = educations_Service;
            _generalTask_Service        = generalTask_Service;
            _notifications_Service      = notifications_Service;

        }


        [HttpGet]
        [Route("ProfileScore")]
        public async Task<int> ProfileScore(string userid)
        {
            try
            {
                int score = 0;
                IList<Dependent> dep            = await _dependentService.Find(x => x.userId == userid);
                IList<Education> edu            = await _educations_Service.Find(x=>x.userId== userid);
                IList<EmergencyContacts> em     = await _emergencyContactService.Find(x=>x.userId== userid);
                IList<JobExperience> job        = await _jobExperienceService.Find(x => x.userId == userid);
                IList<Attachments> att          = await _attachments_Service.Find(x => x.userId == userid);
                IList<ProfessionalLicense> prof = await _professionalLicenseService.Find(x=>x.userId==userid);
                IList<Personal> per             = await _Service.Find(x=>x.UserId==userid);

                if (dep.Count!=0)
                    score += 10;

                if (prof.Count!=0)
                    score += 20;

                if (edu.Count!=0)
                    score += 10;
                if (per.Count != 0)
                    score += 10;

                if (att.Count!=0)
                    score += 20;

                if (em.Count!=0)
                    score += 20;
                if (job.Count != 0)
                    score += 10;
                return score;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }
        }

        [HttpGet]
        [Route("Profile")]
        public async Task<IActionResult> Profile(string userid)
        {
            try
            {
                 IList <Personal> per = await _Service.Find(x => x.UserId == userid);
                 return Ok(per.LastOrDefault());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }
        }


        [HttpGet]
        [Route("EmergengyContacts")]
        public async Task<IActionResult> EmergengyContacts(string userid)
        {
            try
            {
                IList<EmergencyContacts> per = await _emergencyContactService.Find(x => x.userId == userid);
                return Ok(per);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }
        }

        [HttpGet]
        [Route("Dependetns")]
        public async Task<IActionResult> Dependetns(string userid)
        {
            try
            {
                IList<Dependent> per = await _dependentService.Find(x => x.userId == userid);
                return Ok(per);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }
        }

        [HttpGet]
        [Route("Education")]
        public async Task<IActionResult> Education(string userid)
        {
            try
            {
                IList<Education> per = await _educations_Service.Find(x => x.userId == userid);
                return Ok(per);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }
        }

        [HttpGet]
        [Route("JobExperience")]
        public async Task<IActionResult> JobExperience(string userid)
        {
            try
            {
                IList<JobExperience> per = await _jobExperienceService.Find(x => x.userId == userid);
                return Ok(per);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }
        }

        [HttpGet]
        [Route("ProfessionalLicense")]
        public async Task<IActionResult> ProfessionalLicense(string userid)
        {
            try
            {
                IList<ProfessionalLicense> per = await _professionalLicenseService.Find(x => x.userId == userid);
                return Ok(per);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }
        }

        [HttpGet]
        [Route("Attachment")]
        public async Task<IActionResult> Attachment(string userid)
        {
            try
            {
                IList<Attachments> per = await _attachments_Service.Find(x => x.userId == userid);
                return Ok(per);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }
        }

        [HttpGet]
        [Route("Tasks")]
        public async Task<IActionResult> Tasks(string userid)
        {
            try
            {
                IList<GENERALTASK> per = await _generalTask_Service.Find(x => x.UserId == userid);
                return Ok(per);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }
        }


        [HttpGet]
        [Route("Notifications")]
        public async Task<IActionResult> Notifications(string userid)
        {
            try
            {
                IList<NOTIFICATIONS> per = await _notifications_Service.Find(x => x.UserId == userid);
                per = per.OrderBy(x => x.Timestamp).ToList();
                return Ok(per);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }
        }
    }
}
