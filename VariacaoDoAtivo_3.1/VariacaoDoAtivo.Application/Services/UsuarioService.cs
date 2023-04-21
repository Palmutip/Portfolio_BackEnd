using AutoMapper;
using SS.Tecnologia.YahooFinance.Inferfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VariacaoDoAtivo.Auth.Services;
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
                throw new Exception("ID do usuário é inválido!");

            Usuario _usuario = this.usuarioRepository.Find(x => x.Id == usuarioID && !x.IsDeleted);

            if (null == _usuario)
                throw new Exception("Usuário não encontrado");

            return mapper.Map<UsuarioViewModel>(_usuario);
        }

        public bool Post(UsuarioViewModel usuarioViewModel)
        {
            if (usuarioViewModel.Id != Guid.Empty)
                throw new Exception("ID do usuário deve ser vazio!");

            Validator.ValidateObject(usuarioViewModel, new ValidationContext(usuarioViewModel), true);

            var _usuario = mapper.Map<Usuario>(usuarioViewModel);

            this.usuarioRepository.Create(_usuario);

            return true;
        }

        public bool Put(UsuarioViewModel usuarioViewModel)
        {
            if (usuarioViewModel.Id == Guid.Empty)
                throw new Exception("ID do usuário é inválido!");

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
                throw new Exception("ID do usuário é inválido!");

            Usuario _usuario = this.usuarioRepository.Find(x => x.Id == usuarioID && !x.IsDeleted);

            if (null == _usuario)
                throw new Exception("Usuário não encontrado");

            return this.usuarioRepository.Delete(_usuario);

        }

        public UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel usuario)
        {
            if (string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Senha))
                throw new Exception("Os campos E-mail e Senha são obrigatórios!");

            Usuario _usuario = this.usuarioRepository.Find(x => !x.IsDeleted && x.Email.ToLower() == usuario.Email.ToLower());

            if (null == _usuario)
                throw new Exception("Usuário não encontrado");

            return new UserAuthenticateResponseViewModel(mapper.Map<UsuarioViewModel>(_usuario), TokenService.GenerateToken(_usuario));
        }
    }
}
