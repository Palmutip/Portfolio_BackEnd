using AutoMapper;
using VariacaoDoAtivo.Domain;

namespace VariacaoDoAtivo.Application
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModel -> Domain

            CreateMap<VariacaoViewModel, Variacao>();
            CreateMap<UsuarioViewModel, Usuario>();

            #endregion

            #region Domain -> ViewModel

            CreateMap<Variacao, VariacaoViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();

            #endregion
        }
    }
}
