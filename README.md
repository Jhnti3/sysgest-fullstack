Sistema de gestão web 
versão 1.0

✅ Configuração inicial do projeto

- Criado o projeto sysgest-fullstack em ASP.NET Core MVC (.NET 8.0).
- Estruturado o banco de dados com Entity Framework Core.
- Criadas as migrations e atualizado o banco

✅ CRUD de Usuários

- Criado o modelo User.cs com os campos necessários.
- Criado o AppDbContext.cs para gerenciar o banco de dados.
- Implementado o UserController.cs para manipular as operações CRUD.
- Criadas as views Index.cshtml, Create.cshtml, Edit.cshtml e Delete.cshtml.
- Implementadas validações para os campos de usuário.

✅ Painel de Controle (Dashboard)

- Criado o DashboardController.cs para exibir estatísticas do sistema.
- Criado o modelo DashboardViewModel.cs para armazenar os dados da dashboard.
- Criada a view Dashboard.cshtml para exibir estatísticas do sistema.
- Adicionado um gráfico com Chart.js para exibir usuários ativos x inativos.


Update patch (fix bugs) 1.1

✅ Correções e Melhorias

- Corrigido erro de referência no AppDbContext.cs.
- Ajustado problema com namespace Activity no Dashboard.
- Configurado corretamente o _Layout.cshtml para incluir Bootstrap e Chart.js.
- Adicionado o link para o Dashboard na navbar.
- Corrigido erro de roteamento da Dashboard.
- Ajustado tamanho do gráfico no Dashboard.

✅ GitHub e Versionamento

- Configurado repositório no GitHub.
- Realizado commit e push do projeto atualizado.
