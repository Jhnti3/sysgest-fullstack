Sistema de gestão web 
version v1.0

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


Update patch (fix bugs) v1.1

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

Update patch v1.2

↪ Botões responsivos: agora são grandes no mobile e organizados em colunas.
↪ Inputs adaptáveis: no mobile ocupam 100% da tela; em telas maiores, ficam lado a lado.
↪ Ações organizadas: os botões "Editar" e "Excluir" ficam empilhados no mobile e lado a lado no desktop.
↪ Botões no mobile: aumentei o padding e usei btn-block para melhor espaçamento.
↪ Inputs no mobile: usei w-100 (100% da largura) e mb-2 para melhor alinhamento.
↪ Ajustes de margem e espaçamento para evitar que elementos fiquem muito juntos no mobile.
↪ Garantimos que o botão toggleTheme está sendo selecionado corretamente.
↪ Mantivemos o localStorage para salvar a preferência do usuário.
↪ Movemos o botão fora da lista <ul> para evitar problemas com a responsividade.
↪ Mantivemos ms-3 para dar um espaçamento entre os elementos.
↪ Adicionamos text-center para centralizar os links no mobile.
↪ Colocamos btn-sm no botão do tema, deixando ele menor no desktop e adequado no mobile.
↪ Usamos ms-auto nos itens para alinhar corretamente os botões e links.

Update patch v1.3

✅ Chamadas explícitas das views
✅ Ajuste na exclusão
✅ Adicionado Include
✅ Correção no Status
✅ Ajuste em DataCriacao
✅ Melhoria nas anotações
✅ Correção da referência ao controlador
✅ Uso de Titulo, Status e DataCriacao
✅ Correção da formatação de DataCriacao
✅ Melhoria na classe table
✅ Adicionada tabela de tarefas seguindo o mesmo layout da de usuários.
✅ Botões para Exportar para Excel e PDF.
✅ Campo de pesquisa de tarefas.
✅ Botão Criar Nova Tarefa.
✅ Botões Editar e Excluir, com confirmação antes da exclusão.
