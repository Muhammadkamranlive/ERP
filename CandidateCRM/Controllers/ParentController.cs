using AutoMapper;
using ERP.Core.ServiceAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CandidateCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController<T, AutoMapperEntity> : ControllerBase where T : class where AutoMapperEntity : class
    {

        private readonly IMapper _mapper;
        public IBase_Service<T> genericService { get; set; }
        protected virtual string SuccessMessage { get; } = "Operation Successful";
        public ParentController(IBase_Service<T> genericService, IMapper mapper)
        {
            _mapper = mapper;
            this.genericService = genericService;
        }
        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator,Student,Teacher")]
        public virtual async Task<IActionResult> Create(AutoMapperEntity autoMapperEntity)
        {


            try
            {
                var clientData = _mapper.Map<T>(autoMapperEntity);
                await genericService.InsertAsync(clientData);
                await genericService.CompleteAync();
                var message   = "Data Inserted Successfully for " + typeof(T)?.Name;
                return Content($"{{ \"message\": \"{message}\" }}", "application/json");

            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }

        }

        [HttpGet]

        public virtual async Task<IActionResult> GetAll()
        {

            try
            {
                var result = await genericService.GetAll();
                var clientResult = _mapper.Map<IList<AutoMapperEntity>>(result);
                return Ok(clientResult);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await genericService.Get(id);
                var clientResult = _mapper.Map<AutoMapperEntity>(result);
                return Ok(clientResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + e.InnerException?.Message);
            }
        }

        [HttpDelete]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator,Teacher")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await genericService.Delete(id);
                await genericService.CompleteAync();
                if (result == true)
                {
                    var message = "Data Deleted Successfully for " + typeof(T)?.Name;
                    return Content($"{{ \"message\": \"{message}\" }}", "application/json");
                }
                return Ok(result);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }
        }

        [HttpPut]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator,Teacher")]
        public async Task<IActionResult> Update(AutoMapperEntity autoMapperEntity)
        {
            try
            {
                var result = _mapper.Map<T>(autoMapperEntity);
                genericService.UpdateRecord(result);
                var update = await genericService.CompleteAync();
                if (update == 1)
                {
                    var message = "Data Updated Successfully for " + typeof(T)?.Name;
                    return Content($"{{ \"message\": \"{message}\" }}", "application/json");
                }

                return Ok(update);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }



        }

    }


}
