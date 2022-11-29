using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using ProjectName.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectName.Models;

namespace ProjectName.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        [HttpGet("oi")]
        public string oi(){
            return "Hello World";
        }
        
    }
}