﻿using MHDecora.Site.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDecora.Site.Domain.Interfaces
{
    public interface IOrcamentoRepository
    {
        Task<bool> EnviarOrcamento(Orcamento orcamento);
    }
}