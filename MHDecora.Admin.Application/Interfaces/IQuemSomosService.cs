﻿using MHDecora.Admin.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Admin.Application.Interfaces
{
    public interface IQuemSomosService
    {
        Task Salvar(QuemSomos dados, IFormFile imagem);
    }
}