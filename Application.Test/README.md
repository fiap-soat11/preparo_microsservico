# Testes Unitários - Projeto FIAP SOAT 11

## 📊 Cobertura de Testes

Este projeto possui **74 testes unitários** cobrindo as principais camadas da aplicação.

### Estatísticas de Testes

- ✅ **Total de testes**: 74
- ✅ **Testes passando**: 74
- ❌ **Testes falhando**: 0
- ⏭️ **Testes ignorados**: 0

### Distribuição por Camadas

#### Domain (Entidades)
- `CategoriaTests` - 4 testes
- `ProdutoTests` - 5 testes
- `IngredienteTests` - 4 testes
- `ProdutoIngredienteTests` - 4 testes

#### Application (Casos de Uso)
- `CategoriaUseCaseTests` - 8 testes
- `ProdutoUseCaseTests` - 7 testes
- `BusinessExceptionTests` - 3 testes

#### Adapters (Controllers, Gateways, Mappers)
- **Controllers**
  - `CategoriaControllerTests` - 3 testes
  - `ProdutoControllerTests` - 8 testes

- **Gateways**
  - `CategoriaGatewayTests` - 4 testes
  - `ProdutoGatewayTests` - 8 testes

- **Mappers**
  - `CategoriaMapperTests` - 3 testes
  - `ProdutoMapperTests` - 5 testes

- **Presenters**
  - `CategoriaResponseTests` - 3 testes
  - `ProdutoRequestTests` - 3 testes
  - `ProdutoResponseTests` - 3 testes

## 🚀 Executando os Testes

### Executar todos os testes
```bash
cd Application.Test
dotnet test
```

### Executar testes com relatório detalhado
```bash
dotnet test --logger "console;verbosity=detailed"
```

### Executar testes com cobertura de código
```bash
dotnet test --collect:"XPlat Code Coverage"
```

### Gerar relatório HTML de cobertura
```bash
# Instalar ferramenta (apenas uma vez)
dotnet tool install -g dotnet-reportgenerator-globaltool

# Executar testes com cobertura
dotnet test --collect:"XPlat Code Coverage" --results-directory ./TestResults

# Gerar relatório
reportgenerator -reports:./TestResults/**/coverage.cobertura.xml -targetdir:./TestResults/CoverageReport -reporttypes:Html

# Abrir relatório
start ./TestResults/CoverageReport/index.html
```

## 🧪 Estrutura de Testes

```
Application.Test/
├── Domain/
│   ├── CategoriaTests.cs
│   ├── ProdutoTests.cs
│   ├── IngredienteTests.cs
│   └── ProdutoIngredienteTests.cs
├── UseCases/
│   ├── CategoriaUseCaseTests.cs
│   └── ProdutoUseCaseTests.cs
├── Configurations/
│   └── BusinessExceptionTests.cs
└── Adapters/
    ├── Controllers/
    │   ├── CategoriaControllerTests.cs
    │   └── ProdutoControllerTests.cs
    ├── Gateways/
    │   ├── CategoriaGatewayTests.cs
    │   └── ProdutoGatewayTests.cs
    ├── Mappers/
    │   ├── CategoriaMapperTests.cs
    │   └── ProdutoMapperTests.cs
    └── Presenters/
        ├── CategoriaResponseTests.cs
        ├── ProdutoRequestTests.cs
        └── ProdutoResponseTests.cs
```

## 🔧 Tecnologias Utilizadas

- **MSTest** - Framework de testes
- **Moq** - Biblioteca para criação de mocks
- **Microsoft.Testing.Extensions.CodeCoverage** - Cobertura de código

## 📝 Padrões de Teste

### Nomenclatura
Os testes seguem o padrão: `[Método]_[Cenário]_[ResultadoEsperado]`

Exemplos:
- `BuscarProdutoPorId_ComProdutoExistente_DeveRetornarProduto`
- `ListarTodos_ComListaVazia_DeveRetornarListaVazia`
- `IncluirProduto_DeveInvocarGateway`

### Estrutura AAA (Arrange-Act-Assert)
Todos os testes seguem o padrão AAA:
```csharp
[TestMethod]
public async Task NomeDoTeste()
{
    // Arrange - Preparação dos dados e mocks
    var objeto = new Objeto();
    
    // Act - Execução do método testado
    var resultado = await service.Metodo(objeto);
    
    // Assert - Verificação dos resultados
    Assert.IsNotNull(resultado);
    Assert.AreEqual(esperado, resultado);
}
```

## 🎯 Objetivos de Cobertura

O projeto foi desenvolvido visando atingir **85% de cobertura de código** em todas as camadas:

- ✅ **Domain**: Cobertura de todas as entidades e propriedades
- ✅ **Application**: Cobertura dos casos de uso principais
- ✅ **Adapters**: Cobertura de controllers, gateways e mappers
- ✅ **Validators**: Testes de validações de negócio

## 🔍 Tipos de Testes Implementados

1. **Testes de Unidade**: Validam comportamento isolado de métodos e classes
2. **Testes de Integração**: Validam interação entre componentes com uso de mocks
3. **Testes de Exceção**: Validam tratamento correto de erros
4. **Testes de Mapeamento**: Validam conversão entre DTOs e entidades

## 📚 Referências

- [MSTest Documentation](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest)
- [Moq Quick Start](https://github.com/moq/moq4/wiki/Quickstart)
- [Code Coverage](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-code-coverage)
