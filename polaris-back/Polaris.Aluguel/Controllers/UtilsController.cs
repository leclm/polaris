﻿using Microsoft.AspNetCore.Mvc;

namespace Polaris.Aluguel.Controllers
{
    public class UtilsController : ControllerBase
    {
        protected ObjectResult ReturnError()
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao cadastrar, tente novamente ou contate o administrador.");
        }
    }
}
