using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VariacaoDoAtivo.Domain;

namespace VariacaoDoAtivo.Application
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModel -> Domain

            CreateMap<VariacaoViewModel, Variacao>();

            #endregion

            #region Domain -> ViewModel

            CreateMap<Variacao, VariacaoViewModel>();

            #endregion
        }
    }
}
