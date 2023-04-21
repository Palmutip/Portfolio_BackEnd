using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VariacaoDoAtivo.Application;
using VariacaoDoAtivo.Domain;
using Xunit;

namespace VariacaoDoAtivo.Application.Tests
{
    public class UsuarioServiceTests
    {
        private UsuarioService usuarioService;

        public UsuarioServiceTests()
        {
            usuarioService = new UsuarioService(new Mock<IUsuarioRepository>().Object, new Mock<IMapper>().Object);
        }

        [Fact]
        public void Post_EnviaIDValido()
        {
            var exception = Assert.Throws<Exception>(() => usuarioService.Post(new UsuarioViewModel { Id = Guid.NewGuid()}));
            Assert.Equal("ID do usuário deve ser vazio!", exception.Message);
        }

        [Fact]
        public void GetById_EnviandoGuidVazio()
        {
            var exception = Assert.Throws<Exception>(() => usuarioService.GetById(""));
            Assert.Equal("ID do usuário é inválido!", exception.Message);
        }

        [Fact]
        public void Put_EnviandoGuidVazio()
        {
            var exception = Assert.Throws<Exception>(() => usuarioService.Put(new UsuarioViewModel()));
            Assert.Equal("ID do usuário é inválido!", exception.Message);
        }

        [Fact]
        public void Delete_EnviandoGuidVazio()
        {
            var exception = Assert.Throws<Exception>(() => usuarioService.Delete(""));
            Assert.Equal("ID do usuário é inválido!", exception.Message);
        }

        [Fact]
        public void Authenticate_EnviandoValoresVazios()
        {
            var exception = Assert.Throws<Exception>(() => usuarioService.Authenticate(new UserAuthenticateRequestViewModel()));
            Assert.Equal("Os campos E-mail e Senha são obrigatórios!", exception.Message);
        }

        [Fact]
        public void Post_EnviandoObjetoValido()
        {
            var result = usuarioService.Post(new UsuarioViewModel { Nome = "Pedro Palmuti", Email = "palmutip@hotmail.com" });
            Assert.True(result);
        }

        [Fact]
        public void Get_ValidandoObjeto()
        {
            //Criando a lista com um objeto para que seja retornado pelo repository
            List<Usuario> _usuarios = new List<Usuario>
            {
                new Usuario { Id = Guid.NewGuid(), Nome = "Pedro Palmuti", Email = "palmutip@hotmail.com", DataInclusao = DateTime.Now }
            };

            //Criando um objeto mock do UserRepository e configurando para retornar a lista criada anteriormente se chamar o método GetAll()
            var _userRepository = new Mock<IUsuarioRepository>();
            _userRepository.Setup(x => x.GetAll()).Returns(_usuarios);

            //Criando um objeto mock do AutoMapper para que possamos converter o retorno para o tipo List<UserViewModel>()
            var _autoMapperProfile = new AutoMapperSetup();
            var _configuration = new MapperConfiguration(x => x.AddProfile(_autoMapperProfile));
            IMapper _mapper = new Mapper(_configuration);

            //Istanciando nossa classe de serviço novamente com os novos objetos mocks que criamos
            usuarioService = new UsuarioService(_userRepository.Object, _mapper);

            //Obtendo os valores do método Get para validar se vai retornar o objeto criado acima.
            var result = usuarioService.Get();

            //Validando se o retorno contém uma lista com objetos.
            Assert.True(result.Count > 0);
        }

        [Fact]
        public void Post_EnviandoObjetoInvalido()
        {
            var exception = Assert.Throws<ValidationException>(() => usuarioService.Post(new UsuarioViewModel { Nome = "Pedro Palmuti" }));
            Assert.Equal("The Email field is required.", exception.Message);
        }

    }
}
