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
        private DataContext dc;

        //Construtor
        public PessoaController(DataContext context)
        {
         dc = context;
        }

        //Rota Post
        [HttpPost("api")]
        public async Task<ActionResult> cadastrar([FromBody] Pessoa p)
        {
            dc.pessoa.Add(p);
            
            
            await dc.SaveChangesAsync();

            return Created("Objeto Pessoa", p);
        }

        [HttpGet("api")]
        public async Task<ActionResult> listar()
        {
            var dados = await dc.pessoa.ToListAsync();
            return Ok(dados);
        }
        //Rota com parêmetros.
        [HttpGet("api/{id}")]
        public Pessoa filtrar(int id)
        {
            Pessoa p = dc.pessoa.Find(id);
            return p;
        } 

        //Método Put
        [HttpPut("api")]

        public async Task<ActionResult> editar([FromBody] Pessoa p)
        {
            dc.pessoa.Update(p);
            await dc.SaveChangesAsync();
            return Ok(p);
        }
        [HttpDelete("api/{id}")]

        public async Task<ActionResult> remover(int id)
        {
            Pessoa p = filtrar(id);

            if(p == null){
                return NotFound();
            }else{
                dc.pessoa.Remove(p);
                await dc.SaveChangesAsync();
                return Ok();
            }
        }

        [HttpGet("oi")]
        public string oi(){
            return "Hello World";
        }
        
    }
}