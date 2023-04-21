using AutoMapper;
using SS.Tecnologia.YahooFinance.Inferfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VariacaoDoAtivo.Domain;

namespace VariacaoDoAtivo.Application
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
        }

        public List<UsuarioViewModel> Get()
        {
            IEnumerable<Usuario> _variacoes = this.usuarioRepository.GetAll();

            List<UsuarioViewModel> _usuarioViewModel = mapper.Map<List<UsuarioViewModel>>(_variacoes);

            return _usuarioViewModel;
        }

        public UsuarioViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid usuarioID))
                throw new Exception("O usário não possui um ID válido!");

            Usuario _usuario = this.usuarioRepository.Find(x => x.Id == usuarioID && !x.IsDeleted);

            if (null == _usuario)
                throw new Exception("Usuário não encontrado");

            return mapper.Map<UsuarioViewModel>(_usuario);
        }

        public bool Post(UsuarioViewModel usuarioViewModel)
        {
            var _usuario = mapper.Map<Usuario>(usuarioViewModel);

            this.usuarioRepository.Create(_usuario);

            return true;
        }

        public bool Put(UsuarioViewModel usuarioViewModel)
        {
            Usuario _usuario = this.usuarioRepository.Find(x => x.Id == usuarioViewModel.Id && !x.IsDeleted);

            if (null == _usuario)
                throw new Exception("Usuário não encontrado");

            _usuario = mapper.Map<Usuario>(usuarioViewModel);

            this.usuarioRepository.Update(_usuario);

            return true;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid usuarioID))
                throw new Exception("O usário não possui um ID válido!");

            Usuario _usuario = this.usuarioRepository.Find(x => x.Id == usuarioID && !x.IsDeleted);

            if (null == _usuario)
                throw new Exception("Usuário não encontrado");

            return this.usuarioRepository.Delete(_usuario);

        }

        public UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel user)
        {
            throw new NotImplementedException();
        }
    }
}
